using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01_Mi_Primera_Vez.Logica;

namespace _01_Mi_Primera_Vez.Presentacion.Personal
{
    public partial class Frmpersonal : Form
    {
        public bool modoEdision = false;
        public Frmpersonal(string modo)
        {
            InitializeComponent();
            if (modo != "n") this.modoEdision = true;            
        }
        
        private void Frmpersonal_Load(object sender, EventArgs e)
        {
            if (!this.modoEdision)
            {
                lblFrmPersonal.Text = "Ingreso de Nuevo Personal";
            }
            else { 
                lblFrmPersonal.Text = "Actualziacion de Personal";
            }

            var listapaises = new cls_pais();
            
            cmbPais.DataSource = listapaises.leer();
            cmbPais.ValueMember = "IdPais";
            cmbPais.DisplayMember = "Detalle";

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

            private void button2_Click(object sender, EventArgs e)
{
    // Validar que todos los campos necesarios estén llenos
    if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
        string.IsNullOrWhiteSpace(txtCedula.Text) ||
        string.IsNullOrWhiteSpace(txtCargo.Text) ||
        string.IsNullOrWhiteSpace(txtSalario.Text) ||
        cmbPais.SelectedValue == null)
    {
        MessageBox.Show("Por favor, complete todos los campos.");
        return; // Salir del método si hay campos vacíos
    }

    // Intentar convertir el salario a decimal
    decimal sueldo;
    if (!decimal.TryParse(txtSalario.Text, out sueldo))
    {
        MessageBox.Show("Por favor, ingrese un salario válido.");
        return; // Salir del método si la conversión falla
    }

    // Crear el objeto dto_personal
    var dto_personal = new Datos.dto_personal
    {
        cargo = txtCargo.Text,
        cedula = txtCedula.Text,
        idPais = (int)cmbPais.SelectedValue,
        nombre = txtNombres.Text,
        sueldo = sueldo
    };

    // Crear la instancia de cls_personal
    var cls_personal = new cls_personal();

    // Intentar insertar los datos
    string resultado = cls_personal.Insertar(dto_personal);
    if (resultado == "ok")
    {
        MessageBox.Show("Se guardó con éxito.");
        this.Close(); // Cerrar el formulario
    }
    else
    {
        MessageBox.Show("Error al guardar: " + resultado);
    }
}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = cmbPais.SelectedItem.ToString();
            MessageBox.Show("Has seleccionado: " + selectedCountry);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPais.Items.Add("Ecuador");
            cmbPais.Items.Add("Perú");
            cmbPais.Items.Add("Colombia");
            cmbPais.Items.Add("Argentina");
            cmbPais.Items.Add("Brasil");
            cmbPais.Items.Add("Chile");
            cmbPais.Items.Add("México");
            cmbPais.Items.Add("Bolivia");
            cmbPais.Items.Add("Uruguay");
            cmbPais.Items.Add("Paraguay");
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            using (StreamWriter writer = new StreamWriter("cedulas.txt", true))

            {
                writer.WriteLine(cedula);
            }
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
