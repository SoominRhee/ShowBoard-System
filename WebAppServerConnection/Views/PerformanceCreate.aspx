﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformanceCreate.aspx.cs" Inherits="WebAppServerConnection.aspx.PerformanceCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>공연 등록</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu-loader.js"></script>
    <script src="/js/performance-create.js"></script>

    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/boardcreate.css" />
</head>
<body>
    <div class="page-container">

        <div id="menu-placeholder"></div>

        <div class="container">
            <div class="ltgroup">
                <label for="category">Category</label>
                <input type="text" id="category" />
            </div>

            <div class="ltgroup">
                <label for="artist">Artist</label>
                <input type="text" id="artist" />
            </div>

            <div class="ltgroup">
                <label for="details">공연내용</label>
                <textarea id="details" rows="4"></textarea>
            </div>

            <div class="ltgroup">
                <label for="location">공연장소</label>
                <textarea id="location" name="location" rows="1"></textarea>
            </div>

            
            <div class="ltgroup">
                <label for="date">공연일정</label>
                <input type="date" id="date" name="date" />
            </div>

            <div class="ltgroup">
                <label for="link">홍보사이트</label>
                <textarea id="link" name="link" rows="1"></textarea>
            </div>
            
            <div class="ltgroup">
                <label for="available">허용좌석</label>
                <textarea id="available" name="available" rows="1"></textarea>
            </div>

            <div class="ltgroup">
                <label for="display">표시기한</label>
                <input type="date" id="display" name="display" />
            </div>

            <div class="create-wrapper">
                <button class="create-btn" >등록</button>
           </div>
            

        </div>


    </div>
</body>
</html>
