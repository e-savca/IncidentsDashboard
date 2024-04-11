export const GetCreateAsync = () => {
    $("#OriginId").change(function () {
        var selectedOriginId = $(this).val();

        $.ajax({
            url: '/Dashboard/GetAmbitListByOriginIdAsync/', 
            type: "GET",
            data: { id: selectedOriginId },
            success: function (data) {
                $("#AmbitId").empty().append($("<option>", { value: "" }).text("Select Ambit"));
                $.each(data, function (index, item) {
                    $("#AmbitId").append($("<option>", { value: item.Id }).text(item.Name)); 
                });
                // Clear Incident Type options (optional)
                $("#IncidentTypeId").empty().append($("<option>", { value: "" }).text("Select Incident Type"));

            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error("AJAX Error:", textStatus, errorThrown);
            }
        });
    });

    $("#AmbitId").change(function () {
        var selectedAmbitId = $(this).val();

        $.ajax({
            url: "/Dashboard/GetIncidentTypeListByAmbitIdAsync", // Replace with your actual URL
            type: "GET",
            data: { id: selectedAmbitId },
            success: function (data) {
                $("#IncidentTypeId").empty().append($("<option>", { value: "" }).text("Select Incident Type"));
                $.each(data, function (index, item) {
                    $("#IncidentTypeId").append($("<option>", { value: item.Id }).text(item.Name)); // Adjust property names as needed
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error("AJAX Error:", textStatus, errorThrown);
                // Handle errors
            }
        });
    });



    // send data to server and handle response
    document.getElementById('createIncidentForm').addEventListener('submit', function (e) {
        e.preventDefault();

        var formData = new FormData(this);

        fetch(this.action, {
            method: this.method,
            body: formData,
            headers: {
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    window.location.href = '#Dashboard';
                }
                else {
                    // Display error messages
                    // foreach in data.message call appendAlert
                    clearAlertValidationMessage();
                    data.errors.forEach((item) => {
                        appendAlertValidationMessage(item.message, item.propertyName)
                    });

                    //appendAlertValidationMessage(data.message, data.messageType, data.element)
                }
            });
    });

    // Append alert message to the page
    const appendAlertValidationMessage = (message, element) => {
        // Find the validation span for the given element
        let validationSpan = document.querySelector(`span[data-valmsg-for="${element}"]`);

        // Set the error message and class
        validationSpan.textContent = message;
        validationSpan.className = `field-validation-error text-danger`;
    }

    // Clear append alert message
    const clearAlertValidationMessage = () => {
        // Find the validation span for all the elements
        let validationSpans = document.querySelectorAll(`span[data-valmsg-for]`);

        // Clear the error message and class
        validationSpans.forEach((item) => {
            item.textContent = '';
            item.className = '';
        });
    }

};