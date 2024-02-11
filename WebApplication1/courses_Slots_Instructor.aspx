<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courses_Slots_Instructor.aspx.cs" Inherits="Admin.courses_Slots_Instructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style>
         <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Arial', sans-serif; /* Change the font family as needed */
        }

        .container {
    position: fixed;
    height: 100vh;
    width: 150px;
    background-color: #45b3e7;
    overflow: hidden;
    transition: width 0.3s;
    z-index: 2; /* Set a higher z-index for the container */
}


        .container:hover {
            width: 300px; /* Adjust the expanded width as needed */
        }
.container {
    position: fixed;
    height: 100vh;
    width: 150px;
    background-color: #45b3e7;
    overflow: hidden;
    transition: width 0.3s;
    z-index: 2; /* Set a higher z-index for the container */
        display: flex;
        flex-direction: column;
}


        .container:hover {
            width: 300px; /* Adjust the expanded width as needed */
        }


        .dropdown {
            width: 100%;
            height: 30px; /* Adjust the height as needed */
            padding: 5px;
            box-sizing: border-box;
            border: none;
            border-radius: 5px;
            margin-bottom: 10px;
            position: relative;
            cursor: pointer;
            text-align:center;
             position: relative;
            
        }

        .buttons {
        display: none;
        position: absolute;
        top: 100%; /* Position below the dropdown */
        left: 0;
        width: 100%;
        background-color: #45b3e7;
        border-radius: 0 0 5px 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        z-index: 1; /* Ensure the dropdown is on top */
        padding-top: 5px; /* Add some padding for separation */
    }

    

    .dropdown:hover .buttons {
            display: block;
    }


        .button {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            text-align: left;
            color: #fff;
            text-decoration: none;
            display: block;
            transition: background-color 0.3s;
            text-align:center;
        }

        .button:hover {
            background-color: #1a6ca4;
        }

        .title {
            text-align: center;
            color: #fff;
            font-size: 18px; /* Adjust the font size as needed */
            font-weight: bold;
            padding: 10px 0;
        }
        .submit-style {
  width: 100%;
  padding: 5%;
  -moz-border-radius: 6px;
  -webkit-border-radius: 6px;
  border: 1px solid #45b3e7;
  font-size: 15px;
  background-color: #45b3e7;
  color: #fff;
  margin-top: 25px;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}

.submit-style:hover {
  width: 100%;
  padding: 5%;
  -moz-border-radius: 6px;
  -webkit-border-radius: 6px;
  border: 1px solid #32CD32;
  font-size: 15px;
  background-color: #32CD32;
  color: #fff;
  margin-top: 25px;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}
    
.header {
     background-color:#301934;
    color: #fff;
    padding: 10px;
    text-align: center;
    position: fixed;
    width: 100%;
    height: 50px;
    top: 0;
    display: flex;
    align-items: center;
           left: 0px;
       }

.title2 {
    flex: 1; 
    color: #000;
    text-align: center; 
}
.input-style {
  width: 90%;
  margin-bottom: 10px;
  padding: 5%;
  -moz-border-radius: 6px;
  -webkit-border-radius: 6px;
  border: 1px solid #000;
  font-size: 15px;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}
.input-style:focus {
  outline: none;
  border-color: #9ecaed;
  box-shadow: 0 0 10px #9ecaed;
  -webkit-transition: all .2s ease-in-out;
  -moz-transition: all .2s ease-in-out;
  transition: all .2s ease-in-out;
}

.logo {
    width: auto;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: flex-start;
}

.logo img {
    max-height: 100%;
    max-width: 100%;
}
.content {
    margin-top: 70px; /* Adjust this value to match the header height */

}
.user-box {
    width: auto;
    padding:10px;
    background-color: #fff;
    border: 1px solid #ccc;
    border-radius:10px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    overflow: hidden;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    z-index: 1;
   overflow-y: auto;
}

.user-header {
    position: relative;
    height: 200px;
}

.user-photo {
    position: absolute;
    top: 10px;
    left: 10px;
    width: 80px;
    height: 80px;
    border-radius: 50%;
    z-index: 2; 
}

.background-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%; 
    z-index: 1;
    overflow: hidden;
}
.custom-gridview {
        font-family: Arial, sans-serif;
        border-collapse: separate;
        border-spacing: 0;
        border: 2px solid #ccc; /* Border color /
        border-radius: 15px; / Rounded corners /
        box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2); / Shadow effect /
        transform: scale(0.9); / Scale down the table /
        margin: auto; / Center horizontally /
        position: absolute; / Positioning /
        top: 50%; / Move table from the top /
        left: 50%; / Move table from the left /
        transform: translate(-50%, -50%); / Centering trick /
    }

    .custom-gridview th,
    .custom-gridview td {
        border: 1px solid #ccc; / Border color for cells */
        padding: 8px;
        text-align: left;
    }

    .custom-gridview th {
        background-color: #f2f2f2;
        color: #333;
    }

    .custom-gridview tr:nth-child(even) {
        background-color: #f9f9f9;
    }

    .custom-gridview tr:hover {
        background-color: #f1f1f1;
    }

