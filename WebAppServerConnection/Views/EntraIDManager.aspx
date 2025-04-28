<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntraIDManager.aspx.cs" Inherits="WebAppServerConnection.Views.EntraIDManager" %>

<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <title>Microsoft Entra ID 관리</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu-loader.js"></script>
    <script src="/js/entra-id.js"></script> 
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/entra-id.css" />
</head>

<body>
    <div class="page-container">
        <div id="menu-placeholder"></div>
    </div>

    <div class="container">
        <div class="menu-box">
            <h3>Microsoft Entra ID</h3>
            <ul class="menu-list">
                <li class="menu-item" id="menu-users" data-type="users">
                    <span class="menu-label">Users</span>
                </li>
                <li class="menu-item" id="menu-groups" data-type="groups">
                    <span class="menu-label">Groups</span>
                </li>
                <li class="menu-item" id="menu-applications" data-type="applications">
                    <span class="menu-label">Applications</span>
                </li>
            </ul>
        </div>

        <div class="info">
            <h3>객체 정보</h3>
            <table id="objectTable">
                <thead>
                  
                </thead>
                <tbody class="main-table-body">

                </tbody>
            </table>
        </div>
    </div>
</body>
</html>