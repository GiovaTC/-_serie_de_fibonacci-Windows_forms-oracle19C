using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // NuGet: Oracle.ManagedDataAccess.Core

namespace FibonacciApp
{
    public partial class Form1 : Form
    {
        // 🔧 Cadena de conexión ajustada (Core)
        // Usa XEPDB1 si es Oracle XE. Si tu servicio es ORCL, deja tal cual.
        private string connectionString =
            "User Id=system;Password=Tapiero123;Data Source=localhost:1521/orcl;Connection Timeout=60;";

        public Form1()
        {
            InitializeComponent();
        }

        private List<int> GenerarFibonacci(int n)
        {
            if (n <= 0)
                throw new ArgumentException("El valor de N debe ser mayor a cero.");

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
                lblEstado.Text = "Serie generada correctamente ✔";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error: " + ex.Message;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResultado.Text))
            {
                lblEstado.Text = "⚠ Primero genere la serie.";
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand(
                        "INSERT INTO SERIE_FIBONACCI (NVALOR, SERIE) VALUES (:n, :serie)", conn))
                    {
                        cmd.Parameters.Add(":n", OracleDbType.Int32).Value = int.Parse(txtN.Text);
                        cmd.Parameters.Add(":serie", OracleDbType.Clob).Value = txtResultado.Text;
                        cmd.ExecuteNonQuery();
                    }
                }

                lblEstado.Text = "📦 Datos registrados en Oracle correctamente.";
            }
            catch (OracleException ex)
            {
                lblEstado.Text = "❌ Error Oracle: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblEstado.Text = "⚠ Error general: " + ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Test de conexión inicial (opcional)
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    lblEstado.Text = "🔗 Conexión establecida con Oracle.";
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "❗ No se pudo conectar a Oracle: " + ex.Message;
            }
        }
    }
}
