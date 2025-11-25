using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client; // NuGet: Oracle.ManagedDataAccess


namespace FibonacciApp
{
    public partial class Form1 : Form
    {
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
