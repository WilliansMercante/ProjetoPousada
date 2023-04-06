
function formataDataHtmlDate(dataSemFormatacao) {

    let data = new Date(dataSemFormatacao);
    let dia = ("0" + data.getDate()).slice(-2);
    let mes = ("0" + (data.getMonth() + 1)).slice(-2);
    let dataFormatada = data.getFullYear() + "-" + (mes) + "-" + (dia);

    return dataFormatada;
}