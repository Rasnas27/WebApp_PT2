// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function logout() {
    // Limpar o cache do navegador
    window.location.reload(true);

    // Redirecionar o usuário para a página de logout
    window.location.href = "/Logout";
    //colocar a tag de login
}

var currentUrl = window.location.pathname; 

function conferePage() {
    if (currentUrl.includes("/Alunos")) {
        var alunosTag = document.getElementById("alunos");
        if (alunosTag) {
            alunosTag.classList.add("active");
        }
    } else if (currentUrl.includes("/Agenda")) {
        var agendaTag = document.getElementById("agenda")
        if (agendaTag) {
            agendaTag.classList.add("active");
        } else {
            return OK;
        }
    }
}

conferePage();

