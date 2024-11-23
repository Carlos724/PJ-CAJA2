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

using MySql.Data.MySqlClient;

namespace PJ_CAJA_2
{
    class Ticket
    {

        ConexionInicial conexionSQL = new ConexionInicial();

        public List<double> cantidades;
        public List<string> denominacion;
        public List<string> datosFolio;
        public List<string> datosCorte;
        public List<string> datosFoliosCan;
        public List<int> datosImpresora;

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

        public void DrawFolio(Graphics graphics, string leftText, string rightText,int x, int y, int width,int height, Font font, Brush brush, StringFormat sfFolios)
        {
            int width1 = (width / 2);
            int x1 = x;  // Posición para el primer rectángulo
            int x2 = x1 + 100;  // Posición para el segundo rectángulo (agregamos un espacio de 10px entre ellos)

            // Texto en el primer rectángulo
            graphics.DrawString(leftText, font, brush, new RectangleF(x1, y, width1, height) , sfFolios);

            // Texto en el segundo rectángulo
            graphics.DrawString(rightText, font, brush, new RectangleF(x2, y, width1, height), sfFolios);

        }

        public void ImprimirCorte(object sender, PrintPageEventArgs e)
        {
            /*
             * Medidas para rollo mini
            int width = 200;
            int height = 20;
            DrawFolio(e.Graphics, "$", cantidades[i].ToString("F2"), x, y += 20, width, height, font, drawBrush, sfFolios);

                        datosImpresora.Add(Papel_width); 0
                        datosImpresora.Add(Papel_height); 1
                        datosImpresora.Add(Papel_height_Suma); 2
                        datosImpresora.Add(Papel_y); 3
                        datosImpresora.Add(Papel_x); 4
                        datosImpresora.Add(Papel_tam_Corte); 5
                        datosImpresora.Add(Papel_tam_Otro); 6
             */
            conexionSQL.datosXML = conexionSQL.LeerXML();
            conexionSQL.cnnInicial = new MySqlConnection(conexionSQL.datosXML);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            StringFormat sfFolios = new StringFormat();
            sfFolios.Alignment = StringAlignment.Far;

            int width = datosImpresora[0];
            int height = datosImpresora[1];
            int y = datosImpresora[3];
            int x = datosImpresora[4];
            float tamaño = datosImpresora[5];
            DateTime fecha = DateTime.Now;

            Font font = new Font("Lucida Fax", tamaño, FontStyle.Regular, GraphicsUnit.Point);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("CORTE DE CAJA", font, Brushes.Black, new RectangleF(x, y, width, height), sf);
            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 10, width, height));
            e.Graphics.DrawString("" + fecha + "", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);

            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 20, width, height));
            // Dibujar los textos

            DrawFolio(e.Graphics, "Sucursal:", conexionSQL.sucursal, x, y += 20, width, height, font, drawBrush, sfFolios);
            DrawText(e.Graphics, "Cajero:", Properties.Settings.Default.strUsuario_, new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Total Folios:", datosCorte[0].ToString(), new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Oper. Can:", datosCorte[1].ToString(), new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Ini. Can:", datosCorte[2].ToString(), new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Mov.Can:", datosCorte[3].ToString(), new RectangleF(x, y += 20, width, height), font, drawBrush);

            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 20, width, height));
            e.Graphics.DrawString("------------------------", font, drawBrush, new RectangleF(x, y += 20, width, height), sf);
            e.Graphics.DrawString("FIRMA", font, drawBrush, new RectangleF(x, y += 25, width, height), sf);
            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 20, width, height));
            e.Graphics.DrawString("--PROMEDIOS--", font, drawBrush, new RectangleF(x, y += 20, width, height), sf);

            DrawText(e.Graphics, "Dolares:", double.Parse(datosCorte[4]).ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "T.C:", datosCorte[5].ToString(), new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Pesos:", double.Parse(datosCorte[6]).ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            e.Graphics.DrawString("", font, drawBrush, new RectangleF(x, y += 20, width, height));

            DrawText(e.Graphics, "Pesos:", double.Parse(datosCorte[9]).ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "T.V:", datosCorte[8].ToString(), new RectangleF(x, y += 20, width, height), font, drawBrush);
            DrawText(e.Graphics, "Dolares:", double.Parse(datosCorte[7]).ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 20, width, height));


            e.Graphics.DrawString("-- DIF C/V --", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);

            double USD = double.Parse(datosCorte[10]);

            if (USD > 0)
            {
                DrawText(e.Graphics, "USD: FAL", USD.ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            }
            else if (double.Parse(datosCorte[10]) == 0)
            {
                DrawText(e.Graphics, "USD:", USD.ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            }
            else if (double.Parse(datosCorte[10]) < 0)
            {
                DrawText(e.Graphics, "USD: SOB", USD.ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            }

            double MXP = double.Parse(datosCorte[11]);

            if (MXP > 0)
            {
                DrawText(e.Graphics, "MXP: FAL", MXP.ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            }
            else if (double.Parse(datosCorte[11]) == 0)
            {
                DrawText(e.Graphics, "MXP:", MXP.ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            }
            else if (double.Parse(datosCorte[11]) < 0)
            {
                DrawText(e.Graphics, "MXP: SOB", MXP.ToString("F2"), new RectangleF(x, y += 20, width, height), font, drawBrush);
            }

            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 20, width, height));

            int numfoliocan = datosFoliosCan.Count();
            e.Graphics.DrawString("-- OPER. CANCELADAS --", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);

            if (numfoliocan > 0)
            {
                for (int i = 0; i < numfoliocan; i++)
                {
                    Console.Write(i);
                    DrawText(e.Graphics, "#Folio:"+datosFoliosCan[i], datosFoliosCan[i+=1], new RectangleF(x, y += 20, width, height), font, drawBrush);
                    DrawText(e.Graphics, datosFoliosCan[i+=1], datosFoliosCan[i+=1], new RectangleF(x + 10, y += 20, width, height), font, drawBrush);
                    DrawText(e.Graphics, "Tipo de cambio", datosFoliosCan[i+=1], new RectangleF(x + 10, y += 20, width, height), font, drawBrush);
                }
            }
            else if(numfoliocan <= 0)
            {
                e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 20, width, height));
                e.Graphics.DrawString("CERO CANCELADAS", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);
            }

            /*
             * Folios activos
             * Folios cancelados
             * Entradas/salidas canceladas
             * Dolares compra
             * Promedio tipo compra
             * pesos compra (dolares compra * pesos compra)
             * Dolares venta
             * Promedio tipo venta
             * pesos compra (dolares venta * pesos venta)
             * 
             * diferencia dolares
             * diferencia pesos
             * 
             * lista operaciones canceladas
            */
        }

        public void ImprimirFolio(object sender, PrintPageEventArgs e)
        {
            /*
            datosImpresora.Add(Papel_width); 0
            datosImpresora.Add(Papel_height); 1
            datosImpresora.Add(Papel_height_Suma); 2
            datosImpresora.Add(Papel_y); 3
            datosImpresora.Add(Papel_x); 4
            datosImpresora.Add(Papel_tam_Corte); 5
            datosImpresora.Add(Papel_tam_Otro); 6
 */
            conexionSQL.datosXML = conexionSQL.LeerXML();
            conexionSQL.cnnInicial = new MySqlConnection(conexionSQL.datosXML);
            datosImpresora = conexionSQL.EjecutarSelectImpresora();

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            StringFormat sfFolios = new StringFormat();
            sfFolios.Alignment = StringAlignment.Far;

            int width = datosImpresora[0];
            int height = datosImpresora[1];
            int y = datosImpresora[3];
            int x = datosImpresora[4];
            float tamaño = datosImpresora[6];
            Font font = new Font("Lucida Fax", tamaño, FontStyle.Regular, GraphicsUnit.Point);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("CENTRO CAMBIARIO", font, Brushes.Black, new RectangleF(x, y, width, height + 10), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);
            DrawFolio(e.Graphics, "Cajero:", "Folio:", x, y += 20, width, height, font, drawBrush, sf);
            DrawFolio(e.Graphics, Properties.Settings.Default.strUsuario_, ""+VariablesGlobales.NumFolio, x, y += 20, width, height, font, drawBrush, sf);

            e.Graphics.DrawString("" + datosFolio[0] + "", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);
            e.Graphics.DrawString("--"+datosFolio[1]+"--", font, drawBrush, new RectangleF(x, y += 20, width, height), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);

            DrawFolio(e.Graphics, datosFolio[2], datosFolio[3], x, y += 20, width, height, font, drawBrush,sfFolios);
            DrawFolio(e.Graphics, datosFolio[4], datosFolio[5], x, y += 20, width, height, font, drawBrush,sfFolios);

            string simbolo = "-";
            int repeticiones = (int)((width) / font.Size);
            string textoLargo = new string(Enumerable.Repeat(simbolo, repeticiones).SelectMany(j => j).ToArray());
            DrawFolio(e.Graphics, "", textoLargo, x, y += 10, width, height, font, drawBrush, sfFolios);

            DrawFolio(e.Graphics, datosFolio[6], datosFolio[7], x, y += 20, width, height, font, drawBrush,sfFolios);
            DrawFolio(e.Graphics, "Efectivo", datosFolio[8], x, y += 20, width, height, font, drawBrush,sfFolios);
            DrawFolio(e.Graphics, "Cambio", datosFolio[9], x, y += 20, width, height, font, drawBrush,sfFolios);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 15, width, height), sf);
            e.Graphics.DrawString("GRACIAS POR SU PREFERENCIA", font, Brushes.Black, new RectangleF(x, y += 20, width, height + 10), sf);

        }

        public void ImprimirSumadora(object sender, PrintPageEventArgs e)
        {
            /*
            datosImpresora.Add(Papel_width); 0
            datosImpresora.Add(Papel_height); 1
            datosImpresora.Add(Papel_height_Suma); 2
            datosImpresora.Add(Papel_y); 3
            datosImpresora.Add(Papel_x); 4
            datosImpresora.Add(Papel_tam_Corte); 5
            datosImpresora.Add(Papel_tam_Otro); 6
             */
            conexionSQL.datosXML = conexionSQL.LeerXML();
            conexionSQL.cnnInicial = new MySqlConnection(conexionSQL.datosXML);
            datosImpresora = conexionSQL.EjecutarSelectImpresora();

            double lastItem = cantidades.LastOrDefault();
            cantidades.Reverse(0,(cantidades.Count - 1));

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            StringFormat sfFolios = new StringFormat();
            sfFolios.Alignment = StringAlignment.Far;

            int width = datosImpresora[0];
            int height = datosImpresora[2];
            int y = datosImpresora[3];
            int x = datosImpresora[4];
            float tamaño = datosImpresora[6];
            DateTime fecha = DateTime.Now;
            Font font = new Font("Lucida Fax", tamaño, FontStyle.Regular, GraphicsUnit.Point);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("SUMATORIA", font, Brushes.Black, new RectangleF(x, y, width, height + 10), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);
            //ToString("F2") = siempre tener dos decimales

            for (int i = 0; i < (cantidades.Count - 1); i++)
            {
                DrawFolio(e.Graphics, "$", cantidades[i].ToString("F2"), x, y += 20, width, height, font, drawBrush, sfFolios);
            }
            // Definir el texto que quieres repetir, en este caso "-"
            string simbolo = "-";

            // Calcular cuántas veces se puede repetir el patrón dentro del ancho disponible
            int repeticiones = (int)((width) / font.Size);  // Divide el ancho entre el tamaño de la fuente para obtener cuántas repeticiones caben

            // Crear un string que contiene las repeticiones del patrón
            string textoLargo = new string(Enumerable.Repeat(simbolo, repeticiones).SelectMany(j => j).ToArray());

            // Dibujar el texto repetido en la posición deseada

            DrawFolio(e.Graphics, "", textoLargo, x, y += 20, width, height, font, drawBrush, sfFolios);

            DrawFolio(e.Graphics, "Total $", lastItem.ToString("F2"), x, y += 20, width, height, font, drawBrush, sfFolios);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);
            e.Graphics.DrawString("" + fecha + "", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);
        }

        public void ImprimirDesgloce(object sender, PrintPageEventArgs e)
        {
            /*
            datosImpresora.Add(Papel_width); 0
            datosImpresora.Add(Papel_height); 1
            datosImpresora.Add(Papel_height_Suma); 2
            datosImpresora.Add(Papel_y); 3
            datosImpresora.Add(Papel_x); 4
            datosImpresora.Add(Papel_tam_Corte); 5
            datosImpresora.Add(Papel_tam_Otro); 6
             */
            conexionSQL.datosXML = conexionSQL.LeerXML();
            conexionSQL.cnnInicial = new MySqlConnection(conexionSQL.datosXML);
            datosImpresora = conexionSQL.EjecutarSelectImpresora();

            double lastItem = cantidades.LastOrDefault();
            cantidades.Reverse(0, (cantidades.Count - 1));
            denominacion.Reverse();

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            StringFormat sfFolios = new StringFormat();
            sfFolios.Alignment = StringAlignment.Far;

            int width = datosImpresora[0];
            int height = datosImpresora[1];
            int y = datosImpresora[3];
            int x = datosImpresora[4];
            float tamaño = datosImpresora[6];
            DateTime fecha = DateTime.Now;
            Font font = new Font("Lucida Fax", tamaño, FontStyle.Regular, GraphicsUnit.Point);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("DESGLOSE", font, Brushes.Black, new RectangleF(x, y, width, height + 10), sf);
            e.Graphics.DrawString("", font, Brushes.Black, new RectangleF(x, y += 10, width, height), sf);
            DrawFolio(e.Graphics, "Denominacion", "Cantidad", x, y += 20, width, height, font, drawBrush, sf);

            for (int i = 0; i < (cantidades.Count - 1); i++)
            {
                DrawFolio(e.Graphics, "[" + denominacion[i].ToString() + "] $", cantidades[i].ToString("F2"), x, y += 20, width, height, font, drawBrush, sfFolios);
            }
            string simbolo = "-";
            int repeticiones = (int)((width) / font.Size);
            string textoLargo = new string(Enumerable.Repeat(simbolo, repeticiones).SelectMany(j => j).ToArray());
            DrawFolio(e.Graphics, "", textoLargo, x, y += 20, width, height, font, drawBrush, sfFolios);

            DrawFolio(e.Graphics, "Total $", lastItem.ToString("F2"), x, y += 20, width, height, font, drawBrush, sfFolios);
            e.Graphics.DrawString("" + fecha + "", font, Brushes.Black, new RectangleF(x, y += 20, width, height), sf);

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
