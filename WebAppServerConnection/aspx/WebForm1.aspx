<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAppServerConnection.aspx.WebForm1" %>

<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <title>조직도 트리뷰</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .tree-view {
            list-style: none;
            padding-left: 20px;
        }
        .tree-toggle {
            cursor: pointer;
        }
        .caret::before {
            content: "\25B6"; /* ▶ */
            display: inline-block;
            margin-right: 5px;
            transition: transform 0.2s;
        }
        .caret-down::before {
            transform: rotate(90deg);
        }
        .nested {
            display: none;
        }
        .active {
            display: block;
        }
    </style>
</head>
<body>
<div class="container mt-4">
    <div class="row">
        <div class="col-md-3">
            <h4>조직도</h4>
            <ul class="tree-view", style = "background-color: #668fda; min-height: 300px; color: white;
    font-weight: bold;">
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
        <div class="col-md-8">
            <h4>사용자 정보</h4>
            <table class="table table-bordered", "border: 2px solid #003366;">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Type</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody id="userTable">
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
