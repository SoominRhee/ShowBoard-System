<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADManager_create.aspx.cs" Inherits="WebAppServerConnection.aspx.ADManager_create" %>

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
            <h3>AD 트리</h3>
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
</body>
</html>
