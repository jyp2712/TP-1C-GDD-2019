namespace FrbaCrucero
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIngresarAdministrador = new System.Windows.Forms.Button();
            this.btnIngresarCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIngresarAdministrador
            // 
            this.btnIngresarAdministrador.Location = new System.Drawing.Point(53, 150);
            this.btnIngresarAdministrador.Name = "btnIngresarAdministrador";
            this.btnIngresarAdministrador.Size = new System.Drawing.Size(182, 58);
            this.btnIngresarAdministrador.TabIndex = 1;
            this.btnIngresarAdministrador.Text = "Ingresar como administrador";
            this.btnIngresarAdministrador.UseVisualStyleBackColor = true;
            this.btnIngresarAdministrador.Click += new System.EventHandler(this.btnIngresarAdministrador_Click);
            // 
            // btnIngresarCliente
            // 
            this.btnIngresarCliente.Location = new System.Drawing.Point(53, 44);
            this.btnIngresarCliente.Name = "btnIngresarCliente";
            this.btnIngresarCliente.Size = new System.Drawing.Size(182, 58);
            this.btnIngresarCliente.TabIndex = 0;
            this.btnIngresarCliente.Text = "Ingresar como cliente";
            this.btnIngresarCliente.UseVisualStyleBackColor = true;
            this.btnIngresarCliente.Click += new System.EventHandler(this.btnIngresarCliente_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnIngresarCliente);
            this.Controls.Add(this.btnIngresarAdministrador);
            this.Name = "MainForm";
            this.Text = "FrbaCrucero";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIngresarAdministrador;
        private System.Windows.Forms.Button btnIngresarCliente;

    }
}

