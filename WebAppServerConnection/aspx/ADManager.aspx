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
            width: 225px;
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

        .node-label {
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
            <h3>디렉토리 탐색기</h3>
            <ul class="tree-view">
                
            </ul>
        </div>

        <div class="user-info">
            <h3>객체 정보</h3>
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
            loadADTree();

            $(document).on("click", ".tree-toggle", function () {
                const $li = $(this).closest("li");
                const $nested = $li.children(".nested");

                const isOpening = !$nested.hasClass("active");

                if (!isOpening) {
                    $nested.find(".active").removeClass("active");
                    $nested.find(".caret-down").removeClass("caret-down");
                }


                if ($nested.children(".dummy").length > 0) {
                    const dn = $(this).data("dn");

                    $.ajax({
                        url: "../AD/GetChildNodes",
                        type: "GET",
                        data: { dn: dn },
                        dataType: "json",
                        success: function (res) {
                            //alert("자식 노드 불러옴");

                            $nested.empty();

                            if (res.length > 0) {
                                res.forEach(child => {
                                    const html = `<li>
                                        <span class="tree-toggle caret" data-dn="${child.DistinguishedName}" data-type="${child.SchemaClassName}"></span>
                                        <span class="node-label" data-dn="${child.DistinguishedName}" data-type="${child.SchemaClassName}">${child.Name}</span>
                                        <ul class="nested">
                                            <li class = "dummy"></li>
                                        </ul>
                                    </li>`
                                    $nested.append(html);
                                });
                            } else {
                                $nested.remove();
                                $li.find(".tree-toggle").removeClass("caret");
                            }
                        },
                        error: function () {
                            alert("자식 노드 불러오기 실패");
                        }
                    })
                }
                $nested.toggleClass("active");
                $(this).toggleClass("caret-down");

            });
        });


        function loadADTree() {
            $.ajax({
                url: "../AD/GetRootNodes",
                type: "GET",
                dataType: "json",
                success: function (res) {
                    //alert("루트 노드 불러옴");
                    let html = "";

                    res.forEach(n => {
                        html += `<li>
                            <span class="tree-toggle caret" data-dn="${child.DistinguishedName}" data-type="${child.SchemaClassName}"></span>
                            <span class="node-label" data-dn="${child.DistinguishedName}" data-type="${child.SchemaClassName}">${child.Name}</span>
                            <ul class="nested">
                                <li class="dummy"></li>
                            </ul>
                        </li>`
                    });

                    console.log("html 내용: " + html);

                    $(".tree-view").html(html);
                },
                error: function () {
                    alert("루트 노드 불러오기 실패");
                }                
            })
        }
        
    </script>
    
</body>
</html>
