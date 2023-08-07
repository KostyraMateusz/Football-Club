$(document).ready(function () {
    $("#klub option[value='']").prop('disabled', true);

    $("#klub").change(function () {
        $("#klub option[value='']").prop('disabled', true);
    });

    $("#klub").change(function () {
        var selectedZarzadId = $(this).val();
        $.ajax({
            url: 'DajCeleZarzadu',
            type: 'GET',
            data: { id: selectedZarzadId },
            success: function (data) {
                console.log(data);
                $("#Cele").val(data);
            }
        });
    });
});