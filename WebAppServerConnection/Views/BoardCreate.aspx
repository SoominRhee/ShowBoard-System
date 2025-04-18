<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardCreate.aspx.cs" Inherits="WebAppServerConnection.BoardCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>게시글 등록</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu-loader.js"></script>
    <script src="/js/board-create.js"></script>

    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/boardcreate.css" />
</head>
<body>
    <div class="page-container">

        <div id="menu-placeholder"></div>
      
        <div class="container">
            
            <div class="ltgroup">
                <label for="summary">알림요약</label>
                <textarea id="summary" name="summary" rows="2"></textarea>
            </div>

            <div class="ltgroup">
                <label for="details">상세내역</label>
                <textarea id="details" name="details" rows="4"></textarea>
            </div>
            
            <div class="ltgroup">
                <label for="date">게시기간</label>
                <input type="date" id="date" name="date" />
                
            </div>

            <div class="create-wrapper">
                <button class="create-btn">등록</button>
            </div>
            

        </div>
    </div>
</body>
</html>
