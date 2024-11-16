using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.Windows;

namespace PJ_CAJA_2
{
    class Ticket
    {


        public List<double> cantidades;

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

        public void ImprimirCorte(object sender, PrintPageEventArgs e)
        {
            /*
             * Medidas para rollo mini
            int width = 200;
            int height = 20;
             */

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            int width = 200;
            int height = 20;
            int y = 20;
            int x = 15;
            float tamaño = 10;
            DateTime fecha = DateTime.Now;
            DateTime hora = DateTime.Now;

            Font font = new Font("Lucida Fax", tamaño, FontStyle.Regular, GraphicsUnit.Point);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("CORTE DE CAJA", font, Brushes.Black, new RectangleF(x, y, width, height), sf);
            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 10, width, height));
            e.Graphics.DrawString("" + fecha + "", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);

            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 20, width, height));
            // Dibujar los textos
            DrawText(e.Graphics, "Sucursal:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Cajero:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Total Folios:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Oper. Can:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Ini. Can:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Mov.Can:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);

            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 20, width, height));
            e.Graphics.DrawString("------------------------", font, drawBrush, new RectangleF(x, y += 20, width, height), sf);
            e.Graphics.DrawString("FIRMA", font, drawBrush, new RectangleF(x, y += 25, width, height), sf);
            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 20, width, height));
            e.Graphics.DrawString("--PROMEDIOS--", font, drawBrush, new RectangleF(x, y += 20, width, height), sf);

            DrawText(e.Graphics, "Dolares:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Tipo Compra:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Pesos:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 20, width, height));

            DrawText(e.Graphics, "Pesos:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Tipo Venta:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Dolares:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 20, width, height));


            e.Graphics.DrawString("-- DIF C/V --", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);
            DrawText(e.Graphics, "USD:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "MXP:", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);

            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 20, width, height));

            e.Graphics.DrawString("-- OPER. CANCELADAS --", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);
            DrawText(e.Graphics, "#Folio:1", hora.ToString("hh:mm tt"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Compra/Venta", "1180.00", new RectangleF(x + 10, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Tipo de cambio", "20.00", new RectangleF(x + 10, y += 20, width, height), font, drawBrush);

            /*
            Bitmap bmp = Properties.Resources.dinero;
            e.Graphics.DrawImage(bmp,new RectangleF(0, y += 10, width, 120));
            */
        }

        public void ImprimirFolio(object sender, PrintPageEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            int width = 200;
            int height = 20;
            int y = 20;
            int x = 15;
            float tamaño = 9;
            DateTime fecha = DateTime.Now;
            Font font = new Font("Lucida Fax", tamaño, FontStyle.Regular, GraphicsUnit.Point);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("CENTRO CAMBIARIO", font, Brushes.Black, new RectangleF(x, y, width, height + 10), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);
            DrawText(e.Graphics, "Cajero: PACO", "Folio:1", new RectangleF(x, y += 30, width, height), font, drawBrush);
            e.Graphics.DrawString("" + fecha + "", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);
            e.Graphics.DrawString("--COMPRA/VENTA--", font, drawBrush, new RectangleF(x, y += 20, width, height), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);
            DrawText(e.Graphics, "Dolares/Pesos", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "T.C/T.V", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Pesos/Dolares", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Efectivo", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Cambio", "PRUEBA", new RectangleF(x, y += 20, width, height), font, drawBrush);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 15, width, height), sf);
            e.Graphics.DrawString("GRACIAS POR SU PREFERENCIA", font, Brushes.Black, new RectangleF(x, y += 20, width, height + 10), sf);

            /*
             * cajero: usuario 		folio: num
compra/venta
dolares00
t.c/t.v
pesos/dolares
efectivo
cambio
fecha hora
gracias por su preferencia

             */

        }

        public void ImprimirSumadora(object sender, PrintPageEventArgs e)
        {
            /*
             * sumadora
________
num
num
num
num
total

fecha y hora
             */

            double lastItem = cantidades.LastOrDefault();
            cantidades.Reverse(0,(cantidades.Count - 1));

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;

            int width = 200;
            int height = 20;
            int y = 20;
            int x = 15;
            float tamaño = 9;
            DateTime fecha = DateTime.Now;
            Font font = new Font("Lucida Fax", tamaño, FontStyle.Regular, GraphicsUnit.Point);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("SUMATORIA", font, Brushes.Black, new RectangleF(x, y, width, height + 10), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);


            for (int i = 0; i < (cantidades.Count - 1); i++)
            {
                e.Graphics.DrawString(cantidades[i].ToString(), font, drawBrush, new RectangleF(x, y += 20, width, height), sf);
            }
            e.Graphics.DrawString("------------", font, drawBrush, new RectangleF(x, y += 20, width, height), sf);
            e.Graphics.DrawString(lastItem.ToString(), font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);

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
