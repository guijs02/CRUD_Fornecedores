document.addEventListener('DOMContentLoaded', function () {
    const CEP_NAO_ENCONTRADO = "CEP não encontrado";
    const CEP_INCORRETO = "CEP incorreto";

    if (document.getElementById('cep') != null) {
        configureCepField('cep', 'endereco');
    }

    if (document.getElementById('cepUpdate') != null) {
        configureCepField('cepUpdate', 'enderecoUpdate');
    }
});

async function configureCepField(cepFieldId, enderecoFieldId) {
    const cepField = document.getElementById(cepFieldId);
    const enderecoField = document.getElementById(enderecoFieldId);

    cepField.addEventListener('focusout', async () => {
        console.log('caiu');
        const cep = cepField.value;
        console.log(cep);

        if (!cepValido(cep)) {
            enderecoField.value = CEP_INCORRETO;
            return;
        }

        const url = `https://viacep.com.br/ws/${cep}/json/`;
        const dados = await fetch(url);
        const content = await dados.json();
        console.log(content)
        if (content.hasOwnProperty('erro')) {
            enderecoField.value = CEP_NAO_ENCONTRADO;
        } else {
            const conteudo_endereco = `${content.bairro} ${content.logradouro}, ${content.localidade}, ${content.uf}`;
            enderecoField.value = conteudo_endereco;
        }
    });
}

function cepValido(cep) {
    return cep.length === 8 && /^\d+$/.test(cep);
}








