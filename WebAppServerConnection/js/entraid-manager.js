$(document).ready(function () {
    $.ajax({
        url: "../EntraID/GetUserList",
        type: "GET",
        success: function (users) {
            users.forEach(user => {
                $('#userTable tbody').append(`
                    <tr>
                        <td>${user.displayName || ''}</td>
                        <td>${user.mail || ''}</td>
                        <td>${user.userPrincipalName || ''}</td>
                    </tr>
                `);
            });
        },
        error: function () {
            alert("사용자 정보를 불러오는 데 실패했습니다.");
        }
    });
});