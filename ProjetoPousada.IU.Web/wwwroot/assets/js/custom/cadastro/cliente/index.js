$(document).ready(function () {

    

    $("#btnPesquisar").off('click').on('click', function () {

        let nome = $("#Cliente_Nome").val();
        let cpf = $("#Cliente_CPF").val();
        let dtNascimento = $("#Cliente_DtNascimento").val();

        let dados = { nome: nome, cpf: cpf, dtNascimento: dtNascimento }

        if (nome == '' && cpf == '' && dtNascimento == '') {

            bootbox.alert("Preencha pelo menos uma opção para pesquisar!");

        } else if (cpf != '' && !verificaCPF(cpf)) {

            bootbox.alert("CPF Inválido!");

        } else {

            requisicao("/Cadastro/Cliente/Pesquisar/", "POST", dados)

                .done(function (retorno) {

                    if (retorno.flSucesso) {

                        preencheTabelaAtendimento(true, retorno.lstClientes);

                    } else {
                        alert(retorno.mensagem);
                    }
                })
        }
    });

    function preencheTabelaAtendimento(destroy, lst) {

        if (destroy) {
            $("#tbClientes tbody tr").remove();
        }

        var tabela = $('#tbClientes tbody');

        // itera sobre a lista de clientes e adiciona cada um à tabela
        $.each(lst, function (i, cliente) {
            // cria uma nova linha para o cliente
            var novaLinha = $('<tr>');

            // adiciona as células da linha com os dados do cliente
            novaLinha.append($('<td>').text(cliente.nome));
            novaLinha.append($('<td>').text(moment(cliente.dtNascimento).format("DD/MM/YYYY")));
            novaLinha.append($('<td>').text(cliente.cpf));
            novaLinha.append($('<td>').text(cliente.rg));
            novaLinha.append($('<td>').text(cliente.flAtivo ? 'Sim' : 'Não'));
            novaLinha.append($('<td>').text(moment(cliente.dtCadastro).format("DD/MM/YYYY")));
            novaLinha.append($('<td>').html('<button style="width:40px; height:40px" class="btn btn-warning bd-placeholder-img rounded-circle"><i style="margin-top: -3px" class="align-middle me-2" data-feather="edit"></i></button>'));

            // adiciona a linha à tabela
            tabela.append(novaLinha);
        });

        feather.replace();
    }

});
