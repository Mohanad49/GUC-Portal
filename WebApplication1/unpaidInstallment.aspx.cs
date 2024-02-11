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
    public partial class unpaidInstallment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int storedUserId = (int)Session["UserId"];

                using (SqlCommand viewInstallment = new SqlCommand("FN_StudentUpcoming_installment", conn))
                {
                    viewInstallment.Parameters.Add(new SqlParameter("@student_ID", storedUserId));
                    viewInstallment.CommandType = CommandType.StoredProcedure;

                    SqlParameter installment = viewInstallment.Parameters.Add("@installdeadline", SqlDbType.Date);
                    installment.Direction = ParameterDirection.ReturnValue;

                    conn.Open();
                    viewInstallment.ExecuteNonQuery();

                    DateTime upcomingInstallmentDeadline = Convert.ToDateTime(installment.Value);

                    if (upcomingInstallmentDeadline != DateTime.MinValue)
                    {
                        // Bind the data to the GridView or any other control you want
                        DataTable dt = new DataTable();
                        dt.Columns.Add("UpcomingInstallmentDeadline");
                        dt.Rows.Add(upcomingInstallmentDeadline.ToString("yyyy-MM-dd"));
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // No upcoming installment found
                        Response.Write("No upcoming installments.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                Response.Write($"An error occurred: {ex.Message}");
            }

        }
    }
}
    
