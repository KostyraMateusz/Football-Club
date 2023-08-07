$(document).ready(function () {
    $("#klub option[value='']").prop('disabled', true);

    $("#klub").change(function () {
        $("#klub option[value='']").prop('disabled', true);
        var selectedZarzadId = $(this).val();
        $.ajax({
            url: 'DajPracownikowZarzadu',
            type: 'GET',
            data: { id: selectedZarzadId },
            success: function (data) {
                $("#Pracownicy").empty();
                $.each(data, function (index, pracownik) {
                    $("#Pracownicy").append($('<option>', {
                        value: pracownik.idPracownik,
                        text: pracownik.imie + ' ' + pracownik.nazwisko
                    }));
                });
            }
        });
    });
});