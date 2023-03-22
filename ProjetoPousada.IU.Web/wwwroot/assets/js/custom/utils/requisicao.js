function requisicao(endereco, tipo, dados) {
    $(".loading").fadeIn();

    var promise = $.ajax({
        url: endereco,
        type: tipo,
        data: dados
    }).always(function () {
        $(".loading").fadeOut();
    });

    return promise;
}