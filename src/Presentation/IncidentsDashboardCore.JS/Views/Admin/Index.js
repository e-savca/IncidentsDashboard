$(document).ready(function () {
    initializeDataTable();

});
function initializeDataTable() {
    /*    $('#usersTable').destroy();*/

    $('#usersTable').dataTable(
        {
            /*serverSide: true,*/
            'autoWidth': true,
            'ajax': {
                'url': '/Admin/GetUsersListAsync',
                'type': 'GET',
                'datatype': 'json',
                'dataSrc': ''
            },
            'columns': [
                { data: 'Id', visible: false },
                { 'data': 'Username' },
                { 'data': 'FirstName' },
                { 'data': 'LastName' },
                { 'data': 'Email' },
                {
                    'data': null,
                    // disable sorting for this column
                    'orderable': false,
                    'render': function (data, type, row) {
                        let isChecked = '';
                        if (row.IsActive) {
                            isChecked = 'checked';
                        }
                        return '<div class="form-check form-switch"><input class="form-check-input" type="checkbox" value="" ' + isChecked + ' disabled></div>';
                    }
                },
                {
                    'data': 'UserRoles',
                    'render': function (data, type, row) {
                        return data.join(', ');

                    }
                },
                {
                    'data': null,
                    orderable: false,
                    'render': function (data, type, row) {
                        return '<a href="#Admin/Edit/' + row.Id + '" class="btn btn-info">Edit</a>';
                    }
                },
                {
                    'data': null,
                    orderable: false,
                    'render': function (data, type, row) {
                        return '<a href="#Admin/Details/' + row.Id + '" class="btn btn-secondary">Details</a>';
                    }
                }
            ]
        }
    );
}