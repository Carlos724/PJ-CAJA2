using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml;

using System.Data.SqlClient;


namespace PJ_CAJA_2
{
    class ConexionInicial
    {
        // Atributo para almacenar la cadena de conexión
        public MySqlConnection cnnInicial;
        public string datosXML;
        public string sucursal;
        public List<string> datosCorte;
        public List<string> datosFoliosCan;
        public List<int> datosImpresora;

        static public string cliente = "PUBLICO EN GENERAL";

        public string LeerXML()
        {
            // Creo la instancia de xmldocument
            XmlDocument doc = new XmlDocument();
            // carga el xml
            doc.Load("ConexionCaja2.xml");
            // Recorro los hijos del nodo MySqlConnection
            foreach (XmlNode n1 in doc.DocumentElement.ChildNodes)
            {
                sucursal = n1.Attributes["Sucursal"].Value;

                // Si tiene nodos, recorro sus hijos
                if (n1.HasChildNodes)
                {
                    foreach (XmlNode n2 in n1.ChildNodes)
                    {
                        datosXML = datosXML + n2.Name + "=" + n2.InnerText + "; ";
                    }
                }
            }
            datosXML = datosXML.TrimEnd();
            //MessageBox.Show(datosXML);
            return datosXML;
        }

        //VERIFICAR SESION INICIADA
        public (bool,bool) VerificarSesion()
        {
            bool estado = false;
            bool inicios = false;

            /*
             SELECT `Sesion_iniciada`, `Cajero`,`TCCompra`, `TCVenta` FROM `caja2`.`datossesion`;
             */
            string querySelect = "SELECT `Sesion_iniciada`, `Cajero`,`TCCompra`, `TCVenta`, `Fecha_inicio` FROM `caja2`.`datossesion`;";
            MySqlDataReader registro;

            try
            {
                //ABRIR CONEXION
                if (cnnInicial.State != ConnectionState.Open)
                {
                    cnnInicial.Open();
                }

                using (MySqlCommand command = new MySqlCommand(querySelect, cnnInicial))
                {
                    registro = command.ExecuteReader();

                    if (registro.Read())
                    {
                        Properties.Settings.Default.strUsuario_ = registro["Cajero"].ToString();
                        Properties.Settings.Default.dblTCCompra_ = (double)registro["TCCompra"];
                        Properties.Settings.Default.dblTCVenta_ = (double)registro["TCVenta"];
                        estado = true;
                    }
                    else
                    {
                        MessageBox.Show("No hay sesión iniciada");
                    }

                }

            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error al iniciar nueva sesion: {ex.Message}");
            }
            finally
            {
                // CERRAR CONEXION
                if (cnnInicial.State == ConnectionState.Open)
                {
                    cnnInicial.Close();
                }
                if (estado)
                {
                    VerificarFolios();
                    inicios = VerificarInicios();
                }
            }


            return (estado,inicios);
            }

