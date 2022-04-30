
var action;

$(document).ready(() => {
	
	var id = 0
	$("#btnAbrir").on('click', () => {
		alert('Load Modal Edit ' + id);
	})

	$("suppliers tr").dblclick(() => {
		//code executed on jQuery double click rather than mouse double click		
		//$("#btnAbrir").click()
		alert('Load Modal Edit ' + id);
	})

	$("td").on("dblclick", function () {
		//var currTable = $(this).closest("table").attr("id"),
		//	destinationTable = (currTable.match(/1/)) ? "#table_2" : "#table_1";
		//$(destinationTable).append($(this).parent());
		alert('Load Modal Edit ' + id);
	});

	$("#suppliers tr").click(function (event) {
		var cell = this.getElementsByTagName("td")[0];
		id = cell.innerText		
		selectLine(this, false); //Selecione apenas um

		alert('Load Modal Edit ' + id);
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


EditSupplierPF = (id) => {
	action = 'update';

	$('#id-warehouse').val(id);
	$('#code').val(code);
	$('#description').val(description);

	$("#frm-add").modal("show");

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