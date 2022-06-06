using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;

namespace Entidades
{
    public class Jugador
    {
        private int nroJugador;
        private string nombre;
        private int edad;
        private string genero;
        private string nacionalidad;
        private bool primerTorneo;

        /// <summary>
        /// Propiedad numero del jugador
        /// </summary>
        public int NroJugador
        {
            get { return nroJugador; }
            set
            {
                if (value > 0)
                {
                    nroJugador = value;
                }
            }
        }

        /// <summary>
        /// Propiedad nickname del jugador
        /// </summary>
        /// <exception cref="Exception_StringNullOrEmpty">Error si el nombre viene vacio o null</exception>
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
                else
                {
                    throw new Exception_StringNullOrEmpty("Error campo vacío o null");
                }
            }
        }

        /// <summary>
        /// Propiedad edad del jugador
        /// </summary>
        /// <exception cref="Exception_EdadInvalida">Error si la edad esta fuera de rango</exception>
        public int Edad
        {
            get { return edad; }
            set
            {
                if (value > 11 && value < 80)
                {
                    edad = value;
                }
                else
                {
                    throw new Exception_EdadInvalida("Error la edad esta fuera de rango");
                }
            }
        }

        /// <summary>
        /// Propiedad genero del jugador
        /// </summary>
        /// <exception cref="Exception_GeneroInvalido">Error si el genero es incorrecto</exception>
        public string Genero
        {
            get { return genero; }
            set
            {
                if (value.Trim() == "Female" || value.Trim() == "Male")
                {
                    genero = value;
                }
                else
                {
                    throw new Exception_GeneroInvalido("Error genero incorrecto");
                }
            }
        }

        /// <summary>
        /// Propiedad nacionalidad del jugador
        /// </summary>
        /// <exception cref="Exception_StringNullOrEmpty">Error si la nacionalidad viene vacio o null</exception>
        public string Nacionalidad
        {
            get { return nacionalidad; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nacionalidad = value;
                }
                else
                {
                    throw new Exception_StringNullOrEmpty("Error campo vacío o null");
                }
            }
        }

        /// <summary>
        /// Propiedad Primer Torneo del jugador
        /// </summary>
        public bool PrimerTorneo
        {
            get { return primerTorneo; }
            set
            {
                if (value || !value)
                {
                    primerTorneo = value;
                }
            }
        }
        /// <summary>
        /// constructor
        /// </summary>
        public Jugador()
        {
        }
        /// <summary>
        /// constructor de atributos
        /// </summary>
        /// <param name="nroJugador"></param>
        /// <param name="nombre"></param>
        /// <param name="edad"></param>
        /// <param name="genero"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="primerTorneo"></param>
        public Jugador(int nroJugador, string nombre, int edad, string genero, string nacionalidad, bool primerTorneo)
        {
            this.nroJugador = nroJugador;
            this.nombre = nombre;
            this.edad = edad;
            this.genero = genero;
            this.nacionalidad = nacionalidad;
            this.primerTorneo = primerTorneo;
        }

        /// <summary>
        /// Sobrecarga metodo toString
        /// </summary>
        /// <returns>Objeto como string</returns>
        public override string ToString()
        {
            StringBuilder jugador = new StringBuilder();
            jugador.AppendLine($"Nro: {this.NroJugador}");
            jugador.AppendLine($"Username: {this.Nombre}");
            jugador.AppendLine($"Edad: {this.Edad}");
            jugador.AppendLine($"Genero: {this.Genero}");
            jugador.AppendLine($"Nacionalidad: {this.Nacionalidad}");
            jugador.AppendLine($"Primer Torneo: {this.PrimerTorneo}");
            jugador.Append($"-----------------------------------------------------------------");
            return jugador.ToString();
        }
    }
}