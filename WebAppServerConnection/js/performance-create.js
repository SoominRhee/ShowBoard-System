$(document).ready(function () {
    $(".create-btn").click(function () {
        let category = $("#category").val();
        let artist = $("#artist").val();
        let details = $("#details").val();
        let location = $("#location").val();
        let date = $("#date").val();
        //date = formatDateToKorean(date);

        let link = $("#link").val();
        let available = $("#available").val();
        console.log(category, artist, details, location, date, link, available);

        $.ajax({
            url: "../Performance/CreatePerformance",
            type: "Post",
            data: { date: date, category: category, artist: artist, location: location, details: details, link: link, availableNum: available },
            beforeSend: function () {
                 //console.log("AJAX 요청 전송 준비 완료");
                 //alert("요청준비완료");
            },
            success: function (response) {
                if (response.success) {
                    alert("등록 성공");
                    window.location.href = "PerformanceList.aspx";
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
