<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADManager.aspx.cs" Inherits="WebAppServerConnection.aspx.ADManager" %>

<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <title>조직도 트리뷰</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu.js"></script>
    <script src="/js/ad-manager.js"></script>
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/admanager.css" />
</head>

<body>
        
   
    <div class="page-container">

        <div class="menu-container">
            <div class="menu-item">
                <div class="menu-bar">알림판</div> 
                <div class="menu">
                    <a href="https://localhost:44349/Views/BoardList.aspx">조회</a>
                    <a href="https://localhost:44349/Views/BoardCreate.aspx">등록</a>
                </div>
            </div>
                
            <div>
                <div class="menu-item">
                    <div class="menu-bar">공연신청</div>
                    <div class="menu">
                        <a href="https://localhost:44349/Views/PerformanceList.aspx">조회</a>
                        <a href="https://localhost:44349/Views/PerformanceReservation.aspx">예약</a>
                        <a href="https://localhost:44349/Views/ReservationList.aspx">예약내역</a>
                        <a href="https://localhost:44349/Views/PerformanceCreate.aspx">공연등록</a>
                    </div>
                </div>
            </div>

            <div>
                <div class="menu-item">
                    <div class="menu-bar">관리자 메뉴</div>
                    <div class="menu">
                        <a href="https://localhost:44349/Views/AdminMenu.aspx">예약자 정보 조회</a>
                    </div>
                </div>
            </div>

            <div>
                <div class="menu-item">
                    <div class="menu-bar">Active Directory</div>
                    <div class="menu">
                        <a href="https://localhost:44349/Views/ADManager.aspx">객체 탐색 및 정보 조회</a>
                    </div>
                </div>
            </div>
                
        </div>
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
