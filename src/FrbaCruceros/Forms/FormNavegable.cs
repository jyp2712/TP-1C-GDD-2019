using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCrucero.DB;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class FormNavegable : Form
    {
        private FormNavegable owner;
        public delegate void AfterClose();
        public delegate void ExceptionableTask();
        private AfterClose afterCloseAction;
        protected string successMessage = "La operación se realizó correctamente";
        protected string errorMessage = "";

        public new FormNavegable Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        public FormNavegable()
        {
            this.owner = null;
            this.afterCloseAction = DoNothing;
            this.FormClosing += CloseNavegable;
        }

        public FormNavegable(FormNavegable owner)
            : this()
        {
            this.owner = owner;
        }

        public FormNavegable(FormNavegable owner, AfterClose afterCloseAction)
            : this(owner)
        {
            this.afterCloseAction = afterCloseAction;
        }

        private void CloseNavegable(object sender, FormClosingEventArgs e)
        {
            afterCloseAction();
        }

        public void Open()
        {
            this.Show();
        }

        public void OpenDialogue()
        {
            this.ShowDialog();
        }

        public void StandaloneOpen()
        {
            this.Show();
            owner.Hide();
            afterCloseAction = ReopenOwner;
        }

        public void FinalStandaloneOpen()
        {
            this.Show();
            owner.Hide();
            afterCloseAction = CloseOwner;
        }

        public void CloseOwner()
        {
            owner.Close();
        }

        public void ReopenOwner()
        {
            owner.Show();
        }

        public void DoNothing()
        {
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "FormNavegable";
            this.Load += new System.EventHandler(this.FormNavegable_Load);
            this.ResumeLayout(false);

        }

        private void FormNavegable_Load(object sender, EventArgs e)
        {
        }

        protected void Execute(ExceptionableTask task)
        {
            try
            {
                task();
            }
            catch (ExcepcionFrbaCrucero e)
            {
                MessageBox.Show(e.Message, "Error");
                errorMessage += "  ";
            }

        }

        protected virtual void ExcecuteAndShow(ExceptionableTask task)
        {
            try
            {
                task();
                MessageBox.Show(successMessage);
                Close();
            }
            catch (ExcepcionFrbaCrucero e)
            {
                MessageBox.Show(e.Message, "Error");
                errorMessage += "  ";
            }
        }

    }
}
