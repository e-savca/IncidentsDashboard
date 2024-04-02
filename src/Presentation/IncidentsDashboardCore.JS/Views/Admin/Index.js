// import module    
import { defaultTable } from '/IDCore.JS/Datatables/defaultTable';

export const GetUserList = () => {
    defaultTable(
        'usersTable',
        'Admin',
        'GetUsersListAsync',
        _columns
    );
};

var _columns = [
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
        title: 'User roles',
        'render': function (data, type, row) {
            return data.join(', ');

        }
    },
    {
        data: null,
        title: '',
        orderable: false,
        'render': function (data, type, row) {
            return '<a href="#Admin/Edit/' + row.Id + '" class="btn btn-info">Edit</a>';
        }
    },
    {
        data: null,
        title: '',
        orderable: false,
        'render': function (data, type, row) {
            return '<a href="#Admin/Details/' + row.Id + '" class="btn btn-secondary">Details</a>';
        }
    }
];