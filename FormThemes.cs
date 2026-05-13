using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursa_darbs
{
    public partial class FormThemes : Form
    {
        public string connString = "Host=localhost;Username=postgres;Password=password;Database=postmarks";
        public DataTable dt;
        public NpgsqlDataAdapter adapter;
        public NpgsqlConnection conn;
        public int cur_node;
        public FormThemes()
        {
            InitializeComponent();

            conn = new NpgsqlConnection(connString);

            // giving permission to edit 
            treeView1.LabelEdit = true;

            dt = new DataTable();

            SubLevel(0, null);
        }

        public void SubLevel(int parentid, TreeNode parentNode)
        {
            string parent;
            // what we exactly searching 
            if (parentid == 0)
            {
                parent = "select theme_id, theme_title from themes where parent_theme_id is null";
            }
            else
            {
                parent = "select theme_id, theme_title from themes where parent_theme_id = @parentid";
            }
            // preparing query for sending 
            NpgsqlCommand cmd = new NpgsqlCommand(parent, conn);

            // insert parameter 
            if (parentid != 0)
            {
                cmd.Parameters.AddWithValue("@parentid", parentid);
            }

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (parentid == 0)
            {
                CreateNodes(dt, treeView1.Nodes);
            }
            else
            {
                CreateNodes(dt, parentNode.Nodes);
            }

        }


        public void CreateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["theme_title"].ToString();
                tn.Name = dr["theme_id"].ToString(); // saglabajam id ieks name 

                nodes.Add(tn);

                // recursive: searching child themes for blocks
                SubLevel(Convert.ToInt32(tn.Name), tn);

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name != "")
            {
                // converting id(name text) to y int  
                int y = Convert.ToInt32(e.Node.Name);
                cur_node = y; // then saving in global variable cur_node,
                              //so the programm always knows which theme is now 

                // "give a column description where row theme_id matches with node"
                NpgsqlCommand cmdApraksts = new NpgsqlCommand("select description from themes where theme_id = @id", conn);
                cmdApraksts.Parameters.AddWithValue("@id", y);

                conn.Open();
                object result = cmdApraksts.ExecuteScalar(); // ExecuteScalar() to pull out only description value, not all table 
                conn.Close();

                if (result != null && result != DBNull.Value)
                {
                    textBox1.Text = result.ToString(); // pieņemot, ka tev ir label1 aprakstam
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // ja mezglam jau ir id datubaze
            if (e.Node.Name != "")
            {
                TreeNode tn = new TreeNode();
                tn.Text = "new";
                e.Node.Nodes.Add(tn);

                // uzreiz var uzrediget
                tn.BeginEdit();
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                e.Node.Text = e.Label; // new text for the nodes
            }
            else
            {
                return; // if nothing changed in table, just exit
            }

            // commandbuilder magic for crud
            // download whole themes table 
            // in dtTemp we can edit data
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter("select * from themes", conn);
            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adapt);
            DataTable dtTemp = new DataTable();
            adapt.Fill(dtTemp);

            int t = -1; // variable for saving new found row 
            int i = 0; // row's counter

            foreach (DataRow dr in dtTemp.Rows)
            {
                // parbaudam ja id no bazes sakrit ar mezglu 
                if (dr["theme_id"].ToString() == e.Node.Name)
                {
                    t = i; // atradam
                    break;
                }
                i++;
            }

            // ja atrasts t != -1(tema atrasta baze), parrakstam nosaukumu
            if (t != -1)
            {
                // mainam nosaukumu
                dtTemp.Rows[t]["theme_title"] = e.Node.Text;
            }
            // ja nav atrasts t != -1(tema nav atrasta baze), parrakstam nosaukumu
            else
            {
                DataRow newRow = dtTemp.NewRow(); 
                newRow["theme_title"] = e.Node.Text;

                // definejam kurs ir sis temas parent 
                if (e.Node.Parent != null)
                {
                    // ja mezglam ir vecaks zars, nemam id 
                    newRow["parent_theme_id"] = Convert.ToInt32(e.Node.Parent.Name);
                }
                else
                {
                    newRow["parent_theme_id"] = DBNull.Value;
                }

                dtTemp.Rows.Add(newRow); // add ready row into table
            }

            // save 
            adapt.Update(dtTemp);

            // restart
            if (t == -1)
            {
                treeView1.Nodes.Clear();
                SubLevel(0, null);
            }
        }
        private void FormThemes_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                // asking user "are you sure you want to delete?"
                DialogResult dialogResult = MessageBox.Show("Vai tiešām vēlaties dzēst šo tēmu?", "Dzēšana", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    // if branch has Name, then it has id and she saved at database 
                    if (treeView1.SelectedNode.Name != "")
                    {
                        try
                        {
                            int idToDelete = Convert.ToInt32(treeView1.SelectedNode.Name);

                            // prepare sql query to delete
                            NpgsqlCommand cmdDelete = new NpgsqlCommand("delete from themes where theme_id = @id", conn);
                            cmdDelete.Parameters.AddWithValue("@id", idToDelete);

                            
                            if (conn.State == ConnectionState.Closed) conn.Open();

                            cmdDelete.ExecuteNonQuery(); // отправляем команду в базу

                            // if in database all is ok, remove from screen on table 
                            treeView1.SelectedNode.Remove();
                            textBox1.Text = ""; // clearing description 
                        }
                        catch (PostgresException ex)
                        {

                            MessageBox.Show($"Kļūda dzēšot no datubāzes: {ex.Message}");

                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open) conn.Close();
                        }
                    }
                    else
                    {
                        // if dont have name, just empty record, remove
                        treeView1.SelectedNode.Remove();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lūdzu, izvēlieties tēmu, kuru vēlaties dzēst.");
            }
        }
        // pievienot jaunu tēmu
        private void button2_Click(object sender, EventArgs e)
        {
            TreeNode tn = new TreeNode();
            tn.Text = "new";

            treeView1.Nodes.Add(tn);
            treeView1.SelectedNode = tn;
            tn.BeginEdit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Name != "")
            {
                try
                {
                    int id = Convert.ToInt32(treeView1.SelectedNode.Name);

                    string updateQuery = "update themes set description = @desc where theme_id = @id";
                    NpgsqlCommand cmdUpdate = new NpgsqlCommand(updateQuery, conn);

                    cmdUpdate.Parameters.AddWithValue("@desc", textBox1.Text);
                    cmdUpdate.Parameters.AddWithValue("@id", id);

                    if (conn.State == ConnectionState.Closed) conn.Open();
                    cmdUpdate.ExecuteNonQuery();

                    MessageBox.Show("Apraksts veiksmīgi saglabāts!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Lūdzu, izvēlieties tēmu (noklikšķiniet uz tās), lai saglabātu aprakstu.");
            }
        }
    }
}
