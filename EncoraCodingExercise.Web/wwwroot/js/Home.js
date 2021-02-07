$(document).ready(function () {
    $('#tbtEditable').SetEditable({
        onEdit:onEditRow(this)
    });

    onEditRow();
    onSaveRow();
})

function onEditRow(row) {
    //ajax call to edit
    console.log("row "+ row);


};