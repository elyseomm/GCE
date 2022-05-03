using CGEWebApp.Tools;
using Newtonsoft.Json.Linq;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCore;
using WebCore.ClientHttp;
using WebCore.DTO;
using WebCore.Enums;
using WebCore.Extensions;
using WebCore.Responses;
using WebCore.Services;

namespace CGEWebApp.Controllers
{
    public class SupplierController : BaseController
    {
        private SupplierService _service = null;

        private SupplierService GetService()
        {
            if (_service.IsNull())
            {
                _service = new SupplierService();
            }
            return _service;
        }

        // GET: Supplier
        public ActionResult Index(int page = 1)
        {
            try
            {
                @ViewBag.Erro = string.Empty;
                _service = GetService();
                var rows = _service.GetAll().Result;
                var pagedRows = rows.OrderByDescending(a => a.TipoPessoa).ToPagedList(page, 50);
                return View(pagedRows);
            }
            catch (Exception ex)
            {
                @ViewBag.Erro = ex.Message;
            }
            return View();
        }

        // GET: Supplier/Details/5
        public JsonResult GetById(int id)
        {
            var response = ResponseBase.ResponseError("Fornecedor não encontrado!");
            _service = GetService();
            var row = _service.GetById(id).Result;
            if (row.IsNotNull())
            {
                var tipoEmpresaList = Tool.GetTipoEmpresasList();
                var porteList = Tool.GetPorteEmpresasList();
                var tipoCapitalList = Tool.GetTipoCapitalList();
                var generoList = Tool.GetGeneroList();
                var estCivilList = Tool.GetEstadoCivilList();

                response.ResponseText = "OK";
                response.Data = new { data = row,
                    lstTpEmpresas = tipoEmpresaList,
                    lstPorteEmpresas = porteList,
                    lstCaractCapital = tipoCapitalList,
                    lstGenero = generoList,
                    lstEstCivil = estCivilList,
                };
                response.Status = true;
                
                return JsonResponse(response);
            }
            return JsonResponse(response);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult CreatePF(FormCollection collection)
        {
            try
            {
                var newPF = new SupplierPFDTO();

                _service = GetService();
                var row = _service.SalvarPF(newPF);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult EditPF(int id, FormCollection collection)
        {
            try
            {
                _service = GetService();
                var row = _service.GetById(id);
                var pf = new SupplierPFDTO();



                _service.SalvarPF(pf);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = ResponseBase.ResponseError("Fornecedor Ativado! Exclusão não permitida.");
            try
            {
                _service = GetService();
                var row = _service.GetById(id).Result;

                if ((row.Situacao == (int)EnumSupplierSituation.Desativado) ||
                    (row.Situacao == (int)EnumSupplierSituation.EmElaboracao))
                {
                    _service.Delete(row.Id);
                    return RedirectToAction("Index");
                }
            }
            catch( Exception ex)
            {
                response.ResponseText = ex.Message;
            }
            return JsonResponse(response);
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult ChangeSituacao(int id, int type)
        {
            var tpStatus = type == EnumSupplierSituation.Ativado.AsInt() ? "Ativado" : "Desativado";

            var response = ResponseBase.ResponseError($"Fornecedor já está {tpStatus}!");
            try
            {
                _service = GetService();
                var row = _service.GetById(id).Result;

                if (row.Situacao == type) 
                {   
                    row.Situacao = type;
                    //_service.SalvarPF(row);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                response.ResponseText = ex.Message;
            }
            return JsonResponse(response);
        }
    }
}
