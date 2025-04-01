<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformanceList.aspx.cs" Inherits="WebAppServerConnection.aspx.PerformanceList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu.js"></script>
    <script src="/js/performance-list.js"></script>
    <link rel="stylesheet" href="/css/style.css"/>
    <link rel="stylesheet" href="/css/boardlist.css"/>
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

            <div class="menu-item">
                <div class="menu-bar">외부 사이트 링크</div>
                <div class="menu">
                    <a href="#">리스트</a>
                    <a href="#">외부사이트등록</a>
                </div>
            </div>

            <div class="menu-item">
                <div class="menu-bar">사용자 관리</div>
                <div class="menu">
                    <a href="#">조회/변경</a>
                    <a href="#">등록</a>
                </div>
            </div>
        </div>

        <div class="table-container">
            <div class="search-container">
                <input type="text" class="search-box" placeholder="검색어 입력" />
                <button class="search-btn">검색</button>
            </div>

            <table>
                <thead>
                    <tr>
                        <th>공연일자</th>
                        <th>Category</th>
                        <th>Artist</th>
                        <th>장소</th>
                        <th>공연내용</th>
                        <th>링크</th>
                        <th>예약</th>
                    </tr>
                </thead>
                <tbody id="performanceTableBody">
                </tbody>
            </table>
            <div class="pagination">
                <button class="page-btn"><<</button>
                <span>0</span>
                <button class="page-btn">>></button>
            </div>
        </div>

        
        

    </div>
</body>
</html>
