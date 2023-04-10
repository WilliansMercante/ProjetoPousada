$(document).ready(function ($) {

    $("#Cliente_CPF").mask("999.999.999-99");
    $("#Endereco_Cep").mask("99999-999");

    $("#TipoTelefone_Id").on('change', function () {

        switch ($("#TipoTelefone_Id").val()) {

            case "1":
                $("#Telefone_Numero").mask("9 9999-9999");
                break;

            default:
                $("#Telefone_Numero").mask("9999-9999");
                break;
        }
    })

    $('#Cliente_CPF').keypress(function (e) {
        if ((e.keyCode == 10) || (e.keyCode == 13)) {
            $("#btnPesquisar").click();
        }
    });

    $("#btnPesquisar").off('click').on('click', function () {

        let cpfSemFormatacao = $("#Cliente_CPF").val();

        if (cpfSemFormatacao != '') {

            let cpfLimpo = limparCPF(cpfSemFormatacao);

            if (verificaCPF(cpfLimpo)) {

                requisicao("/Cliente/Cliente/PesquisarCPF/" + cpfLimpo, "GET")

                    .done(function (retorno) {

                        if (retorno.flSucesso) {

                            console.log(retorno.oCliente)

                            if (retorno.oCliente != null) {

                                if (retorno.oCliente.enderecos.length > 0 && retorno.oCliente.telefones > 0) {

                                    $("#Cliente_CPF").val("");
                                    bootbox.alert("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado e possui endereço e telefone");

                                } else if (retorno.oCliente.enderecos.length > 0 && retorno.oCliente.telefones.length == 0) {

                                    bootbox.alert("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado, faltando apenas telefone");
                                    preencheIdCliente(retorno.oCliente.id)
                                    preencheCliente(retorno.oCliente)
                                    preparaCadastro();
                                    preparaTelefone();                                    
                                    atualizarTabelaEndereco(retorno.oCliente.id);
                                    $('#collapseTwo').collapse();

                                } else if (retorno.oCliente.enderecos.length == 0 && retorno.oCliente.telefones.length > 0) {

                                    bootbox.alert("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado, faltando apenas Endereço");
                                    preencheIdCliente(retorno.oCliente.id)
                                    preencheCliente(retorno.oCliente)
                                    preparaCadastro();
                                    preparaEndereco();

                                } else {

                                    bootbox.alert("O Cliente <b>" + retorno.oCliente.nome + "</b> já esta Cadastrado, porém não possui endereço e telefone, por favor complete os dados");
                                    preencheIdCliente(retorno.oCliente.id)
                                    preparaCadastro();
                                    preencheCliente(retorno.oCliente)
                                    preparaEnderecoTelefone();
                                }

                            } else {

                                $(".readonlyCliente").removeClass('readonlyCliente');
                                preparaCadastro();
                                $("#divBtnCadastrar").show();
                            }

                        } else {
                            bootbox.alert(retorno.mensagem);
                        }
                    })

            } else {
                bootbox.alert("CPF Inválido!")
            }

        } else {
            bootbox.alert("Preencha o CPF!");
        }
    });

    $("#btnCadastrar").off('click').on('click', function () {

        let cpfFormatado = $("#Cliente_CPF").val();
        let dtNascimento = $("#Cliente_DtNascimento").val();
        let cpfLimpo = limparCPF(cpfFormatado);
        let nome = $("#Cliente_Nome").val();
        let idSexo = $("#Cliente_IdSexo").val();
        let rg = $("#Cliente_Rg").val();

        let dados = { cpf: cpfLimpo, nome: nome, dtNascimento: dtNascimento, idSexo: idSexo, rg: rg }

        if (cpfLimpo != '' && nome != '' && dtNascimento != '' && idSexo != '') {

            requisicao("/Cliente/Cliente/Cadastro", "POST", dados).done(function (retorno) {

                if (retorno.flSucesso) {

                    preencheIdCliente(retorno.idCliente);
                    bootbox.alert(retorno.mensagem);
                    preparaEnderecoTelefone();

                } else {

                    bootbox.alert(retorno.mensagem);

                }
            })
        }
    });

    function preencheCliente(cliente) {

        $("#Cliente_Nome").val(cliente.nome);
        $('#Cliente_DtNascimento').val(moment(cliente.dtNascimento).format("YYYY-MM-DD"));
        $("#Cliente_IdSexo").val(cliente.idSexo);
        $("#Cliente_Rg").val(cliente.rg);
    }

    function preparaCadastro() {

        $("#Cliente_CPF").addClass("readonlyCliente");
        $("#btnPesquisar").addClass("readonlyCliente");
        $("#divBtnPesquisar").hide();
    }

    function preparaEndereco() {

        $(".readonlyEndereco").removeClass('readonlyEndereco');
        $("#divBtnCadastrarEndereco").show();
        $("#divMensagemPreenchimentoEndereco").text("Continue o preenchimento do endereço").css({ "color": "red" });
    }

    function preparaTelefone() {

        $(".readonlyTelefone").removeClass('readonlyTelefone');
        $("#divBtnCadastrarTelefone").show();
        $("#divMensagemPreenchimentoTelefone").text("Continue o preenchimento do telefone").css({ "color": "red" });
    }

    function preparaEnderecoTelefone() {

        $('.collapse').collapse();
        preparaEndereco();
        preparaTelefone();

        $("#btnCadastrar").addClass("readonlyCliente");
        $("#divBtnCadastrar").hide();
    }

    $("#Endereco_Cep").blur(function () {

        var cep = $(this).val().replace(/\D/g, '');

        if (cep != "") {

            var validacep = /^[0-9]{8}$/;

            if (validacep.test(cep)) {
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#Endereco_Rua").val(dados.logradouro).attr('readonly', true);
                        $("#Endereco_Bairro").val(dados.bairro).attr('readonly', true);
                        $("#Endereco_Municipio").val(dados.localidade).attr('readonly', true);
                        $("#Endereco_UF").val(dados.uf).attr('readonly', true);
                    }
                    else {
                        bootbox.alert("CEP não encontrado.");
                        limparDadosEndereco();
                    }
                });

            } else {

                bootbox.alert("Formato de CEP inválido.");
                limparDadosEndereco();
            }
        } else {

            limparDadosEndereco();
        }
    });

    function limparDadosEndereco() {

        $("#Endereco_Rua").val("");
        $("#Endereco_Bairro").val("");
        $("#Endereco_Municipio").val("");
        $("#Endereco_UF").val("");
        $("#Endereco_Cep").val("");
        $("#Endereco_Numero").val("");
        $("#Endereco_Complemento").val("");
    }

    $("#btnCadastrarEndereco").off().on('click', function () {

        if ($("#frmEndereco")[0].checkValidity()) {

            cadastraEndereco();

        } else {

            $("#frmEndereco")[0].reportValidity();

        }
    })

    function preencheIdCliente(idCliente) {

        $("#Cliente_Id").val(idCliente);

    }

    function cadastraEndereco() {

        let idCliente = $("#Cliente_Id").val();
        let idTipoEndereco = $("#TipoEndereco_Id").val();
        let cep = $("#Endereco_Cep").val();
        let rua = $("#Endereco_Rua").val();
        let numero = $("#Endereco_Numero").val();
        let complemento = $("#Endereco_Complemento").val();
        let bairro = $("#Endereco_Bairro").val();
        let municipio = $("#Endereco_Municipio").val();
        let uf = $("#Endereco_UF").val();

        let dados = { idCliente: idCliente, idTipoEndereco: idTipoEndereco, cep: cep, rua: rua, numero: numero, complemento: complemento, bairro: bairro, municipio: municipio, uf: uf }

        requisicao("/Cliente/Endereco/Cadastro", "POST", dados).done(function (retorno) {

            if (retorno.flSucesso) {
                bootbox.alert(retorno.mensagem);
                limparDadosEndereco();
                $("#TipoEndereco_Id").val("");
                atualizarTabelaEndereco(idCliente);
            } else {

                bootbox.alert(retorno.mensagem);

            }
        })
    }

    async function atualizarTabelaEndereco(idCliente) {

        let retorno = await obterEnderecos(idCliente);
        if (retorno.flSucesso) {
            $("#divTbEndereco").show();
            preencheTbEndereco(true, retorno.lstEndereco);
        }
        else {
            bootbox.alert(retorno.mensagem);
        }
    }

    async function obterEnderecos(idCliente) {
        return await requisicao("/Cliente/Endereco/ListarPorCliente/" + idCliente, "GET");
    }

    function preencheTbEndereco(destroy, lstEndereco) {

        if (destroy) {
            $("#tbEndereco tbody tr").remove();
        }

        console.log(lstEndereco);

        var tabela = $('#tbEndereco tbody');

        // itera sobre a lista de clientes e adiciona cada um à tabela
        $.each(lstEndereco, function (i, endereco) {
            // cria uma nova linha para o cliente
            var novaLinha = $('<tr>');

            // adiciona as células da linha com os dados do cliente
            novaLinha.append($('<td>').text(endereco.tipoEndereco.tipo));
            novaLinha.append($('<td>').text(endereco.rua));
            novaLinha.append($('<td>').text(endereco.numero));
            novaLinha.append($('<td>').text(endereco.flAtivo ? 'Sim' : 'Não'));
            novaLinha.append($('<td>').text(endereco.bairro));
            novaLinha.append($('<td>').text(endereco.municipio));
            novaLinha.append($('<td>').text(endereco.uf));
            novaLinha.append($('<td>').text(moment(endereco.dtCadastro).format("DD/MM/YYYY")));

            // adiciona a linha à tabela
            tabela.append(novaLinha);
        });
    }
});