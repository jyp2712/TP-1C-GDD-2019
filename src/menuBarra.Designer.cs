namespace FrbaCrucero
{
    partial class menuBarra
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generarViaje = new System.Windows.Forms.ToolStripTextBox();
            this.compra_reserva = new System.Windows.Forms.ToolStripTextBox();
            this.abm = new System.Windows.Forms.ToolStripMenuItem();
            this.abmRol = new System.Windows.Forms.ToolStripTextBox();
            this.abmRecorrido = new System.Windows.Forms.ToolStripTextBox();
            this.abmCrucero = new System.Windows.Forms.ToolStripTextBox();
            this.pagarReserva = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarViaje,
            this.compra_reserva,
            this.abm,
            this.pagarReserva});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generarViaje
            // 
            this.generarViaje.Name = "generarViaje";
            this.generarViaje.Size = new System.Drawing.Size(120, 31);
            this.generarViaje.Text = "Generar Viaje";
            this.generarViaje.Click += new System.EventHandler(this.generarViaje_Click);
            // 
            // compra_reserva
            // 
            this.compra_reserva.Name = "compra_reserva";
            this.compra_reserva.Size = new System.Drawing.Size(160, 31);
            this.compra_reserva.Text = "Comprar/Reservar";
            this.compra_reserva.Click += new System.EventHandler(this.compra_reserva_Click);
            // 
            // abm
            // 
            this.abm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abmRol,
            this.abmRecorrido,
            this.abmCrucero});
            this.abm.Name = "abm";
            this.abm.Size = new System.Drawing.Size(62, 31);
            this.abm.Text = "ABM";
            // 
            // abmRol
            // 
            this.abmRol.Name = "abmRol";
            this.abmRol.Size = new System.Drawing.Size(40, 31);
            this.abmRol.Text = "Rol";
            this.abmRol.Click += new System.EventHandler(this.toolStripTextBox1_Click_1);
            // 
            // abmRecorrido
            // 
            this.abmRecorrido.Name = "abmRecorrido";
            this.abmRecorrido.Size = new System.Drawing.Size(90, 31);
            this.abmRecorrido.Text = "Recorrido";
            this.abmRecorrido.Click += new System.EventHandler(this.abmRecorrido_Click);
            // 
            // abmCrucero
            // 
            this.abmCrucero.Name = "abmCrucero";
            this.abmCrucero.Size = new System.Drawing.Size(70, 31);
            this.abmCrucero.Text = "Crucero";
            // 
            // pagarReserva
            // 
            this.pagarReserva.Name = "pagarReserva";
            this.pagarReserva.Size = new System.Drawing.Size(130, 31);
            this.pagarReserva.Text = "Pagar Reserva";
            this.pagarReserva.Click += new System.EventHandler(this.pagarReserva_Click);
            // 
            // menuBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 459);
            this.Controls.Add(this.menuStrip1);
            this.Name = "menuBarra";
            this.Text = "FRBACrucero";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox generarViaje;
        private System.Windows.Forms.ToolStripTextBox compra_reserva;
        private System.Windows.Forms.ToolStripMenuItem abm;
        private System.Windows.Forms.ToolStripTextBox abmRol;
        private System.Windows.Forms.ToolStripTextBox abmRecorrido;
        private System.Windows.Forms.ToolStripTextBox abmCrucero;
        private System.Windows.Forms.ToolStripTextBox pagarReserva;

    }
}