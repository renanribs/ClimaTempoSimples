function obterClimaSemana() {
    let id = $('#cidades').find(":selected").val();
    let nome = $('#cidades').find(":selected").text();

    $.ajax(
        {
            type: 'GET',
            url: 'Home/obterClimaSemana',
            data: {
                Id: id,
                Nome: nome
            },
            dataType: 'html',
            cache: false,
            async: true,
            success: function (data) {
                $('#previsao').html(data);
            }
        }
    );
}