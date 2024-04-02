export const defaultTable = (
    tableId,
    controller,
    action,
    tableColumns,
    _scrollX = true,
    _stateSave = true,
    _autoWidth = true
    ) => {
    $('#' + tableId).dataTable(
        {
            scrollX: _scrollX,
            stateSave: _stateSave,
            autoWidth: _autoWidth,
            'ajax': {
                'url': '/' + controller + '/' + action,
                'type': 'GET',
                'datatype': 'json',
                'dataSrc': ''
            },
            columns: tableColumns
        }
    );
};