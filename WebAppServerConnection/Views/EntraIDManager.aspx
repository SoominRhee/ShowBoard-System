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
    <link rel="stylesheet" href="/css/admanager.css" />
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

    <div id="userCreateModal" class="modal">
        <div class="modal-content">
            <h3>Create New User</h3>

            <label for="entraUserLogon">User Principal Name</label>
            <div style="display: flex; align-items: center;">
                <input type="text" id="entraUserLogon" style="flex: 1;" />
                <span style="margin-left: 6px; font-size: 13px; white-space: nowrap;">@soominrhee01gmail.onmicrosoft.com</span>
            </div>

            <label for="entraDisplayName">Display Name</label>
            <input type="text" id="entraDisplayName" />

            <label for="entraPassword">Password</label>
            <input type="password" id="entraPassword" />
            
            <div class="modal-actions">
                <button id="createUserBtn">Create</button>
                <button class="cancel-btn">Cancel</button>
            </div>
        </div>
    </div>

    <div id="groupCreateModal" class="modal">
        <div class="modal-content">
            <h3>Create New Group</h3>

            <label for="entraGroupName">Group Name</label>
            <input type="text" id="entraGroupName" />

            <label for="entraGroupDescription">Description</label>
            <input type="text" id="entraGroupDescription" />

            <div class="modal-actions">
                <button id="createGroupBtn">Create</button>
                <button class="cancel-btn">Cancel</button>
            </div>
        </div>
    </div>

</body>
</html>