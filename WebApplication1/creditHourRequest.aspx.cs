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
    public partial class creditHourRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Literal1.Text = null;
                Literal2.Text = null;
                Literal3.Text = null;
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                int storedUserId = (int)Session["UserId"];
                String creditHoursStr = crditH.Text;
                String type = typ.Text;
                String comment = comm.Text;

                String formattedText;
                if (string.IsNullOrWhiteSpace(creditHoursStr))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter Credit Hours</h4>
                </div>";
                    Literal1.Text = formattedText;

                }
                else if (string.IsNullOrWhiteSpace(type))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter a Type</h4>
                </div>";
                    Literal2.Text = formattedText;

                }
                else if (string.IsNullOrWhiteSpace(comment))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter a Comment</h4>
                </div>";
                    Literal3.Text = formattedText;

                }
                else
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                    <h4>Request Sent</h4>
                </div>";
                    Literal3.Text = formattedText;


                    crditH.Text = null;
                    typ.Text = null;
                    comm.Text = null;

                    int courseId = int.Parse(creditHoursStr);

                    SqlCommand courseRequest = new SqlCommand("[Procedures_StudentSendingCHRequest]", conn);
                    courseRequest.CommandType = CommandType.StoredProcedure;
                    courseRequest.Parameters.Add(new SqlParameter("@StudentID", storedUserId));
                    courseRequest.Parameters.Add(new SqlParameter("@credit_hours", courseId));
                    courseRequest.Parameters.Add(new SqlParameter("@type", type));
                    courseRequest.Parameters.Add(new SqlParameter("@comment", comment));


                    conn.Open();
                    courseRequest.ExecuteNonQuery();
                    conn.Close();
                }



            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                // Log or display an error message
                Response.Write($"An error occurred: {ex.Message}");
            }
        }
    }
}