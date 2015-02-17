﻿using System;
using System.Linq;

namespace NumerosALetras.Classes
{
    public class ClsNumerosALetras
    {

        /// <summary>
        /// Separar parte entera y decimal, convertirlas e unirlas.
        /// </summary>
        /// <param name="numero">Número a convertir.</param>
        /// <returns>Número en formato de texto.</returns>
        public static string ConvertirNumerosALetras(string numero)
        {
            // Variables
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;
            try
            {
                // Validar vacíos.
                if (string.IsNullOrEmpty(numero))
                {
                    return "";
                }
                // Validar longitud (Double 16).
                if (numero.Split('.')[0].Length > 16)
                {
                    return "Número fuera de rango.";
                }              
                // Tratar de convertir cadena a número.
                nro = Double.Parse(numero);
                // Obtener la parte entera y decimal.
                entero = Convert.ToInt64(Math.Truncate(nro));
                decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
                // Convertir parte decimal.
                if (decimales > 0)
                {
                    dec = " CON " + decimales.ToString() + "/100";
                }
                // Convertir parte entera y unirla con la parte decimal.
                res = CovertirValor(Convert.ToDouble(entero)) + dec;

                // Acentos.
                if (res.IndexOf("DIECISEIS") != -1)
                {
                    res.Replace("DIECISEIS", "DIECISÉIS");
                }
                // Acentos.
                if (res.IndexOf("VEINTIDOS") != -1)
                {
                    res.Replace("VEINTIDOS", "VEINTIDÓS");
                }
                // Acentos.
                if (res.IndexOf("VEINTITRES") != -1)
                {
                    res.Replace("VEINTITRES", "VEINTITRÉS");
                }
                // Acentos.
                if (res.IndexOf("VEINTISEIS") != -1)
                {
                    res.Replace("VEINTISEIS", "VEINTISÉIS");
                }

                return res;
            }
            catch
            {
                return "No es un número.";
            }
        }

        /// <summary>
        /// Convertir un valor a letras.
        /// </summary>
        /// <param name="value">Valor a convertir.</param>
        /// <returns>Valor en formato de texto.</returns>
        private static string CovertirValor(double value)
        {
            string resultado = "";
            value = Math.Truncate(value);
            if (value == 0) resultado = "CERO";
            else if (value == 1) resultado = "UNO";
            else if (value == 2) resultado = "DOS";
            else if (value == 3) resultado = "TRES";
            else if (value == 4)
                resultado = "CUATRO";
            else if (value == 5) resultado = "CINCO";
            else if (value == 6) resultado = "SEIS";
            else if (value == 7) resultado = "SIETE";
            else if (value == 8) resultado = "OCHO";
            else if (value == 9) resultado = "NUEVE";
            else if (value == 10) resultado = "DIEZ";
            else if (value == 11) resultado = "ONCE";
            else if (value == 12)
                resultado = "DOCE";
            else if (value == 13) resultado = "TRECE";
            else if (value == 14) resultado = "CATORCE";
            else if (value == 15) resultado = "QUINCE";
            else if (value < 20) resultado = "DIECI" + CovertirValor(value - 10);
            else if (value == 20) resultado = "VEINTE";
            else if (value < 30) resultado = "VEINTI" + CovertirValor(value - 20);
            else if (value == 30) resultado = "TREINTA";
            else if (value == 40) resultado = "CUARENTA";
            else if (value == 50) resultado = "CINCUENTA";
            else if (value == 60) resultado = "SESENTA";
            else if (value == 70) resultado = "SETENTA";
            else if (value == 80) resultado = "OCHENTA";
            else if (value == 90) resultado = "NOVENTA";
            else if (value < 100) resultado = CovertirValor(Math.Truncate(value / 10) * 10) + " Y " + CovertirValor(value % 10);
            else if (value == 100) resultado = "CIEN";
            else if (value < 200) resultado = "CIENTO " + CovertirValor(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) resultado = CovertirValor(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) resultado = "QUINIENTOS";
            else if (value == 700) resultado = "SETECIENTOS";
            else if (value == 900) resultado = "NOVECIENTOS";
            else if (value < 1000) resultado = CovertirValor(Math.Truncate(value / 100) * 100) + " " + CovertirValor(value % 100);
            else if (value == 1000) resultado = "MIL";
            else if (value < 2000) resultado = "MIL " + CovertirValor(value % 1000);
            else if (value < 1000000)
            {
                resultado = CovertirValor(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) resultado = resultado + " " + CovertirValor(value % 1000);
            }

            else if (value == 1000000) resultado = "UN MILLÓN";
            else if (value < 2000000) resultado = "UN MILLÓN " + CovertirValor(value % 1000000);
            else if (value < 1000000000000)
            {
                resultado = CovertirValor(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) resultado = resultado + " " + CovertirValor(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) resultado = "UN BILLÓN";
            else if (value < 2000000000000) resultado = "UN BILLÓN " + CovertirValor(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                resultado = CovertirValor(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) resultado = resultado + " " + CovertirValor(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return resultado;

        }

    }
}