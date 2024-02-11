using System;
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
    public partial class missingCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                // Create a new connection
                SqlConnection conn = new SqlConnection(connStr);
                //int id = Int16.Parse(userID.Text);
                int storedUserId = (int)Session["UserId"];
                SqlCommand optionalproc = new SqlCommand("[Procedures_ViewMS]", conn);
                optionalproc.CommandType = CommandType.StoredProcedure;
                optionalproc.Parameters.Add(new SqlParameter("@StudentID", storedUserId));

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(optionalproc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind the result to GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
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