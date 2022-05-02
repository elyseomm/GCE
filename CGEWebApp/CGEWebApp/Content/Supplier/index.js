
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
		//$(destinationTable).append($(this).parent())
		$("#btnAbrir").click()
	})

	$("#suppliers tr").click(function (event) {
		var cell = this.getElementsByTagName("td")[0];
		id = cell.innerText		
		selectLine(this, false) //Selecione apenas um
	})
	
})

MaskCPFCNPJ = () => {
	let value = $('#cpfcnpj').val().replace(/[^\d]+/g, '')	
	var tamanho = value.length;
	//console.log(tamanho)
	if (tamanho == 11) {
		$("#cpfcnpj").inputmask("999.999.999-99")
	} else if (tamanho == 14) {
		$("#cpfcnpj").inputmask("99.999.999/9999-99")
	}
}

MaskNumber = (field) => {

	field.inputmask({
		mask: Number,
		min: -10000,
		max: 10000,
		thousandsSeparator: ' '
	})
}

MaskMoney = (field) => {
	
		field.inputmask('decimal', {
			'alias': 'numeric',			
			'autoGroup': true,
			'digits': 2,
			'radixPoint': ",",
			'groupSeparator': ".",
			'digitsOptional': false,
			'allowMinus': false,
			'prefix': 'R$ ',
			'placeholder': ''
		})
}




GetDate = (epoch) => {
	if (epoch) {
		var val = parseInt(epoch.replace('/Date(', '').replace(')/', ''))
		var frmDate = new Date(val).toLocaleString('en-GB')
		//console.log(frmDate)
		return frmDate
	}
	return ""
}

function selectLine(linha, multiplos) {
	if (!multiplos) {
		var linhas = linha.parentElement.getElementsByTagName("tr")
		for (var i = 0; i < linhas.length; i++) {
			var linha_ = linhas[i];
			linha_.classList.remove("selecionado")
		}
	}
	linha.classList.toggle("selecionado")	
}

GetSupplierByID = (id) => {

	$('#alerts').html('')

	var url = "/Supplier/GetById" 
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




EditSupplier = (response) => {
	action = 'update';
	//console.log(response)

	var data = response.data
	if (data) {

		$('#id-supplier').val(data.Id)
		$('#id-tipopessoa').val(data.TipoPessoa)

		let title = 'Fornecedor ' + data.GetTipoPessoa
		$('#mdl-title').text(title)

		$('#tipoPessoa').val(data.GetTipoPessoa).prop("disabled", true)
		$('#dtatualizacao').val(GetDate(data.DtAtualizacao)).prop("disabled", true)
		$('#situacao').val(data.GetSituacao).prop("disabled", true)

		/*console.log('Nacional ' + data.Nacional)*/
		$("#nacional").val(data.Nacional)
		$('#cpfcnpj').val(data.CPFCNPJ)
		MaskCPFCNPJ()
		$('#razaosocial').val(data.RazaoSocial)
		$('#nomefantasia').val(data.NomeFantasia)
		$('#tipoempresa').val(data.GetTipoEmpresa)
		$('#porte').val(data.GetPorte)
		$('#fone1').val(data.Fone1).inputmask("(99)9999[9]-9999")
		$('#fone2').val(data.Fone2).inputmask("(99)9999[9]-9999")
		$('#fone3').val(data.Fone3).inputmask("(99)9999[9]-9999")

		$('#website').val(data.WebSite)
		$('#email').val(data.Email).inputmask({ alias: "email" });

		$("#dtConstituicao").val(GetDate(data.DtConstituicao)).inputmask("99/99/9999")
		
		// Fill option select Tipo Empresas
		var lstTpEmpresas = response.lstTpEmpresas
		FillOptions($('#tipoempresa'), lstTpEmpresas)
		$('#tipoempresa').val(data.TipoEmpresa)

		// Fill option select Porte Empresas
		var lstPorte = response.lstPorteEmpresas
		FillOptions($('#porte'), lstPorte)
		$('#porte').val(data.Porte)

		// Fill option select Caracterizacao do Capital
		var lstPorte = response.lstCaractCapital
		FillOptions($('#caractcapital'), lstPorte)
		$('#caractcapital').val(data.CaracterizacaoCapital)

		
		$('#qtdquota').val(data.QtdQuota)
		//MaskNumber($('#qtdquota'))
		
		$('#vlrquota').val(data.VlrQuota).inputmask({ alias: "currency", prefix: 'R$ ' });
		//MaskMoney($('#vlrquota'))
				
		//MaskMoney($('#capitalsocial'))
		$('#capitalsocial').val(data.CapitalSocial).inputmask({ alias: "currency", prefix: 'R$ ' });

		$("#modal-supplier-edit").modal("show")
	}
}


FillOptions = (optionname, data) => {

	let itens = '<option value=""></option>'

	$.each(data, function (index, value) {
		//console.log(index, value)
		itens += '<option value="' + value.Value + '">' + value.Text + '</option>'
	})

	$(optionname).html('')
	$(optionname).html(itens)
}

function InsertWarehouse(warehouseCode, description) {
	var url = "/Warehouse/Insert";
	var params = {
		WarehouseCode: warehouseCode,
		Description: description,
	};

	$.post(url, params, function (data) {
		if (data.Status === false) {
			dialogMessageDanger(data.Description)
		} else {
			dialogMessageSuccess(data.Description)
			ListWarehouse()
			$("#frm-add").modal("hide")
		}
	})
}

let alertSuccess = (message) => {
	$('#alerts').html('')
	alertSuccessMessage("alerts", message)
	$('#alerts').show()
}

let alertError = (message) => {
	$('#alerts').html('')
	alertErrorMessage("alerts", message)
	$('#alerts').show()
}

function alertWarningMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-warning" style="height: 50px; font-size: 16px;">' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Warning!</strong> ' + msg +
		'</div>'
	))
}

function alertSuccessMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-success" style="height: 50px; font-size: 16px; background-color: #3cc900; border-color: #3cc900; color: #FFFFFF;">' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Success!</strong> ' + msg +
		'</div>'
	))
}

function alertErrorMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-danger" style="height: 50px; font-size: 16px; background-color: #ff0000; border-color: #ff0000; color: #FFFFFF;">' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Error!</strong> ' + msg +
		'</div>'
	))
}

function alertInfoMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-info" style="height: 50px; font-size: 16px;>"' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Info!</strong> ' + msg +
		'</div>'
	))
}