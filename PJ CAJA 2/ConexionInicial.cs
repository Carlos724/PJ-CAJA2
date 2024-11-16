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
            string querySelect = "SELECT `Sesion_iniciada`, `Cajero`,`TCCompra`, `TCVenta` FROM `caja2`.`datossesion`;";
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
                string queryUltimoFolio = "SELECT Numero_Folio FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Clase_Operacion = 'folio' ORDER BY fecha_operacion DESC LIMIT 1;";
                using (MySqlCommand comandoFolio = new MySqlCommand(queryUltimoFolio, cnnInicial))
                {
                    MySqlDataReader numFolio = comandoFolio.ExecuteReader();

                    if (numFolio.Read())
                    {
                        VariablesGlobales.NumFolio = ((int)numFolio["Numero_Folio"]) + 1;
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
                string queryInicio = "SELECT Numero_Folio FROM operaciones WHERE Cajero = '" + Properties.Settings.Default.strUsuario_ + "' AND Clase_Operacion = 'Inicio' ORDER BY fecha_operacion DESC LIMIT 1;";
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

            string queryInsrt = "INSERT INTO `caja2`.`datossesion` VALUES ('"+1+"','"+Properties.Settings.Default.strUsuario_+"','"+ Properties.Settings.Default.dblTCCompra_+ "','"+ Properties.Settings.Default.dblTCVenta_+ "');";

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

        public void CerrarSesion()
        {
            /*
             *DELETE FROM `caja2`.`datossesion` WHERE `Sesion_iniciada` = 'Sesion_iniciada'
             */
            string queryInsrt = "DELETE FROM `caja2`.`datossesion` WHERE `Sesion_iniciada` =" +1+";";

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

            if (Num_Folio == 0) { queryInsrt = queryInsrt + "NULL"; }
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

            queryInsrt = queryInsrt + "NULL";
            queryInsrt = queryInsrt + ");";

            //ESCRIBE LA CONSULTA EN UN TXT COMO PRUEBA
            //System.IO.File.WriteAllText(@"C:\Users\Usuario\Documents\GitHub\PRUEBA_CONSULTA"+num.ToString()+".txt", queryInsrt);

            EjecutarConsultaInsert(queryInsrt);
        }
    }
}
