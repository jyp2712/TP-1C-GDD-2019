namespace FrbaCrucero.AbmRecorrido
{
    partial class ModificacionRecorridoForm
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
            this.comboBoxCiudadPuertoDestino = new System.Windows.Forms.ComboBox();
            this.comboBoxCiudadPuertoOrigen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Modificar = new System.Windows.Forms.Button();
            this.Precio = new System.Windows.Forms.TextBox();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxCiudadPuertoDestino
            // 
            this.comboBoxCiudadPuertoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCiudadPuertoDestino.FormattingEnabled = true;
            this.comboBoxCiudadPuertoDestino.Location = new System.Drawing.Point(163, 151);
            this.comboBoxCiudadPuertoDestino.Name = "comboBoxCiudadPuertoDestino";
            this.comboBoxCiudadPuertoDestino.Size = new System.Drawing.Size(146, 21);
            this.comboBoxCiudadPuertoDestino.TabIndex = 2;
            // 
            // comboBoxCiudadPuertoOrigen
            // 
            this.comboBoxCiudadPuertoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCiudadPuertoOrigen.FormattingEnabled = true;
            this.comboBoxCiudadPuertoOrigen.Location = new System.Drawing.Point(163, 103);
            this.comboBoxCiudadPuertoOrigen.Name = "comboBoxCiudadPuertoOrigen";
            this.comboBoxCiudadPuertoOrigen.Size = new System.Drawing.Size(146, 21);
            this.comboBoxCiudadPuertoOrigen.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(41, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Campos de Recorrido";
            // 
            // Modificar
            // 
            this.Modificar.Location = new System.Drawing.Point(251, 249);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(75, 23);
            this.Modificar.TabIndex = 5;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = true;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // Precio
            // 
            this.Precio.Location = new System.Drawing.Point(163, 199);
            this.Precio.Name = "Precio";
            this.Precio.Size = new System.Drawing.Size(146, 20);
            this.Precio.TabIndex = 3;
            this.Precio.TextChanged += new System.EventHandler(this.Precio_TextChanged);
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(163, 59);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(146, 20);
            this.Codigo.TabIndex = 0;
            this.Codigo.TextChanged += new System.EventHandler(this.Codigo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Ciudad - Puerto Destino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ciudad - Puerto Origen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Codigo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModificacionRecorridoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 316);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCiudadPuertoDestino);
            this.Controls.Add(this.comboBoxCiudadPuertoOrigen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.Precio);
            this.Controls.Add(this.Codigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModificacionRecorridoForm";
            this.Text = "ModificacionRecorridoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCiudadPuertoDestino;
        private System.Windows.Forms.ComboBox comboBoxCiudadPuertoOrigen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Modificar;
        private System.Windows.Forms.TextBox Precio;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}