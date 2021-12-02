// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function createCreator() {
    let urlAPI = ''

}

function createBacker() {

    let urlAPI = 'https://localhost:44317/api/Backer';
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
        .done(result => alert(JSON.stringify(result)))
        .fail(failure => alert("Something went wrong. Try again later."));
}

function getBacker() {
    let urlAPI = 'https://localhost:44317/api/Backer/{id}'
    let method = 'GET'
    let data = JSON.stringify({
        Id: $('Id').val()
    });

    let contentType = 'application/json';

    $.ajax({
        url: urlAPI,
        method: method,
        contentType: contentType,
        data: data
    })
        .done(result => function (data) {
            window.location = 'Backer/Index.html';
            })
        .fail(failure => alert("Id not found. Create an account below."));
    
}
