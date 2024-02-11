using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class chooseInstructor : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int storedUserId = (int)Session["UserId"];
                String SemesterCode = sc.Text;
                String courseIDStr = cid.Text;
                String InstructorIdStr = typ.Text;

                String formattedText;
                if (string.IsNullOrWhiteSpace(courseIDStr))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please A Course ID</h4>
                </div>";
                    Literal1.Text = formattedText;

                }
                else if (string.IsNullOrWhiteSpace(InstructorIdStr))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please An Instructor ID</h4>
                </div>";
                    Literal2.Text = formattedText;

                }
                else if (string.IsNullOrWhiteSpace(SemesterCode))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please A Semester Code</h4>
                </div>";
                    Literal3.Text = formattedText;

                }
                else
                {
                    int courseID = int.Parse(cid.Text);
                    int InstructorId = int.Parse(typ.Text);
                    SqlCommand chooseInstructor = new SqlCommand("[Procedures_Chooseinstructor]", conn);
                    chooseInstructor.CommandType = CommandType.StoredProcedure;
                    chooseInstructor.Parameters.Add(new SqlParameter("@StudentID", storedUserId));
                    chooseInstructor.Parameters.Add(new SqlParameter("@instrucorID", InstructorId));
                    chooseInstructor.Parameters.Add(new SqlParameter("@CourseID", courseID));
                    chooseInstructor.Parameters.Add(new SqlParameter("@current_semester_code", SemesterCode));
                    conn.Open();
                    int rowAffected = chooseInstructor.ExecuteNonQuery();
                    Literal1.Text = null;
                    Literal2.Text = null;
                    Literal3.Text = null;
                    if (rowAffected > 0)
                    {
                        formattedText = $@"
                    <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                        <h4>Instructor Chosen</h4>
                    </div>";
                        Literal3.Text = formattedText;

                    }
                    else
                    {
                        formattedText = $@"
                    <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                        <h4>Instructor Not Chosen</h4>
                    </div>";
                        Literal3.Text = formattedText;

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