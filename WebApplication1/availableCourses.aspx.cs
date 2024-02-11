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
    public partial class availableCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Literal1.Text = null;
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                //create a new connection
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
                {
                    string sqlQuery = $"SELECT * FROM [FN_SemsterAvailableCourses](@semstercode)";
                    Console.WriteLine($"SQL Query: {sqlQuery}"); // Output the query for debugging

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@semstercode", semesCode); // Corrected parameter name

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
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                // Log or display an error message
                Response.Write($"An error occurred: {ex.Message}");
            }

        }
    }
}