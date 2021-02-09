$(document).ready(function () {
    var grid, editManager;

    editManager = function (value, record, $cell, $displayEl, id, $grid) {
        var data = $grid.data(),
            $edit = $('<button class="btn btn-sm btn-default" data-bs-toggle="tooltip" title="Edit"><i class="fas fa-pen"></i></button>').attr('data-key', id).attr("data-record",record),
            $update = $('<button class="btn btn-sm btn-default"><i class="fas fa-check"></i></button>').attr('data-key', id).attr("data-record", record).hide(),
            $cancel = $('<button class="btn btn-sm btn-default"><i class="fas fa-times"></i> </button>').attr('data-key', id).attr("data-record", record).hide();
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

    grid.on('rowDataChanged', function (e, id, record) {
        // Clone the record in new object where you can format the data to format that is supported by the backend.
        var data = $.extend(true, {}, record);
        //get update url
        var uri = $(this).data("save");
        // Post the data to the server
        $.ajax({ url: uri, data: { property: data }, method: 'POST' })
            .fail(function () {
                alert('Failed to save.');
            });
    });

    
});

