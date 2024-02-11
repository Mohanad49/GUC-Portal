<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register2.aspx.cs" Inherits="Admin.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    body,
        html {
          width: 100%;
          height: 100%;
          padding-top: 1%;
          margin: 0;
          background-color: #e6e6e6;
          font-family: arial;
          -webkit-font-smoothing: antialiased;
          -moz-osx-font-smoothing: grayscale;
           background-image: url('https://www.northeaststate.edu/_assets/_images/multi-campus-programs/Library%20Sunset%20Pic.jpg');
           background-size:cover; /* Adjust this property */
           background-position:unset;
           background-repeat: no-repeat;
        }

        .title-bar {
          text-align: center;
          color: #fff;
          font-size: 30px;
          padding-bottom: 10px;
        }

        .info-bar {
          text-align: center;
          font-family: 'Arial', sans-serif;
          color: #000;
          font-size: 15px;
          padding-bottom: 10px; /* Adjust as needed */
        }

        .info-bar a {
          color: #45b3e7;
          text-decoration: none;
        }

        .wrap {
          background-color: #E0B0FF;
          padding: 2%;
          width: 25%;
          min-width: 350px;
          margin: 0 auto;
          -moz-border-radius: 6px;
          -webkit-border-radius: 6px;
          box-shadow: 0 0 5px #ccc;
          border: 1px solid #fff;
        }

        .input-style {
          width: 90%;
          margin-bottom: 10px;
          padding: 5%;
          -moz-border-radius: 6px;
          -webkit-border-radius: 6px;
          border: 1px solid #efefef;
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

        .submit-style {
          width: 100%;
          padding: 5%;
          -moz-border-radius: 6px;
          -webkit-border-radius: 6px;
          border: 1px solid #45b3e7;
          font-size: 15px;
          background-color: #800080;
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
          border: 1px solid #301934;
          font-size: 15px;
          background-color: #301934;
          color: #fff;
          margin-top: 25px;
          -webkit-transition: all .2s ease-in-out;
          -moz-transition: all .2s ease-in-out;
          transition: all .2s ease-in-out;
        }
</style>
</head>
<body>
    
    <form id="form1" runat="server">
   <div class="title-bar">
    Register As Student
   </div>
  <div class="wrap">
        <div class="info-bar">
       First Name
    </div>
    <asp:TextBox ID="fname" runat="server" CssClass="input-style"></asp:TextBox>
      <asp:Literal ID="Literal1" runat="server"></asp:Literal>

          
        <div class="info-bar">
       Last Name
    </div>
    <asp:TextBox ID="lname" runat="server" CssClass="input-style"></asp:TextBox>
      <asp:Literal ID="Literal2" runat="server"></asp:Literal>


      <div class="info-bar">
      password
  </div>
  <asp:TextBox ID="pass" runat="server" CssClass="input-style"></asp:TextBox>
      <asp:Literal ID="Literal3" runat="server"></asp:Literal>


          <div class="info-bar">
      Faculty
  </div>
  <asp:TextBox ID="fac" runat="server" CssClass="input-style"></asp:TextBox>
      <asp:Literal ID="Literal4" runat="server"></asp:Literal>


      <div class="info-bar">
      Email
  </div>
  <asp:TextBox ID="email" runat="server" CssClass="input-style"></asp:TextBox>
      <asp:Literal ID="Literal5" runat="server"></asp:Literal>


      <div class="info-bar">
      Major
  </div>
  <asp:TextBox ID="maj" runat="server" CssClass="input-style"></asp:TextBox>
      <asp:Literal ID="Literal6" runat="server"></asp:Literal>


      <div class="info-bar">
      Semester
  </div>
  <asp:TextBox ID="semes" runat="server" CssClass="input-style"></asp:TextBox>
      <asp:Literal ID="Literal7" runat="server"></asp:Literal>


  <asp:Button ID="signup" runat="server" OnClick="register" Text="Register" CssClass="submit-style" />
    <div style="text-align: center; color: #000; font-size: 15px;padding-top:10px;height:2px">
    Already Registered?
</div>
     <asp:Literal ID="RegistrationResponseLiteral" runat="server"></asp:Literal>
   <asp:Button ID="return" runat="server" OnClick="login" Text="Log in" CssClass="submit-style" />
  
  </div>


    </form>
</body>
</html>
