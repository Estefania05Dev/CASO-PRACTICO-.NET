$(document).ready(function () {
    obtenerOpciones();
    $('#opciones').change(function () {
        var opcionSeleccionada = $(this).val();
    });
});

function obtenerOpciones() {
    $.ajax({
        url: '/Sede/ListarSedesJson',
        type: 'GET',
        success: function (data) {
            $.each(data, function (index, opcion) {
                /*$('#opciones').append($('<option>').text(opcion.Texto).attr('value', opcion.Valor));*/
            });
        },
        error: function () {
            console.log('Error al obtener las opciones del servidor');
        }
    });
}