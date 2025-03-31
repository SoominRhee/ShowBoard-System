//$(document).ready(function () {
//    $("#btnLogin").click(function () {
//        let username = $("#username").val();
//        let password = $("#password").val();

//        $.post("/Account/Login", { Username: username, Password: password })
//            .done(function (response) {
//                if (response.success) {
//                    //var message = "로그인 성공";
//                    //alert(message);
//                    alert(response.message)
//                    window.location.href = "MainWindow.aspx";
//                } else {
//                    //var message = "아이디 또는 비밀번호가 잘못되었습니다.";
//                    //alert(message);
//                    alert(response.message);
//                    window.location.href = "LoginFail.aspx";
//                }
//            })
//            .fail(function () {
//                //var message = "서버오류";
//                //alert(message);
//                $("#resultContainer").html("<p style='color: red;'>서버 오류가 발생했습니다.</p>");
//            });
//    });
//});

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
                    window.location.href = "LoginFail.aspx"
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
