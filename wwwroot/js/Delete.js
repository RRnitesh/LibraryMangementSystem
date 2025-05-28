document.addEventListener("DOMContentLoaded", function () {
    var deleteModal = document.getElementById("deleteModal");

    deleteModal.addEventListener('show.bs.modal', function (e) {
        var button = e.relatedTarget;
        var bookId = button.getAttribute('data-id');
        var bookTitle = button.getAttribute('data-title'); // Get the book title from the button

        // Update the modal's confirmation message with the book title
        var modalBody = deleteModal.querySelector(".modal-body");
        modalBody.innerHTML = 'Are you sure you want to delete the book <strong>' + bookTitle + '</strong>?';

        // Set the form action dynamically
        var modelform = deleteModal.querySelector("#deleteForm");
        modelform.action = '/Book/Delete/' + bookId;
    });
});