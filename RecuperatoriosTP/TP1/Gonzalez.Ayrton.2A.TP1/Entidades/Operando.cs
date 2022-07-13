﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Operando
    {
        /// <summary>
        /// Convertira un numero binario a decimal, primero validará que se trate de un binario y luego lo convertirá
        /// </summary>
        /// <param name="binario"></param>string
        /// <returns></returns> Retornara un string que contiene el valor decimal en caso de ser posible. Caso contrario retornará "Valor inválido
        public static string BinarioDecimal(string binario)
        {
            int longitud = binario.Length - 1;
            double numeroDecimal = 0;
            int contador = 0;

            if (EsBinario(binario))
            {
                for (int i = longitud; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        numeroDecimal += Math.Pow(2, contador);
                    }

                    contador++;
                }

                return numeroDecimal.ToString();
            }

            return "Valor inválido";
        }
        /// <summary>
        /// Método que convertira un número decimal a binario 
        /// </summary>
        /// <param name="numero"></param> double
        /// <returns></returns> retornará un string que contiene el valor binario en caso de ser posible. Caso contrario retornará "Valor inválido".
        public static string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }
        /// <summary>
        /// Método que convertira un número decimal a binario 
        /// </summary>
        /// <param name="numero"></param> string
        /// <returns></returns> retornará un string que contiene el valor binario en caso de ser posible. Caso contrario retornará "Valor inválido".
        public static string DecimalBinario(string numero)
        {
            int num;
            string result = "Valor inválido";
            if (int.TryParse(numero, out num))
            {
                if (num > 0)
                {
                    result = Convert.ToString(num, 2);
                }
            }
            return result;
        }
        //Sobrecarga de Constructores
        /// <summary>
        /// El constructor por defecto(sin parámetros) asignará valor 0 al atributo numero.
        /// </summary>
        private double numero;
        public Operando() : this(0)
        {

        }
        /// <summary>
        /// Constructor que recibe un double
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero) : this(numero.ToString())
        {

        }
        /// <summary>
        /// Constructor que recibe un string
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        //set
        /// <summary>
        /// La propiedad Numero asignará un valor al atributo número, previa validación. En este lugar será el único en todo el código que llame al método ValidarOperando.
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = this.ValidarOperando(value);
            }
        }
        /// <summary>
        /// El método privado EsBinario validará que la cadena de caracteres esté compuesta SOLAMENTE por caracteres '0' o '1'.
        /// </summary>
        /// <param name="caracter"></param>
        /// <returns>un booleano que retorna falso si no es un numero binario </returns>
        private static bool EsBinario(string binario)
        {
            foreach (char c in binario)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }

            return true;
        }

        #region Operator
        /// <summary>
        /// Calculo entre dos numeros de tipo suma
        /// </summary>
        /// <param name="num1"></param> recibe un numero de tipo Operando
        /// <param name="num2"></param> recibe un numero de tipo Operando
        /// <returns></returns> retorna el calculo entre los dos numeros
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Calculo entre dos numeros de tipo resta
        /// </summary>
        /// <param name="num1"></param> recibe un numero de tipo Operando
        /// <param name="num2"></param> recibe un numero de tipo Operando
        /// <returns></returns> retorna el calculo entre los dos numeros
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Calculo entre dos numeros de tipo multiplicacion
        /// </summary>
        /// <param name="num1"></param> recibe un numero de tipo Operando
        /// <param name="num2"></param> recibe un numero de tipo Operando
        /// <returns></returns> retorna el calculo entre los dos numeros
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Calculo entre dos numeros de tipo division
        /// </summary>
        /// <param name="num1"></param> recibe un numero de tipo Operando
        /// <param name="num2"></param> recibe un numero de tipo Operando
        /// <returns></returns> retorna el calculo entre los dos numeros
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        #endregion

        /// <summary>
        /// ValidarOperando comprobará que el valor recibido sea numérico, y lo retornará en formato double.Caso contrario, retornará 0.
        /// </summary> 
        /// <param></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {
            double num;

            if (!double.TryParse(strNumero, out num)) //en caso de que NO pueda retornarlo en double, lo retorna en 0
            {
                num = 0;
            }
            return num;
        }
    }
}