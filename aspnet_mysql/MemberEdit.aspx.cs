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
    public partial class MemberEdit : System.Web.UI.Page
    {
        int id
        {
            get
            {
                int i = 0;
                int.TryParse(ViewState["id"] + "", out i);
                return i;
            }
            set
            {
                ViewState["id"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string istr = Request.QueryString["id"] + "";
                if (istr.Length > 0)
                {
                    int i = 0;
                    if (int.TryParse(istr, out i))
                    {
                        id = i;
                    }
                }

                LoadData();
            }
        }

        void LoadData()
        {
            if (id == 0)
            {
                lbId.Text = "[new data]";
                return;
            }

            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(config.ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    cmd.CommandText = $"select * from member where id={id} limit 0,1;";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    conn.Close();
                }
            }

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                lbId.Text = dr["id"] + "";
                txtName.Text = dr["name"] + "";
                txtCode.Text = dr["code"] + "";
                txtPhone.Text = dr["phone"] + "";

                try
                {
                    dropGender.SelectedValue = dr["gender"] + "";
                }
                catch { }
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (txtCode.Text.Trim().Length == 0)
            {
                sb.Append("Code cannot be blank.<br />");
            }

            if(txtName.Text.Trim().Length==0)
            {
                sb.Append("Name cannot be blank.<br />");
            }

            if(txtPhone.Text.Trim().Length==0)
            {
                sb.Append("Phone cannot be blank.<br />");
            }

            if(dropGender.SelectedIndex==0)
            {
                sb.Append("Please select gender.<br />");
            }

            if(sb.Length>0)
            {
                ph1.Controls.Add(new LiteralControl($"<span style='color: red;'>{sb}</span>"));
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(config.ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    if (id == 0)
                    {
                        cmd.CommandText = "insert into `member`(code,name,phone,gender)values(@code,@name,@phone,@gender);";
                    }
                    else
                    {
                        cmd.CommandText = "update `member` set code=@code, name=@name, phone=@phone, gender=@gender where id=@id limit 1;";
                        cmd.Parameters.AddWithValue("@id", id);
                    }

                    cmd.Parameters.AddWithValue("@code", txtCode.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@gender", dropGender.SelectedValue);

                    cmd.ExecuteNonQuery();

                    if (id == 0)
                    {
                        id = (int)cmd.LastInsertedId;
                    }

                    conn.Close();
                }
            }

            ph1.Controls.Add(new LiteralControl("<span style='color: darkgreen;'>Data saved.</span>"));

            LoadData();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            if (id == 0)
                return;

            using (MySqlConnection conn = new MySqlConnection(config.ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    cmd.CommandText = $"delete from `member` where id={id} limit 1;";
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }

            Response.Redirect("Default.aspx", true);
        }
    }
}