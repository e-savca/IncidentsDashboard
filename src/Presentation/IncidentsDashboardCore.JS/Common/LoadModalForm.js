import { GetCreateAsync } from '/IDCore.JS/Views/Admin/GetCreateAsync';
export const LoadModalForm = (url, title) => {

    var xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);
    xhr.onload = function () {
        if (xhr.status === 200) {
            document.getElementById('modalContent').innerHTML = xhr.responseText;
            document.getElementById('modalViewLabel').textContent = title; // Change modal title
            var myModal = new bootstrap.Modal(document.getElementById('modalView'), {});
            myModal.show();
            GetCreateAsync(myModal);

            // Add event listener to close button
            document.getElementById('closeModalBtn').addEventListener('click', function () {
                CloseModal(myModal);
            });
            document.getElementById('closeModalFromCornerBtn').addEventListener('click', function () {
                CloseModal(myModal);
            });
        } else {
            console.error('Request failed. Status: ' + xhr.status);
        }
    };
    xhr.send();
}

function CloseModal(modalObj) {
    window.location.hash = "#Admin"; // Change hash
    modalObj.hide(); // Close modal
}