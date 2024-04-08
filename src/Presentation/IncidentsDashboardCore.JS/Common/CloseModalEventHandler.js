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
}
function CloseModal(modalObj, hashUrl) {
    window.location.hash = hashUrl; // Change hash
    modalObj.hide(); // Close modal
}