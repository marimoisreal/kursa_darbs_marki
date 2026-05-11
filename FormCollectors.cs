using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursa_darbs
{
    public partial class FormCollectors : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=password;Database=postmarks";
        private DataTable dt;
        private NpgsqlDataAdapter adapter;
        private BindingSource bs;
        public FormCollectors()
        {
            InitializeComponent();
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                // load data for textbox 
                string queryCountries = "select country_id, country_name from countries";
                NpgsqlDataAdapter adapterCountries = new NpgsqlDataAdapter(queryCountries, conn);
                DataTable dtCountries = new DataTable();
                adapterCountries.Fill(dtCountries);

                string selectQuery = "select collector_id, name, surname, age, phone, email, country_id from collectors";

                adapter = new NpgsqlDataAdapter(selectQuery, conn);
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(adapter);

                dt = new DataTable();
                adapter.Fill(dt);
                // bs to make datatable more smart, exposing at cursor
                bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;

                dataGridView1.Columns["collector_id"].Visible = false;
                dataGridView1.Columns["name"].HeaderText = "Vārds";
                dataGridView1.Columns["surname"].HeaderText = "Uzvārds";
                dataGridView1.Columns["age"].HeaderText = "Vecums";
                dataGridView1.Columns["phone"].HeaderText = "Telefona numurs";
                dataGridView1.Columns["email"].HeaderText = "E-pasts";

                dataGridView1.Columns["country_id"].Visible = false;

                DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
                cb.Name = "Valstis";
                cb.HeaderText = "Valsts";
                cb.DataSource = dtCountries;
                cb.DisplayMember = "country_name";
                cb.ValueMember = "country_id";
                cb.DataPropertyName = "country_id";
                dataGridView1.Columns.Add(cb);

                // cosmetic
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormStamps_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
