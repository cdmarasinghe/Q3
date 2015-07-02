using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Q3
{
    public partial class DBView : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=c:\\users\\marasinghe\\documents\\visual studio 2013\\Projects\\Q3\\Q3\\Database1.mdf;Integrated Security=True");

        public DBView()
        {
            InitializeComponent();
        }

        private void DBView_Load(object sender, EventArgs e)
        {
            dataGridView1.Update();
            dataGridView1.Refresh();
            /* try
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("CREATE TABLE Person(ID int IDENTITY(1,1) PRIMARY KEY,First_Name char(50),Last_Name char(50),Gender char(10),Birth_Date datetime);", con))
                    command.ExecuteNonQuery();

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            */
            // TODO: This line of code loads data into the 'database1DataSet.Person' table. You can move, or remove it, as needed.
            this.personTableAdapter.Fill(this.database1DataSet.Person);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Visible = true;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Operations ob = new Operations();
            ob.Visible = true;
            this.Hide();
        }
    }
}
