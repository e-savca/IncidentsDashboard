$(document).ready(function () {
    initializeDataTable();
});
function initializeDataTable() {
    $('#usersTable').DataTable(
        {
            /*serverSide: true,*/
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
                        return '<button class="btn btn-info" onclick="editUser(' + row.Id + ')">Edit</button>';
                    }
                },
                {
                    'data': null,
                    orderable: false,
                    'render': function (data, type, row) {
                        return '<button class="btn btn-danger" onclick="deleteUser(' + row.Id + ')">Delete</button>';
                    }
                }
            ]
        }
    );
}


function editUser(userId) {
    alert('Edit user with id: ' + userId);
}

function deleteUser(userId) {
    alert('Delete user with id: ' + userId);
}