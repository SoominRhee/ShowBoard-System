$(document).ready(function () {
    console.log("페이지로드");
    //alert("페이지 로드");
    $.ajax({
        url: "../Account/CheckAdmin",
        type: "GET",
        dataType: "json",
        success: function (response) {
            if (!response.isAdmin) {
                alert("관리자만 접근 가능합니다.");
                window.location.href = "MainWindow.aspx";
            } else {
                alert("관리자 확인");

                loadCategoryList();
            }
        },
        error: function () {
            alert("권한 확인 중 오류 발생");
            window.location.href = "Login.aspx";
        }
    });

    
});


$(document).on("click", ".category-label", function () {
    $("#userInfoTable thead").empty();
    $("#userInfoTable tbody").empty();
    const category = $(this).data("category");
    console.log(category);
    $("#performanceBox h3").remove(); 
    $("#performanceBox").prepend(`<h3 style="text-align: left; width: 100%;">Category: ${category}</h3>`);
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
                            <th>총 좌석 수</th>
                            <th>예약 현황</th>
                            <th>예약자</th>
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

function loadCategoryList() {
    $.ajax({
        url: "../Performance/GetCategoryList",
        type: "Get",
        dataType: "json",
        success: function (data) {
            console.log("요청성공");
            //alert("카테고리 정보를 불러오는데 성공했습니다.")
            var listBody = $("#categoryList");
            listBody.empty();

            listBody.append("<h3>Category</h3>");
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
}