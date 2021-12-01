// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function createCreator() {
    let urlAPI = ''

}

function createBacker() {

    letAPI = 'https://localhost:44317/api/Backer';
    let method = 'POST';
    let data = JSON.stringify({
        FirstName: $('#FirstName').val(),
        LasteName: $('#LastName').val(),
        Email: $('#Email').val()
    });

    let contentType = 'application/json';

    $.ajax(
        {
            url: urlAPI,
            method: method,
            contentType: contentType,
            data: data

        })
        .done(result => alert("Account created successfully with id:" + backer.Id))
        .fail(failure => alert("Something went wrong. Try again later."));
}
}