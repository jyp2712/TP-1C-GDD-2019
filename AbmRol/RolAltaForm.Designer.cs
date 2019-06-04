namespace FrbaCrucero.AbmRol
{
    partial class RolAltaForm
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblFuncionalidades = new System.Windows.Forms.Label();
            this.comboFuncionalidades = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.listViewFuncionalidadesSeleccionadas = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(35, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(136, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(214, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblFuncionalidades
            // 
            this.lblFuncionalidades.AutoSize = true;
            this.lblFuncionalidades.Location = new System.Drawing.Point(35, 64);
            this.lblFuncionalidades.Name = "lblFuncionalidades";
            this.lblFuncionalidades.Size = new System.Drawing.Size(87, 13);
            this.lblFuncionalidades.TabIndex = 2;
            this.lblFuncionalidades.Text = "Funcionalidades:";
            this.lblFuncionalidades.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboFuncionalidades
            // 
            this.comboFuncionalidades.FormattingEnabled = true;
            this.comboFuncionalidades.Location = new System.Drawing.Point(136, 61);
            this.comboFuncionalidades.Name = "comboFuncionalidades";
            this.comboFuncionalidades.Size = new System.Drawing.Size(152, 21);
            this.comboFuncionalidades.TabIndex = 3;
            this.comboFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.comboFuncionalidades_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(294, 61);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(56, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(260, 203);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(90, 23);
            this.btnCrear.TabIndex = 8;
            this.btnCrear.Text = "Guardar";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // listViewFuncionalidadesSeleccionadas
            // 
            this.listViewFuncionalidadesSeleccionadas.FullRowSelect = true;
            this.listViewFuncionalidadesSeleccionadas.Location = new System.Drawing.Point(38, 90);
            this.listViewFuncionalidadesSeleccionadas.Name = "listViewFuncionalidadesSeleccionadas";
            this.listViewFuncionalidadesSeleccionadas.Size = new System.Drawing.Size(312, 97);
            this.listViewFuncionalidadesSeleccionadas.TabIndex = 9;
            this.listViewFuncionalidadesSeleccionadas.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Quitar seleccion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RolAltaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 240);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewFuncionalidadesSeleccionadas);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.comboFuncionalidades);
            this.Controls.Add(this.lblFuncionalidades);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "RolAltaForm";
            this.Text = "RolAltaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblFuncionalidades;
        private System.Windows.Forms.ComboBox comboFuncionalidades;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.ListView listViewFuncionalidadesSeleccionadas;
        private System.Windows.Forms.Button button1;
    }
}