namespace FrbaCrucero.AbmCrucero
{
    partial class CruceroBajaForm
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
            this.Cancelar = new System.Windows.Forms.Button();
            this.Seleccionar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCabinas = new System.Windows.Forms.TextBox();
            this.comboServicio = new System.Windows.Forms.ComboBox();
            this.comboMarcas = new System.Windows.Forms.ComboBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.Eliminar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMotivo = new System.Windows.Forms.ComboBox();
            this.Motivo = new System.Windows.Forms.Label();
            this.dateTimePickerBaja = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(22, 360);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 41;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Seleccionar
            // 
            this.Seleccionar.Location = new System.Drawing.Point(239, 237);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.Seleccionar.TabIndex = 40;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(155, 54);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(159, 20);
            this.txtCodigo.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Codigo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(40, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Campos de Crucero";
            // 
            // txtCabinas
            // 
            this.txtCabinas.Enabled = false;
            this.txtCabinas.Location = new System.Drawing.Point(155, 239);
            this.txtCabinas.Name = "txtCabinas";
            this.txtCabinas.Size = new System.Drawing.Size(65, 20);
            this.txtCabinas.TabIndex = 36;
            // 
            // comboServicio
            // 
            this.comboServicio.FormattingEnabled = true;
            this.comboServicio.Location = new System.Drawing.Point(155, 200);
            this.comboServicio.Name = "comboServicio";
            this.comboServicio.Size = new System.Drawing.Size(159, 21);
            this.comboServicio.TabIndex = 35;
            // 
            // comboMarcas
            // 
            this.comboMarcas.FormattingEnabled = true;
            this.comboMarcas.Location = new System.Drawing.Point(155, 161);
            this.comboMarcas.Name = "comboMarcas";
            this.comboMarcas.Size = new System.Drawing.Size(159, 21);
            this.comboMarcas.TabIndex = 34;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(155, 124);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(159, 20);
            this.txtModelo.TabIndex = 33;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(155, 88);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(159, 20);
            this.txtNombre.TabIndex = 32;
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(250, 360);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(75, 23);
            this.Eliminar.TabIndex = 31;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Cantidad de cabinas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Tipo de Servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Modelo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nombre";
            // 
            // comboBoxMotivo
            // 
            this.comboBoxMotivo.FormattingEnabled = true;
            this.comboBoxMotivo.Location = new System.Drawing.Point(155, 275);
            this.comboBoxMotivo.Name = "comboBoxMotivo";
            this.comboBoxMotivo.Size = new System.Drawing.Size(159, 21);
            this.comboBoxMotivo.TabIndex = 43;
            this.comboBoxMotivo.SelectedIndexChanged += new System.EventHandler(this.comboBoxMotivo_SelectedIndexChanged);
            // 
            // Motivo
            // 
            this.Motivo.AutoSize = true;
            this.Motivo.Location = new System.Drawing.Point(31, 278);
            this.Motivo.Name = "Motivo";
            this.Motivo.Size = new System.Drawing.Size(39, 13);
            this.Motivo.TabIndex = 42;
            this.Motivo.Text = "Motivo";
            // 
            // dateTimePickerBaja
            // 
            this.dateTimePickerBaja.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerBaja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBaja.Location = new System.Drawing.Point(155, 317);
            this.dateTimePickerBaja.MinDate = new System.DateTime(2019, 6, 9, 0, 0, 0, 0);
            this.dateTimePickerBaja.Name = "dateTimePickerBaja";
            this.dateTimePickerBaja.Size = new System.Drawing.Size(159, 20);
            this.dateTimePickerBaja.TabIndex = 44;
            this.dateTimePickerBaja.Value = new System.DateTime(2019, 6, 9, 0, 0, 0, 0);
            this.dateTimePickerBaja.ValueChanged += new System.EventHandler(this.dateTimePickerBaja_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Fecha de Reinicio ";
            // 
            // CruceroBajaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 395);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerBaja);
            this.Controls.Add(this.comboBoxMotivo);
            this.Controls.Add(this.Motivo);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Seleccionar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCabinas);
            this.Controls.Add(this.comboServicio);
            this.Controls.Add(this.comboMarcas);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "CruceroBajaForm";
            this.Text = "CruceroBajaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Seleccionar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCabinas;
        private System.Windows.Forms.ComboBox comboServicio;
        private System.Windows.Forms.ComboBox comboMarcas;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMotivo;
        private System.Windows.Forms.Label Motivo;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaja;
        private System.Windows.Forms.Label label4;
    }
}