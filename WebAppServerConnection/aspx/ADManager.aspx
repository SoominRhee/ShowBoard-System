<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADManager.aspx.cs" Inherits="WebAppServerConnection.aspx.ADManager" %>

<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <title>조직도 트리뷰</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="/js/menu.js"></script>
    <link rel="stylesheet" href="/css/style.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            //margin: 20px;
            background-color: #f5f5f5;
        }

        .container {
            display: flex;
            gap: 30px;
            width: 47.5%;
            justify-content: center; 
            margin: 0 auto;
        }

        .tree-box {
            background-color: #8EB4E3;
            color: white;
            font-weight: bold;
            min-height: 400px;
            width: 180px;
            padding: 20px;
            border-radius: 8px;
        }

        .tree-view {
            list-style: none;
            padding-left: 0;
        }

        .tree-view li {
            list-style: none;
            margin: 5px 0;
        }

        .tree-toggle {
            cursor: pointer;
            display: inline-block;
        }

        .caret::before {
            content: "\25B6"; /* ▶ */
            display: inline-block;
            margin-right: 6px;
            transition: transform 0.2s;
        }

        .caret-down::before {
            transform: rotate(90deg);
        }

        .nested {
            display: none;
            padding-left: 20px;
        }

        .active {
            display: block;
        }

        .user-info {
            flex-grow: 1;
            background: white;
            padding: 20px;
            border: 2px solid #ccc;
            border-radius: 8px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        th, td {
            padding: 10px;
            border: 1px solid #aaa;
            text-align: left;
        }

        th {
            background-color: #eee;
        }
    </style>
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




    <div class="container">
        <!-- 트리뷰 영역 -->
        <div class="tree-box">
            <h3>조직도</h3>
            <ul class="tree-view">
                <li>
                    <span class="tree-toggle caret">iqpad</span>
                    <ul class="nested">
                        <li>
                            <span class="tree-toggle caret">솔루션사업본부</span>
                            <ul class="nested">
                                <li>개발지원팀</li>
                                <li>구축수행팀</li>
                                <li>운영지원팀</li>
                                <li>본부장</li>
                            </ul>
                        </li>
                        <li>
                            <span class="tree-toggle caret">인프라사업본부</span>
                            <ul class="nested">
                                <li>구축수행팀</li>
                                <li>운영지원팀</li>
                                <li>본부장</li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>

        <!-- 사용자 정보 영역 -->
        <div class="user-info">
            <h3>사용자 정보</h3>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Type</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Admin User1</td>
                        <td>User</td>
                        <td>관리자 계정</td>
                    </tr>
                    <tr>
                        <td>Normal User1</td>
                        <td>User</td>
                        <td>일반 사용자</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script>
        const togglers = document.getElementsByClassName("tree-toggle");
        for (let i = 0; i < togglers.length; i++) {
            togglers[i].addEventListener("click", function () {
                this.parentElement.querySelector(".nested").classList.toggle("active");
                this.classList.toggle("caret-down");
            });
        }
    </script>

</body>
</html>
