var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#SearchString").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/User/ListName",
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
        $(function () {
            $('#AlertBox').removeClass('hide');
            $('#AlertBox').delay(5000).slideUp(500);
        });

        $('#UserTypeId').on('change', function (event) {
            var form = $(event.target).parents('form');
            form.submit();
        });
    }
}
common.init();