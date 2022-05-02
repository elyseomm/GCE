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
            var row = _service.GetById(id);
            if (row.IsNotNull())
            {
                var tipoEmpresaList = Tool.GetListTipoEmpresas();
                var porteList = Tool.GetListPorteEmpresas();
                var lstTipoCapital = Tool.GetListTipoCapital();

                response.ResponseText = "OK";
                response.Data = new { data = row,
                    lstTpEmpresas = tipoEmpresaList,
                    lstPorteEmpresas = porteList,
                    lstCaractCapital = lstTipoCapital,
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

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _service = GetService();
                var row = _service.GetById(id);

                if ((row.Situacao == (int)EnumSupplierSituation.Desativado) ||
                    (row.Situacao == (int)EnumSupplierSituation.EmElaboracao))
                {
                    _service.Delete(row.Id);
                    return RedirectToAction("Index");
                }
                //else
                //return new ObjectResult("Fornecedor Ativado!");

                return null;
            }
            catch
            {
                return View();
            }
        }
    }
}
