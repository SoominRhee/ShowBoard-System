<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformanceCreate.aspx.cs" Inherits="WebAppServerConnection.aspx.PerformanceCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu.js"></script>
    <script src="/js/performance-create.js"></script>

    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/boardcreate.css" />
</head>
<body>
    <div>

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
                <div class="menu-bar">공연신청</div>
                <div class="menu">
                    <a href="#">조회/변경</a>
                    <a href="#">등록</a>
                </div>
            </div>
        </div>
                
      


        <div class="container">
            <div class="ltgroup">
                <label for="category">Category</label>
                <input type="text" id="category" />
            </div>

            <div class="ltgroup">
                <label for="artist">Artist</label>
                <input type="text" id="artist" />
            </div>

            <div class="ltgroup">
                <label for="details">공연내용</label>
                <textarea id="details" rows="4"></textarea>
            </div>

            <div class="ltgroup">
                <label for="location">공연장소</label>
                <textarea id="location" name="location" rows="1"></textarea>
            </div>

            
            <div class="ltgroup">
                <label for="date">공연일정</label>
                <input type="date" id="date" name="date" />
            </div>

            <div class="ltgroup">
                <label for="link">홍보사이트</label>
                <textarea id="link" name="link" rows="1"></textarea>
            </div>
            
            <div class="ltgroup">
                <label for="available">허용좌석</label>
                <textarea id="available" name="available"></textarea>
            </div>

            <div class="ltgroup">
                <label for="display">표시기한</label>
                <input type="date" id="display" name="display" />
            </div>

            <button class="create-btn" >등록</button>
           
            

        </div>


    </div>
</body>
</html>
