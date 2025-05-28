
function showLoginModal() {

    //$.get('Librarian/LoginModal', function () {
        //show the modal
        var modal = new bootstrap.Modal(document.getElementById("librarianLoginModal"));
        modal.show();
    //})
}

//submitting the data using ajax
$(document).on("submit", "#librarianLoginForm", function () {

    var formdata = {
        username : $('#username').val(),
        password : $('#password').val()
    };

    $.post('Librarian/Login', formdata, function (response) {
        if (response.success) {
            var modalLg = document.getElementById("librarianLoginModal");
            var modal = bootstrap.Modal.getInstance(modalLg);
            model.hide();
            //if success reponse comes from action then hide the modal

            

            //now we must hide the nonlibrarianNavigation and display LibrairanNav
            $('#loginButton').hide();
            $('#librarianNav').show();
        }
        else {
            $('#librarianLoginMessage')
                .text(response.message).addClass('alert alert-danger mt-2');
        }
    }
)})

function LibrarianLogout() {
    $.post('Librarian/Logout', function () {
        //toggle between navbar
        $('#LoginButton').show();
        $('#LibrarianNav').hide();
    })
}