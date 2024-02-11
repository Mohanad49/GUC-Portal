using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Admin
{
    public partial class login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                int id = Int16.Parse(username.Text);
                String user = username.Text;
                String password = pass.Text;
                String formattedText;
                if(string.IsNullOrEmpty(user))
                {
                    formattedText = $@"
            <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                <h6>Please enter an ID</h6>
            </div>";
                    Literal1.Text = formattedText;
                }
                else if (string.IsNullOrEmpty(password))
                {
                    formattedText = $@"
            <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                <h6>Please enter your Password</h6>
            </div>";
                    Literal2.Text = formattedText;
                }
                else {
                    Literal1.Text = null;
                    SqlCommand loginproc = new SqlCommand("[FN_StudentLogin]", conn);
                    loginproc.CommandType = CommandType.StoredProcedure;
                    loginproc.Parameters.Add(new SqlParameter("@Student_id", id));
                    loginproc.Parameters.Add(new SqlParameter("@password", password));

                    SqlParameter bit = loginproc.Parameters.Add(new SqlParameter("RETURN_VALUE", SqlDbType.Bit));
                    bit.Direction = ParameterDirection.ReturnValue;

                    conn.Open();
                    loginproc.ExecuteNonQuery();
                    conn.Close();
                    if (bit.Value.ToString() == "True")
                    {
                        Session["UserId"] = id;
                        Response.Redirect($"studentDashboard.aspx?Student_id={id}");
                    }
                    if (bit.Value.ToString() == "False")
                    {
                        formattedText = $@"
                    <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                        <h4>Please enter a valid User ID and Password</h4>
                    </div>";
                        Literal2.Text = formattedText;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if necessary
                String formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>please enter a valid User Id</h4>
                </div>";
                Literal1.Text = formattedText;
            }
        }

        protected void register(object sender, EventArgs e)
        {
            Response.Redirect("Register2.aspx");
        }
    }
}