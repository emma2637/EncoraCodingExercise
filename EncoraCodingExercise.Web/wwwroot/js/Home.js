$(document).ready(function () {
    var grid, editManager;

    editManager = function (value, record, $cell, $displayEl, id, $grid) {
        var data = $grid.data(),
            $edit = $('<button class="btn btn-sm btn-default" data-bs-toggle="tooltip" title="Edit"><i class="fas fa-pen"></i></button>').attr('data-key', id),
            $update = $('<button class="btn btn-sm btn-default"><i class="fas fa-check"></i></button>').attr('data-key', id).hide(),
            $cancel = $('<button class="btn btn-sm btn-default"><i class="fas fa-times"></i> </button>').attr('data-key', id).hide();
        $edit.on('click', function (e) {
            $grid.edit($(this).data('key'));
            $edit.hide();
            $update.show();
            $cancel.show();
        });

        $update.on('click', function (e) {
            $grid.update($(this).data('key'));
            $edit.show();
            $update.hide();
            $cancel.hide();
        });
        $cancel.on('click', function (e) {
            $grid.cancel($(this).data('key'));
            $edit.show();
            $update.hide();
            $cancel.hide();
        });
        $displayEl.empty().append($edit).append($update).append($cancel);
    }
    grid = $("#grid").grid({
        dataSource: $(this).data("source"),
        //autoGenerateColumns: true,
        inlineEditing: { mode: 'command', managementColumn: false },
        uiLibrary: 'bootstrap4',
        iconsLibrary: 'fontawesome',
        responsive: true,
        primaryKey: "id",
        resizableColumns: true,
        columns: [
            { field: "id", width: 50 },
            { field: "address", width: 150,type:'',editor:true},
            { field: "yearBuilt", width: 100, editor: true,decimalDigitis:2},
            { field: "listPrice", width: 100, editor: true},
            { field: "montlyRent", width: 100, editor: true},
            { field: "grossYield", width: 100, editor: true},
            { width: 100, align: 'center', renderer: editManager }
        ],
    });

    function update(data) {
        $.ajax({ url: '/Players/Save', data: { record: data }, method: 'POST' })
            .fail(function () {
                alert('Failed to save.');
            });

    }

    //grid = $("#grid").grid({
    //    dataSource: $(this).data("source"),
    //    uiLibrary: "bootstrap4",
    //    primaryKey: 'ID',
    //    inlineEditing: { mode: 'command' },
    //    columns: [
    //{ field: "Id", width: 50},
    //{ field: "Address", editor: true },
    //{ field: "YearBuilt", title: "Year of Built", editor: true },
    //{ field: "ListPrice", title: "List of Price", editor: true },
    //{ field: "MontlyRent", title: "Monthly Rent", editor: true },
    //        { field: "GrossYield", title: "Gross of Yield", editor: true, editor: false }
    //    ],
    //});
    //grid.on('rowDataChanged', function (e, id, record) {
    //    // Clone the record in new object where you can format the data to format that is supported by the backend.
    //    var data = $.extend(true, {}, record);
    //    // Format the date to format that is supported by the backend.
    //    data.DateOfBirth = gj.core.parseDate(record.DateOfBirth, 'mm/dd/yyyy').toISOString();
    //    // Post the data to the server
    //    $.ajax({ url: '/Players/Save', data: { record: data }, method: 'POST' })
    //        .fail(function () {
    //            alert('Failed to save.');
    //        });
    //});
    //grid.on('rowRemoving', function (e, $row, id, record) {
    //    if (confirm('Are you sure?')) {
    //        $.ajax({ url: '/Players/Delete', data: { id: id }, method: 'POST' })
    //            .done(function () {
    //                grid.reload();
    //            })
    //            .fail(function () {
    //                alert('Failed to delete.');
    //            });
    //    }
    //});
});

