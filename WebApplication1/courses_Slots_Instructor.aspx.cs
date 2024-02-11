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
    public partial class courses_Slots_Instructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    // Check if the session variable is not null
                    if (Session["UserId"] != null)
                    {
                        int storedUserId = (int)Session["UserId"];
                        // Use advisorId as needed, for example, display it in a label
                        BindCoursesAndSlotsAndInstructorData(storedUserId);
                    }
                    else
                    {
                        // Handle the case when advisor_Id is not present in the session
                        Response.Redirect("login.aspx"); // Redirect to login page or handle appropriately
                    }
                }
            }
        }

        private void BindCoursesAndSlotsAndInstructorData(int storedUserId)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                // Replace "YourConnectionString" with the actual name of your connection string

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses_Slots_Instructor", conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", storedUserId);
                        cmd.CommandType = CommandType.Text;

                        conn.Open();

                        // Execute the query
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the result to GridViewCourses
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions by logging or displaying an error message
                Response.Write($"An error occurred: {ex.Message}");
            }
        }
    }
}