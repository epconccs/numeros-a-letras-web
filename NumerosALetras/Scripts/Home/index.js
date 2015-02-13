// Al cambiar texto hacer petición de convertir el número.
$('#txtNumero').keyup(function () {
    // Llamada a convertir el número.
    $.ajax({
        url: $('#ConvertirNumerosALetras').attr('data-url'),
        data: { numero : $(this).val() },
        success: function (data) {
            $('#lblLetra').html(data);
        }
    });
}); 