.background-img {
    width: 100%;
    height: 100px;
    opacity: 0.3; 
    object-fit: cover;
}
  .info-bar {
    text-align: center;
    color: #000;
    font-size: 18px;
    font-weight:700;
    padding-bottom: 10px; /* Adjust as needed */
  }

  .info-bar a {
    color: #45b3e7;
    text-decoration: none;
  }
  .container {
            background-color:  #301934;
        }

        .buttons-container,
        .btnIssueInstallment,
        input[type="submit"],
        .dropdown .buttons {
            background-color: #800080  ;
        }

        .btnIssueInstallment:hover,
        input[type="submit"]:hover,
        .button:hover {
            background-color:   #301934;
        }
 body {
    margin: 0;
    padding: 0;
    font-family: 'Arial', sans-serif;
    background-image: url('https://www.northeaststate.edu/_assets/_images/multi-campus-programs/Library%20Sunset%20Pic.jpg');
    background-size: cover; / Adjust this property */
    background-position: center;
    background-repeat: no-repeat;
    height: 100vh;
    overflow: hidden;
    
}

   </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
       <div class="logo">
          <img src="https://static.wixstatic.com/media/a0f2a3_be80e1eea60346428345ef09f184b64b~mv2.png/v1/crop/x_0,y_55,w_614,h_268/fill/w_412,h_178,al_c,q_85,usm_0.66_1.00_0.01,enc_auto/23687_edited.png" alt="Logo" />
        </div>
        <div class="title2">
            <h1 style="color:#fff">Student Portal</h1>
        </div>

    </div>
<div class="content">


     <div class="container">
      <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Main Menu</span>
    <div class="buttons">
        <a href="studentDashboard.aspx" class="button">DashBoard</a>
        <a href="addPhoneNo.aspx" class="button">Add Phone Number</a>
        <a href="register1stMakeup.aspx" class="button">Register for first makeup exam</a>
        <a href="register2ndMakeup.aspx" class="button">Register for second makeup exam</a>
        <a href="chooseInstructor.aspx" class="button">Choose Instructor for a certain course</a>
    </div>
</div>
            <div class="dropdown" onclick="toggleDropdown(this)">
               <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">View</span>
                <div class="buttons">
                    
                    <a href="optionalCourses.aspx" class="button">Optional Courses</a>
                    <a href="availableCourses.aspx" class="button">Available Courses</a>
                    <a href="requiredCourses.aspx" class="button">Required Courses</a>
                    <a href="missingCourses.aspx" class="button">Missing Courses</a>
                    <a href="gradPlan.aspx" class="button">Grad Plan</a>
                    <a href="unpaidInstallment.aspx" class="button">Unpaid Installment</a>
                    <a href="coursesAndExams.aspx" class="button">Courses And Exam Details</a>
                    <a href="courses_Slots_Instructor.aspx" class="button">Courses And Slots And Instructors</a>
                    <a href="slotsOfInstructor.aspx" class="button">Slots Of An Instructor</a>
                    <a href="coursesAndpreq.aspx" class="button">Courses And Preq</a>
                </div>
            </div>

     <div class="dropdown" onclick="toggleDropdown(this)">
   <span class="dropdown-text" style="text-align: center;color: #fff; font-size: 18px; font-weight: bold;">Send</span>
    <div class="buttons">
        
        <a href="courseRequest.aspx" class="button">Course Request</a>
        <a href="creditHourRequest.aspx" class="button">Credit Hour Request</a>
    </div>
</div>

             
     
</div>
     <div class="user-box" style="top:380px;left:54%; text-align:center;height:auto;width:auto; background-color:#E0B0FF;">         <div>
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True">
             </asp:GridView>
         </div>

 </div>
</div>

       <script>
           var dropdownTimeout;

           function showDropdown(buttons) {
               clearTimeout(dropdownTimeout);
               buttons.classList.add('show');
           }

           function hideDropdown(buttons) {
               dropdownTimeout = setTimeout(function () {
                   buttons.classList.remove('show');
               }, 10000000); // Adjust the delay as needed (200 milliseconds in this example)
           }

           // Attach event listeners to handle dropdown visibility
           document.addEventListener('DOMContentLoaded', function () {
               var dropdowns = document.querySelectorAll('.dropdown');

               dropdowns.forEach(function (dropdown) {
                   var buttons = dropdown.querySelector('.buttons');

                   dropdown.addEventListener('mouseenter', function () {
                       showDropdown(buttons);
                   });

                   dropdown.addEventListener('mouseleave', function () {
                       hideDropdown(buttons);
                   });

                   buttons.addEventListener('mouseenter', function () {
                       clearTimeout(dropdownTimeout);
                   });

                   buttons.addEventListener('mouseleave', function () {
                       hideDropdown(buttons);
                   });
               });
           });
</script>
            
    </form>
</body>

</html>

