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

                                $(".readonly").removeClass('readonly');
                                $("#Cliente_CPF").addClass("readonly");
                                $("#btnPesquisar").addClass("readonly");
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
});