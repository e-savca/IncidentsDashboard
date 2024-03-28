export const GetDetailsAsync = () => { 
    // send data to server and handle response
    document.getElementById('deleteIncidentForm').addEventListener('submit', function (e) {
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
                    alert('Incident not deleted');
                }
            });
    });
};