        public void VerificarFolios()
        {
            try
            {
                //ABRIR CONEXION
                if (cnnInicial.State != ConnectionState.Open)
                {
                    cnnInicial.Open();
        }
                string queryUltimoFolio = "SELECT Numero_Folio FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Clase_Operacion = 'folio' AND Fecha_Corte IS NULL ORDER BY fecha_operacion DESC LIMIT 1;";
                using (MySqlCommand comandoFolio = new MySqlCommand(queryUltimoFolio, cnnInicial))
                {
                    MySqlDataReader numFolio = comandoFolio.ExecuteReader();

                    if (numFolio.Read())
                    {
                        VariablesGlobales.NumFolio = ((int)numFolio["Numero_Folio"]);
                    }
                    else
                    {
                        MessageBox.Show("No folios");
                    }

                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error al insertar datos: {ex.Message}");
            }
            finally
        {
            // CERRAR CONEXION
                if (cnnInicial.State == ConnectionState.Open)
            {
                    cnnInicial.Close();
                }
            }
        }

        public bool VerificarInicios()
        {
            bool inicio = true;
            try
            {
                //ABRIR CONEXION
                if (cnnInicial.State != ConnectionState.Open)
                {
                    cnnInicial.Open();
                }
                string queryInicio = "SELECT Numero_Folio FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Clase_Operacion = 'Inicio' AND Fecha_Corte IS NULL ORDER BY fecha_operacion DESC LIMIT 1;";
                using (MySqlCommand comandoInicio = new MySqlCommand(queryInicio, cnnInicial))
                {
                    MySqlDataReader numFolio = comandoInicio.ExecuteReader();

                    if (numFolio.Read())
                    {
                        MessageBox.Show("Si tiene inicios :0");
            }
            else
            {
                        inicio = false;
            }

        }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error al insertar datos: {ex.Message}");
            }
            finally
            {
                // CERRAR CONEXION
                if (cnnInicial.State == ConnectionState.Open)
                {
                    cnnInicial.Close();
                }
            }
            return inicio;
        }
        public void InsertarSesion()
        {
            //INSERT INTO `caja2`.`datossesion` VALUES ('Sesion_iniciada','Cajero','TCCompra','TCVenta');
            //0 = FALSE 1 = TRUE

            string queryInsrt = "INSERT INTO `caja2`.`datossesion` VALUES ('"+1+"','"+Properties.Settings.Default.strUsuario_+"','"+ Properties.Settings.Default.dblTCCompra_+ "','"+ Properties.Settings.Default.dblTCVenta_+ "','" + DateTime.Now.ToString("yyyy-MM-dd") +"');";

            //ESCRIBE LA CONSULTA EN UN TXT COMO PRUEBA
            //System.IO.File.WriteAllText(@"C:\Users\Usuario\Documents\GitHub\PRUEBA_CONSULTA"+num.ToString()+".txt", queryInsrt);

            EjecutarConsultaInsert(queryInsrt);
        }

        public void ModificarTipos()
        {
            /*
             * UPDATE `caja2`.`datossesion` SET `Sesion_iniciada` = 'Sesion_iniciada',`Cajero` = 'Cajero',`TCCompra` = 'TCCompra',`TCVenta` = 'TCVenta';
             * WHERE `Sesion_iniciada` = 'Sesion_iniciada' AND `Cajero` = 'Cajero' AND `TCCompra` = 'TCCompra' AND `TCVenta` = 'TCVenta';
             */
            string queryInsrt = "UPDATE `caja2`.`datossesion` SET `TCCompra` = '"+ Properties.Settings.Default.dblTCCompra_ + "',`TCVenta` = '"+ Properties.Settings.Default.dblTCVenta_ + "';";
            
            EjecutarConsultaInsert(queryInsrt);

        }

        public void CancelarFolio(int numFolio)
        {
            /*
             * UPDATE `caja2`.`datossesion` SET `Sesion_iniciada` = 'Sesion_iniciada',`Cajero` = 'Cajero',`TCCompra` = 'TCCompra',`TCVenta` = 'TCVenta';
             * WHERE `Sesion_iniciada` = 'Sesion_iniciada' AND `Cajero` = 'Cajero' AND `TCCompra` = 'TCCompra' AND `TCVenta` = 'TCVenta';
             * Hora_Cancelacion` = '"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"'
             * 
             */
            string queryInsrt = "UPDATE `caja2`.`operaciones` SET `Hora_Cancelacion` = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Clase_Operacion = 'folio' AND Fecha_Corte IS NULL AND Numero_Folio = '" + numFolio + "';";

            EjecutarConsultaInsert(queryInsrt);

        }

        public void CerrarSesion()
        {
            /*
             *DELETE FROM `caja2`.`datossesion` WHERE `Sesion_iniciada` = 'Sesion_iniciada'
             */

            string queryFechaCorte = "UPDATE `caja2`.`operaciones` SET   `Fecha_Corte` = '"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Fecha_Corte IS NULL;";
            string queryInsrt = "DELETE FROM `caja2`.`datossesion` WHERE `Sesion_iniciada` =" +1+";";
            EjecutarConsultaInsert(queryFechaCorte);
            EjecutarConsultaInsert(queryInsrt);
        }

        //## METODOS ##
        //EJECUTA LA CONSULTA PARA INSERTAR LAS OPERACIONES
        private void EjecutarConsultaInsert(string queryInsert)
        {
            try
            {
                //ABRIR CONEXION
                if (cnnInicial.State != ConnectionState.Open)
                {
                    cnnInicial.Open();
                }

                // Crear el comando con la consulta INSERT
                using (MySqlCommand command = new MySqlCommand(queryInsert, cnnInicial))
                {
                    // Ejecutar el comando
                    int result = command.ExecuteNonQuery();

                    // Comprobar el resultado
                    if (result > 0)
                    {
                        MessageBox.Show("Datos insertados correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se insertaron datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error al insertar datos: {ex.Message}");
            }
            finally
            {
                // CERRAR CONEXION
                if (cnnInicial.State == ConnectionState.Open)
                {
                    cnnInicial.Close();
                }
            }
        }

        public void InsertarGenerico(int Num_Folio, string Clase_Ope, string Tipo_Ope, double Dolares, double Pesos, double Tipo_Cam, char Tipo_Especial, double Tipo_Sis, double Pago, double Cambio, char Activo, char Corte)
        {

            /*
             * INSERT INTO `caja2`.`operaciones` VALUES ('Cajero','Sucursal','Cliente','Fecha_Operacion','Hora_Operacion','Numero_Folio','Clase_Operacion','Tipo_Operacion','Dolares','Pesos',
             * 'Tipo_Cambio','Tipo_Especial','Tipo_Sistema','Pago','Cambio','Activo','Corte','Fecha_Corte');
             */
            string queryInsrt = "INSERT INTO `caja2`.`operaciones` VALUES ('" + Properties.Settings.Default.strUsuario_ + "','" + sucursal + "',";

            if (Num_Folio >= 3000) { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + ConexionInicial.cliente + "'"; }
            
            queryInsrt = queryInsrt + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("HH:mm:ss") + "',";

            if (Num_Folio == 0) { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Num_Folio + "'"; }
            queryInsrt = queryInsrt + ",";


            if (Clase_Ope == "") { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Clase_Ope + "'"; }
            queryInsrt = queryInsrt + ",";

            queryInsrt = queryInsrt + "'" + Tipo_Ope + "'";
            queryInsrt = queryInsrt + ",";

            if (Dolares < 0) { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Dolares + "'"; }
            queryInsrt = queryInsrt + ",";

            if (Pesos < 0) { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Pesos + "'"; }
            queryInsrt = queryInsrt + ",";

            if (Tipo_Cam < 0) { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Tipo_Cam + "'"; }
            queryInsrt = queryInsrt + ",";

            if (Tipo_Especial == 'X') { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Tipo_Especial + "'"; }
            queryInsrt = queryInsrt + ",";

            if (Tipo_Sis < 0) { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Tipo_Sis + "'"; }
            queryInsrt = queryInsrt + ",";

            if (Pago < 0) { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Pago + "'"; }
            queryInsrt = queryInsrt + ",";

            if (Cambio < 0) { queryInsrt = queryInsrt + "NULL"; }
            else { queryInsrt = queryInsrt + "'" + Cambio + "'"; }
            queryInsrt = queryInsrt + ",";

            if (Activo != 'S') { queryInsrt = queryInsrt + "'" + "N" + "'"; }
            else { queryInsrt = queryInsrt + "'" + Activo + "'"; }
            queryInsrt = queryInsrt + ",";

            if (Corte != 'S') { queryInsrt = queryInsrt + "'" + "N" + "'"; }
            else { queryInsrt = queryInsrt + "'" + Corte + "'"; }
            queryInsrt = queryInsrt + ",";

            queryInsrt = queryInsrt + "NULL,NULL";
            queryInsrt = queryInsrt + ");";

            //ESCRIBE LA CONSULTA EN UN TXT COMO PRUEBA
            //System.IO.File.WriteAllText(@"C:\Users\Usuario\Documents\GitHub\PRUEBA_CONSULTA"+num.ToString()+".txt", queryInsrt);

            EjecutarConsultaInsert(queryInsrt);
        }

        public List<string> RealizarCorte()
        {
            datosCorte = new List<string>();
            try
            {
                // Primer consulta: Folios activos
                string queryFoliosActivos = "SELECT COUNT(*) AS Folio_Activo FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Clase_Operacion = 'folio' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryFoliosActivos, "Folio_Activo"));

                // Segunda consulta: Folios cancelados
                string queryFoliosCancelados = "SELECT COUNT(*) AS Folio_Can FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Clase_Operacion = 'folio' AND Activo = 'N' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryFoliosCancelados, "Folio_Can"));

                // Tercera consulta: Inicios cancelados
                string queryIniCanceladas = "SELECT COUNT(*) AS IniCan FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Numero_Folio BETWEEN '3000' AND '3130' AND Activo = 'N' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryIniCanceladas, "IniCan"));

                // Cuarta consulta: Entradas/salidas canceladas
                string queryEntSalCanceladas = "SELECT COUNT(*) AS EntSalCan FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Numero_Folio BETWEEN '3199' AND '5400' AND Activo = 'N' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryEntSalCanceladas, "EntSalCan"));
                
                // Quinta consulta: Dolares compra
                string queryDolCompra = "SELECT SUM(Dolares) AS TotalDolComp FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "'AND Tipo_Operacion = 'COMPRA' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryDolCompra, "TotalDolComp"));

                // Sexta consulta: Promedio tipo compra
                string queryPromCompra = "SELECT ROUND((SUM(Dolares * Tipo_Cambio)) / SUM(Dolares),6) AS TipoCompra FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Tipo_Operacion = 'COMPRA' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryPromCompra, "TipoCompra"));

                // Septima consulta: pesos compra (dolares compra * pesos compra)
                string queryPesosCompra = "SELECT SUM(Dolares)*AVG(Tipo_Cambio) AS PesoCompra FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Tipo_Operacion = 'COMPRA' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryPesosCompra, "PesoCompra"));

                // Octava consulta: Dolares venta
                string queryDolVenta = "SELECT SUM(Dolares) AS TotalDolVent FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Tipo_Operacion = 'VENTA' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryDolVenta, "TotalDolVent"));

                // Novena consulta: Promedio tipo venta
                string queryPromVenta = "SELECT ROUND((SUM(Dolares * Tipo_Cambio)) / SUM(Dolares),6) AS TipoVenta FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Tipo_Operacion = 'VENTA' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryPromVenta, "TipoVenta"));

                // Decima consulta: pesos venta (dolares venta * pesos venta)
                string queryPesosVenta = "SELECT SUM(Dolares)*AVG(Tipo_Cambio) AS PesoVenta FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Tipo_Operacion = 'VENTA' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryPesosVenta, "PesoVenta"));

                // Decimo primera consulta: diferencia dolares
                string queryDifDol = "SELECT COALESCE(SUM(CASE WHEN Clase_Operacion IN('EntD', 'Inicio') THEN Dolares ELSE 0 END), 0) + COALESCE(SUM(CASE WHEN Tipo_Operacion = 'COMPRA' THEN Dolares ELSE 0 END), 0) -" +
                    " COALESCE(SUM(CASE WHEN Tipo_Operacion = 'VENTA' THEN Dolares ELSE 0 END), 0) - COALESCE(SUM(CASE WHEN Clase_Operacion = 'SalD' THEN Dolares ELSE 0 END), 0) AS TotalDol" +
                    " FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryDifDol, "TotalDol"));

                // Decimo segunda consulta: diferencia pesos
                string queryDifPesos = "SELECT COALESCE(SUM(CASE WHEN Clase_Operacion IN('EntP', 'Inicio') THEN Pesos ELSE 0 END), 0) + COALESCE(SUM(CASE WHEN Tipo_Operacion = 'VENTA' THEN Pesos ELSE 0 END), 0) -" +
                    " COALESCE(SUM(CASE WHEN Tipo_Operacion = 'COMPRA' THEN Pesos ELSE 0 END), 0) - COALESCE(SUM(CASE WHEN Clase_Operacion = 'SalP' THEN Pesos ELSE 0 END), 0) AS TotalPesos" +
                    " FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Activo = 'S' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                datosCorte.Add(EjecutarConsultaSelect(queryDifPesos, "TotalPesos"));

                return (datosCorte);
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error al ejecutar las consultas: {ex.Message}");
    }
            return (datosCorte);
}

        private string EjecutarConsultaSelect(string queryInsert,string titulo)
        {
            string dato = "";
            try
            {
                //ABRIR CONEXION
                if (cnnInicial.State != ConnectionState.Open)
                {
                    cnnInicial.Open();
                }

                // Crear el comando con la consulta INSERT
                using (MySqlCommand command = new MySqlCommand(queryInsert, cnnInicial))
                {
                    // Ejecutar el comando
                    MySqlDataReader result = command.ExecuteReader();
                    if (result.Read())
                    {
                        // Verificar si el valor de la columna es DBNull
                        if (result.IsDBNull(result.GetOrdinal(titulo)))
                        {
                            dato = "0"; // o algún valor predeterminado
                        }
                        else
                        {
                            dato = result[titulo].ToString();
                        }
                    }
                    else
                    {
                        dato = "0"; // No se encontraron filas
                    }
                }
                return dato;
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error al seleccionar datos: {ex.Message}");
            }
            finally
            {
                // CERRAR CONEXION
                if (cnnInicial.State == ConnectionState.Open)
                {
                    cnnInicial.Close();
                }
            }
            return dato;
        }

        public List<string> EjecutarConsultaListaCancelacions()
        {
            datosFoliosCan = new List<string>();
            try
            {
                //ABRIR CONEXION
                if (cnnInicial.State != ConnectionState.Open)
                {
                    cnnInicial.Open();
                }
                // Decimo tercera consulta: lista operaciones canceladas              
                string queryOpCan = "SELECT `Hora_Operacion`, `Numero_Folio`, `Tipo_Operacion`, `Dolares`, `Tipo_Cambio` FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Clase_Operacion = 'folio' AND Activo = 'N' AND Corte = 'S' AND Fecha_Corte IS NULL;";
                using (MySqlCommand cmdOpCan = new MySqlCommand(queryOpCan, cnnInicial))
                {
                    MySqlDataReader listOpCan = cmdOpCan.ExecuteReader();
                    while (listOpCan.Read())
                    {
                        // Agregar cada operación con sus respectivos campos a la lista
                        //Num Folio Hora compra/venta cantidad en dolares tipo de cambio
                        string hora = listOpCan["Hora_Operacion"].ToString();
                        string numFolio = listOpCan["Numero_Folio"].ToString();
                        string tipoOpe = listOpCan["Tipo_Operacion"].ToString();
                        string dolares = listOpCan["Dolares"].ToString();
                        string tipoCambio = listOpCan["Tipo_Cambio"].ToString();

                        // Agregar a la lista (puedes agregar a una lista de tu preferencia, por ejemplo un List<string>)
                        datosFoliosCan.Add(numFolio);
                        datosFoliosCan.Add(hora);
                        datosFoliosCan.Add(tipoOpe);
                        datosFoliosCan.Add(dolares);
                        datosFoliosCan.Add(tipoCambio);
                    }
                }
                return (datosFoliosCan);
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error al seleccionar datos: {ex.Message}");
            }
            finally
            {
                // CERRAR CONEXION
                if (cnnInicial.State == ConnectionState.Open)
                {
                    cnnInicial.Close();
                }
            }
            return (datosFoliosCan);
        }

        public List<int> EjecutarSelectImpresora()
        {
            datosImpresora = new List<int>();
            try
            {
                //ABRIR CONEXION
                if (cnnInicial.State != ConnectionState.Open)
                {
                    cnnInicial.Open();
                }
                // Decimo tercera consulta: lista operaciones canceladas              
                string queryOpCan = "SELECT `Papel_width`,`Papel_height`,`Papel_height_Suma`,`Papel_y`,`Papel_x`,`Papel_tam_Corte`,`Papel_tam_Otro` FROM `caja2`.`datosfijos`";
                using (MySqlCommand cmdOpCan = new MySqlCommand(queryOpCan, cnnInicial))
                {
                    MySqlDataReader listOpCan = cmdOpCan.ExecuteReader();
                    while (listOpCan.Read())
                    {
                        // Agregar cada operación con sus respectivos campos a la lista
                        //Num Folio Hora compra/venta cantidad en dolares tipo de cambio
                        int Papel_width = (int)listOpCan["Papel_width"];
                        int Papel_height = (int)listOpCan["Papel_height"];
                        int Papel_height_Suma = (int)listOpCan["Papel_height_Suma"];
                        int Papel_y = (int)listOpCan["Papel_y"];
                        int Papel_x = (int)listOpCan["Papel_x"];
                        int Papel_tam_Corte = (int)listOpCan["Papel_tam_Corte"];
                        int Papel_tam_Otro = (int)listOpCan["Papel_tam_Otro"];

                        // Agregar a la lista (puedes agregar a una lista de tu preferencia, por ejemplo un List<string>)
                        datosImpresora.Add(Papel_width);
                        datosImpresora.Add(Papel_height);
                        datosImpresora.Add(Papel_height_Suma);
                        datosImpresora.Add(Papel_y);
                        datosImpresora.Add(Papel_x);
                        datosImpresora.Add(Papel_tam_Corte);
                        datosImpresora.Add(Papel_tam_Otro);
                    }
                }
                return (datosImpresora);
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error al seleccionar datos: {ex.Message}");
            }
            finally
            {
                // CERRAR CONEXION
                if (cnnInicial.State == ConnectionState.Open)
                {
                    cnnInicial.Close();
                }
            }
            return (datosImpresora);
        }

    }
}