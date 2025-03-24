<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppServerConnection.Login" %>

<!DOCTYPE html>
<html lang="ko">
<head runat="server">
    <meta charset="UTF-8">
    <title>로그인</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/login.js"></script>
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="card p-4 mx-auto" style="max-width: 400px;">
                <h2 class="text-center">Login</h2>
                <label>아이디:</label>
                <input type="text" id="username" class="form-control" required />

                <label>비밀번호:</label>
                <input type="password" id="password" class="form-control" required />

                <button type="button" id="btnLogin" class="btn btn-primary w-100 mt-3">로그인</button>
            </div>
        </div>  
        <div id="resultContainer"></div>
    </form>
</body>
</html>
