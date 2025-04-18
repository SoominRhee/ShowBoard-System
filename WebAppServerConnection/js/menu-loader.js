$(function () {
    $("#menu-placeholder").load("/Views/Shared/menu.html", function () {
        // 비동기 로딩 끝났을 때 이벤트 위임 등록
        $(document).on("click", ".menu-bar", function () {
            $(this).next().slideToggle();
        });
    });
});
