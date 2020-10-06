﻿$(document).ready(function () {

    BuildPanels();
});

function Pesquisar(urlAction) {

    let estadoEscolhido = $('#ddlEstados').val();
    let municipioEscolhido = $('#ddlMunicipios').val();

    if (estadoEscolhido === '') {
        alert('Selecione um estado antes de prosseguir.');
    }
    else if (municipioEscolhido === '') {
        alert('Selecione um munícipio antes de prosseguir.');

    } else {
        $.ajax({
            url: urlAction,
            data: { estadoEscolhido, municipioEscolhido },
            type: "GET",
            async: true,

            beforeSend: function () {
                showLoadingSpinner();
            },

            success: function (retorno) {

                if (retorno.OK) {

                    BuildPanels(retorno.PrevisaoTempoAtual);

                    hideLoadingSpinner();

                } else {

                    alert(retorno.Mensagem);

                    hideLoadingSpinner();
                }
            },

            error: function (retorno) {
                alert('Ocorreu um erro ao pesquisar o tempo do município escolhido. ' +
                    'Tente mais uma vez e se o erro persistir contate o administrador.' +
                    retorno);

                hideLoadingSpinner();
            }
        });
    }
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

                alert('Oops! Ocorreu um erro ao buscar os municípios do estado selecionado. ' +
                    'Tente novamente.' +
                    retorno);

                hideLoadingSpinner();
            }
        },

        error: function (retorno) {
            alert('Oops! Ocorreu um erro ao buscar os municípios do estado selecionado. ' +
                'Tente novamente.' +
                retorno);

            hideLoadingSpinner();
        }
    });
}

function BuildPanels(previsaoTempoAtual) {

    let painelPrincipal = $('#accordion');

    let painel =
        "<div class='panel'>" +
            "<div class='panel-heading'>" +
                "<a class='accordion-toggle collapsed' data-toggle='collapse' href='#collapseExample1' aria-expanded='false' aria-controls='collapseExample'>" +
                    "Teste1"+
                "</a>"+
            "</div>"+
        "</div>";

    let conteudo = "";


    painelPrincipal.append(painel.concat(conteudo));


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
