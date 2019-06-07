namespace FrbaCrucero.menuBarra
{
    partial class menu
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
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.abm = new System.Windows.Forms.ToolStripMenuItem();
            this.abmCrucero = new System.Windows.Forms.ToolStripTextBox();
            this.abmRol = new System.Windows.Forms.ToolStripTextBox();
            this.abmRecorrido = new System.Windows.Forms.ToolStripTextBox();
            this.compra_reserva = new System.Windows.Forms.ToolStripTextBox();
            this.pagoReserva = new System.Windows.Forms.ToolStripTextBox();
            this.estadistica = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.abm,
            this.compra_reserva,
            this.pagoReserva,
            this.estadistica});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(120, 31);
            this.toolStripTextBox1.Text = "Generar Viaje";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // abm
            // 
            this.abm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abmCrucero,
            this.abmRol,
            this.abmRecorrido});
            this.abm.Name = "abm";
            this.abm.Size = new System.Drawing.Size(62, 31);
            this.abm.Text = "ABM";
            // 
            // abmCrucero
            // 
            this.abmCrucero.Name = "abmCrucero";
            this.abmCrucero.Size = new System.Drawing.Size(100, 31);
            this.abmCrucero.Text = "Crucero";
            this.abmCrucero.Click += new System.EventHandler(this.abmCrucero_Click);
            // 
            // abmRol
            // 
            this.abmRol.Name = "abmRol";
            this.abmRol.Size = new System.Drawing.Size(100, 31);
            this.abmRol.Text = "Rol";
            this.abmRol.Click += new System.EventHandler(this.abmRol_Click);
            // 
            // abmRecorrido
            // 
            this.abmRecorrido.Name = "abmRecorrido";
            this.abmRecorrido.Size = new System.Drawing.Size(100, 31);
            this.abmRecorrido.Text = "Recorrido";
            this.abmRecorrido.Click += new System.EventHandler(this.abmRecorrido_Click);
            // 
            // compra_reserva
            // 
            this.compra_reserva.Name = "compra_reserva";
            this.compra_reserva.Size = new System.Drawing.Size(150, 31);
            this.compra_reserva.Text = "Compra/Reserva";
            this.compra_reserva.Click += new System.EventHandler(this.toolStripTextBox2_Click);
            // 
            // pagoReserva
            // 
            this.pagoReserva.Name = "pagoReserva";
            this.pagoReserva.Size = new System.Drawing.Size(120, 31);
            this.pagoReserva.Text = "Pago Reserva";
            this.pagoReserva.Click += new System.EventHandler(this.pagoReserva_Click);
            // 
            // estadistica
            // 
            this.estadistica.Name = "estadistica";
            this.estadistica.Size = new System.Drawing.Size(160, 31);
            this.estadistica.Text = "Listado Estadistico";
            this.estadistica.Click += new System.EventHandler(this.estadistica_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 426);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "menu";
            this.Text = "FRBACrucero";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem abm;
        private System.Windows.Forms.ToolStripTextBox abmCrucero;
        private System.Windows.Forms.ToolStripTextBox abmRol;
        private System.Windows.Forms.ToolStripTextBox abmRecorrido;
        private System.Windows.Forms.ToolStripTextBox compra_reserva;
        private System.Windows.Forms.ToolStripTextBox pagoReserva;
        private System.Windows.Forms.ToolStripTextBox estadistica;
    }
}