var action;
var dados;

var pf = 0;
var pj = 1;

var em_elaboracao = 0;
var ativado = 1;
var desativado = 2;


$(document).ready(() => {
	
	var id = 0
	var item;

	$("#btnAbrir").on('click', () => {		
		GetSupplierByID(id)
	})
	
	$("td").on("dblclick", function () {		
		$("#btnAbrir").click()
	})

	$("#suppliers tr").click(function (event) {
		var cell = this.getElementsByTagName("td")[0];
		id = cell.innerText		
		selectLine(this, false) //Selecione apenas um
	})
		
	$("#btnExcluir").on('click', () => {
		DeleteByID(id)
	})

	$("#btnAtivar").on('click', () => {
		ChangeSituationByID(id, ativado)
	})

	$("#btnDesativar").on('click', () => {
		ChangeSituationByID(id, desativado)
	})
})

MaskCPFCNPJ = (field) => {
	let value = field.val().replace(/[^\d]+/g, '')	
	var tamanho = value.length;
	//console.log(tamanho)
	if (tamanho == 11) {
		field.inputmask("999.999.999-99")
	} else if (tamanho == 14) {
		field.inputmask("99.999.999/9999-99")
	}
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

		// DEFAULT SUPPLIER INFORMATION
		$('#tipoPessoa').val(data.GetTipoPessoa).prop("disabled", true)
		$('#dtatualizacao').val(GetDate(data.DtAtualizacao)).prop("disabled", true)
		$('#situacao').val(data.GetSituacao).prop("disabled", true)
		$("#nacional").val(data.Nacional)

		$('#cpf').val(data.CPFCNPJ)
		MaskCPFCNPJ($('#cpf'))
		$('#cnpj').val(data.CPFCNPJ)
		MaskCPFCNPJ($('#cnpj'))

		$('#nome').val(data.RazaoSocial)
		$('#razaosocial').val(data.RazaoSocial)

		$('#emailpf').val(data.Email).inputmask({ alias: "email" })
		$('#emailpj').val(data.Email).inputmask({ alias: "email" })

		$('#fone1pf').val(data.Fone1).inputmask("(99)9999[9]-9999")
		$('#fone2pf').val(data.Fone2).inputmask("(99)9999[9]-9999")
		$('#fone3pf').val(data.Fone3).inputmask("(99)9999[9]-9999")

		$('#fone1pj').val(data.Fone1).inputmask("(99)9999[9]-9999")
		$('#fone2pj').val(data.Fone2).inputmask("(99)9999[9]-9999")
		$('#fone3pj').val(data.Fone3).inputmask("(99)9999[9]-9999")
		//---------------------------------------------------------------

		// Fill option select Tipo Empresas
		var lstTpEmpresas = response.lstTpEmpresas

		FillOptions($('#tipoempresapf'), lstTpEmpresas)
		$('#tipoempresapf').val(data.TipoEmpresa)
		FillOptions($('#tipoempresapj'), lstTpEmpresas)
		$('#tipoempresapj').val(data.TipoEmpresa)

		$('#detalhePF').hide()
		$('#detalhePJ').hide()

		// SUPPLIER PF
		if (data.TipoPessoa == pf)
		{
			$('#profissao').val(data.Profissao)
			$("#dtnascimento").val(GetDate(data.DtNascimento)).inputmask("99/99/9999")
			$('#nacionalidade').val(data.Nacionalidade)
			
			
			

			// Fill option select Estado Civil
			var lstEstCivil = response.lstEstCivil
			FillOptions($('#estadocivil'), lstEstCivil)
			$('#estadocivil').val(data.EstadoCivil)

			// Fill option select Gênero
			var lstGenero = response.lstGenero
			FillOptions($('#genero'), lstGenero)
			$('#genero').val(data.Genero)

			$('#detalhePF').show()
			//---------------------------------------------------------------
		}
		else // SUPPLIER PJ
		{
			

			$('#nomefantasia').val(data.NomeFantasia)
			$('#porte').val(data.GetPorte)
			$('#website').val(data.WebSite)
			$('#email').val(data.Email).inputmask({ alias: "email" });
			$("#dtConstituicao").val(GetDate(data.DtConstituicao)).inputmask("99/99/9999")

			

			// Fill option select Porte Empresas
			var lstPorte = response.lstPorteEmpresas
			FillOptions($('#porte'), lstPorte)
			$('#porte').val(data.Porte)

			// Fill option select Caracterizacao do Capital
			var lstPorte = response.lstCaractCapital
			FillOptions($('#caractcapital'), lstPorte)
			$('#caractcapital').val(data.CaracterizacaoCapital)

			$('#qtdquota').val(data.QtdQuota).inputmask({ alias: "integer", min: 0, max: 10000, thousandsSeparator: ' ' })

			$('#vlrquota').val(data.VlrQuota).inputmask({ alias: "currency", prefix: 'R$ ' })
			$('#capitalsocial').val(data.CapitalSocial).inputmask({ alias: "currency", prefix: 'R$ ' })

			$('#detalhePJ').show()
			//---------------------------------------------------------------
		}



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

DeleteByID = (id) => {

	$('#alerts').html('')

	let resp = confirm("Deseja realmente excluir o fornecedor?");

	if (resp == true) {

		var url = "/Supplier/Delete"
		var params = {
			id: id
		}
		$.post(url, params, function (response) {

			if (response.Status == false)
				alertError(response.ResponseText)
		})
	}
}

ChangeSituationByID = (id, situacao) => {

	$('#alerts').html('')

	let tipo = situacao == ativado ? 'ativar' : 'desativar'

	let resp = confirm("Deseja realmente " + tipo + " o fornecedor?");

	if (resp == true) {

		var url = "/Supplier/MudarSituacao"
		var params = {
			situacao: situacao,
			id: id
		}
		$.post(url, params, function (response) {

			if (response.Status == true)
				location.reload()
			else
				alertError(response.ResponseText)
		})
	}
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
		'<strong>Warning! </strong> ' + msg +
		'</div>'
	))
}

function alertSuccessMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-success" style="height: 50px; font-size: 16px; background-color: #3cc900; border-color: #3cc900; color: #FFFFFF;">' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Success! </strong> ' + msg +
		'</div>'
	))
}

function alertErrorMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-danger" style="height: 50px; font-size: 16px; background-color: #ff0000; border-color: #ff0000; color: #FFFFFF;">' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Error! </strong> ' + msg +'</h5></div>'
	))
}

function alertInfoMessage(idElement, msg) {
	$('#' + idElement).prepend($(
		'<div class="alert alert-info" style="height: 50px; font-size: 16px;>"' +
		'<a href="#" class="close" data-dismiss="alert">&times;</a>' +
		'<strong>Info! </strong> ' + msg +
		'</div>'
	))
}