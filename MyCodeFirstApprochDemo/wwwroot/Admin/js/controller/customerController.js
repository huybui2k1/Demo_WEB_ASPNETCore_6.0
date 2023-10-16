var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#SearchString").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/Customer/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            focus: function (event, ui) {
                $("#SearchString").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#SearchString").val(ui.item.label);
                return false;
            }
        });
            /*.autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<a>" + item.label + "</a>")
                    .appendTo(ul);
            };*/
    }
}
common.init();

$(document).on("click", ".delete-link", function (e) {
    e.preventDefault();
    var id = $(this).data("id");
    var confirmMessage = $(this).data("confirm");

    $("#confirmMessage").text(confirmMessage);
    $("#confirmDelete").data("id", id); // Lưu trữ ID để sử dụng trong xử lý xóa

    $("#confirmModal").modal("show");
});
$(document).on("click", "#confirmDelete", function (e) {
    e.preventDefault();
    var id = $(this).data("id");
    //if (confirm($(this).data("confirm"))) {
    $.ajax({
        url: "/Admin/Customer/DeleteId/" + id,
        dataType: "json",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        success: function (res) {
            if (res.status == true) {
                window.location.href = '/Admin/Customer';
                //$("#getCodeModal").modal("toggle");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    //}
});
$(function () {
    $('#AlertBox').removeClass('hide');
    $('#AlertBox').delay(5000).slideUp(500);
});

$('#CityId').on('change', function (event) {
    var form = $(event.target).parents('form');
    form.submit();
});