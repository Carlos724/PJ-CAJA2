using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml;


namespace PJ_CAJA_2
{
    class Conexion
    {
        // Atributo para almacenar la cadena de conexión
        public MySqlConnection cnnPrueba;
        public string prueba;
        public string sucursal;

        static public string cliente = "PUBLICO EN GENERAL";

        public string LeerXML()
        {
            // Creo la instancia de xmldocument
            XmlDocument doc = new XmlDocument();
            // carga el xml
            doc.Load("Conexion.xml");
            // Recorro los hijos del nodo MySqlConnection
            foreach (XmlNode n1 in doc.DocumentElement.ChildNodes)
            {
                sucursal = n1.Attributes["Sucursal"].Value;

                // Si tiene nodos, recorro sus hijos
                if (n1.HasChildNodes)
                {
                    foreach (XmlNode n2 in n1.ChildNodes)
                    {
                        prueba = prueba + n2.Name + "=" + n2.InnerText + "; ";
                    }
                }
            }
            prueba = prueba.TrimEnd();
            MessageBox.Show(prueba);
            return prueba;
        }

        public void EjecutarConexionMySQL()
        {
            try
            {
                cnnPrueba.Open();
                if (cnnPrueba.State == ConnectionState.Open)
                {
                    MessageBox.Show("SE CONECTO CON EXITO", "CONEXION CON LA BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cnnPrueba.Open();
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                MessageBox.Show($"Error conectarse al servidor: {ex.Message}");
            }

        }

        public void CerrarConexion()
        {
            // CERRAR CONEXION
            if (cnnPrueba.State == ConnectionState.Open)
            {
                cnnPrueba.Close();
                MessageBox.Show("ESTABA ABIERTA", "CONEXION CON LA BASE DE DATOS TERMINADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO LO AGARRA", "CONEXION CON LA BASE DE DATOS TERMINADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //FALTA PROBAR SI FUNCIONA
        //## METODOS ##
        //EJECUTA LA CONSULTA PARA INSERTAR LAS OPERACIONES
        private void EjecutarConsultaInsert(string queryInsert)
        {
            try
            {
                //ABRIR CONEXION
                if (cnnPrueba.State != ConnectionState.Open)
                {
                    cnnPrueba.Open();
                }

                // Crear el comando con la consulta INSERT
                using (MySqlCommand command = new MySqlCommand(queryInsert, cnnPrueba))
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
                if (cnnPrueba.State == ConnectionState.Open)
                {
                    cnnPrueba.Close();
                }
            }
        }

        public void InsertarGenerico(int Num_Folio, string Clase_Ope, string Tipo_Ope, double Dolares, double Pesos, double Tipo_Cam, char Tipo_Especial, double Tipo_Sis, double Pago, double Cambio, char Activo, char Corte)
        {

            /*
             * INSERT INTO `caja2`.`operaciones` VALUES ('Cajero','Sucursal','Cliente','Fecha_Operacion','Hora_Operacion','Numero_Folio','Clase_Operacion','Tipo_Operacion','Dolares','Pesos',
             * 'Tipo_Cambio','Tipo_Especial','Tipo_Sistema','Pago','Cambio','Activo','Corte','Fecha_Corte');
             */
            string queryInsrt = "INSERT INTO `caja2`.`operaciones` VALUES ('" + Properties.Settings.Default.strUsuario_ + "','" + sucursal + "','" + Conexion.cliente;
            queryInsrt = queryInsrt + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("HH:mm:ss") + "',";

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
