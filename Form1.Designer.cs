using System.Drawing;
using System.Windows.Forms;

namespace FibonacciApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // ▶ Declaración de controles
        private TextBox txtN;
        private TextBox txtResultado;
        private Label lblEstado;
        private Label lblN;
        private Button btnGenerar;
        private Button btnGuardar;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.txtN = new TextBox();
            this.txtResultado = new TextBox();
            this.lblEstado = new Label();
            this.lblN = new Label();
            this.btnGenerar = new Button();
            this.btnGuardar = new Button();

            this.SuspendLayout();

            // 
            // txtN
            // 
            this.txtN.Location = new Point(150, 50);
            this.txtN.Name = "txtN";
            this.txtN.Size = new Size(150, 23);

            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new Point(50, 53);
            this.lblN.Name = "lblN";
            this.lblN.Size = new Size(85, 15);
            this.lblN.Text = "Ingrese N:";

            // 
            // txtResultado
            // 
            this.txtResultado.Location = new Point(50, 100);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new Size(500, 150);

            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new Point(320, 48);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new Size(100, 25);
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new Point(430, 48);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(100, 25);
            this.btnGuardar.Text = "Guardar BD";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new Point(50, 270);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new Size(150, 15);
            this.lblEstado.Text = "Estado: Esperando acción...";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(650, 350);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblEstado);
            this.Name = "Form1";
            this.Text = "🧮 Serie Fibonacci + Oracle 19C";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
