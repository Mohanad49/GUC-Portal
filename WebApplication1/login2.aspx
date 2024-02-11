<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="Admin.login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body,
        html {
          width: 100%;
          height: 100%;
          padding-top: 1.8%;
          margin: 0;
          font-family: arial;
          -webkit-font-smoothing: antialiased;
          -moz-osx-font-smoothing: grayscale;
          font-family: 'Arial', sans-serif;
          background-image: url('https://www.northeaststate.edu/_assets/_images/multi-campus-programs/Library%20Sunset%20Pic.jpg');
          background-size: cover; /* Adjust this property */
          background-position: center;
          background-repeat: no-repeat;
          overflow: hidden;
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
            Log in As Sutdent
        </div>
        <div class="wrap">
            <div class="info-bar">
                User ID
            </div>
            <asp:TextBox ID="username" runat="server" CssClass="input-style" ></asp:TextBox>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <div class="info-bar">
                Password
            </div>
            <asp:TextBox ID="pass" runat="server" TextMode="Password" CssClass="input-style" ></asp:TextBox>
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            <asp:Button ID="signin" runat="server" OnClick="Login" Text="Log in" CssClass="submit-style" />
             <div style="text-align: center; color: #000; font-size: 15px;padding-top:10px;height:2px">
    Not Registered?
</div>
            <asp:Button ID="Register" runat="server" OnClick="register" Text="Register" CssClass="submit-style" />

                
</div>
            
     
            <br />
       
    </form>
</body>
</html>
