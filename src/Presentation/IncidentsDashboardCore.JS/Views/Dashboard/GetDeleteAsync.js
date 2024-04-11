export const GetDeleteAsync = (
    modal
) => {

    // send data to server and handle response
    document.getElementById('deleteIncidentForm').addEventListener('submit', function (e) {
        e.preventDefault();

        // Get the value of the input with id "Id"
        var idValue = document.getElementById("Id").value;

        $.ajax({
            url: this.action,
            type: this.method,
            contentType: 'application/json', // Specify content type as JSON
            headers: {
                '__RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            },
            data: JSON.stringify({ Id: idValue }), // Convert data to JSON string
            success: function (data) {
                if (data.success) {
                    window.location.href = '#Dashboard';
                    modal.hide();
                } else {
                    // in case that the incident was not deleted
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error("AJAX Error:", textStatus, errorThrown);
                // Handle errors (display an error message, etc.)
            }
        });


        //// Get the value of the input with id "Id"
        //var idValue = document.getElementById("Id").value;

        //fetch(this.action, {
        //    method: this.method,
        //    body: JSON.stringify({ Id: idValue }),
        //    headers: {
        //        'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
        //    }
        //})
        //    .then(response => response.json())
        //    .then(data => {
        //        if (data.success) {
        //            window.location.href = '#Dashboard';
        //            modal.hide();
        //        }
        //        else {
        //            // in case that the incident was not deleted

        //        }
        //    });
    });
};

