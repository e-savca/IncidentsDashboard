export const CloseModalEventHandler = (modalObj, hashUrl) => {
    const closeModalBtn = document.getElementById('closeModalBtn');
    const closeModalFromCornerBtn = document.getElementById('closeModalFromCornerBtn');
    const redirectToAnotherModal = document.getElementById('redirectToAnotherModal');
    

    if (closeModalBtn) {
        closeModalBtn.addEventListener('click', function () {
            CloseModal(modalObj, hashUrl);
        });
    }

    if (closeModalFromCornerBtn) {
        closeModalFromCornerBtn.addEventListener('click', function () {
            CloseModal(modalObj, hashUrl);
        });
    }

    if (redirectToAnotherModal) {
        redirectToAnotherModal.addEventListener('click', function () {
            modalObj.hide();
        });
    }

    // close modal using ESC key
    $(document).keyup(function (e) {
        if (e.keyCode === 27) {
            CloseModal(modalObj, hashUrl);
        }
    });
}
function CloseModal(modalObj, hashUrl) {
    window.location.hash = hashUrl + '/ModalClosed'; // Change hash
    modalObj.hide(); // Close modal
}