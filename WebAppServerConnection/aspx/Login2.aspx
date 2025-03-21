<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="WebAppServerConnection.Login2" %>


<!DOCTYPE html>
<html lang="ko">
<head runat="server">
    <meta charset="UTF-8">
    <title>로그인</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/login.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <style>
    .login-box {
        width: 350px;
        padding: 20px;
        margin: auto;
        border-radius: 10px;
        box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.2);
    }

    .my-check{
        accent-color: blueviolet;
        color: darkgray;
        font-size: 15px;
        float: left;
    }

    .my-button{
        background-color: blueviolet;
        color: white;
        border-radius: 10px;
        padding: 10px;
        font-size: 20px;
        font-weight: bold;
        cursor: pointer;
    }

    .my-txtbox{
        border: 1px solid #ccc;
        border-radius: 10px;
        padding: 10px;
        background-color: ghostwhite;
        color: black;
        font-size: 15px;
        outline: none;
    }

    .my-txtbox::placeholder {
        color: darkgray;
    }

    .my-txtbox:focus {
        border-color: blueviolet;
        box-shadow: 0 0 5px rgba(138, 43, 226, 0.5);
    }

    .my-label{
        font-size: 30px;
        color: blueviolet;
        font-weight: bold;
    }
    .login-container {
        display: flex;
        flex-direction: column;
        width: 90%;
        margin: auto;
        gap: 10px;
    }

</style>
</head>
<body>
    <form id="form1" runat="server">
        

        <div class="login-box">
            <div class="login-container">
                <asp:Label CssClass="my-label" ID="Label1" runat="server" Text="Login"></asp:Label>
                <asp:TextBox CssClass="my-txtbox" ID="username" runat="server" PlaceHolder="Email"></asp:TextBox>
                <asp:TextBox CssClass="my-txtbox" ID="password" runat="server" TextMode="Password" PlaceHolder="Password"></asp:TextBox>
                <asp:Button CssClass="my-button" ID="btnLogin" runat="server" Text="Login" />
            </div>
        </div>
    </form>
</body>
</html>

