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
