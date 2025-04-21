<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADManager.aspx.cs" Inherits="WebAppServerConnection.aspx.ADManager" %>

<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <title>조직도 트리뷰</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu-loader.js"></script>
    <script src="/js/ad-manager.js"></script>
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/admanager.css" />
</head>

<body>
        
   
    <div class="page-container">

        <div id="menu-placeholder"></div>

    </div>

    <div class="container">
        <div class="tree-box">
            <h3>AD 관리</h3>
            <ul class="tree-view">
                
            </ul>
        </div>

        <div class="info">
            <h3>객체 정보</h3>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Type</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody class="main-table-body">
                    
                </tbody>
            </table>
        </div>

    </div>
    <div class="detail-popup" id="detail-box">
        <div class="detail-content">
        
        </div>
    </div>

    <div id="userCreateModal" class="modal">
        <div class="modal-content">
            <h3>Create New User</h3>
            <form id="userCreateForm">
                <input type="hidden" name="parentDn" id="userParentDn" />
                <label>First Name</label>
                <input type="text" name="firstName" required />
                <label>Initials</label>
                <input type="text" name="initials" />
                <label>Last Name</label>
                <input type="text" name="lastName" required />
                <label>User Logon Name</label>
                <input type="text" name="logonName" required />
                <label>Password</label>
                <input type="password" name="password" required />
                <div class="modal-actions">
                    <button type="submit">Create</button>
                    <button type="button" class="cancel-btn">Cancel</button>            
                </div>
            </form>
        </div>
    </div>


    <div id="groupCreateModal" class="modal">
        <div class="modal-content">
            <h3>Create New Group</h3>
            <form id="groupCreateForm">
                <input type="hidden" name="parentDn" id="groupParentDn" />
                <label>Group Name</label>
                <input type="text" name="groupName" required />
                <div class="modal-actions">
                    <button type="submit">Create</button>
                    <button type="button" class="cancel-btn">Cancel</button>            

                </div>
            </form>
        </div>
    </div>

    <div id="organizationalunitCreateModal" class="modal">
    <div class="modal-content">
        <h3>Create New Organizational Unit</h3>
        <form id="organizationalunitCreateForm">
            <input type="hidden" name="parentDn" id="organizationalunitParentDn" />
            <label>OU Name</label>
            <input type="text" name="ouName" required />
            <div class="modal-actions">
                <button type="submit">Create</button>
                <button type="button" class="cancel-btn">Cancel</button>            
            </div>
        </form>
    </div>
</div>
</body>
</html>