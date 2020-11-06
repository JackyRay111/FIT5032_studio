$(function () {
    var today = new Date()

    var dataTable = $('#dtable').DataTable();

    $('#datepicker').datepicker({
        defaultViewDate: today,
        format: "dd/mm/yyyy",
        startDate: today
    })

    $('#datepicker').on('keyup click change', function () {
        var v = $(this).val();
        dataTable.search(v).draw();
    });
    //$('#datepicker').datepicker('show');
});