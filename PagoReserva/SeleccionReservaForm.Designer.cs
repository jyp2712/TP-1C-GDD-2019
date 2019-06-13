namespace FrbaCrucero.PagoReserva
{
    partial class SeleccionReservaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdReserva = new System.Windows.Forms.TextBox();
            this.btnIngresarAlPago = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id de reserva:";
            // 
            // txtIdReserva
            // 
            this.txtIdReserva.Location = new System.Drawing.Point(136, 29);
            this.txtIdReserva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdReserva.MaxLength = 8;
            this.txtIdReserva.Name = "txtIdReserva";
            this.txtIdReserva.Size = new System.Drawing.Size(148, 26);
            this.txtIdReserva.TabIndex = 1;
            this.txtIdReserva.Text = "53930108";
            this.txtIdReserva.TextChanged += new System.EventHandler(this.txtIdReserva_TextChanged);
            // 
            // btnIngresarAlPago
            // 
            this.btnIngresarAlPago.Location = new System.Drawing.Point(87, 88);
            this.btnIngresarAlPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIngresarAlPago.Name = "btnIngresarAlPago";
            this.btnIngresarAlPago.Size = new System.Drawing.Size(148, 38);
            this.btnIngresarAlPago.TabIndex = 2;
            this.btnIngresarAlPago.Text = "Ingresar al Pago";
            this.btnIngresarAlPago.UseVisualStyleBackColor = true;
            this.btnIngresarAlPago.Click += new System.EventHandler(this.btnIngresarAlPago_Click);
            // 
            // SeleccionReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 145);
            this.Controls.Add(this.btnIngresarAlPago);
            this.Controls.Add(this.txtIdReserva);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SeleccionReservaForm";
            this.Text = "Pago de Reserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdReserva;
        private System.Windows.Forms.Button btnIngresarAlPago;
    }
}