using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Q3
{
    class connection
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=c:\\users\\marasinghe\\documents\\visual studio 2013\\Projects\\Q3\\Q3\\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;

        public void operation(string query)
        {
            con.Open();
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
