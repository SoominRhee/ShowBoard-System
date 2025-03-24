$(document).ready(function () {
    loadReservationList();

    $(".search-btn").click(function () {
        let keyword = $(".search-box").val();
        loadReservationList(keyword);
    });
});

function loadReservationList(keyword) {
    $.ajax({
        url: "../Reservation/GetReservationList",
        type: "Get",
        data: { keyword: keyword },
        dataType: "json",
        success: function (data) {
            var tableBody = $("#reservationTableBody");
            tableBody.empty();

            $.each(data, function (index, item) {
                //console.log(item.IsAvailableNum);
                //alert("IsAvailableNum 값 확인");
                var row =
                    `<tr data-id="${item.ID}">
                            <td>${item.Date}</td>
                            <td>${item.Category}</td>
                            <td>${item.Artist}</td>   
                            <td>${item.Location}</td>
                            <td>${item.IsAvailableNum}</td>
                            <td>${item.ReservationNum}</td>
                            <td><button class="detail-btn">상세</td>
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

$(document).on("click", ".detail-btn", function () {
    var row = $(this).closest("tr");
    var performanceId = row.data("id");
    console.log("선택된 공연 ID:", performanceId);

    $.ajax({
        url: "../Performance/GetPerformanceDetail",
        type: "Post",
        data: { id: performanceId },
        success: function (response) {
            console.log("서버 응답:", response);

            $("#detailContent").html(`
                <strong>공연 일자:</strong> ${response.Date}<br>
                <strong>Category:</strong> ${response.Category}<br>
                <strong>Artist:</strong> ${response.Artist}<br>
                <strong>장소:</strong> ${response.Location}<br>
                <strong>예약 좌석:</strong> ${response.isAvailableNum}<br>
                <strong>예약 완료:</strong> ${response.ReservationNum}
            `);

            $("#detailModal, .modal-overlay").fadeIn();
        },
        error: function () {
            alert("상세 정보를 불러오지 못했습니다.");
        }
    });
});

$(document).on("click", ".close, .modal-overlay", function () {
    $("#detailModal, .modal-overlay").fadeOut();
});