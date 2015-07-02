using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Q3
{
    public partial class Form1 : Form
    {
        //string cons = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=c:\\users\\marasinghe\\documents\\visual studio 2013\\Projects\\Q3\\Q3\\Database1.mdf;Integrated Security=True";
        //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=c:\\users\\marasinghe\\documents\\visual studio 2013\\Projects\\Q3\\Q3\\Database1.mdf;Integrated Security=True");
        //SqlCommand cmd;

        connection ob = new connection();  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string fname = txtFname.Text;
            string lname = txtLname.Text;
            string gender = cmbGender.SelectedItem.ToString();
            string dob = txtYear.Text + "-" + txtMonth.Text + "-" + txtDate.Text;*/

            if((txtFname.Text!="" && txtLname.Text!="") && (cmbGender.Text!="" && dateTimePicker1.Value.ToString("MM/dd/yyyy")!=""))
            {
               //con.Open();
               
               /*cmd = new SqlCommand("INSERT INTO Person VALUES(@fname,@lname,@gender,@dob)",con);
               cmd.Parameters.Add("@fname", txtFname.Text);
               cmd.Parameters.Add("@lname", txtLname.Text);
               cmd.Parameters.Add("@gender", cmbGender.SelectedItem.ToString());
               cmd.Parameters.Add("@dob", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
               cmd.ExecuteNonQuery();*/
               
               string query = "INSERT INTO Person VALUES('" + txtFname.Text + "','" + txtLname.Text + "','" + cmbGender.SelectedItem.ToString() + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "')";
               MessageBox.Show("Data Successfully Inserted");
               ob.operation(query);
               
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBView ob = new DBView();
            this.Close();
            ob.Visible = true;
        }
    }
}
