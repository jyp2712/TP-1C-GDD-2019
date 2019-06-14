namespace FrbaCrucero.menuBarra
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generarViaje = new System.Windows.Forms.ToolStripMenuItem();
            this.abm = new System.Windows.Forms.ToolStripMenuItem();
            this.abmCrucero = new System.Windows.Forms.ToolStripMenuItem();
            this.abmRol = new System.Windows.Forms.ToolStripMenuItem();
            this.abmRecorrido = new System.Windows.Forms.ToolStripMenuItem();
            this.compra_reserva = new System.Windows.Forms.ToolStripMenuItem();
            this.pagoReserva = new System.Windows.Forms.ToolStripMenuItem();
            this.estadistica = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarViaje,
            this.abm,
            this.compra_reserva,
            this.pagoReserva,
            this.estadistica});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(527, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generarViaje
            // 
            this.generarViaje.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.generarViaje.Name = "generarViaje";
            this.generarViaje.Size = new System.Drawing.Size(88, 22);
            this.generarViaje.Text = "Generar Viaje";
            this.generarViaje.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // abm
            // 
            this.abm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.abm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abmCrucero,
            this.abmRol,
            this.abmRecorrido});
            this.abm.Name = "abm";
            this.abm.Size = new System.Drawing.Size(45, 22);
            this.abm.Text = "ABM";
            // 
            // abmCrucero
            // 
            this.abmCrucero.Name = "abmCrucero";
            this.abmCrucero.Size = new System.Drawing.Size(125, 22);
            this.abmCrucero.Text = "Crucero";
            this.abmCrucero.Click += new System.EventHandler(this.abmCrucero_Click);
            // 
            // abmRol
            // 
            this.abmRol.Name = "abmRol";
            this.abmRol.Size = new System.Drawing.Size(125, 22);
            this.abmRol.Text = "Rol";
            this.abmRol.Click += new System.EventHandler(this.abmRol_Click);
            // 
            // abmRecorrido
            // 
            this.abmRecorrido.Name = "abmRecorrido";
            this.abmRecorrido.Size = new System.Drawing.Size(125, 22);
            this.abmRecorrido.Text = "Recorrido";
            this.abmRecorrido.Click += new System.EventHandler(this.abmRecorrido_Click);
            // 
            // compra_reserva
            // 
            this.compra_reserva.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compra_reserva.Name = "compra_reserva";
            this.compra_reserva.Size = new System.Drawing.Size(107, 22);
            this.compra_reserva.Text = "Compra/Reserva";
            this.compra_reserva.Click += new System.EventHandler(this.toolStripTextBox2_Click);
            // 
            // pagoReserva
            // 
            this.pagoReserva.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pagoReserva.Name = "pagoReserva";
            this.pagoReserva.Size = new System.Drawing.Size(89, 22);
            this.pagoReserva.Text = "Pago Reserva";
            this.pagoReserva.Click += new System.EventHandler(this.pagoReserva_Click);
            // 
            // estadistica
            // 
            this.estadistica.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.estadistica.Name = "estadistica";
            this.estadistica.Size = new System.Drawing.Size(116, 22);
            this.estadistica.Text = "Listado Estadistico";
            this.estadistica.Click += new System.EventHandler(this.estadistica_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Captura.PNG");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::FrbaCrucero.Properties.Resources.Captura;
            this.pictureBox1.Location = new System.Drawing.Point(28, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(470, 205);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 277);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Menu";
            this.Text = "FRBACrucero";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abm;
        private System.Windows.Forms.ToolStripMenuItem estadistica;
        private System.Windows.Forms.ToolStripMenuItem generarViaje;
        private System.Windows.Forms.ToolStripMenuItem compra_reserva;
        private System.Windows.Forms.ToolStripMenuItem pagoReserva;
        private System.Windows.Forms.ToolStripMenuItem abmCrucero;
        private System.Windows.Forms.ToolStripMenuItem abmRol;
        private System.Windows.Forms.ToolStripMenuItem abmRecorrido;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}