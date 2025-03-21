$(document).ready(function () {
    $(".create-btn").click(function () {
        let summary = $("#summary").val();
        let details = $("#details").val();
        let date = $("#date").val();

        $.ajax({
            url: "../Board/CreateBoardPost",
            type: "Post",
            data: { summary: summary, details: details, date: date },
            success: function (response) {
                if (response.success) {
                    alert("등록 성공");
                    window.location.href = "BoardList.aspx";
                } else {
                    alert("등록 실패");
                }
            },
            error: function () {
                alert("요청 실패");
            }
        });

    });
});