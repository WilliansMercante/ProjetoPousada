function limparCPF(cpf) {
    let cpfLimpo = cpf.replace(/[^\d]/g, "");

    return cpfLimpo;
}