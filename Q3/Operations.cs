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
    public partial class Operations : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=c:\\users\\marasinghe\\documents\\visual studio 2013\\Projects\\Q3\\Q3\\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;
        connection cn = new connection();
        public Operations()
        {
            InitializeComponent();
        }

        private void Operations_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Person' table. You can move, or remove it, as needed.
            dataGridView1.Update();
            dataGridView1.Refresh();
            this.personTableAdapter.Fill(this.database1DataSet1.Person);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtFname.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtLname.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cmbGender.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("UPDATE Person SET First_Name=@fName, Last_Name=@lName, Gender=@gender, Birth_Date=@dob WHERE ID=@id", con);

                cmd.Parameters.Add("@id", txtId.Text);
                cmd.Parameters.Add("@fName", txtFname.Text);
                cmd.Parameters.Add("@lName", txtLname.Text);
                cmd.Parameters.Add("@gender", cmbGender.SelectedText.ToString());
                cmd.Parameters.Add("@dob", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                cmd.ExecuteNonQuery();
                con.Close();


                /*string query = "UPDATE Person SET First_Name='" + txtFname.Text + "', Last_Name='" + txtLname.Text + "', Gender='" + cmbGender.SelectedItem.ToString() + "', Birth_Date='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' WHERE ID='" + txtId.Text + "'";
                cn.operation(query);*/
                MessageBox.Show("Successfully Updated");
                DBView ob = new DBView();
                this.Close();
                ob.Show();
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                //con.Open();

                //cmd = new SqlCommand("DELETE FROM Person WHERE ID=@id", con);
                //cmd.Parameters.Add("@id", txtId.Text);
                //cmd.ExecuteNonQuery();

                //MessageBox.Show("Successfully Deleted");
                //con.Close();

                string query = "DELETE FROM Person WHERE ID='" + txtId.Text + "'";
                cn.operation(query);
                MessageBox.Show("Successfully Deleted");
                DBView ob = new DBView();
                this.Close();
                ob.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterView ob = new FilterView();
            this.Close();
            ob.Show();
        }
    }
}
