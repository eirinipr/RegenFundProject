// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


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
    let urlAPI = 'https://localhost:44317/api/Backer/{email}';
    let method = 'GET';
    let data = JSON.stringify({
        Email: $('Email').val()
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
        .fail(failure => alert("Email not found. Create an account below."));
    
}


$(document).ready(function () {
    if ($("#Results").length != 0) {
        getallProjects()
    }
});

function getallProjects() {
    let urlAPI = "https://localhost:44317/api/Project";
    let method = 'GET';

    $.ajax({
        url: urlAPI,
        method: method
        })
        .done(result => {
            let resultData = "<table class='table'>";
            result.forEach(project => resultData += ('<tr><td>' + project.Id + '</td><td>' + project.Title + '</td></tr>'));

            resultData += '</table'>
            $("#Results").html(resultData);
        })
        .fail(failure => {
            alert("Something went wrong.");
        });

}


function getCreator() {
    let urlAPI = 'https://localhost:44317/api/ProjectCreator/{email}';
    let method = 'GET';
    let data = JSON.stringify({
        Email: $('Email').val()
    });

    let contentType = 'application/json';

    $.ajax({
        url: urlAPI,
        method: method,
        contentType: contentType,
        data: data
    })
        .done(result => function (data) {
            window.location = 'Creator/Index.html';
        })
        .fail(failure => alert("Email not found. Create an account below."));

}

function searchProjects() {

}

/*dropdown category selector jsfunctions*/
const selected = document.querySelector(".selected");
const optionsContainer = document.querySelector(".options-container-category");

const optionsList = document.querySelectorAll(".option");

selected.addEventListener("click", () => {
    optionsContainer.classList.toggle("active");
});

optionsList.forEach(o => {
    o.addEventListener("click", () => {
        selected.innerHTML = o.querySelector("label").innerHTML;
        optionsContainer.classList.remove("active");
    });
});