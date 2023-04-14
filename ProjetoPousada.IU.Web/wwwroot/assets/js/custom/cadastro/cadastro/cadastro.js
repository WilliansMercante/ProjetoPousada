$(document).ready(function ($) {

    //Em caso de edição
    if ($("#Cliente_Id").val() > 0) {

        $("#btnCadastrar").text("Editar");

        let cpfSemFormatacao = $("#Cliente_CPF").val();

        $(".readonlyCliente").removeClass('readonlyCliente');
        preparaCadastro();
        $("#divBtnCadastrar").show();
        $("#divFlAtivo").show();

        let cpfLimpo = limparCPF(cpfSemFormatacao);

        if (verificaCPF(cpfLimpo)) {

            requisicao("/Cliente/Cliente/PesquisarCPF/" + cpfLimpo, "GET")

                .done(function (retorno) {

                    if (retorno.flSucesso) {

                        if (retorno.oCliente != null) {

                            if (retorno.oCliente.enderecos.length > 0 && retorno.oCliente.telefones.length > 0) {

                                msgAjax.alerta("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado e possui endereço e telefone");
                                preencheIdCliente(retorno.oCliente.id)
                                preencheCliente(retorno.oCliente)
                                preparaEndereco();
                                preparaTelefone();
                                atualizarTabelaEndereco(retorno.oCliente.id);
                                atualizarTabelaTelefone(retorno.oCliente.id);
                                abrirCadastros();
                            } else if (retorno.oCliente.enderecos.length > 0 && retorno.oCliente.telefones.length == 0) {

                                msgAjax.alerta("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado, faltando apenas telefone");
                                $("#divMensagemPreenchimentoTelefone").text("Continue o preenchimento do telefone").css({ "color": "red" });
                                preencheIdCliente(retorno.oCliente.id)
                                preencheCliente(retorno.oCliente)
                                preparaEndereco();
                                preparaTelefone();
                                atualizarTabelaEndereco(retorno.oCliente.id);
                                $('#collapseTwo').collapse();

                            } else if (retorno.oCliente.enderecos.length == 0 && retorno.oCliente.telefones.length > 0) {

                                msgAjax.alerta("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado, faltando apenas Endereço");
                                $("#divMensagemPreenchimentoEndereco").text("Continue o preenchimento do endereço").css({ "color": "red" });
                                preencheIdCliente(retorno.oCliente.id)
                                preencheCliente(retorno.oCliente)
                                preparaEndereco();
                                preparaTelefone();
                                atualizarTabelaTelefone(retorno.oCliente.id);
                                $('#collapseOne').collapse();

                            } else {

                                msgAjax.alerta("O Cliente <b>" + retorno.oCliente.nome + "</b> já esta Cadastrado, porém não possui endereço e telefone, por favor complete os dados");
                                $("#divMensagemPreenchimentoEndereco").text("Continue o preenchimento do endereço").css({ "color": "red" });
                                $("#divMensagemPreenchimentoTelefone").text("Continue o preenchimento do telefone").css({ "color": "red" });
                                preencheIdCliente(retorno.oCliente.id)
                                preencheCliente(retorno.oCliente)
                                preparaEndereco();
                                preparaTelefone();
                                $('.collapse').collapse();
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
        }
    }

    //Máscaras
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

    //Captando o enter no campo CPF
    $('#Cliente_CPF').keypress(function (e) {
        if ((e.keyCode == 10) || (e.keyCode == 13)) {
            $("#btnPesquisar").click();
        }
    });

    //Pesquisando cliente
    $("#btnPesquisar").off('click').on('click', function () {

        let cpfSemFormatacao = $("#Cliente_CPF").val();

        if (cpfSemFormatacao != '') {

            let cpfLimpo = limparCPF(cpfSemFormatacao);

            if (verificaCPF(cpfLimpo)) {

                requisicao("/Cliente/Cliente/PesquisarCPF/" + cpfLimpo, "GET")

                    .done(function (retorno) {

                        if (retorno.flSucesso) {

                            if (retorno.oCliente != null) {

                                if (retorno.oCliente.enderecos.length > 0 && retorno.oCliente.telefones.length > 0) {

                                    preencheIdCliente(retorno.oCliente.id)
                                    preencheCliente(retorno.oCliente)
                                    preparaCadastro();
                                    preparaEndereco();
                                    preparaTelefone();
                                    atualizarTabelaEndereco(retorno.oCliente.id);
                                    atualizarTabelaTelefone(retorno.oCliente.id);
                                    $('#collapseOne').collapse();
                                    $('#collapseTwo').collapse();
                                    msgAjax.alerta("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado e possui endereço e telefone");

                                } else if (retorno.oCliente.enderecos.length > 0 && retorno.oCliente.telefones.length == 0) {

                                    preencheIdCliente(retorno.oCliente.id)
                                    preencheCliente(retorno.oCliente)
                                    preparaCadastro();
                                    preparaEndereco();
                                    preparaTelefone();
                                    atualizarTabelaEndereco(retorno.oCliente.id);
                                    $('#collapseTwo').collapse();
                                    msgAjax.alerta("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado, faltando apenas telefone");

                                } else if (retorno.oCliente.enderecos.length == 0 && retorno.oCliente.telefones.length > 0) {

                                    preencheIdCliente(retorno.oCliente.id)
                                    preencheCliente(retorno.oCliente)
                                    preparaCadastro();
                                    preparaEndereco();
                                    preparaTelefone();
                                    atualizarTabelaTelefone(retorno.oCliente.id);
                                    $('#collapseOne').collapse();
                                    msgAjax.alerta("O Cliente <b>" + retorno.oCliente.nome + "</b> já está Cadastrado, faltando apenas Endereço");

                                } else {

                                    preencheIdCliente(retorno.oCliente.id)
                                    preparaCadastro();
                                    preencheCliente(retorno.oCliente)
                                    preparaEnderecoTelefone();
                                    msgAjax.alerta("O Cliente <b>" + retorno.oCliente.nome + "</b> já esta Cadastrado, porém não possui endereço e telefone, por favor complete os dados");
                                }

                            } else {

                                $(".readonlyCliente").removeClass('readonlyCliente');
                                preparaCadastro();
                                $("#divBtnCadastrar").show();
                            }

                        } else {
                            msgAjax.erro("O Cliente <b>" + retorno.oCliente.nome + "</b> já esta Cadastrado, porém não possui endereço e telefone, por favor complete os dados"); (retorno.mensagem);
                        }
                    })

            } else {
                msgAjax.alerta("CPF Inválido!")
            }

        } else {
            msgAjax.alerta("Preencha o CPF!");
        }
    });

    //Cadastrar cliente
    $("#btnCadastrar").off('click').on('click', function () {

        let id = $("#Cliente_Id").val();
        let cpfFormatado = $("#Cliente_CPF").val();
        let dtNascimento = $("#Cliente_DtNascimento").val();
        let cpfLimpo = limparCPF(cpfFormatado);
        let nome = $("#Cliente_Nome").val();
        let idSexo = $("#Cliente_IdSexo").val();
        let rg = $("#Cliente_Rg").val();
        let flAtivo = true;


        if ($("#Cliente_FlAtivo").is(":checked")) {

            flAtivo = true

        } else {

            flAtivo = false;
        }

        let dados = { flAtivo: flAtivo, id: id, cpf: cpfLimpo, nome: nome, dtNascimento: dtNascimento, idSexo: idSexo, rg: rg }

        if (cpfLimpo != '' && nome != '' && dtNascimento != '' && idSexo != '') {

            requisicao("/Cliente/Cliente/Cadastro", "POST", dados).done(function (retorno) {

                if (retorno.flSucesso) {

                    preencheIdCliente(retorno.idCliente);

                    if (!retorno.flEditar) {
                        preparaEnderecoTelefone();
                        travaCadastro();
                    }

                    msgAjax.sucesso(retorno.mensagem);

                } else {

                    msgAjax.erro(retorno.mensagem);

                }
            })
        }
    });

    function travaCadastro() {

        $("#Cliente_Nome").addClass("readonlyCliente");
        $("#Cliente_DtNascimento").addClass("readonlyCliente");
        $("#Cliente_IdSexo").addClass("readonlyCliente");
        $("#Cliente_Rg").addClass("readonlyCliente");
    }

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

    }

    function preparaTelefone() {

        $(".readonlyTelefone").removeClass('readonlyTelefone');
        $("#divBtnCadastrarTelefone").show();

    }

    function preparaEnderecoTelefone() {

        $('.collapse').collapse();
        preparaEndereco();
        preparaTelefone();

        $("#btnCadastrar").addClass("readonlyCliente");
        $("#divBtnCadastrar").hide();
    }

    $('#Endereco_Cep').keypress(function (e) {
        if ((e.keyCode == 10) || (e.keyCode == 13)) {
            $("#Endereco_Cep").blur();
        }
    });

    //busca CEP
    $("#Endereco_Cep").blur(function () {

        var cep = $(this).val().replace(/\D/g, '');

        if (cep != "") {

            var validacep = /^[0-9]{8}$/;

            if (validacep.test(cep)) {
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#Endereco_Rua").val(dados.logradouro).addClass('readonlyEndereco');
                        $("#Endereco_Bairro").val(dados.bairro).addClass('readonlyEndereco');
                        $("#Endereco_Municipio").val(dados.localidade).addClass('readonlyEndereco');
                        $("#Endereco_UF").val(dados.uf).addClass('readonlyEndereco');
                    }
                    else {
                        msgAjax.alerta("CEP não encontrado.");
                        limparDadosEnderecoCep();
                    }
                });

            } else {

                msgAjax.erro("Formato de CEP inválido.");
                limparDadosEnderecoCep();
            }
        } else {

            limparDadosEnderecoCep();
        }
    });

    function limparDadosEnderecoCep() {

        $("#Endereco_Rua").val("");
        $("#Endereco_Bairro").val("");
        $("#Endereco_Municipio").val("");
        $("#Endereco_UF").val("");
        $("#Endereco_Cep").val("");
        $("#Endereco_Numero").val("");
        $("#Endereco_Complemento").val("");
    }

    function limparDadosEndereco() {

        $("#TipoEndereco_Id").val("");
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

                $("#divMensagemPreenchimentoEndereco").text("");
                $(".readonlyEndereco").removeClass('readonlyEndereco')
                msgAjax.sucesso(retorno.mensagem);
                limparDadosEndereco();
                atualizarTabelaEndereco(idCliente);

            } else {

                msgAjax.erro(retorno.mensagem);

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
            msgAjax.erro(retorno.mensagem);
        }
    }

    async function obterEnderecos(idCliente) {
        return await requisicao("/Cliente/Endereco/ListarPorCliente/" + idCliente, "GET");
    }

    function preencheTbEndereco(destroy, lstEndereco) {

        if (destroy) {
            $("#tbEndereco tbody tr").remove();
        }

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
            novaLinha.append($('<td>').text(moment(endereco.dtCadastro).format("DD/MM/YYYY HH:mm:ss")));

            // adiciona a linha à tabela
            tabela.append(novaLinha);
        });
    }

    $("#btnCadastrarTelefone").off().on('click', function () {

        if ($("#frmTelefone")[0].checkValidity()) {

            cadastraTelefone();

        } else {

            $("#frmTelefone")[0].reportValidity();

        }
    })

    function cadastraTelefone() {

        let idCliente = $("#Cliente_Id").val();
        let idTipoTelefone = $("#TipoTelefone_Id").val();
        let ddd = $("#Telefone_DDD").val();
        let numero = $("#Telefone_Numero").val();

        let dados = { idCliente: idCliente, idTipoTelefone: idTipoTelefone, ddd: ddd, numero: numero }

        requisicao("/Cliente/Telefone/Cadastro", "POST", dados).done(function (retorno) {

            if (retorno.flSucesso) {

                $("#divMensagemPreenchimentoTelefone").text("");
                msgAjax.sucesso(retorno.mensagem);
                limparDadosTelefone();
                atualizarTabelaTelefone(idCliente);

            } else {

                msgAjax.erro(retorno.mensagem);

            }
        })
    }

    function limparDadosTelefone() {

        $("#TipoTelefone_Id").val("");
        $("#Telefone_DDD").val("");
        $("#Telefone_Numero").val("");
    }

    async function atualizarTabelaTelefone(idCliente) {

        let retorno = await obterTelefones(idCliente);

        if (retorno.flSucesso) {

            $("#divTbTelefone").show();
            preencheTbTelefone(true, retorno.lstEndereco);

        }
        else {
            msgAjax.erro(retorno.mensagem);
        }
    }

    async function obterTelefones(idCliente) {
        return await requisicao("/Cliente/Telefone/ListarPorCliente/" + idCliente, "GET");
    }


    function preencheTbTelefone(destroy, lstTelefone) {

        if (destroy) {
            $("#tbTelefone tbody tr").remove();
        }

        var tabela = $('#tbTelefone tbody');

        // itera sobre a lista de clientes e adiciona cada um à tabela
        $.each(lstTelefone, function (i, telefone) {
            // cria uma nova linha para o cliente
            var novaLinha = $('<tr>');

            // adiciona as células da linha com os dados do cliente
            novaLinha.append($('<td>').text(telefone.tipoTelefone.tipo));
            novaLinha.append($('<td>').text(telefone.ddd));

            switch (telefone.idTipoTelefone) {

                case enum_tipo_telefone.celular:
                    novaLinha.append($('<td>').text(telefone.numero.substring(0, 1) + " " + telefone.numero.substring(1, 5) + "-" + telefone.numero.substring(5, 9)));
                    break;

                case enum_tipo_telefone.residencial:
                    novaLinha.append($('<td>').text(telefone.numero.substring(0, 4) + "-" + telefone.numero.substring(4, 8)));
                    break;

                case enum_tipo_telefone.comercial:
                    novaLinha.append($('<td>').text(telefone.numero.substring(0, 4) + "-" + telefone.numero.substring(4, 8)));
                    break;


                default:
                    novaLinha.append($('<td>').text(telefone.numero));
                    break;
            }

            novaLinha.append($('<td>').text(telefone.flAtivo ? 'Sim' : 'Não'));
            novaLinha.append($('<td>').text(moment(telefone.dtCadastro).format("DD/MM/YYYY HH:mm:ss")));

            // adiciona a linha à tabela
            tabela.append(novaLinha);
        });
    }

    function abrirCadastros() {
        $('#collapseOne').collapse();
        $('#collapseTwo').collapse();
    }
});