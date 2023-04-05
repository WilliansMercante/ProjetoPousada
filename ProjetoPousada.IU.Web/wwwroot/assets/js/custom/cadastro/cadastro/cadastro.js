$(document).ready(function ($) {

    $("#Cliente_CPF").mask("999.999.999-99");

    $('#Cliente_CPF').keypress(function (e) {
        if ((e.keyCode == 10) || (e.keyCode == 13)) {
            e.preventDefault();
        }
    });

    $("#btnPesquisar").off('click').on('click', function () {

        let cpfSemFormatacao = $("#Cliente_CPF").val();

        if (cpfSemFormatacao != '') {

            let cpfLimpo = formatarCPF(cpfSemFormatacao);

            if (verificaCPF(cpfLimpo)) {

                requisicao("/Cadastro/Cliente/PesquisarCPF/" + cpfLimpo, "GET")

                    .done(function (retorno) {

                        if (retorno.flSucesso) {

                            if (retorno.oCliente != null) {

                                $("#Cliente_CPF").val("");
                                bootbox.alert("O Cliente " + retorno.oCliente.nome + " já esta Cadastrado");

                            } else {

                                $(".readonlyCliente").removeClass('readonlyCliente');
                                $("#Cliente_CPF").addClass("readonlyCliente");
                                $("#btnPesquisar").addClass("readonlyCliente");
                                $("#divBtnPesquisar").hide();
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

            requisicao("/Cadastro/Cliente/Cadastro", "POST", dados).done(function (retorno) {

                if (retorno.flSucesso) {

                    $('.collapse').collapse();

                } else {

                    alert(retorno.mensagem);

                }
            })
        }
    });














    // $("#frmCadastro").on("submit", function (event) {

    //    event.preventDefault();
    //    event.stopPropagation();

    //    requisicao("/Cadastro/Cliente/Cadastro", "POST", $("#frmCadastro").find(":input").serialize())

    //        .done(function (retorno) {

    //            if (retorno.flSucesso) {

    //                bootbox.alert(retorno.mensagem);


    //            }
    //            else {
    //                bootbox.alert(retorno.mensagem);
    //            }
    //        })
    //})












    $("#Endereco_Cep").blur(function () {

        var cep = $(this).val().replace(/\D/g, '');

        if (cep != "") {

            var validacep = /^[0-9]{8}$/;

            if (validacep.test(cep)) {
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#Endereco_rua").val(dados.logradouro);
                        $("#Endereco_Bairro").val(dados.bairro);
                        $("#Paciente_Municipio").val(dados.localidade);
                        $("#Paciente_UF").val(dados.uf);
                    }
                    else {
                        toastr.error("CEP não encontrado.");
                        limparDadosEndereco();
                    }
                });

            } else {

                toastr.error("Formato de CEP inválido.");
                limparDadosEndereco();
            }
        } else {

            limparDadosEndereco();
        }
    });

    function limparDadosEndereco() {

        $("#Paciente_Logradouro").val("");
        $("#Paciente_Bairro").val("");
        $("#Paciente_Municipio").val("");
        $("#Paciente_UF").val("");
        $("#Paciente_Cep").val("");
    }




















});