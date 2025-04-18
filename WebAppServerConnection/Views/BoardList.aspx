﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoardList.aspx.cs" Inherits="WebAppServerConnection.BoardList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>게시글 조회</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu-loader.js"></script>
    <script src="/js/board-list.js"></script>
    <link rel="stylesheet" href="/css/style.css"/>
    <link rel="stylesheet" href="/css/boardlist.css"/>
</head>
<body>
    <div class="page-container">

        <div id="menu-placeholder"></div>

        <div class="table-container">
            <div class="search-container">
                <input type="text" class="search-box" placeholder="검색어 입력" />
                <button class="search-btn">검색</button>
            </div>
            <table>
                <thead>
                    <tr>
                        <th>등록일자</th>
                        <th>등록자</th>
                        <th>요약</th>
                        <th>상세내역</th>
                        <th>표시 기간</th>
                        <th>삭제</th>
                    </tr>
                </thead>
                <tbody id="postTableBody">
                </tbody>
            </table>
            <div class="pagination">
                <button class="page-btn"><<</button>
                <span>0</span>
                <button class="page-btn">>></button>
            </div>
        </div>

        
        

    </div>
</body>
</html>
