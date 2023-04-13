$(document).ready(function () {

    

    $("#btnPesquisar").off('click').on('click', function () {

        let nome = $("#Cliente_Nome").val();
        let cpf = $("#Cliente_CPF").val();
        let dtNascimento = $("#Cliente_DtNascimento").val();

        let dados = { nome: nome, cpf: cpf, dtNascimento: dtNascimento }

        requisicao("/Cliente/Cliente/Pesquisar/", "GET", dados)

            .done(function (retorno) {

                if (retorno.flSucesso) {

                    preencheTabelaAtendimento(true, retorno.lstClientes);

                } else {
                    msgAjax.erro(retorno.mensagem);
                }
            })

    });

    $("#btnPesquisar").click();

    $('#Cliente_Nome , #Cliente_CPF , #Cliente_DtNascimento').keypress(function (e) {
        if ((e.keyCode == 10) || (e.keyCode == 13)) {
            $("#btnPesquisar").click();
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
            novaLinha.append($('<td>').text(cliente.cpf.substring(0, 3) + "." + cliente.cpf.substring(3, 6) + "." + cliente.cpf.substring(6, 9) + "-" + cliente.cpf.substring(9, 11)));
            novaLinha.append($('<td>').text(cliente.rg ? cliente.rg : ''));
            novaLinha.append($('<td>').text(cliente.sexo.sexo));
            novaLinha.append($(cliente.flAtivo ? '<td class="text-center" style="color: blue;"  title="Ativo"> <i class="text-center" data-feather="thumbs-up" ></i> <span class="text-center"></span></td>' : '<td class="text-center" style="color: red;" title="Inativo"> <i class="text-center" data-feather="thumbs-down"></i> <span class="text-center"></span></td>'));
            novaLinha.append($('<td>').text(moment(cliente.dtCadastro).format("DD/MM/YYYY HH:mm:ss")));
            novaLinha.append($('<td>').html('<a style="width:40px; height:40px" class="editar btn btn-warning bd-placeholder-img rounded-circle" title="Editar" href="/Cliente/Cliente/Editar/' + cliente.id + '"><i style="margin-top: 2px; margin-left: -1px;" class="align-middle me-2" data-feather="edit"></i></a>'));

            // adiciona a linha à tabela
            tabela.append(novaLinha);
        });

        feather.replace();
    }
});
