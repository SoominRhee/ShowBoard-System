$(document).ready(function () {
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

    loadADTree();

    $(document).on("click", ".tree-toggle", function () {
        const $li = $(this).closest("li");
        const $nested = $li.children(".nested");

        const isOpening = !$nested.hasClass("active");

        if (!isOpening) {
            $nested.find(".active").removeClass("active");
            $nested.find(".caret-down").removeClass("caret-down");
        }


        if ($nested.children(".dummy").length > 0) {
            const dn = $(this).data("dn");

            $.ajax({
                url: "../AD/GetChildNodes",
                type: "GET",
                data: { dn: dn },
                dataType: "json",
                success: function (res) {
                    //alert("자식 노드 불러옴");

                    $nested.empty();

                    if (res.length > 0) {
                        res.forEach(child => {
                            const html = `<li>
                                        <span class="tree-toggle caret" data-dn="${child.DistinguishedName}" data-type="${child.SchemaClassName}"></span>
                                        <span class="node-label" data-dn="${child.DistinguishedName}" data-type="${child.SchemaClassName}">${child.Name}</span>
                                        <ul class="nested">
                                            <li class = "dummy"></li>
                                        </ul>
                                    </li>`
                            $nested.append(html);
                        });
                    } else {
                        $nested.remove();
                        $li.find(".tree-toggle").removeClass("caret");
                    }
                },
                error: function () {
                    alert("자식 노드 불러오기 실패");
                }
            })
        }
        $nested.toggleClass("active");
        $(this).toggleClass("caret-down");

    });


    $(document).on("click", ".node-label", function () {
        const dn = $(this).data("dn");

        $.ajax({
            url: "../AD/GetChildrenFlat",
            type: "GET",
            dataType: "json",
            data: { dn: dn },
            success: function (res) {
                let html = "";

                res.forEach(obj => {
                    html += `<tr data-dn="${obj.DistinguishedName}">
                                <td>${obj.Name}</td>
                                <td>${obj.Type}</td>
                                <td>${obj.Description}</td>
                            </tr>`;
                    console.log(obj.DistinguishedName, obj.Name, obj.Type, obj.Description);
                });

                $(".main-table-body").html(html);
            },
            error: function () {
                alert("메인 정보 불러오기 실패");
            }
        });
    });


    $(document).on("dblclick", ".main-table-body tr", function () {
        const dn = $(this).data("dn");
        alert("상세 정보 가져오기")
        $.ajax({
            url: "../AD/GetDetails",
            type: "GET",
            data: { dn: dn },
            dataType: "json",
            success: function (res) {
                alert("상세 정보 가져오기 성공")

                let html = "";

                if (res.Name) html += `<p><strong>Name:</strong> ${res.Name}</p>`;
                if (res.Type) html += `<p><strong>Type:</strong> ${res.Type}</p>`;
                if (res.Description) html += `<p><strong>Description:</strong> ${res.Description}</p>`;
                if (res.DisplayName) html += `<p><strong>Display Name:</strong> ${res.DisplayName}</p>`;
                if (res.DistinguishedName) html += `<p><strong>DN:</strong> ${res.DistinguishedName}</p>`;
                if (res.Guid) html += `<p><strong>GUID:</strong> ${res.Guid}</p>`;
                if (res.SamAccountName) html += `<p><strong>Account:</strong> ${res.SamAccountName}</p>`;
                if (res.Mail) html += `<p><strong>Email:</strong> ${res.Mail}</p>`;
                if (res.Created) html += `<p><strong>Created:</strong> ${res.Created}</p>`;

                $("#detail-box .detail-content").append(html);
                $("#detail-box").fadeIn();
            },
            error: function () {
                alert("상세 정보 조회 실패");
            }
        });
    });


    $(document).on("click", ".close-btn", function () {
        $("#detail-box").fadeOut();
        $("#detail-box .detail-content").html(`<span class="close-btn">&times;</span>`);
    });

});


function loadADTree() {
    $.ajax({
        url: "../AD/GetRootNodes",
        type: "GET",
        dataType: "json",
        success: function (res) {
            //alert("루트 노드 불러옴");
            let html = "";

            res.forEach(n => {
                html += `<li>
                            <span class="tree-toggle caret" data-dn="${n.DistinguishedName}" data-type="${n.SchemaClassName}"></span>
                            <span class="node-label" data-dn="${n.DistinguishedName}" data-type="${n.SchemaClassName}">${n.Name}</span>
                            <ul class="nested">
                                <li class="dummy"></li>
                            </ul>
                        </li>`
            });

            console.log("html 내용: " + html);

            $(".tree-view").html(html);
        },
        error: function () {
            alert("루트 노드 불러오기 실패");
        }
    })
}