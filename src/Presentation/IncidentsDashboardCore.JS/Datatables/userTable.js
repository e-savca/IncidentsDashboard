export const userTable = () => {
    var table = $('#usersTable').DataTable(
        {
            select: 'single',
            "columnDefs": [
                {
                    "className": "text-center custom-middle-align",
                    targets: [1, 2, 3, 4, 5, 6]
                }
            ],
            processing: true,
            serverSide: true,
            scrollX: true,
            stateSave: true,
            autoWidth: true,
            order: [[0, 'desc']],
            ajax: {
                'url': '/Admin/GetUsersListAsync',
                'type': 'POST',
                'datatype': 'json'
            },
            columns: [
                {
                    data: 'Id',
                    visible: false,
                    title: 'Id'
                },
                {
                    data: 'Username',
                    title: 'Username'
                },
                {
                    data: 'FirstName',
                    title: 'First Name'
                },
                {
                    data: 'LastName',
                    title: 'Last Name'
                },
                {
                    data: 'Email',
                    title: 'Email'
                },
                {
                    data: null,
                    title: 'Is Active',
                    // disable sorting for this column
                    orderable: false,
                    render: function (data, type, row) {
                        let isChecked = '';
                        if (row.IsActive) {
                            isChecked = 'checked';
                        }
                        return '<div class="form-check form-switch"><input class="form-check-input" type="checkbox" value="" ' + isChecked + ' disabled></div>';
                    }
                },
                {
                    data: 'UserRoles',
                    title: 'User Roles',
                    orderable: false,
                    'render': function (data, type, row) {
                        return data.join(', ');

                    }
                }
            ]
        }
    );

    $('#usersTable tbody').contextMenu({
        selector: 'tr',
        trigger: 'right',
        callback: function (key, options) {

            let row = table.row(options.$trigger);
            row.select();

            switch (key) {
                case 'details':
                    window.location.href = "#Admin/Details/" + row.data()["Id"];
                    break;
                case 'edit':
                    window.location.href = "#Admin/Edit/" + row.data()["Id"];
                    break;
                default:
                    break
            }
        },
        items: {
            "edit": {
                name: "Edit"
            },
            "details": {
                name: "Details"
            }
        }
    });
};

