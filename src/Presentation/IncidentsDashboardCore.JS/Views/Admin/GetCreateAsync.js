export const GetCreateAsync = (
    modal
) => {
    // model.IsActive property
    document.querySelectorAll('input[name="btnradio"]').forEach(function (radio) {
        radio.addEventListener('change', function () {
            document.getElementById('isActiveField').value = this.value;
        });
    });


    // send data to server and handle response
    document.getElementById('createUserForm').addEventListener('submit', function (e) {
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
                    window.location.href = '#Admin';
                    modal.hide();
                }
                else {
                    // Display error messages
                    // foreach in data.message call appendAlert
                    clearAlertValidationMessage();
                    data.errors.forEach((item) => {
                        appendAlertValidationMessage(item.message, item.propertyName)
                    });
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

