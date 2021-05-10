using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace aspnet_mysql
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(config.ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    cmd.CommandText = "select * from `member` order by name;";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    conn.Close();
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(@"
<table>
<tr>
<th></th>
<th>ID</th>
<th>Code</th>
<th>Name</th>
<th>Phone</th>
<th>Gender</th>
</tr>
");

            if(dt.Rows.Count==0)
            {
                sb.Append("<tr><td colspan='6'>No data</td></tr>");
            }
            else
            { 
                foreach(DataRow dr in dt.Rows)
                {
                    string gender = "";
                    string genderid = dr["gender"] + "";

                    switch(genderid)
                    {
                        case "1":
                            gender = "Male";
                            break;
                        case "2":
                            gender = "Female";
                            break;
                    }

                    sb.Append($@"
<tr>
<td><a href='MemberEdit.aspx?id={dr["id"]}'>Edit</a></td>
<td>{dr["id"]}</td>
<td>{dr["code"]}</td>
<td>{dr["name"]}</td>
<td>{dr["phone"]}</td>
<td>{gender}</td>
</tr>
");
                }
            }

            sb.Append("</table>");

            ph1.Controls.Add(new LiteralControl(sb.ToString()));
        }
    }
}