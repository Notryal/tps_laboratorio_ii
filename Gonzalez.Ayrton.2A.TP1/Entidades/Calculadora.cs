using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        /// <summary>
        /// El método ValidarOperador será privado y estático. 
        /// Deberá validar que el operador recibido sea +, -, / o *. 
        /// Caso contrario retornará +.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Devuelve el signo del operacion</returns>
        private static char ValidarOperador(char operador)
        {
            char resultado;

            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                resultado = operador;
            }
            else
            {
                resultado = '+';
            }

            return resultado;
        }

        /// <summary>
        /// El método Operar será de clase: 
        /// validará y realizará la operación pedida entre ambos números.
        ///
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>el resultado de la operatcion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;


            switch (ValidarOperador(operador))
            {

                case '+':
                    resultado = num1 + num2;
                    break;

                case '-':
                    resultado = num1 - num2;
                    break;

                case '/':
                    resultado = num1 / num2;
                    break;

                case '*':
                    resultado = num1 * num2;
                    break;

                default:
                    resultado = num1 + num2;
                    break;

            }



            return resultado;
        }





    }
}