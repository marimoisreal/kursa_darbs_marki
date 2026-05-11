using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursa_darbs
{
    public partial class FormCollectionManagment : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=password;Database=postmarks";
        private NpgsqlConnection conn;
        private DataTable cart; // temporary table for records 
        public FormCollectionManagment()
        {
            InitializeComponent();
            conn = new NpgsqlConnection(connString);  
            cart = new DataTable();
            cart.Columns.Add("stamp_id", typeof(int));
            cart.Columns.Add("stamp_name", typeof(string)); 
            cart.Columns.Add("condition", typeof(string));

            dataGridView1.DataSource = cart;
            dataGridView1.Columns["stamp_id"].Visible = false;
        }

        private void FormCollectionManagment_Load(object sender, EventArgs e)
        {
            try
            {
                // fulfill 1. combobox with collectors 
                NpgsqlDataAdapter daCol = new NpgsqlDataAdapter("select collector_id, name || ' ' || surname as full_name from collectors", conn);
                DataTable dtCol = new DataTable();
                daCol.Fill(dtCol);

                comboBox1.DataSource = dtCol;
                comboBox1.DisplayMember = "full_name"; // what user sees
                comboBox1.ValueMember = "collector_id"; // what saves into database 

                // fulfill 2. combobox with postmarks
                NpgsqlDataAdapter daStamp = new NpgsqlDataAdapter("select stamp_id, name from stamps", conn);
                DataTable dtStamp = new DataTable();
                daStamp.Fill(dtStamp);

                comboBox2.DataSource = dtStamp;
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "stamp_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kļūda ielādējot sarakstus: " + ex.Message);
            }
        }
        // mes izvelamies kam pieder(kolekcionaram) kolekcija
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // kolekcijas nisaukums 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // kolekcijas apraksts 
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // markas 
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // condition of postmark 
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        // saivng at "cart"
        private void button1_Click(object sender, EventArgs e)
        {
            // if postmark has chosen
            if (comboBox2.SelectedValue != null)
            {
                DataRow row = cart.NewRow();
                row["stamp_id"] = comboBox2.SelectedValue;
                row["stamp_name"] = comboBox2.Text;
                row["condition"] = textBox3.Text;

                cart.Rows.Add(row);
                textBox3.Text = "";
            }
        }
        // cart
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ( cart.Rows.Count == 0 || textBox1.Text == "")
            {
                MessageBox.Show("Lūdzu, ievadiet nosaukumu un pievienojiet vismaz vienu marku!");
                return;
            }
            if(conn.State == ConnectionState.Closed)
            conn.Open();
            using (NpgsqlTransaction transaction = conn.BeginTransaction()) 
            {
                try
                {
                    // returning collection_id immediately return new fresh collection ID
                    string query = @"insert into collections (collector_id, name, description) values (@c_id, @name, @descr) returning collection_id";
                    NpgsqlCommand cmdCol = new NpgsqlCommand(query, conn, transaction);
                    cmdCol.Parameters.AddWithValue("@c_id", Convert.ToInt32(comboBox1.SelectedValue));
                    cmdCol.Parameters.AddWithValue("@name", textBox1.Text);
                    cmdCol.Parameters.AddWithValue("@desc", textBox2.Text);

                    // getting new collection ID
                    int newColId = Convert.ToInt32(cmdCol.ExecuteScalar());

                    string queryStamps = @"INSERT INTO collections_stamps (collection_id, stamp_id, condition) 
                                       VALUES (@col_id, @st_id, @cond)";

                    foreach (DataRow row in cart.Rows)
                    {
                        NpgsqlCommand cmdSt = new NpgsqlCommand(queryStamps, conn, transaction);
                        cmdSt.Parameters.AddWithValue("@col_id", newColId);         // Тот самый новый ID коллекции
                        cmdSt.Parameters.AddWithValue("@st_id", row["stamp_id"]);   // ID марки из корзины
                        cmdSt.Parameters.AddWithValue("@cond", row["condition"]);   // Состояние из корзины

                        cmdSt.ExecuteNonQuery(); // Отправляем строку в базу
                    }

                    // ШАГ В: Если мы дошли до сюда, значит ошибок не было. Подтверждаем транзакцию!
                    transaction.Commit();

                    MessageBox.Show("Kolekcija veiksmīgi saglabāta!");

                    // Очищаем форму для ввода следующей коллекции
                    textBox1.Text = "";
                    textBox2.Text = "";
                    cart.Rows.Clear();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
        }

    }
}
