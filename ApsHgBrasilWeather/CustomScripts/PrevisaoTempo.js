$(document).ready(function () {


});

function Pesquisar(urlAction) {

    let estadoEscolhido = $('#ddlEstados').val();
    let municipioEscolhido = $('#ddlMunicipios').val();

    if (estadoEscolhido === '') {
        alert('Selecione um estado antes de prosseguir.');
    } else {
        if (municipioEscolhido === '') {
            alert('Selecione um munícipio antes de prosseguir.');
        }
    }

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
            alert('Ocorreu um erro ao pesquisar o CNPJ na Receita Federal.' +
                'Tente mais uma vez e se o erro persistir, digite os dados manualmente.' +
                retorno);

            hideLoadingSpinner();
        }
    });
}

function GetMunicipios(urlAction) {

    let estadoEscolhido = $('#ddlEstados').val();

    $.ajax({
        url: urlAction,
        data: { estadoEscolhido },
        type: "GET",
        async: true,

        beforeSend: function () {
            showLoadingSpinner();
        },

        success: function (retorno) {

            if (retorno.OK) {

                PopulateDropDownMunicipios(retorno.Municipios);

                hideLoadingSpinner();

            } else {

                alert('Oops! Deu errado.');
             
                hideLoadingSpinner();
            }
        },

        error: function (retorno) {
            alert('Ocorreu um erro ao buscar os municípios do estado selecionado. ' +
                'Tente novamente.' +
                retorno);

            hideLoadingSpinner();
        }
    });
}

function PopulateDropDownMunicipios(municipios) {

    let ddlMunicipios = $('#ddlMunicipios')

    ddlMunicipios.find('option').not(':first').remove();

    for (let i = 0; i < municipios.length; i++) {

        let option = `<option value="${municipios[i].Nome}">${municipios[i].Nome}</option>`;
        ddlMunicipios.append(option);
    }
}


function hideLoadingSpinner() {
    $('#loading').hide();
}

function showLoadingSpinner() {
    $('#loading').show();
}