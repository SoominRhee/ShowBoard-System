<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainWindow.aspx.cs" Inherits="WebAppServerConnection.MainWindow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>메인화면</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu.js"></script>
    <link rel="stylesheet" href="/css/style.css" />
</head>
<body>
    <div class="page-container">

        <div class="menu-container">
            <div class="menu-item">
                <div class="menu-bar">알림판</div> 
                <div class="menu">
                    <a href="https://localhost:44349/aspx/BoardList.aspx">조회</a>
                    <a href="https://localhost:44349/aspx/BoardCreate.aspx">등록</a>
                </div>
            </div>
                
            <div>
                <div class="menu-item">
                    <div class="menu-bar">공연신청</div>
                    <div class="menu">
                        <a href="https://localhost:44349/aspx/PerformanceList.aspx">조회</a>
                        <a href="https://localhost:44349/aspx/PerformanceReservation.aspx">예약</a>
                        <a href="https://localhost:44349/aspx/ReservationList.aspx">예약내역</a>
                        <a href="https://localhost:44349/aspx/PerformanceCreate.aspx">공연등록</a>
                        <a href="https://localhost:44349/aspx/AdminMenu.aspx">관리자 메뉴</a>

                    </div>
                </div>
            </div>

            <div>
                <div class="menu-item">
                    <div class="menu-bar">외부 사이트 링크</div>
                    <div class="menu">
                        <a href="#">리스트</a>
                        <a href="#">외부사이트등록</a>
                    </div>
                </div>
            </div>

            <div>
                <div class="menu-item">
                    <div class="menu-bar">사용자 관리</div>
                    <div class="menu">
                        <a href="#">조회/변경</a>
                        <a href="#">등록</a>
                    </div>
                </div>
            </div>
                
        </div>
    </div>
</body>
</html>
