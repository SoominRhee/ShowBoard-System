$(document).ready(function () {
    $("#btnLogin").click(function () {
        let username = $("#username").val();
        let password = $("#password").val();
        let isAdLogin = $("#isAdLogin").is(":checked");

        $.ajax({
            url: "../Account/Login",
            type: "Post",
            data: { Username: username, Password: password, IsADLogin: isAdLogin},
            success: function (response) {
                if (response.success) {
                    alert(response.message)
                    window.location.href = "MainWindow.aspx";
                } else {
                    alert(response.message);
                    window.location.href = "Login.aspx"
                }
            },
            error: function () {
                //var message = "서버오류";
                alert("서버 오류가 발생했습니다.");
                //$("#resultContainer").html("<p style='color: red;'>서버 오류가 발생했습니다.</p>");
            }
        });
    });
});
