using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace kursa_darbs
{
    public partial class FormCountries : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=password;Database=postmarks";
        private DataTable dt;
        private NpgsqlDataAdapter adapter;
        private BindingSource bs;
        public FormCountries()
        {
            InitializeComponent();
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                string selectQuery = "select country_id, country_name from countries";

                adapter = new NpgsqlDataAdapter(selectQuery, conn);
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(adapter);

                dt = new DataTable();
                adapter.Fill(dt);
                // bs to make datatable more smart, exposing at cursor
                bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;

                dataGridView1.Columns["country_id"].Visible = false;
                dataGridView1.Columns["country_name"].HeaderText = "Valsts Nosaukums";
                // cosmetic
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCountries_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // EndEdit strict way to say DataTable put rows at the back, saving last changes 
                dataGridView1.EndEdit();
                bs.EndEdit();
                adapter.Update(dt);
                MessageBox.Show("Dati veiksmīgi saglabāti!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // if row is not null it could be deleted
            if (bs.Current != null)
            {
                bs.RemoveCurrent();
            } 
        }
    }
}
