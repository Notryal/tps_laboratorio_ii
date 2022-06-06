using System;

namespace Excepciones
{
    public class Exception_StringNullOrEmpty : Exception
    {
        /// <summary>
        /// Crea una excepcion con un mensaje
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public Exception_StringNullOrEmpty(string message) : this(message, null)
        {

        }

        /// <summary>
        /// Crea una excepcion con un mensaje y un innerException
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        /// <param name="innerException">innerException de la excepcion</param>
        public Exception_StringNullOrEmpty(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
