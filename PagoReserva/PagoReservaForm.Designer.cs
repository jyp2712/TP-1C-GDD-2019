namespace FrbaCrucero.PagoReserva
{
    partial class PagoReservaForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.btnOrigen = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtNombreCrucero = new System.Windows.Forms.TextBox();
            this.txtCabina = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDestino = new System.Windows.Forms.Button();
            this.btnCrucero = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtModeloCrucero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMarcaCrucero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpRegreso = new System.Windows.Forms.DateTimePicker();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnReservarYPagar = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            this.pasajesUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboTipoCabina = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pasajesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Origen:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Destino:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha de salida:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha de regreso:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nombre:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Numero:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(116, 13);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(198, 20);
            this.txtOrigen.TabIndex = 8;
            this.txtOrigen.TextChanged += new System.EventHandler(this.onTxtChanged);
            // 
            // btnOrigen
            // 
            this.btnOrigen.Location = new System.Drawing.Point(322, 10);
            this.btnOrigen.Name = "btnOrigen";
            this.btnOrigen.Size = new System.Drawing.Size(75, 23);
            this.btnOrigen.TabIndex = 9;
            this.btnOrigen.Text = "Seleccionar";
            this.btnOrigen.UseVisualStyleBackColor = true;
            this.btnOrigen.Click += new System.EventHandler(this.btnOrigen_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(116, 39);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(198, 20);
            this.txtDestino.TabIndex = 10;
            this.txtDestino.TextChanged += new System.EventHandler(this.onTxtChanged);
            // 
            // txtNombreCrucero
            // 
            this.txtNombreCrucero.Location = new System.Drawing.Point(116, 13);
            this.txtNombreCrucero.Name = "txtNombreCrucero";
            this.txtNombreCrucero.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCrucero.TabIndex = 13;
            // 
            // txtCabina
            // 
            this.txtCabina.Location = new System.Drawing.Point(66, 13);
            this.txtCabina.Name = "txtCabina";
            this.txtCabina.Size = new System.Drawing.Size(100, 20);
            this.txtCabina.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cantidad de pasajes:";
            // 
            // btnDestino
            // 
            this.btnDestino.Location = new System.Drawing.Point(322, 37);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(75, 23);
            this.btnDestino.TabIndex = 17;
            this.btnDestino.Text = "Seleccionar";
            this.btnDestino.UseVisualStyleBackColor = true;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // btnCrucero
            // 
            this.btnCrucero.Location = new System.Drawing.Point(140, 277);
            this.btnCrucero.Name = "btnCrucero";
            this.btnCrucero.Size = new System.Drawing.Size(100, 23);
            this.btnCrucero.TabIndex = 20;
            this.btnCrucero.Text = "Seleccionar";
            this.btnCrucero.UseVisualStyleBackColor = true;
            this.btnCrucero.Click += new System.EventHandler(this.btnCrucero_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtModeloCrucero);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtMarcaCrucero);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNombreCrucero);
            this.groupBox1.Location = new System.Drawing.Point(24, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 93);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crucero";
            // 
            // txtModeloCrucero
            // 
            this.txtModeloCrucero.Location = new System.Drawing.Point(116, 65);
            this.txtModeloCrucero.Name = "txtModeloCrucero";
            this.txtModeloCrucero.Size = new System.Drawing.Size(100, 20);
            this.txtModeloCrucero.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Modelo:";
            // 
            // txtMarcaCrucero
            // 
            this.txtMarcaCrucero.Location = new System.Drawing.Point(116, 39);
            this.txtMarcaCrucero.Name = "txtMarcaCrucero";
            this.txtMarcaCrucero.Size = new System.Drawing.Size(100, 20);
            this.txtMarcaCrucero.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Marca:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pasajesUpDown);
            this.groupBox2.Controls.Add(this.dtpRegreso);
            this.groupBox2.Controls.Add(this.dtpSalida);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnDestino);
            this.groupBox2.Controls.Add(this.txtOrigen);
            this.groupBox2.Controls.Add(this.btnOrigen);
            this.groupBox2.Controls.Add(this.txtDestino);
            this.groupBox2.Location = new System.Drawing.Point(24, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 152);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Viaje";
            // 
            // dtpRegreso
            // 
            this.dtpRegreso.Location = new System.Drawing.Point(116, 93);
            this.dtpRegreso.Name = "dtpRegreso";
            this.dtpRegreso.Size = new System.Drawing.Size(200, 20);
            this.dtpRegreso.TabIndex = 21;
            // 
            // dtpSalida
            // 
            this.dtpSalida.Location = new System.Drawing.Point(116, 67);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(200, 20);
            this.dtpSalida.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Tipo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPiso);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.comboTipoCabina);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtCabina);
            this.groupBox3.Location = new System.Drawing.Point(255, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 93);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cabina";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnReservarYPagar);
            this.groupBox4.Controls.Add(this.btnReservar);
            this.groupBox4.Location = new System.Drawing.Point(24, 306);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(407, 100);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reserva / Pago";
            // 
            // btnReservarYPagar
            // 
            this.btnReservarYPagar.Location = new System.Drawing.Point(289, 28);
            this.btnReservarYPagar.Name = "btnReservarYPagar";
            this.btnReservarYPagar.Size = new System.Drawing.Size(108, 55);
            this.btnReservarYPagar.TabIndex = 1;
            this.btnReservarYPagar.Text = "Confirmar Reserva y Pagar";
            this.btnReservarYPagar.UseVisualStyleBackColor = true;
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(11, 28);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(108, 55);
            this.btnReservar.TabIndex = 0;
            this.btnReservar.Text = "Reservar (Pago diferido)";
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // pasajesUpDown
            // 
            this.pasajesUpDown.Location = new System.Drawing.Point(116, 120);
            this.pasajesUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pasajesUpDown.Name = "pasajesUpDown";
            this.pasajesUpDown.Size = new System.Drawing.Size(120, 20);
            this.pasajesUpDown.TabIndex = 22;
            // 
            // comboTipoCabina
            // 
            this.comboTipoCabina.FormattingEnabled = true;
            this.comboTipoCabina.Location = new System.Drawing.Point(66, 39);
            this.comboTipoCabina.Name = "comboTipoCabina";
            this.comboTipoCabina.Size = new System.Drawing.Size(100, 21);
            this.comboTipoCabina.TabIndex = 25;
            this.comboTipoCabina.SelectedIndexChanged += new System.EventHandler(this.comboTipoCabina_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Piso";
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(66, 65);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(100, 20);
            this.txtPiso.TabIndex = 27;
            // 
            // PagoReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 414);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCrucero);
            this.Name = "PagoReservaForm";
            this.Text = "PagoReservaForm";
            this.Load += new System.EventHandler(this.PagoReservaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pasajesUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Button btnOrigen;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtNombreCrucero;
        private System.Windows.Forms.TextBox txtCabina;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.Button btnCrucero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMarcaCrucero;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtModeloCrucero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpRegreso;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReservarYPagar;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.NumericUpDown pasajesUpDown;
        private System.Windows.Forms.ComboBox comboTipoCabina;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label label11;
    }
}