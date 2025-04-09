<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppServerConnection.Login" %>

<!DOCTYPE html>
<html lang="ko">
<head runat="server">
    <meta charset="UTF-8">
    <title>로그인</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/login.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="/css/login.css" />
</head>
<body style="background-color:#f5f5f5;">
    <div>
        <div class="container mt-5">
            <div class="card mx-auto shadow" style="max-width: 450px; padding: 40px;">
                <h2 class="text-center mb-4 fs-2 fw-bold">Login</h2>

                <label class="form-label fs-6">아이디:</label>
                <input type="text" id="username" class="form-control mb-3" required />

                <label class="form-label fs-6">비밀번호:</label>
                <input type="password" id="password" class="form-control mb-3" required />

                <div class="form-check mb-3">
                    <input class="form-check-input" type="checkbox" id="isAdLogin">
                    <label class="form-check-label fs-6" for="isAdLogin">
                        AD 계정으로 로그인
                    </label>
                </div>

                <button type="button" id="btnLogin" class="btn w-100">로그인</button>
            </div>      
        </div>  
        <div id="resultContainer" class="text-center mt-3"></div>
    </div>
</body>
</html>
