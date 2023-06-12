var rows = document.querySelectorAll('table tbody tr');
var idAluno = "";
rows.forEach(function (row) {
    row.addEventListener('click', function () {
        // Verificar se a linha j� est� selecionada
        var isSelected = this.classList.contains('selected-row');

        // Remover a classe 'selected-row' de todas as linhas
        rows.forEach(function (row) {
            row.classList.remove('selected-row');
        });

        // Se a linha n�o estava selecionada, adicionar a classe 'selected-row'
        if (!isSelected) {
            this.classList.add('selected-row');

            var tr = document.querySelectorAll('tr');

            tr.forEach(function (el) {
                el.addEventListener('click', meuID);
            });
        }
    });
});
function meuID(e) {
    var dados = e.currentTarget.innerText.split('\t');

    var aluno = {
        nome: dados[0],
        telefone: dados[1],
        email: dados[2],
        nascimento: dados[3]
    };

    obterIdDoAlunoPorNome(aluno.nome);
}

function apagarDados() {
    document.getElementById('nome').value = '';
    document.getElementById('telefone').value = '';
    document.getElementById('email').value = '';
    document.getElementById('nascimento').value = '';
    document.getElementById('profissao').value = '';
    document.getElementById('pagamento').value = '';
    document.getElementById('cpf').value = '';
}

var nomeModal = "";

function obterIdDoAlunoPorNome(nome) {
    var endpoint = '/Alunos/FindAlunoByName/' + nome;

    fetch(endpoint)
        .then(function (response) {
            if (!response.ok) {
                throw new Error('Erro na solicita��o: ' + response.status);
            }

            return response.json();
        })
        .then(function (aluno) {
            if (aluno) {
                nomeModal = aluno.nome;
                idAluno = aluno.id_Aluno;
                console.log(aluno);
                console.log(aluno.id_Aluno);
            } else {
                console.log('Aluno n�o encontrado');
            }
        })
        .catch(function (error) {
            console.error('Erro na solicita��o:', error);
        });
}

function excluirAluno() {
    
    if (confirm("Deseja excluir o perfil do aluno " + nomeModal + "?")) {
        var endpoint = '/Alunos/ExcluirAluno/' + idAluno.toString();
        fetch(endpoint, {
            method: 'DELETE'
        })
            .then(response => {
                if (response.ok) {
                    // Redirecionar para a p�gina de alunos ap�s a exclus�o (caso desejado)
                    window.location.href = '/Alunos';
                } else {
                    throw new Error('Erro ao excluir o aluno: ' + response.status);
                }
            })
            .catch(error => {
                console.error('Erro na solicita��o:', error);
            });
    } 
}

