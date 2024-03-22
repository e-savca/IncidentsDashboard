$(document).ready(function () {
    initializeDataTable();

});
function initializeDataTable() {
    $('#incidentsTable').dataTable(
        {
            'autoWidth': true,
            'ajax': {
                'url': '/Dashboard/GetIncidentsListAsync',
                'type': 'GET',
                'datatype': 'json',
                'dataSrc': ''
            },
            'columns': [
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
                },               
                {
                    'data': null,
                    title : '',
                    orderable: false,
                    'render': function (data, type, row) {
                        return '<a href="#Dashboard/Edit/' + row.Id + '" class="btn btn-info">Edit</a>';
                    }
                },
                {
                    'data': null,
                    title: '',
                    orderable: false,
                    'render': function (data, type, row) {
                        return '<a href="#Dashboard/Details/' + row.Id + '" class="btn btn-secondary">Details</a>';
                    }
                },
                {
                    'data': null,
                    title: '',
                    orderable: false,
                    'render': function (data, type, row) {
                        return '<a href="#Dashboard/Delete/' + row.Id + '" class="btn btn-danger">Delete</a>';
                    }
                }
            ]
        }
    );
}