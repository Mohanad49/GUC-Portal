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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Admin"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            String firstname = fname.Text;
            String lastname = lname.Text;
            String password = pass.Text;
            String faculty = fac.Text;
            String mail = email.Text;
            String major = maj.Text;
            String semesterStr = semes.Text;
            String formattedText;
            if (string.IsNullOrWhiteSpace(firstname))
            {
                formattedText = $@"
            <script>
            alert('please enter a First name');
            </script>";

                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(lastname))
            {
                formattedText = $@"
            <script>
            alert('please enter a Last name');
            </script>";

                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(password))
            {
                formattedText = $@"
            <script>
            alert('please enter a password');
            </script>";
                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(faculty))
            {
                formattedText = $@"
            <script>
            alert('please enter a Faculty');
            </script>";

                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(mail))
            {
                formattedText = $@"
            <script>
            alert('please enter an email');
            </script>";

                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(major))
            {
                formattedText = $@"
            <script>
            alert('please enter an Major');
            </script>";
                Response.Write(formattedText);
                return;

            }
            if (string.IsNullOrWhiteSpace(semesterStr))
            {
                formattedText = $@"
            <script>
            alert('please enter a Semester');
            </script>";

                Response.Write(formattedText);
                return;

            }

            int semester = int.Parse(semesterStr);

            SqlCommand signup = new SqlCommand("[Procedures_StudentRegistration]", conn);
            signup.CommandType = CommandType.StoredProcedure;
            signup.Parameters.Add(new SqlParameter("@first_name", firstname));
            signup.Parameters.Add(new SqlParameter("@last_name", lastname));
            signup.Parameters.Add(new SqlParameter("@password", password));
            signup.Parameters.Add(new SqlParameter("@faculty", faculty));
            signup.Parameters.Add(new SqlParameter("@email", mail));
            signup.Parameters.Add(new SqlParameter("@major", major));
            signup.Parameters.Add(new SqlParameter("@Semester", semester));

            SqlParameter id = signup.Parameters.Add(new SqlParameter("@Student_id", SqlDbType.Int));
            id.Direction = ParameterDirection.Output;

            conn.Open();
            signup.ExecuteNonQuery();
            conn.Close();
            int StudentId = Convert.ToInt32(id.Value);
            formattedText = $@"
         <script>
    var username = '{firstname}';
    var userId = '{StudentId}';
    var alertMessage = 'Welcome, ' + username + '!\nYour user ID is: ' + userId + '\nThank you for registering with us.' + '\nPlease log in below.';
    alert(alertMessage);
    window.location.href = 'login2.aspx';
</script>";

            RegistrationResponseLiteral.Text = formattedText;

            // Use Response.Write to output the HTML
        }

        protected void login(object sender, EventArgs e)
        {
            Response.Redirect("login2.aspx");
        }
    }
}