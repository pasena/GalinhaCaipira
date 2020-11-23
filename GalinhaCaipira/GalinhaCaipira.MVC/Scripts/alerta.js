function ExibirMensagemErro(titulo, mensagem) {
    Swal.fire(titulo, mensagem, "error")
}

function ExibirMensagemAlerta(titulo, mensagem) {
    Swal.fire(titulo, mensagem, "warning")
}

function ExibirMensagemSucesso(titulo, mensagem) {
    Swal.fire(titulo, mensagem, "success")
}

function ExibirMensagemSucessoRedirect(titulo, mensagem, functionCallback) {
    Swal.fire({
        title: titulo,
        html: mensagem,
        type: "success",
        icon: "success",
        closeOnClickOutside: false,
        buttons: { confirm: "Ok" }
    })
        .then(function (confirm) {
            if (confirm) {
                functionCallback();
            }
        })
}

function ExibirMensagemErroRedirect(titulo, mensagem, functionCallback) {
    Swal.fire({
        title: titulo,
        html: mensagem,
        icon: "error",
        closeOnClickOutside: false,
        buttons: { confirm: "Ok" }
    })
        .then(function (confirm) {
            if (confirm) {
                functionCallback();
            }
        })
}