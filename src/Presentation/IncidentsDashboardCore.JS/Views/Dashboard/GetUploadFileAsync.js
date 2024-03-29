export const GetUploadFileAsync = () => {
    //$(document).ready(function () {
    //    $('#uploadButton').click(function () {
    //        var formData = new FormData();
    //        var file = $('#formFile')[0].files[0];
    //        formData.append('file', file);

    //        $.ajax({
    //            url: '@Url.Action("UploadCSVAsync", "Dashboard")',
    //            type: 'POST',
    //            data: formData,
    //            processData: false,
    //            contentType: false,
    //            success: function (response) {
    //                // Handle success
    //                console.log(response);
    //            },
    //            error: function (xhr, status, error) {
    //                // Handle error
    //                console.error(xhr.responseText);
    //            }
    //        });
    //    });
    //});

    document.getElementById('uploadFileForm').addEventListener('submit', function (e) {
        e.preventDefault();

        var formData = new FormData();
        var file = $('#formFile')[0].files[0];
        formData.append('file', file);

        $.ajax({
            url: '@Url.Action("UploadCSVAsync", "Dashboard")',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            headers: {
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            },
            success: function (response) {
                // Handle success
                console.log(response);
            },
            error: function (xhr, status, error) {
                // Handle error
                console.error(xhr.responseText);
            }
        });
    });
};