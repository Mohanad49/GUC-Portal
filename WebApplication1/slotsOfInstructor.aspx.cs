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
    public partial class slotsOfInstructor : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            string formattedText;
            
            String courseID = cid.Text;
            String InstructorId = typ.Text;

            try
            {

                // Validate data (additional validation can be added)
                 if (string.IsNullOrEmpty(courseID))
                {
                    formattedText = $@"
            <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                <h6>Please enter Course ID</h6>
            </div>";
                    Literal1.Text = formattedText;
                }
                else if (string.IsNullOrEmpty(InstructorId))
                {
                    formattedText = $@"
            <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                <h6>Please enter Instructor ID</h6>
            </div>";
                    Literal2.Text = formattedText;
                }
                else
                {
                    Literal1.Text = null;
                    Literal2.Text = null;
                    // Connection string (replace with your actual connection string)
                    string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        string sqlQuery = $"SELECT * FROM [FN_StudentViewSlot](@courseID,@InstructorID)";
                        Console.WriteLine($"SQL Query: {sqlQuery}"); // Output the query for debugging

                        using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@courseID", courseID); // Corrected parameter name
                            cmd.Parameters.AddWithValue("@instructorID", InstructorId);
                            conn.Open();

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Bind the result to GridView
                            GridView1.DataSource = dt;
                            GridView1.DataBind();




                        }
                    }
                }
            }
            catch (Exception ex)
            {
                formattedText = $@"
        <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
            <h4>Please enter valid Instructor ID and Course ID</h4>
        </div>";
                Literal2.Text = formattedText;
            }
        }
    }
}