$(document).ready(function () {
    $("#recordsPerPage").change(function () {
        var selectedValue = $(this).val();
        // Aquí agregar la lógica para mostrar el número de registros seleccionados.
    });

    $("#search").on("input", function () {
        var searchValue = $(this).val().toLowerCase();
        $("table tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(searchValue) > -1)
        });
    });
});