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
        <div class="entra-menu-box">
            <h3>Microsoft Entra ID</h3>
            <ul class="entra-menu-list">
                <li class="entra-menu-item" id="menu-users" data-type="users">
                    <span class="entra-menu-label">Users</span>
                </li>
                <li class="entra-menu-item" id="menu-groups" data-type="groups">
                    <span class="entra-menu-label">Groups</span>
                </li>
                <li class="entra-menu-item" id="menu-applications" data-type="applications">
                    <span class="entra-menu-label">Applications</span>
                </li>
            </ul>
        </div>

        <div class="info">
            <h3></h3>
            <table id="objectTable">
                <thead>
                  
                </thead>
                <tbody class="main-table-body">

                </tbody>
            </table>
        </div>
    </div>

    <div id="groupMembersModal" class="modal">
        <div class="modal-content">
            <span class="close-btn">&times;</span>
            <h3>Group Members</h3>
            <table id="membersTable">
                <thead>
                    <tr>
                        <th>Display Name</th>
                        <th>User Principal Name</th>
                        <th>ID</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>