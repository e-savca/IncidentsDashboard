function initializeDataTable() {
    $('#usersTable').DataTable(
        {
            /*serverSide: true,*/
            "ajax": {
                "url": "/Admin/GetUsersListAsync",
                "type": "GET",
                "datatype": "json",
                "dataSrc": ""
            },
            "columns": [
                { "data": "Username" },
                { "data": "FirstName" },
                { "data": "LastName" },
                { "data": "Email" },
                { "data": "IsActive" },
                {
                    "data": "UserRoles",
                    "render": function (data, type, row) {
                        return data.join(", ");

                    }
                }
            ]
        }
    );
}
