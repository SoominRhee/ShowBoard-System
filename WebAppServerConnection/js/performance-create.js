$(document).ready(function () {
    $(".create-btn").click(function () {
        let artist = $("#artist").val();
        let details = $("#details").val();
        let location = $("#location").val();
        let date = $("#date").val();
        //date = formatDateToKorean(date);

        let link = $("#link").val();
        let available = $("#available").val();
        console.log(artist, details, location, date, link, available);

        $.ajax({
            url: "../Performance/CreatePerformance",
            type: "Post",
            data: { date: date, artist: artist, location: location, details: details, link: link, availableNum: available },
            beforeSend: function () {
                 //console.log("🚀 AJAX 요청 전송 준비 완료!");
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



function formatDateToKorean(dateString) {
    let date = new Date(dateString); // "yyyy-MM-dd"를 Date 객체로 변환
    let year = date.getFullYear();
    let month = (date.getMonth() + 1).toString().padStart(2, "0"); // 01~12월
    let day = date.getDate().toString().padStart(2, "0"); // 01~31일

    return `${year}년${month}월${day}일`;
}