export const GetUploadFileAsync = () => {
    document.getElementById('uploadFileForm').addEventListener('submit', function (e) {
        e.preventDefault();

        var formData = new FormData();
        var file = $('#formFile')[0].files[0];
        formData.append('file', file);

        //var formData = new FormData(this);

        var token = document.querySelector('input[name="__RequestVerificationToken"]').value;
        formData.append("__RequestVerificationToken", token);

        $.ajax({
            url: '/Dashboard/UploadCSVAsync',
            xhrFields: {
                withCredentials: true
            },
            data: formData,
            processData: false,
            contentType: false,
            type: "POST",
            success: function (response) {
                if (response.success) {
                    window.location.href = '#Dashboard';
                }
                else {
                    clearAlertValidationMessage();
                    data.errors.forEach((item) => {
                        appendAlertValidationMessage(item.message, item.propertyName)
                    });
                }
            },
            error: function (error) {
                appendAlertValidationMessage('There are errors: ' + error, 'formFile')
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