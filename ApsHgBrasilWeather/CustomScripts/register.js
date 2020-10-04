$(document).ready(function () {


});

function Pesquisar(urlAction) {

    let cnpjDigitado = $('#Cliente_Cnpj').val();

    $.ajax({
        url: urlAction,
        data: { cnpjDigitado },
        type: "GET",
        async: true,

        beforeSend: function () {
            showLoadingSpinner();
        },

        success: function (retorno) {

            if (retorno.OK) {

                PopulateSomeFields(retorno.Info);

                hideLoadingSpinner();

            } else {

                alert('Oops! O CNPJ digitado é inválido. Tente novamente.');
                $('#Cliente_Cnpj').val("");

                hideLoadingSpinner();
            }
        },

        error: function (retorno) {
            alert('Ocorreu um erro ao pesquisar o CNPJ na Receita Federal.'+
                'Tente mais uma vez e se o erro persistir, digite os dados manualmente.' +
                retorno);

            hideLoadingSpinner();
        }
    });
}

function PopulateSomeFields(Info) {

    $('#Cliente_Nome').val(Info.Nome);
    $('#Cliente_Fantasia').val(Info.Fantasia);
    $('#Cliente_Endereco').val(Info.Endereco);
    $('#Cliente_Bairro').val(Info.Bairro);
    $('#Cliente_Municipio').val(Info.Municipio);
    $('#EstadoSelecionado option[value=' + Info.Uf + ']').attr('selected', 'selected');
    $('#Cliente_Cep').val(Info.Cep);

}


function hideLoadingSpinner() {
    $('#loading').hide();
}

function showLoadingSpinner() {
    $('#loading').show();
}