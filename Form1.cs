using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // NuGet: Oracle.ManagedDataAccess


namespace FibonacciApp
{
    public partial class Form1 : Form
    {
        // ▶ Cadena de conexión a Oracle
        private string connectionString = "User Id=system;Password=Tapiero123;Data Source=localhost:1521/orcl;";
        public Form1()
        {
            InitializeComponent();
        }

        private List<int> GenerarFibonacci(int n)
        {
            List<int> serie = new List<int>();

            int a = 0, b = 1;

            for (int i = 0; i < n; i++)
            {
                serie.Add(a);
                int temp = a + b;
                a = b;
                b = temp;
            }
            return serie;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(txtN.Text);
                var serie = GenerarFibonacci(n);
                txtResultado.Text = string.Join(", ", serie);
                lblEstado.Text = "Serie generada correctamente.";
            }
            catch
            {
                lblEstado.Text = "Error: ingrese un número válido.";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResultado.Text))
            {
                lblEstado.Text = "Primero genere la serie.";
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO SERIE_FIBONACCI (NVALOR, SERIE) VALUES (:n, :serie)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":n", int.Parse(txtN.Text));
                        cmd.Parameters.Add(":serie", txtResultado.Text);
                        cmd.ExecuteNonQuery();
                        lblEstado.Text = "Datos registrados en Oracle.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error BD: " + ex.Message;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
