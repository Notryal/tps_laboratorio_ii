using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        #region Botones
        /// <summary>
        /// Cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
           this.Close();
        }
        /// <summary>
        /// Realiza la operacion matematica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {

            /// <returns>retornar el resultado al método de evento del botón btnOperar que reflejará el resultado en el Label txtResultado.</returns>
            /// 
            string operador = cmbOperador.Text;
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;


            double validador;

            if (double.TryParse(numero1, out validador) && double.TryParse(numero2, out validador))
            {
                if (operador == string.Empty)
                {
                    operador = "+";
                }

                double result = FormCalculadora.Operar(numero1, numero2, operador);
                lblResultado.Text = result.ToString();
                lstOperaciones.Items.Add(numero1 + operador + numero2 + "=" + result.ToString());
            }
            else
            {
                MessageBox.Show("El formulario no se lleno correctamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Metodo del evento click del boton convertir a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #endregion

        /// <summary>
        /// borrará los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            
            cmbOperador.SelectedItem = "";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text="";

        }
        /// <summary>
        /// El método Operar será estático recibirá los dos números y el operador para luego llamar al método Operar de Calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>retornar el resultado al método de evento del botón btnOperar que reflejará el resultado en el Label txtResultado.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            if (operador == "/" && numero2 == "0")
            {
                MessageBox.Show("No se puede dividir por cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            return Calculadora.Operar(num1, num2, Convert.ToChar(operador));
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult flag = MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (flag == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        /// <summary>
        /// Metodo del evento click del boton convertir a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text != "" && txtNumero2.Text != "" && lblResultado.Text != "0" && lblResultado.Text != "Valor inválido")
            {
                string result = Operando.DecimalBinario(lblResultado.Text);
                lblResultado.Text = result;
                btnConvertirABinario.Enabled = false;
            }
        }
        /// <summary>
        /// Metodo del evento click del boton covertir a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text != "" && txtNumero2.Text != "" && lblResultado.Text != "0" && lblResultado.Text != "Valor inválido")
            {
                string result = Operando.BinarioDecimal(lblResultado.Text);
                lblResultado.Text = result;
                btnConvertirADecimal.Enabled = false;
            }
        }
    }
}
