var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#SearchString").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Admin/Product/ListName",
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


        // Add the following code if you want the name of the file appear on select
        /*       $(".custom-file-input").on("change", function () {
                   *//*$(this).siblings('#btnUpload').removeClass('hidden');*//*
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
        
    });*/


    }
}
common.init();