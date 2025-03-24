$(document).ready(function () {
    console.log("페이지로드");
    //alert("페이지 로드");
    $.ajax({
        url: "../Performance/GetCategoryList",
        type: "Get",
        dataType: "json",
        success: function (data) {
            console.log("요청성공");
            //alert("카테고리 정보를 불러오는데 성공했습니다.")
            var listBody = $("#categoryList");
            listBody.empty();
            
            listBody.append("<h4>Category</h4>");
            $.each(data, function (index, item) {
                var categoryName =
                `<label class="category-label" data-category="${item}">${item}</label>`
                listBody.append(categoryName);
            });
        },
        error: function () {
            console.log("요청 실패");
            //alert("카테고리 정보를 불러오는데 실패했습니다.")
        }
    });
});


$(document).on("click", ".category-label", function () {
    const category = $(this).data("category");
    console.log(category);
    $("#performanceBox h4").remove(); 
    $("#performanceBox").prepend(`<h4>Category: ${category}</h4>`);
    $.ajax({
        url: "../Performance/GetPerformanceListByCategory",
        type: "Get",
        data: { category: category },
        dataType: "json",
        success: function (data) {
            console.log("요청 성공");
            
            var tableBody = $("#performanceTableBody");
            tableBody.empty();
            $("#performanceTableHead").empty();
            $("#performanceTableHead").append(`
                        <tr>
                            <th>공연일자</th>
                            <th>Category</th>
                            <th>Artist</th>
                            <th>장소</th>
                            <th>공연내용</th>
                            <th>링크</th>
                            <th>예약</th>
                        </tr>
                    `);

            $.each(data, function (index, item) {
                //console.log(item.IsAvailableNum);
                var row =
                    `<tr data-id="${item.ID}">
                            <td>${item.Date}</td>
                            <td>${item.Category}</td>
                            <td>${item.Artist}</td>   
                            <td>${item.Location}</td>
                            <td>${item.IsAvailableNum}</td>
                            <td>${item.ReservationNum}</td>
                            <td><button class="info-btn">정보</td>
                        </tr>`;
                tableBody.append(row);
            });
        },
        error: function () {
            console.log("요청실패");
            alert("공연 정보를 불러오는데 실패했습니다.");
        }
    });
});


$(document).on("click", ".info-btn", function (event) {

    //console.log("버튼 클릭 이벤트 실행");
    //alert("버튼 클릭")
    var row = $(this).closest("tr");
    var performanceId = row.data("id");

    $.ajax({
        url: "../Reservation/GetUserListByPerformanceId",
        type: "Get",
        data: { id: performanceId },
        //beforeSend: function () {
        //    console.log("🚀 AJAX 요청 전송 준비 완료!");
        //    alert("요청준비완료");
        //},
        success: function (data) {
            var tableBody = $("#infoTableBody");
            tableBody.empty();
            $("#infoTableHead").empty();
            $("#infoTableHead").append(`
                        <tr>
                            <th>UserID</th>
                            <th>Username</th>
                            <th>ReservationDate</th>
                        </tr>
                    `);

            $.each(data, function (index, item) {
                //console.log(item.IsAvailableNum);
                //alert("IsAvailableNum 값 확인");
                var row =
                    `<tr data-id="${item.UserID}">
                            <td>${item.UserID}</td>
                            <td>${item.Username}</td>
                            <td>${item.ReservationDate}</td>
                        </tr>`;
                console.log(row);
                tableBody.append(row);
            });
        },
        error: function () {
            alert("요청 실패");
        }
    });

});
