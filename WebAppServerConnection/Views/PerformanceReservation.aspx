<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformanceReservation.aspx.cs" Inherits="WebAppServerConnection.aspx.PerformanceReservation" %>
<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>공연 예약</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script src="/js/menu.js"></script>
    <script src="/js/performance-reservation.js"></script>


    <link rel="stylesheet" href="/css/style.css"/>
    <link rel="stylesheet" href="/css/performancereservation.css"/>
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

        <div class="container" id="info">
            
        </div>
      </div>
</body>
</html>
   