//$(document).ready(function () {
//    $.ajax({
//        url: "../Board/GetBoardList",
//        type: "Get",
//        dataType: "json",
//        success: function (data) {
//            var tableBody = $("#postTableBody");
//            tableBody.empty();

//            $.each(data, function (index, item) {
//                var row =
//                    `<tr data-id="${item.ID}">
//                        <td>${item.Date}</td>
//                        <td>${item.Organizer}</td>
//                        <td>${item.Summary}</td>
//                        <td>${item.Details.replace(/\n/g, "<br>")}</td>
//                        <td>${item.DisplayPeriod}</td>
//                        <td><button class="delete-btn">제거</td>
//                    </tr>`;
//                tableBody.append(row);
//            });
//        },
//        error: function () {
//            alert("공연 정보를 불러오는데 실패했습니다.");
//        }
//    });
//});

//$(document).on("click", ".delete-btn", function () {
//    var row = $(this).closest("tr");
//    var postId = row.data("id");

//    $.ajax({
//        url: "../Board/DeleteBoardPost",
//        type: "Post",
//        data: {id: postId},
//        success: function (response) {
//            if (response.success) {
//                row.remove();
//            } else {
//                alert("삭제 실패");
//            }
//        },
//        error: function () {
//            alert("요청 실패");
//        }

//    });
//});


$(document).ready(function () {
    loadBoardList("");

    $(".search-btn").click(function () {
        let keyword = $(".search-box").val();
        loadBoardList(keyword);
    });

    // ✅ 게시글 리스트 불러오기 (검색 포함)
    function loadBoardList(keyword) {
        $.ajax({
            url: "../Board/GetBoardList",
            type: "GET",
            data: { keyword: keyword }, // 서버에 검색어 전달
            dataType: "json",
            success: function (data) {
                var tableBody = $("#postTableBody");
                tableBody.empty(); // 기존 데이터 삭제

                $.each(data, function (index, item) {
                    var row =
                        `<tr data-id="${item.ID}">
                            <td>${item.Date}</td>
                            <td>${item.Organizer}</td>
                            <td>${item.Summary}</td>
                            <td>${item.Details.replace(/\n/g, "<br>")}</td>
                            <td>${item.DisplayPeriod}</td>
                            <td><button class="delete-btn">제거</button></td>
                        </tr>`;
                    tableBody.append(row);
                });
            },
            error: function () {
                alert("게시글을 불러오는 데 실패했습니다.");
            }
        });
    }

    // ✅ 삭제 버튼 클릭 시 삭제 요청
    $(document).on("click", ".delete-btn", function () {
        var row = $(this).closest("tr");
        var postId = row.data("id");

        $.ajax({
            url: "../Board/DeleteBoardPost",
            type: "POST",
            data: { id: postId },
            success: function (response) {
                if (response.success) {
                    row.remove();
                } else {
                    alert("삭제 실패");
                }
            },
            error: function () {
                alert("삭제 요청 실패");
            }
        });
    });
});
