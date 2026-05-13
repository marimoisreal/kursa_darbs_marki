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
    public partial class FormCollectionViews : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=password;Database=postmarks";
        private NpgsqlConnection conn;
        public FormCollectionViews()
        {
            InitializeComponent();

            conn = new NpgsqlConnection(connString);
            try
            {
                // sql pakartots pieprasijums, samainot kolonnam nosaukumus 
                string sql = @"select c.collection_id, c.name AS ""Kolekcijas nosaukums"", 
                             cl.name || ' ' || cl.surname AS ""Īpašnieks"", 
                             c.description AS ""Apraksts"" 
                             from collections c
                             join collectors cl on c.collector_id = cl.collector_id";

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["collection_id"].Visible = false; 
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // nemam id no pirmas kolonnas
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["collection_id"].Value);
                LoadStampsInCollection(selectedId);
            }
        }

        private void LoadStampsInCollection(int colId)
        {
            try
            {
                // postmarkas tabulu saistitam ar saistibas tabulu
                string sql = @"select s.name as ""Markas nosaukums"", 
                               cs.condition as ""Stāvoklis"", 
                               cs.added_at_date as ""Pievienošanas datums"", 
                               cs.added_at_time as ""Laiks""
                               from collections_stamps cs
                               join stamps s on cs.stamp_id = s.stamp_id
                               where cs.collection_id = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", colId);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // aizpildam kolonnu ar postmarkiem
                dataGridView2.DataSource = dt;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCollectionViews_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
