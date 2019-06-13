namespace FrbaCrucero.AbmCrucero
{
    partial class CruceroModificacion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboServicio = new System.Windows.Forms.ComboBox();
            this.Seleccionar = new System.Windows.Forms.Button();
            this.Marca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CodigoContiene = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewCruceros = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCruceros)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboServicio);
            this.groupBox1.Controls.Add(this.Seleccionar);
            this.groupBox1.Controls.Add(this.Marca);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CodigoContiene);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.Codigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 114);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // comboServicio
            // 
            this.comboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServicio.FormattingEnabled = true;
            this.comboServicio.Location = new System.Drawing.Point(420, 16);
            this.comboServicio.Name = "comboServicio";
            this.comboServicio.Size = new System.Drawing.Size(150, 21);
            this.comboServicio.TabIndex = 2;
            // 
            // Seleccionar
            // 
            this.Seleccionar.Location = new System.Drawing.Point(495, 43);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(75, 23);
            this.Seleccionar.TabIndex = 4;
            this.Seleccionar.Text = "Seleccionar";
            this.Seleccionar.UseVisualStyleBackColor = true;
            this.Seleccionar.Click += new System.EventHandler(this.Seleccionar_Click);
            // 
            // Marca
            // 
            this.Marca.Enabled = false;
            this.Marca.Location = new System.Drawing.Point(420, 45);
            this.Marca.Name = "Marca";
            this.Marca.Size = new System.Drawing.Size(53, 20);
            this.Marca.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Marca";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Servicio";
            // 
            // CodigoContiene
            // 
            this.CodigoContiene.Location = new System.Drawing.Point(97, 46);
            this.CodigoContiene.Name = "CodigoContiene";
            this.CodigoContiene.Size = new System.Drawing.Size(113, 20);
            this.CodigoContiene.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Codigo contiene";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(509, 77);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(10, 77);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(60, 17);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(150, 20);
            this.Codigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // dataGridViewCruceros
            // 
            this.dataGridViewCruceros.AllowUserToAddRows = false;
            this.dataGridViewCruceros.AllowUserToDeleteRows = false;
            this.dataGridViewCruceros.AllowUserToResizeColumns = false;
            this.dataGridViewCruceros.AllowUserToResizeRows = false;
            this.dataGridViewCruceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCruceros.Location = new System.Drawing.Point(23, 159);
            this.dataGridViewCruceros.MultiSelect = false;
            this.dataGridViewCruceros.Name = "dataGridViewCruceros";
            this.dataGridViewCruceros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCruceros.Size = new System.Drawing.Size(590, 191);
            this.dataGridViewCruceros.TabIndex = 0;
            this.dataGridViewCruceros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCruceros_CellContentClick);
            // 
            // CruceroModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 382);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewCruceros);
            this.Name = "CruceroModificacion";
            this.Text = "CruceroModificacion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCruceros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CodigoContiene;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCruceros;
        private System.Windows.Forms.ComboBox comboServicio;
        private System.Windows.Forms.Button Seleccionar;
        private System.Windows.Forms.TextBox Marca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}