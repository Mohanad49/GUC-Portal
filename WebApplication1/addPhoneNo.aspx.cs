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
    public partial class addPhoneNo : System.Web.UI.Page
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
                int storedUserId = (int)Session["UserId"];
                String numStr = phoneNo.Text;
                String formattedText;
                if (string.IsNullOrWhiteSpace(numStr))
                {
                    formattedText = $@"
                <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                    <h4>Please enter a Phone Number</h4>
                </div>";
                    Literal1.Text = formattedText;

                }
                else
                {
                    phoneNo.Text = null;
                    SqlCommand addNum = new SqlCommand("[Procedures_StudentaddMobile]", conn);
                    addNum.CommandType = CommandType.StoredProcedure;
                    addNum.Parameters.Add(new SqlParameter("@StudentID", storedUserId));
                    addNum.Parameters.Add(new SqlParameter("@mobile_number", numStr));
                    conn.Open();
                    int rowAffcted = addNum.ExecuteNonQuery();
                    if (rowAffcted > 0)
                    {
                        formattedText = $@"
                    <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #00ff00;'>
                        <h4>Phone Number Added</h4>
                    </div>";
                        Literal1.Text = formattedText;

                    }
                    else
                    {
                        formattedText = $@"
                    <div style='text-align: center; margin-top: 2px; padding: 2px; background-color: #f0f0f0; border-radius: 3px; box-shadow: 0 0 5px rgba(0, 0, 0, 0.1); border: 1px solid #ff0000;'>
                        <h4>Phone Number Not Added</h4>
                    </div>";
                        Literal1.Text = formattedText;

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