
var controllerName = "/ProjectControl";

$(document).ready(() => {   
    //$("#btn-add").click(() => FormInfoValidate())    
    CheckProject()

    $("#ID_PROJECT").on('change', () => CheckProject());   
});

CheckProject = () => {
    let project = $("#ID_PROJECT").val()
    // Se desativou VisibleWO é desativado junto
    $("#btn-create").attr('disabled', project == -1)
}

function FormInfoValidate()
{
    if ($('#param_name').val().trim().length > 0) {
        //var url = 'Adding?Name=' + $('#param_name').val() + '&Description=' + $('#description') + '&IsActive=' + $('#Status').val() + '&Editable=' + $('#Editable').val() + '&Wo=' + $('#Wo').val();

        // Refactore by Elyseo Mesquita em 12/08/2020
        try {
            var url = controllerName + "/Add";

            var parameters = {
                Name: $('#param_name').val(),
                Description: $('#description').val(),
                IsActive: $('#Status').is(':checked'),
                Editable: $('#Editable').is(':checked'),
                Wo: $('#wo').is(':checked')
            };

            var result = false;

            Request.Post(url, parameters,
                (response) => {
                    console.log(response);
                    result = response.Status
                    SetModalDlgMessage(response.ResponseText)
                    OpenModal("#infoModal")
                    Sleep(2500, "Loading Index...", gotoIndex)
                },
                (err) => {
                    SetModalDlgMessage("Erro: " + err.ErrorMessage)
                    OpenModal("#infoModal")
                }
            );
            return result;

        } catch (e) {
            alert(e);
        }
    } else
    {
        SetModalDlgMessage("A Requered Field is Empty")
        OpenModal("#infoModal")
    }

}