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
        // realizeta tab funkcija 
        private void OpenFormInTab(Form childForm, string tabTitle)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Text == tabTitle)
                {
                    // atgriez tab
                    tabControl1.SelectTab(tab);
                    return;
                }
            }

            TabPage newTab = new TabPage();
            newTab.Text = tabTitle;
            newTab.Name = "tab_" + tabTitle; // pieskir nosaukumu 
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; // veido pilno lauku
            newTab.Controls.Add(childForm);
            tabControl1.TabPages.Add(newTab);
            childForm.Show();
            tabControl1.SelectedTab = newTab;
        }
        private void valstisToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            OpenFormInTab(new FormCountries(), "Valstis");
        }

        private void tēmasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInTab(new FormThemes(), "Tēmas");
        }

        private void markiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInTab(new FormStamps(), "Postmarki");
        }
        private void kolekcionariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInTab(new FormCollectors(), "Kolekcionāri");
        }

        private void kolekcijuPārvaldībaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInTab(new FormCollectionManagment(), "Kolekciju pārvaldība");
        }

        private void logiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kolekcijasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFormInTab(new FormCollectionViews(), "Kolekcijas");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void aizvērtAktīvoCilniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 0)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
