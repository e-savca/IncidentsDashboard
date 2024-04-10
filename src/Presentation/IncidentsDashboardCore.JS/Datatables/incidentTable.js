export const incidentTable = () => {
    var table = $('#incidentsTable').DataTable(
        {
            //select: 'single',
            "columnDefs": [
                {
                    "className": "text-center custom-middle-align",
                    targets: [1, 2, 3, 4, 5, 6, 7]
                }
            ],
            processing: true,
            serverSide: true,
            scrollX: true,
            stateSave: true,
            autoWidth: true,
            order: [[0, 'desc']],
            ajax: {
                'url': '/Dashboard/GetIncidentsListAsync',
                'type': 'POST',
                'datatype': 'json'
            },
            columns: [
                {
                    data: 'Id',
                    visible: false,
                    title: 'ID'
                },
                {
                    data: 'CallCode',
                    title: 'Call Code'
                },
                {
                    data: 'SubsystemCode',
                    title: 'Subsystem Code'
                },
                {
                    data: 'OpenedDate',
                    title: 'Opened Date'
                },
                {
                    data: 'ClosedDate',
                    title: 'Closed Date'
                },
                {
                    data: 'RequestType',
                    title: 'Request Type'
                },
                {
                    data: 'ApplicationType',
                    title: 'Application Type'
                },
                {
                    data: 'Urgency',
                    title: 'Urgency'
                },
                {
                    data: 'SubCause',
                    visible: false,
                    title: 'Sub Cause'
                },
                {
                    data: 'Summary',
                    visible: false,
                    title: 'Summary'
                },
                {
                    data: 'Description',
                    visible: false,
                    title: 'Description'
                },
                {
                    data: 'Solution',
                    visible: false,
                    title: 'Solution'
                },
                {
                    data: 'OriginId',
                    visible: false,
                    title: 'Origin ID'
                },
                {
                    data: 'AmbitId',
                    visible: false,
                    title: 'Ambit ID'
                },
                {
                    data: 'IncidentTypeId',
                    visible: false,
                    title: 'Incident Type ID'
                },
                {
                    data: 'ScenarioId',
                    visible: false,
                    title: 'Scenario ID'
                },
                {
                    data: 'ThreatId',
                    visible: false,
                    title: 'Threat ID'
                }
            ]
        }
    );

    $('#incidentsTable tbody').contextMenu({
        selector: 'tr',
        trigger: 'right',
        callback: function (key, options) {

            let row = table.row(options.$trigger);

            switch (key) {
                case 'details':
                    window.location.href = "#Dashboard/Details/" + row.data()["Id"];
                    break;
                case 'edit':
                    window.location.href = "#Dashboard/Edit/" + row.data()["Id"];
                    break;
                case 'delete':
                    window.location.href = "#Dashboard/Delete/" + row.data()["Id"];
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
            },
            "delete": {
                name: "Delete"
            }
        }
    });
};

