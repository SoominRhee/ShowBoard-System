<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="WebAppServerConnection.aspx.AdminMenu" %>

<!DOCTYPE html>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>관리자 메뉴</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu.js"></script>
    <script src="/js/admin-menu.js"></script>
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/boardlist.css" />
    <link rel="stylesheet" href="/css/adminmenu.css" />
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
    
    

        <div class="category-performance-container">   
            <div class="category-list" id="categoryList">
                
            </div>

            <div class="performance-box" id="performanceBox">
                <table id="performanceTable">
                    <thead id ="performanceTableHead"></thead>
                    
                    <tbody id="performanceTableBody">
                    </tbody>
                </table>
            </div>

            

        </div>

        <div class="info-box" id="InfoBox" style="margin-top: 20px;">
            <table id="userInfoTable">
                <thead id ="infoTableHead"></thead>
    
                <tbody id="infoTableBody"></tbody>
            </table>
        </div>

    </div>
</body>
</html>
