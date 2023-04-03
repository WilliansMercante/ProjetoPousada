function formatarCPF(cpf) {
    let cpfLimpo = cpf.replace(/[^\d]/g, "");

    return cpfLimpo;
}