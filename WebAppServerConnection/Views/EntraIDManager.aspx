<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntraIDManager.aspx.cs" Inherits="WebAppServerConnection.Views.EntraIDManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Entra ID 사용자 목록</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/entraid-manager.js"></script>
    <style>
        table { border-collapse: collapse; width: 80%; margin: 20px auto; }
        th, td { border: 1px solid #ccc; padding: 8px 12px; text-align: left; }
        th { background-color: #f5f5f5; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h2>Microsoft Entra ID 사용자 목록</h2>
            <table id="userTable">
                <thead>
                    <tr>
                        <th>Display Name</th>
                        <th>Email</th>
                        <th>User Principal Name</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
    </form>

    
</body>
</html>
    