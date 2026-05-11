using System;
using System.Windows.Forms;

namespace kursa_darbs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void valstisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm.GetType() == typeof(FormCountries))
                {
                    openForm.Activate();
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    return;
                }
            }
            FormCountries stampsForm = new FormCountries();
            stampsForm.MdiParent = this;
            stampsForm.Show();
        }

        private void tēmasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm.GetType() == typeof(FormThemes))
                {
                    openForm.Activate();
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    return;
                }
            }
            FormThemes stampsForm = new FormThemes();
            stampsForm.MdiParent = this;
            stampsForm.Show();
        }

        private void markiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm.GetType() == typeof(FormStamps))
                {
                    openForm.Activate();
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    return;
                }
            }
            FormStamps stampsForm = new FormStamps();
            stampsForm.MdiParent = this;
            stampsForm.Show();
        }
        private void kolekcionariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm.GetType() == typeof(FormCollectors))
                {
                    openForm.Activate();
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    return;
                }
            }
            FormCollectors stampsForm = new FormCollectors();
            stampsForm.MdiParent = this;
            stampsForm.Show();
        }

        private void kolekcijuPārvaldībaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in this.MdiChildren)
            {
                if (openForm.GetType() == typeof(FormCollectionManagment))
                {
                    openForm.Activate();
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                    }
                    return;
                }
            }
            FormCollectionManagment stampsForm = new FormCollectionManagment();
            stampsForm.MdiParent = this;
            stampsForm.Show();
        }

        private void logiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
