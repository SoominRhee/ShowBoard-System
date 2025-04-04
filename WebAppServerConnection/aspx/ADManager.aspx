﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADManager.aspx.cs" Inherits="WebAppServerConnection.aspx.ADManager" %>

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
            background-color: #f5f5f5;
        }

        .container {
            max-width: 1200px;
            display: flex;
            gap: 30px;
            width: 100%;
            justify-content: center; 
            margin: 0 auto;
        }

        .tree-box {
            background-color: #8EB4E3;
            color: #F5F5F5;
/*            font-weight: bold;*/
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

        .last {
            text-decoration: underline;
            cursor: pointer;

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
        <div class="tree-box">
            <h3>조직도</h3>
            <ul class="tree-view">
                
            </ul>
        </div>

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
        $(document).ready(function () {
            loadOrgTree();

            $(document).on("click", ".tree-toggle", function () {
                const parentLi = $(this).parent();
                const nested = parentLi.children(".nested");

                // 펼치기 / 접기
                const isOpening = !nested.hasClass("active");

                if (!isOpening) {
                    nested.find(".active").removeClass("active");
                    nested.find(".caret-down").removeClass("caret-down");
                }

                nested.toggleClass("active");
                $(this).toggleClass("caret-down");

            
            });

            $(document).on("click", ".last", function () {
                const dn = $(this).data("dn");
                console.log("보낼 DN: ", dn);

                $.ajax({
                    url: "../AD/GetUsersByOU",
                    type: "GET",
                    dataType: "json",
                    data: { dn: dn },
                    success: function (res) {
                        console.log("응답:", res);
                        let html = "";
                        res.forEach(u => {
                            html += `<tr>
                                        <td>${u.Name}</td>
                                        <td>${u.Type}</td>
                                        <td>${u.Description}</td>
                                    </tr>`;
                        });
                        $(".user-info tbody").html(html);
                    },
                    error: function () {
                        alert("사용자 정보 불러오기 실패");
                    }
                });
            });
        });


        function loadOrgTree() {
            $.ajax({
                url: "../AD/GetOrgTree",
                type: "GET",
                dataType: "json",
                beforeSend: function () {
                    alert("요청 전송 준비 완료");
                },
                success: function (res) {
                    alert("응답 받음");
                    console.log(res);
                    const treeHtml = buildTreeView(res);
                    $(".tree-view").html(treeHtml);
                },
                error: function () {
                    alert("응답 없음")
                }
            });
        }

        function buildTreeView(nodes) {
            let html = "";
            nodes.forEach(n => {
                html += `<li>`;

                if (n.Children.length > 0) {
                    html += `<span class="tree-toggle caret" data-dn="${n.DistinguishedName}">${n.Name}</span>
                         <ul class="nested">${buildTreeView(n.Children)}</ul>`;
                } else {
                    html += `<span class="last" data-dn="${n.DistinguishedName}">${n.Name}</span>`
                }

                html += `</li>`;
            });
            return html;
        }
    </script>

</body>
</html>
