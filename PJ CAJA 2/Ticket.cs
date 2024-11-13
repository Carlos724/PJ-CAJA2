using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Drawing;

namespace PJ_CAJA_2
{
    class Ticket
    {
        public void DrawText(Graphics graphics, string leftText, string rightText, RectangleF availableSpace, Font font, Brush brush)
        {
            // Medir el ancho de las cadenas
            SizeF leftTextSize = graphics.MeasureString(leftText, font);
            SizeF rightTextSize = graphics.MeasureString(rightText, font);

            // Posición de la cadena izquierda (justificada a la izquierda)
            float leftX = availableSpace.Left;
            float leftY = availableSpace.Top + (availableSpace.Height - leftTextSize.Height) / 2;  // Centrado verticalmente

            // Dibujar la cadena izquierda
            graphics.DrawString(leftText, font, brush, leftX, leftY);

            // Verificar si la suma de los anchos de ambas cadenas es menor que el ancho del espacio disponible
            float totalWidth = leftTextSize.Width + rightTextSize.Width;
            if (totalWidth < availableSpace.Width)
            {
                // Posición de la cadena derecha (justificada a la derecha)
                float rightX = availableSpace.Right - rightTextSize.Width;
                float rightY = availableSpace.Top + (availableSpace.Height - rightTextSize.Height) / 2;  // Centrado verticalmente

                // Dibujar la cadena derecha
                graphics.DrawString(rightText, font, brush, rightX, rightY);
            }
        }

        /*
        // Atributo para almacenar la cadena de conexión
        public MySqlConnection cnnInicial;
        public string datosXML;
        public string sucursal;

        static public string cliente = "PUBLICO EN GENERAL";

        private void EjecutarConsultaInsertCajero(string queryInsert)
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
        public void EjecutarConexionMySQL()
        {
            try
            {
                cnnInicial.Open();
                if (cnnInicial.State == ConnectionState.Open)
                {
                    MessageBox.Show("SE CONECTO CON EXITO", "CONEXION CON LA BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cnnInicial.Open();
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
            if (cnnInicial.State == ConnectionState.Open)
            {
                cnnInicial.Close();
                MessageBox.Show("ESTABA ABIERTA", "CONEXION CON LA BASE DE DATOS TERMINADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO LO AGARRA", "CONEXION CON LA BASE DE DATOS TERMINADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        */
    }
}
