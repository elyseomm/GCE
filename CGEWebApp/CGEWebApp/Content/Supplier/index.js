var action;
var dados;

var pf = 0;
var pj = 1;

var em_elaboracao = 0;
var ativado = 1;
var desativado = 2;
var id = 0;

$(document).ready(() => {
	
	$("#btnAbrir").on('click', () => {		
		GetSupplierByID(id)
	})
	
	$("td").on("dblclick", function () {		
		$("#btnAbrir").click()
	})

	$("#suppliers tr").click(function (event) {
		var cell = this.getElementsByTagName("td")[0];
		id = cell.innerText		
		SelectLine(this, false) //Selecione apenas uma linha

		let situacao = parseInt($("#sit" + id).val())
		EnableButons(situacao)
	})
	
	$("#btnIncluir").on('click', () => {
		GetComboLists()
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
	
	$("#add-btnSalvar").on('click', () => {
		InsertSupplier()
	})

	$("#add-tipopessoa").on('change', () => {

		$('#add-detalhePF').hide()
		$('#add-detalhePJ').hide()

		let tpPessoa = $("#add-tipopessoa").val()
		if (tpPessoa == pf) {

			$('#add-detalhePF').show()
		}
		else {
			$('#add-detalhePJ').show()
        }
	});

	$("#btn-edit-Salvar").on('click', () => {
		SaveChangedSupplier()
	})

	$("#btn-edit-Desativar").on('click', () => {
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

SelectLine = (linha, multiplos) => {
	if (!multiplos) {
		var linhas = linha.parentElement.getElementsByTagName("tr")
		for (var i = 0; i < linhas.length; i++) {
			var linha_ = linhas[i];
			linha_.classList.remove("selecionado")
		}
	}
	linha.classList.toggle("selecionado")	
}

EnableButons = (situacao) => {

	$("#btnAtivar").prop("disabled", false)
	$("#btnDesativar").prop("disabled", false)
	$("#btn-edit-Desativar").prop("disabled", false)

	if (situacao == ativado) {
		$("#btnAtivar").prop("disabled", true)
	}
	else if (situacao == desativado) {
		$("#btnDesativar").prop("disabled", true)
		$("#btn-edit-Desativar").prop("disabled", true)
	}
}

GetSupplierByID = (id) => {

	$('#alerts').html('')
	$('#edit-alerts').html('')

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
	//console.log(response)

	var data = response.data
	if (data) {

		//$('#id-supplier').val(data.Id)
		$('#id-tipopessoa').val(data.TipoPessoa)

		let title = 'Fornecedor ' + data.GetTipoPessoa
		$('#mdl-edit-title').text(title)

		// * HABILITA DIV's CONFORME A SITUAÇÃO ( ATIVADO / DESATIVADO )
		let situacao = parseInt(data.Situacao)
		$('#btn-edit-Salvar').prop("disabled", false)
		$('#frm-edit :input').prop("disabled", false)
		if (situacao == ativado || situacao == desativado) {
			$('#btn-edit-Salvar').prop("disabled", true)
			$('#frm-edit :input').prop("disabled", true)
		}

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
		$('#email').val(data.Email).inputmask({ alias: "email" })

		$('#fone1pf').val(data.Fone1).inputmask("(99)9999[9]-9999")
		$('#fone2pf').val(data.Fone2).inputmask("(99)9999[9]-9999")
		$('#fone3pf').val(data.Fone3).inputmask("(99)9999[9]-9999")

		$('#fone1').val(data.Fone1).inputmask("(99)9999[9]-9999")
		$('#fone2').val(data.Fone2).inputmask("(99)9999[9]-9999")
		$('#fone3').val(data.Fone3).inputmask("(99)9999[9]-9999")
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

		// * CARREGA A TELA EDIT MODAL 
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

GetComboLists = () => {

	$('#alerts').html('')

	var url = "/Supplier/GetComboLists"
	var params = {}
	$.get(url, params, function (response) {

		if (response.Status == true) {

			ShowModalInsertSupplier(response.Data)

		} else {
			alertError(response.ResponseText)
		}
	})
}

ShowModalInsertSupplier = (response) => {

	$("#add-tipopessoa").val(0)
	$("#add-tipopessoa").change()	
	
	// DEFAULT SUPPLIER INFORMATION
	$('#add-tipoPessoa').val('').prop("disabled", true)
	$("#add-nacional").val(1)
	
	$('#add-cpf').val('').inputmask("999.999.999-99")	
	$('#add-cnpj').val('').inputmask("99.999.999/9999-99")	

	$('#add-nome').val('')
	$('#add-razaosocial').val('')

	$('#add-emailpf').val('').inputmask({ alias: "email" })
	$('#add-emailpj').val('').inputmask({ alias: "email" })

	$('#add-fone1pf').val('').inputmask("(99)9999[9]-9999")
	$('#add-fone2pf').val('').inputmask("(99)9999[9]-9999")
	$('#add-fone3pf').val('').inputmask("(99)9999[9]-9999")

	$('#add-fone1pj').val('').inputmask("(99)9999[9]-9999")
	$('#add-fone2pj').val('').inputmask("(99)9999[9]-9999")
	$('#add-fone3pj').val('').inputmask("(99)9999[9]-9999")
	//---------------------------------------------------------------

	// Fill option select Tipo Empresas
	var lstTpEmpresas = response.lstTpEmpresas

	FillOptions($('#add-tipoempresapf'), lstTpEmpresas)
	$('#add-tipoempresapf').val('')
	FillOptions($('#add-tipoempresapj'), lstTpEmpresas)
	$('#add-tipoempresapj').val('')
	
	// SUPPLIER PF
	
	$('#add-profissao').val('')
	$("#add-dtnascimento").val('').inputmask("99/99/9999")
	$('#add-nacionalidade').val('')

	// Fill option select Estado Civil
	var lstEstCivil = response.lstEstCivil
	FillOptions($('#add-estadocivil'), lstEstCivil)
	$('#add-estadocivil').val('')

	// Fill option select Gênero
	var lstGenero = response.lstGenero
	FillOptions($('#add-genero'), lstGenero)
	$('#add-genero').val('')

	//---------------------------------------------------------------
	
	// SUPPLIER PJ
	{
		$('#add-nomefantasia').val('')
		$('#add-porte').val('')
		$('#add-website').val('')
		$('#add-email').val('').inputmask({ alias: "email" });
		$("#add-dtConstituicao").val('').inputmask("99/99/9999")

		// Fill option select Porte Empresas
		var lstPorte = response.lstPorteEmpresas
		FillOptions($('#add-porte'), lstPorte)
		$('#add-porte').val('')

		// Fill option select Caracterizacao do Capital
		var lstPorte = response.lstCaractCapital
		FillOptions($('#add-caractcapital'), lstPorte)
		$('#add-caractcapital').val('')

		$('#add-qtdquota').val(0).inputmask({ alias: "integer", min: 0, max: 10000, thousandsSeparator: ' ' })

		$('#add-vlrquota').val(0).inputmask({ alias: "currency", prefix: 'R$ ' })
		$('#add-capitalsocial').val(0).inputmask({ alias: "currency", prefix: 'R$ ' })
				
		//---------------------------------------------------------------
	}

	// * CARREGA A TELA INSERT MODAL 
	$("#modal-supplier-add").modal("show")
}

// * SAVE NEW 
InsertSupplier = () => {

	var url = "/Supplier/Create";
	let resp = confirm("Deseja realmente salvar?");

	if (resp == true) {

		let tpPessoa = parseInt($("#add-tipopessoa").val())

		var params = (tpPessoa == pf) ?
			{
				CPF: $('#add-cpf').val(),
				Nome: $('#add-nome').val(),
				Email: $('#add-emailpf').val(),
				TipoPessoa: tpPessoa,
				Nacional: $('#add-nacional').val(),
				TipoEmpresa: $('#add-tipoempresapf').val(),

				EstadoCivil: $('#add-estadocivil').val(),
				Profissao: $('#add-profissao').val(),
				Fone1: $('#add-fone1pf').val(),
				Fone2: $('#add-fone2pf').val(),
				Fone3: $('#add-fone3pf').val(),
				DtNascimento: $('#add-dtnascimento').val(),
				Genero: $('#add-genero').val(),
				Nacionalidade: $('#add-nacionalidade').val(),
			} :
			{
				CNPJ: $('#add-cnpj').val(),
				RazaoSocial: $('#add-razaosocial').val(),
				Email: $('#add-emailpj').val(),
				TipoPessoa: tpPessoa,
				Nacional: $('#add-nacional').val(),
				TipoEmpresa: $('#add-tipoempresapj').val(),

				NomeFantasia: $('#add-nomefantasia').val(),
				DtConstituicao: $('#add-dtConstituicao').val(),
				Porte: $('#add-porte').val(),
				Fone1: $('#add-fone1').val(),
				Fone2: $('#add-fone2').val(),
				Fone3: $('#add-fone3').val(),
				WebSite: $('#add-website').val(),
				Email: $('#add-email').val(),
			};

		$.post(url, params, function (response) {
			if (data.Status === false) {
				alertError(response.ResponseText)
			} else {
				alertSuccess(response.ResponseText)
				$("#modal-supplier-add").modal("hide")
			}
		})
	}
}

// * SAVE EDIT
SaveChangedSupplier = () => {

	var url = "/Supplier/Edit";

	let resp = confirm("Deseja realmente salvar as alterações?");

	if (resp == true) {

		let tpPessoa = parseInt($("#id-tipopessoa").val())
		var params = (tpPessoa == pf) ?
		{
			ID: id,
			CPF: $('#cpf').val(),
			Nome: $('#nome').val(),
			Email: $('#emailpf').val(),
			TipoPessoa: tpPessoa,
			Nacional: $('#nacional').val(),
			TipoEmpresa: $('#tipoempresapf').val(),

			EstadoCivil: $('#estadocivil').val(),
			Profissao: $('#profissao').val(),
			Fone1: $('#fone1pf').val(),
			Fone2: $('#fone2pf').val(),
			Fone3: $('#fone3pf').val(),
			DtNascimento: $('#dtnascimento').val(),
			Genero: $('#genero').val(),
			Nacionalidade: $('#nacionalidade').val(),
		} :
		{
				ID: id,
				CNPJ: $('#cnpj').val(),
				RazaoSocial: $('#razaosocial').val(),
				Email: $('#emailpj').val(),
				TipoPessoa: tpPessoa,
				Nacional: $('#nacional').val(),
				TipoEmpresa: $('#tipoempresapj').val(),

				NomeFantasia: $('#nomefantasia').val(),
				DtConstituicao: $('#dtConstituicao').val(),
				Porte: $('#porte').val(),
				Fone1: $('#fone1').val(),
				Fone2: $('#fone2').val(),
				Fone3: $('#fone3').val(),
				WebSite: $('#website').val(),
				Email: $('#email').val(),
				CaracterizacaoCapital: $('#caractcapital').val(),
				QtdQuota: $('#qtdquota').val(),
				VlrQuota: $('#vlrquota').val(),
				CapitalSocial: $('#capitalsocial').val(),
		};

		$.post(url, params, function (response) {

			console.log(response)

			if (response.Status === false) {
				editAlertError(response.ResponseText)
			} else {
				editAlertSuccess(response.ResponseText)
				$("#modal-supplier-add").modal("hide")
			}
		})
	}
}
// * ALARMES
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

let editAlertError = (message) => {
	$('#edit-alerts').html('')
	alertErrorMessage("edit-alerts", message)
	$('#edit-alerts').show()
}
let editAlertSuccess = (message) => {
	$('#edit-alerts').html('')
	alertSuccessMessage("edit-alerts", message)
	$('#edit-alerts').show()
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