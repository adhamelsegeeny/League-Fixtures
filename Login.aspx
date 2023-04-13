<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sports.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            background-image: url('images/home.jpg');
            background-repeat: no-repeat;
            background-size: 100%;
            width: 552px;
            margin-left: 601px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 318px; color:ghostwhite;font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; width: 552px; margin-left: 2px; margin-top: 60px;">
            <strong>
            Please Log In<br />
            <br />
            Username:<br />
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="signin" runat="server" OnClick="login" Text="Log in" />
            <br />
            <br />
            <a href="Register.aspx">I don't have an account</a>
                </strong>
        </div>
    </form>
</body>
</html>
