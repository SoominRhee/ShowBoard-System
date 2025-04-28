$(document).ready(function () {

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
        $.ajax({
            url: "../EntraID/GetGroupList",
            type: "GET",
            success: function (groups) {
                const tbody = $('#objectTable tbody');
                tbody.empty();

                groups.forEach(group => {
                    tbody.append(`
                        <tr>
                            <td>${group.displayName || ''}</td>
                            <td>${group.groupTypes ? group.groupTypes.join(', ') : ''}</td>
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

    $('#menu-users').click(function () {
        setTableHeader(['Display Name', 'User Principal Name', 'ID']);
        loadUsers();
    });

    $('#menu-groups').click(function () {
        setTableHeader(['Group Name', 'Group Type', 'ID']);
        loadGroups();
    });

    $('#menu-applications').click(function () {
    });

});
