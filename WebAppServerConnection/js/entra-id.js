$(document).ready(function () {
    $.ajax({
        url: "../Account/CheckAdmin",
        type: "GET",
        dataType: "json",
        success: function (response) {
            if (!response.isAdmin) {
                alert("관리자만 접근 가능합니다.");
                window.location.href = "MainWindow.aspx";
            } else {
                alert("관리자 확인");
            }
        },
        error: function () {
            alert("권한 확인 중 오류 발생");
            window.location.href = "Login.aspx";
        }
    });

    function setTableHeader(columns) {
        const thead = $('#objectTable thead');
        thead.empty();

        let headerRow = '<tr>';
        columns.forEach(col => {
            headerRow += `<th>${col}</th>`;
        });
        headerRow += '</tr>';

        thead.append(headerRow);
    }

    function loadUsers() {
        $('.info h3').text('사용자 목록');
        $.ajax({
            url: "../EntraID/GetUserList",
            type: "GET",
            success: function (users) {
                const tbody = $('#objectTable tbody');
                tbody.empty();

                users.forEach(user => {
                    tbody.append(`
                        <tr>
                            <td>${user.displayName || ''}</td>
                            <td>${user.userPrincipalName || ''}</td>
                            <td>${user.id || ''}</td>
                        </tr>
                    `);
                });
            },
            error: function () {
                alert("사용자 정보를 불러오는 데 실패했습니다.");
            }
        });
    }

    function loadGroups() {
        $('.info h3').text('그룹 목록');
        $.ajax({
            url: "../EntraID/GetGroupList",
            type: "GET",
            success: function (groups) {
                const tbody = $('#objectTable tbody');
                tbody.empty();

                groups.forEach(group => {
                    tbody.append(`
                        <tr data-group-id="${group.id}">
                            <td>${group.displayName || ''}</td>
                            <td>${group.description || ''}</td>
                            <td>${group.groupTypes && group.groupTypes.length > 0 ? group.groupTypes.join(', ') : 'Security Group'}</td>
                            <td>${group.id || ''}</td>
                        </tr>
                    `);
                });
            },
            error: function () {
                alert("그룹 정보를 불러오는 데 실패했습니다.");
            }
        });
    }

    function loadApplications() {
        $('.info h3').text('애플리케이션 목록');
        $.ajax({
            url: "../EntraID/GetApplicationList",
            type: "GET",
            success: function (applications) {
                const tbody = $('#objectTable tbody');
                tbody.empty();

                applications.forEach(application => {
                    tbody.append(`
                        <tr>
                            <td>${application.displayName || ''}</td>
                            <td>${application.appID || ''}</td>
                            <td>${application.publisherDomain || ''}</td>
                            <td>${application.signInAudience || ''}</td>
                        </tr>
                    `);
                });
            },
            error: function () {
                alert("애플리케이션 정보를 불러오는 데 실패했습니다.");
            }
        });
    }

    $('#menu-users').click(function () {
        setTableHeader(['Display Name', 'User Principal Name', 'ID']);
        loadUsers();
    });

    $('#menu-groups').click(function () {
        setTableHeader(['Display Name', 'Description', 'Group Type', 'ID']);
        loadGroups();
    });

    $('#menu-applications').click(function () {
        setTableHeader(['Display Name', 'Application ID', 'Publisher Domain', 'Sign In Audience']);
        loadApplications();
    });



    $(document).on('dblclick', '#objectTable tbody tr', function () {
        const groupId = $(this).data('group-id');

        if (groupId) {
            $.ajax({
                url: "../EntraID/GetGroupMembers",
                type: "GET",
                data: { groupId: groupId },
                success: function (members) {
                    const tbody = $('#membersTable tbody');
                    tbody.empty();

                    members.forEach(member => {
                        tbody.append(`
                            <tr>
                                <td>${member.displayName || ''}</td>
                                <td>${member.userPrincipalName || ''}</td>
                                <td>${member.id || ''}</td>
                            </tr>
                        `);
                    });

                    $('#groupMembersModal').addClass('active');
                },
                error: function () {
                    alert("그룹 멤버를 불러오는 데 실패했습니다.");
                }
            });
        }
    });

    $(document).on('click', '.close-btn', function () {
        $('#groupMembersModal').removeClass('active');
    });

});

// ------------------- 우클릭 메뉴 표시 -------------------
$(document).on("contextmenu", "#menu-users", function (e) {
    e.preventDefault();
    $(".context-menu").remove();

    const $menu = $("<ul>", {
        class: "context-menu",
        css: {
            position: "absolute",
            top: e.pageY - 10,
            left: e.pageX,
            background: "#fff",
            border: "1px solid #ccc",
            padding: "5px",
            "z-index": 1000,
            "list-style": "none"
        }
    });

    const $item = $("<li>", {
        class: "context-menu-item",
        text: "Create User"
    });

    $menu.append($item);
    $("body").append($menu);
});

// ------------------- 클릭 시 모달 표시 -------------------
$(document).on("click", ".context-menu-item", function () {
    $(".context-menu").remove();
    $("#userCreateModal").addClass("active");
});

// ------------------- 바깥 클릭 시 메뉴 제거 -------------------
$(document).on("mousedown", function (e) {
    if (!$(e.target).closest(".context-menu, #menu-users").length) {
        $(".context-menu").remove();
    }
});

// ------------------- 사용자 생성 요청 처리 -------------------
$(document).on("click", "#createUserBtn", function () {
    const displayName = $("#entraDisplayName").val().trim();
    const userPrincipalName = $("#entraUserLogon").val().trim();
    const password = $("#entraPassword").val().trim();

    if (!displayName || !userPrincipalName || !password) {
        alert("모든 항목을 입력하세요.");
        return;
    }

    const fullUpn = userPrincipalName + "@soominrhee01gmail.onmicrosoft.com";

    $.ajax({
        url: "../EntraID/CreateUser",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({
            displayName: displayName,
            userPrincipalName: fullUpn,
            password: password
        }),
        success: function () {
            alert("사용자 생성 완료");
            $("#userCreateModal").removeClass("active");
            $("#menu-users").click();  // 사용자 목록 새로고침
        },
        error: function () {
            alert("사용자 생성 실패");
        }
    });
});

// ------------------- 모달 닫기 -------------------
$(document).on("click", ".cancel-btn", function () {
    $(this).closest(".modal").removeClass("active");
});
