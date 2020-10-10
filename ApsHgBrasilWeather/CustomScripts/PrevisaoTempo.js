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

                    BuildPanels(retorno.stringHtml);
                    hideLoadingSpinner();
                    showPainel();


                } else {

                    hideLoadingSpinner();
                    hidePainel();
                    alert(retorno.Mensagem);
                    

                }
            },

            error: function (retorno) {

                hideLoadingSpinner();
                hidePainel();
                alert('Ocorreu um erro ao pesquisar o tempo do município escolhido. ' +
                    'Tente mais uma vez e se o erro persistir contate o administrador.' +
                    retorno);
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
            $('#accordion').hide();
        },

        success: function (retorno) {

            if (retorno.OK) {

                PopulateDropDownMunicipios(retorno.Municipios);
                hideLoadingSpinner();

            } else {

                hideLoadingSpinner();
                alert('Oops! Ocorreu um erro ao buscar os municípios do estado selecionado. ' +
                    'Tente novamente.' +
                    retorno);
            }
        },

        error: function (retorno) {

            hideLoadingSpinner();
            alert('Oops! Ocorreu um erro ao buscar os municípios do estado selecionado. ' +
                'Tente novamente.' +
                retorno);
        }
    });
}

function BuildPanels(previsaoTempoAtual) {

    let painelPrincipal = $('#accordion');
    painelPrincipal.empty();
    painelPrincipal.append(previsaoTempoAtual);
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

function showPainel() {
    $('#accordion').show();
}

function hidePainel() {
    $('#accordion').hide();
    $('#accordion').empty();
}

