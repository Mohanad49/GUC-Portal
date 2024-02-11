using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Admin
{
    public partial class optionalCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                // Create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                String semesCode = semes.Text;
                String formattedText;
                if (string.IsNullOrWhiteSpace(semesCode))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter a Semester Code</h4>
                </div>";
                    Literal1.Text = formattedText;
                }
                //int id = Int16.Parse(userID.Text);
                int storedUserId = (int)Session["UserId"];
                SqlCommand optionalproc = new SqlCommand("[Procedures_ViewOptionalCourse]", conn);
                optionalproc.CommandType = CommandType.StoredProcedure;
                optionalproc.Parameters.Add(new SqlParameter("@StudentID", storedUserId));
                optionalproc.Parameters.Add(new SqlParameter("@current_semester_code", semesCode));

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(optionalproc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind the result to GridView
                GridView2.DataSource = dt;
                GridView2.DataBind();
                conn.Close();


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