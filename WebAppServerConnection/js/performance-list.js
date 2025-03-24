$(document).ready(function () {
    loadPerformanceList("");

    $(".search-btn").click(function () {
        let keyword = $(".search-box").val();
        loadPerformanceList(keyword);
    });
    
});

function loadPerformanceList(keyword) {
    $.ajax({
        url: "../Performance/GetPerformanceList",
        type: "Get",
        data: { keyword: keyword },
        dataType: "json",
        success: function (data) {
            var tableBody = $("#performanceTableBody");
            tableBody.empty();

            $.each(data, function (index, item) {
                var row =
                    `<tr data-id="${item.ID}">
                        <td>${item.Date}</td>
                        <td>${item.Category}</td>
                        <td>${item.Artist}</td>
                        <td>${item.Location}</td>
                        <td>${item.Details.replace(/\n/g, "<br>")}</td>
                        <td>${item.Link}</td>
                        <td><button class="reservation-btn">예약</td>
                    </tr>`;
                tableBody.append(row);
            });
            //console.log("추가된 버튼 개수:", $(".reservation-btn").length);
        },
        error: function () {
            alert("공연 정보를 불러오는데 실패했습니다.");
        }
    });
}

$(document).on("click", ".reservation-btn", function (event) {
    
    //console.log("버튼 클릭 이벤트 실행");
    //alert("버튼 클릭")
    var row = $(this).closest("tr");
    var performanceId = row.data("id");

    $.ajax({
        url: "../Performance/SavePerformanceId",
        type: "Post",
        data: { id: performanceId },
        //beforeSend: function () {
        //    console.log("🚀 AJAX 요청 전송 준비 완료!");
        //    alert("요청준비완료");
        //},
        success: function (response) {
            //console.log("AJAX 요청 성공:", response);
            //alert("요청성공");

            if (response.success) {
                //console.log("페이지 이동 실행");
                //alert("페이지 이동 준비 완료");
                window.location.href = "PerformanceReservation.aspx";

            } else {
                //console.error("서버 응답 success 값이 false")
                alert("예약 오류");
            }
        },
        error: function () {
            alert("요청 실패");
        }
    });
    
});


