using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCore;
using WebCore.ClientHttp;
using WebCore.DTO;
using WebCore.Enums;
using WebCore.Services;

namespace CGEWebApp.Controllers
{
    public class SupplierController : Controller
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
        public ActionResult Index()
        {
            _service = GetService();
            var rows = _service.GetAll().Result;
            return View(rows);
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            _service = GetService();
            var row = _service.GetById(id);
            return View(row);
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
