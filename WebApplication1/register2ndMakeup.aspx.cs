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
    public partial class register2ndMakeup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                int storedUserId = (int)Session["UserId"];
                String SemesterCode = sc.Text;
                String courseIDStr = cid.Text;

                String formattedText;
                if (string.IsNullOrWhiteSpace(courseIDStr))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter a Course ID</h4>
                </div>";
                    Literal1.Text = formattedText;

                }
                else if (string.IsNullOrWhiteSpace(SemesterCode))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter a Semester Code</h4>
                </div>";
                    Literal2.Text = formattedText;

                }
                else
                {
                    Literal1.Text = null;
                    Literal2.Text = null;

                    int courseID = int.Parse(cid.Text);
                    SqlCommand reg2MakeUp = new SqlCommand("[Procedures_StudentRegisterSecondMakeup]", conn);
                    reg2MakeUp.CommandType = CommandType.StoredProcedure;
                    reg2MakeUp.Parameters.Add(new SqlParameter("@StudentID", storedUserId));
                    reg2MakeUp.Parameters.Add(new SqlParameter("@CourseID", courseID));
                    reg2MakeUp.Parameters.Add(new SqlParameter("@studentCurr_sem", SemesterCode));
                    conn.Open();
                    int rowAffected = reg2MakeUp.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        formattedText = $@"
                    <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                        <h4>MakeUp Registered</h4>
                    </div>";
                        Literal2.Text = formattedText;

                    }
                    else
                    {
                        formattedText = $@"
                    <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                        <h4>MakeUp Not Registered or Already Registered</h4>
                    </div>";
                        Literal2.Text = formattedText;

                    }
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