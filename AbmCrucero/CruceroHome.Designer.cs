namespace FrbaCrucero.AbmCrucero
{
    partial class CruceroHome
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
            this.button3 = new System.Windows.Forms.Button();
            this.Baja = new System.Windows.Forms.Button();
            this.Alta = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(92, 217);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 60);
            this.button3.TabIndex = 5;
            this.button3.Text = "Modificacion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Baja
            // 
            this.Baja.Location = new System.Drawing.Point(94, 132);
            this.Baja.Name = "Baja";
            this.Baja.Size = new System.Drawing.Size(132, 60);
            this.Baja.TabIndex = 4;
            this.Baja.Text = "Baja";
            this.Baja.UseVisualStyleBackColor = true;
            this.Baja.Click += new System.EventHandler(this.Baja_Click);
            // 
            // Alta
            // 
            this.Alta.Location = new System.Drawing.Point(92, 52);
            this.Alta.Name = "Alta";
            this.Alta.Size = new System.Drawing.Size(132, 60);
            this.Alta.TabIndex = 3;
            this.Alta.Text = "Alta";
            this.Alta.UseVisualStyleBackColor = true;
            this.Alta.Click += new System.EventHandler(this.Alta_Click);
            // 
            // CruceroHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 326);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Baja);
            this.Controls.Add(this.Alta);
            this.Name = "CruceroHome";
            this.Text = "CruceroHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Baja;
        private System.Windows.Forms.Button Alta;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}