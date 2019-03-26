using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebTEST
{
    public partial class AddressBookConnected : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection getconnection()
        {
            return (cn = new SqlConnection(ConfigurationManager.ConnectionStrings["con1"].ToString()));
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            using (getconnection())
            {
                using (cmd = new SqlCommand("Proc_Insert_AddressBook", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", txtAddressId.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("Record Inserted");
                }
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (getconnection())
            {
                using (cmd = new SqlCommand("Proc_Delete_AddressBook", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", txtAddressId.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("record deleted");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (getconnection())
            {
                using (cmd = new SqlCommand("Proc_Update_AddressBook", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", txtAddressId.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("record updated");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (getconnection())
            {
                using (cmd = new SqlCommand("Proc_Search_AddressBook", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LastName",txtfindLastName.Text);
                    cn.Open();
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                }
            }
        }
    }
}