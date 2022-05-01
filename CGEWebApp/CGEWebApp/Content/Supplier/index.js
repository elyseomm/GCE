
var action;
var dados;

var pf = 0;
var pj = 1;

$(document).ready(() => {
	
	var id = 0
	var item;

	$("#btnAbrir").on('click', () => {		
		GetSupplierByID(id)
	})

	
	$("td").on("dblclick", function () {
		//var currTable = $(this).closest("table").attr("id"),
		//	destinationTable = (currTable.match(/1/)) ? "#table_2" : "#table_1";
		//$(destinationTable).append($(this).parent());
		$("#btnAbrir").click()
	});

	$("#suppliers tr").click(function (event) {
		var cell = this.getElementsByTagName("td")[0];
		id = cell.innerText		
		selectLine(this, false); //Selecione apenas um
	})
})

function selectLine(linha, multiplos) {
	if (!multiplos) {
		var linhas = linha.parentElement.getElementsByTagName("tr");
		for (var i = 0; i < linhas.length; i++) {
			var linha_ = linhas[i];
			linha_.classList.remove("selecionado");
		}
	}
	linha.classList.toggle("selecionado");	
}

GetSupplierByID = (id) => {

	$('#alerts').html('');

	var url = "Supplier/GetById" 
	var params = {
		id: id
	}
	$.get(url, params, function (response) {

		if (response.Status == true) {

			EditSupplier(response.Data)

		} else {
			alertError(response.ResponseText)
		}
	})
}



EditSupplier = (data) => {
	action = 'update';
	console.log(data)
	
	$('#id-supplier').val(data.Id);
	$('#id-tipopessoa').val(data.TipoPessoa);
	
	let title = 'Fornecedor ' + data.GetTipoPessoa
	$('#mdl-title').text(title)

	$('#tipoPessoa').val(data.GetTipoPessoa)
	$('#tipoPessoa').prop("disabled", true);

	$('#nacional').val(data.GetNacional);

	$('#dtatualizacao').val(data.DtAtualizacao);
	$('#situacao').val(data.GetSituacao);
	$('#situacao').prop("disabled", true);

	$('#cpfcnpj').val(data.CPFCNPJ)
	$('#razaosocial').val(data.RazaoSocial)
	$('#nomefantasia').val(data.NomeFantasia)

	$('#tipoempresa').val(data.GetTipoEmpresa);
	$('#porte').val(data.GetPorte);
	$('#fone1').val(data.Fone1);
	//$('#razaosocial').val(data.RazaoSocial);
	//$('#razaosocial').val(data.RazaoSocial);
	$("#modal-supplier-edit").modal("show");

}

function InsertWarehouse(warehouseCode, description) {
	var url = "/Warehouse/Insert";
	var params = {
		WarehouseCode: warehouseCode,
		Description: description,
	};

	$.post(url, params, function (data) {
		if (data.Status === false) {
			dialogMessageDanger(data.Description);
		} else {
			dialogMessageSuccess(data.Description);
			ListWarehouse();
			$("#frm-add").modal("hide");
		}
	});
}

let alertSuccess = (message) => {
	$('#alerts').html('');
	alertSuccessMessage("alerts", message);
	$('#alerts').show();
}

let alertError = (message) => {
	$('#alerts').html('');
	alertErrorMessage("alerts", message);
	$('#alerts').show();
}

function alertWarningMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-warning" style="height: 50px; font-size: 16px;">' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Warning!</strong> ' + msg +
		'</div>'
	));
}

function alertSuccessMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-success" style="height: 50px; font-size: 16px; background-color: #3cc900; border-color: #3cc900; color: #FFFFFF;">' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Success!</strong> ' + msg +
		'</div>'
	));
}

function alertErrorMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-danger" style="height: 50px; font-size: 16px; background-color: #ff0000; border-color: #ff0000; color: #FFFFFF;">' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Error!</strong> ' + msg +
		'</div>'
	));
}

function alertInfoMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-info" style="height: 50px; font-size: 16px;>"' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Info!</strong> ' + msg +
		'</div>'
	));
}