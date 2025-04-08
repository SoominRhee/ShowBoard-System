$(document).ready(function () {
    $.ajax({
        url: "../Performance/GetPerformanceData",
        type: "Get",
        dataType: "json",
        success: function (data) { 
            //console.log("서버 응답:", data);

            let remainingSeats = data.IsAvailableNum - data.ReservationNum;

            let reserveBtn = remainingSeats <= 0
                ? `<button class="reservation-btn" disabled>예약 불가</button>`
                : `<button class="reservation-btn">예약</button>`;

            document.getElementById("info").innerHTML = `
            <div class="details-box">
                ${data.Details.replace(/\n/g, "<br>")}
            </div>

            <p class="info">공연장소 : ${data.Location}</p>
            <p class="info">공연일정 : ${data.Date}</p>
            <label for="reservationDate">예약 :</label>
            <input type="date" id="reservationDate" class="date-input">
            <div class="button-container">
                ${reserveBtn}
            </div>
            `
        },
        error: function () {
            alert("요청 실패")
        }
    });
});

$(document).on("click", ".reservation-btn", function () {
    $.ajax({
        url: "../Reservation/CreateReservation",
        type: "Post",
        success: function (response) {
            //alert("응답받음");
            //console.log(response);
            if (response.success) {
                alert("예약 성공");
                window.location.href = "ReservationList.aspx";
            } else {
                alert("예약 실패");
            }
        },
        error: function () {
            alert("요청 실패");
        }
    });
});