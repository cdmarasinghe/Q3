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
using System.Data.Sql;

namespace Q3
{
    public partial class FilterView : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=c:\\users\\marasinghe\\documents\\visual studio 2013\\Projects\\Q3\\Q3\\Database1.mdf;Integrated Security=True");
        
        public FilterView()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;

            string query = "SELECT * From Person Where Gender='"+comboBox1.SelectedItem.ToString()+"'";

            con.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
               // dataGridView1.Columns["ID"].Visible = true;

            }
            con.Close();
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;

            string query = "SELECT * From Person Where Birth_Date >'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'";

            con.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
               // dataGridView1.Columns["ID"].Visible = true;

            }
            con.Close();
        }
    }
}
