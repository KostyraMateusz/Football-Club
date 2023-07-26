$(document).ready(function () {
    $("#klub option[value='']").prop('disabled', true);

    $("#klub").change(function () {
        $("#klub option[value='']").prop('disabled', true);
    });

    var culture = "en-US";
    var numberFormat = new Intl.NumberFormat(culture, {
        style: "decimal",
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
        useGrouping: true
    });

    $("#klub").change(function () {
        var selectedZarzadId = $(this).val();
        $.ajax({
            url: 'DajBudzetZarzadu',
            type: 'GET',
            data: { id: selectedZarzadId },
            success: function (data) {
                var formattedBudzet = numberFormat.format(parseFloat(data));
                $("#Budzet").val(formattedBudzet);
            }
        });
    });
});