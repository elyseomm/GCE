
var controllerName = "/Product";
var active_value = "2";
var inactive_value = "0";

$(document).ready(() => {    
   
    $("#btn-info-modal").click(() => $('#PRODUCT_CODE').focus())

    let dbActive = $("#STATUS").val() == "2";
    // * Carrega os valores iniciais ( Controller )        
    $("#chkActive").prop('checked', dbActive)

    $("#chkActive").on('change', () => {
        let status = $("#chkActive").is(':checked')
        $("#STATUS").val(status ? active_value : inactive_value)
    });

    let error = $('#error').val().trim()
    if (error.length > 0)
        AlertTitleError("Saving Error! ", error)

    let msg = $('#message').val().trim()
    if (msg.length > 0)
        AlertTitleSuccess("Sucesso!", msg)
});