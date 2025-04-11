﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservationList.aspx.cs" Inherits="WebAppServerConnection.aspx.ReservationList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu.js"></script>
    <script src="/js/reservation-list.js"></script>
    <link rel="stylesheet" href="/css/style.css"/>
    <link rel="stylesheet" href="/css/boardlist.css"/>
    <link rel="stylesheet" href="/css/modalstyle.css"/>
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


        

        <div class="table-container">
            <div class="search-container">
                <input type="text" class="search-box" placeholder="검색어 입력" />
                <button class="search-btn">검색</button>
            </div>
            <table>
                <thead>
                    <tr>
                        <th>공연 일자</th>
                        <th>Category</th>
                        <th>Artist</th>
                        <th>장소</th>
                        <th>총 좌석 수</th>
                        <th>예약 현황</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody id="reservationTableBody">
                </tbody>
            </table>
            <div class="pagination">
                <button class="page-btn"><<</button>
                <span>0</span>
                <button class="page-btn">>></button>
            </div>
        </div>

        

        <div class="modal-overlay"></div>

        <div id="detailModal" class="modal">
            <span class="close">&times;</span>
            <h2>공연 상세 정보</h2>
            <p id="detailContent">상세 정보</p>
        </div>

    </div>
</body>
</html>
