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

namespace GestionPropiedades_sln
{
    public partial class frmPropiedades : Form
    {
        public frmPropiedades()
        {
            InitializeComponent();

            dtgCasa.Columns.Add("Dirección", "Dirección");
            dtgCasa.Columns[0].Width = 130;
            dtgCasa.Columns.Add("Área", "Área");
            dtgCasa.Columns[1].Width = 130;
            dtgCasa.Columns.Add("Alcobas", "Alcobas ");
            dtgCasa.Columns[2].Width = 130;
            dtgCasa.Columns.Add("Baños", "Baños");
            dtgCasa.Columns[3].Width = 130;
            dtgCasa.Columns.Add("Parqueadero", "Parqueadero");
            dtgCasa.Columns[4].Width = 130;
            dtgCasa.Columns.Add("Jardin", "Jardin");
            dtgCasa.Columns[5].Width = 130;
            dtgCasa.Columns.Add("Precio", "Precio");
            dtgCasa.Columns[6].Width = 130;


            dtgApartamento.Columns.Add("Dirección", "Dirección");
            dtgApartamento.Columns[0].Width = 130;
            dtgApartamento.Columns.Add("Área", "Área");
            dtgApartamento.Columns[1].Width = 130;
            dtgApartamento.Columns.Add("Alcobas", "Alcobas ");
            dtgApartamento.Columns[2].Width = 130;
            dtgApartamento.Columns.Add("Baños", "Baños");
            dtgApartamento.Columns[3].Width = 130;
            dtgApartamento.Columns.Add("Parqueadero", "Parqueadero");
            dtgApartamento.Columns[4].Width = 130;
            dtgApartamento.Columns.Add("Balcón", "Balcón");
            dtgApartamento.Columns[5].Width = 130;
            dtgApartamento.Columns.Add("Precio", "Precio");
            dtgApartamento.Columns[6].Width = 130;
        }

        private void btnIngresarCasa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDireccionCasa.Text) || string.IsNullOrWhiteSpace(txtAreaCasa.Text) || string.IsNullOrWhiteSpace(txtAlcobasCasa.Text) || string.IsNullOrWhiteSpace(txtBañosCasa.Text) || string.IsNullOrWhiteSpace(txtParqueaderoCasa.Text) || string.IsNullOrWhiteSpace(txtJardin.Text) || string.IsNullOrWhiteSpace(txtPrecioCasa.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            clsCasa PropiedadCasa = new clsCasa();
            PropiedadCasa.direccion = txtDireccionCasa.Text;
            PropiedadCasa.area = txtAreaCasa.Text;
            PropiedadCasa.alcobas = Convert.ToInt32(txtAlcobasCasa.Text);
            PropiedadCasa.baños = Convert.ToInt32(txtBañosCasa.Text);
            PropiedadCasa.parqueadero = txtParqueaderoCasa.Text;
            PropiedadCasa.jardin = txtJardin.Text;
            PropiedadCasa.precio = (int)Convert.ToInt64(txtPrecioCasa.Text);



            dtgCasa.Rows.Add(PropiedadCasa.direccion, PropiedadCasa.area, PropiedadCasa.alcobas, PropiedadCasa.baños, PropiedadCasa.parqueadero, PropiedadCasa.jardin, PropiedadCasa.precio);

            txtDireccionCasa.Text = "";
            txtAreaCasa.Text = "";
            txtAlcobasCasa.Text = "";
            txtBañosCasa.Text = "";
            txtParqueaderoCasa.Text = "";
            txtJardin.Text = "";
            txtPrecioCasa.Text = "";

        }

        private void btnCargarCasa_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Archivos de texto (*.Txt)|*.Txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader file = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] valores = line.Split(';');
                            if (valores.Length == 7)
                            {
                                dtgCasa.Rows.Add(valores[0], valores[1], valores[2], valores[3], valores[4], valores[5], valores[6]);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo: " + ex.Message);
                }
            }
        }

        private void btnLimpiarCasa_Click(object sender, EventArgs e)
        {
            dtgCasa.Rows.Clear();
        }

        private void btnIngresarApartamento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDireccionApartamento.Text) || string.IsNullOrWhiteSpace(txtAreaApartamento.Text) || string.IsNullOrWhiteSpace(txtAlcobasApartamento.Text) || string.IsNullOrWhiteSpace(txtBañosApartamento.Text) || string.IsNullOrWhiteSpace(txtParqueaderoApartamento.Text) || string.IsNullOrWhiteSpace(txtBalcones.Text) || string.IsNullOrWhiteSpace(txtPrecioApartamento.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            clsApartamento PropiedadApartamento = new clsApartamento();
            PropiedadApartamento.direccion = txtDireccionApartamento.Text;
            PropiedadApartamento.area = txtAreaApartamento.Text;
            PropiedadApartamento.alcobas = Convert.ToInt32(txtAlcobasApartamento.Text);
            PropiedadApartamento.baños = Convert.ToInt32(txtBañosApartamento.Text);
            PropiedadApartamento.parqueadero = txtParqueaderoApartamento.Text;
            PropiedadApartamento.balcones = txtBalcones.Text;
            PropiedadApartamento.precio = (int)Convert.ToInt64(txtPrecioApartamento.Text);



            dtgApartamento.Rows.Add(PropiedadApartamento.direccion, PropiedadApartamento.area, PropiedadApartamento.alcobas ,PropiedadApartamento.baños, PropiedadApartamento.parqueadero, PropiedadApartamento.balcones, PropiedadApartamento.precio);

            txtDireccionApartamento.Text = "";
            txtAreaApartamento.Text = "";
            txtAlcobasApartamento.Text = "";
            txtBañosApartamento.Text = "";
            txtParqueaderoApartamento.Text = "";
            txtBalcones.Text = "";
            txtPrecioApartamento.Text = "";

        }

        private void btnCargarApartamento_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Archivos de texto (*.Txt)|*.Txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader file = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] valores = line.Split(';');
                            if (valores.Length == 7)
                            {
                                dtgApartamento.Rows.Add(valores[0], valores[1], valores[2], valores[3], valores[4], valores[5], valores[6]);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo: " + ex.Message);
                }
            }
        }

        private void btnLimpiarApartamento_Click(object sender, EventArgs e)
        {
            dtgApartamento.Rows.Clear();
        }
    }
}

