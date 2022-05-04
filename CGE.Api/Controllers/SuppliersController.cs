using CGE.Api.Responses;
using CGE.Core;
using CGE.Core.DTO;
using CGE.Core.Models;
using CGE.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CGE.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ApiControllerBase
    {
        private SupplierRepository _repo = null;

        public SuppliersController(ILogger<SuppliersController> logger,
            CGEContext db,
            IHttpContextAccessor accessor) : base(db, logger, accessor)
        {
            _repo = new SupplierRepository(logger, db);
        }

        [HttpGet]
        [Route("ping")]
        public ObjectResult Ping() => new ObjectResult("Pong!");

        [HttpGet]        
        public IEnumerable<Supplier> Get() => _repo.GetAll();

        [HttpGet]
        [Route("{id}")]
        public ObjectResult GetById(int id)
        {
            var resp = _repo.GetById(id);
            return new ObjectResult(resp);
        }

        [HttpPost]
        [Route("newpf")]
        public ResponseBase NewSupplierPF(SupplierPFDTO pf)
        {
            var response = new ResponseBase();
            try
            {
                var resp = _repo.NewPF(pf);
                response.Status = true;
                response.Data = resp;
            }
            catch (Exception ex)
            {
                response = ResponseBase.ResponseError(ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("newpJ")]
        public ResponseBase NewSupplierPJ(SupplierPJDTO pj)
        {
            var response = new ResponseBase();
            try
            {
                var resp = _repo.NewPJ(pj);
                response.Status = true;
                response.Data = resp;
            }
            catch (Exception ex)
            {
                response = ResponseBase.ResponseError(ex.Message);
            }
            return response;
        }

        [HttpPut]
        [Route("ativar/{id}")]
        public ActionResult<bool>ActivateSupplier(int id)
        {
            var resp = _repo.AtivarSupplier(id);
            return new ObjectResult(resp);
        }

        [HttpPut]
        [Route("desativar/{id}")]
        public ActionResult<bool> DeactivateSupplier(int id)
        {
            var resp = _repo.DesativarSupplier(id);
            return new ObjectResult(resp);
        }

        [HttpPut]
        [Route("updatepf")]
        public ResponseBase UpdateSupplierPF(SupplierPFDTO pf)
        {
            var response = new ResponseBase();
            try
            {
                var resp = _repo.UpdatePF(pf);
                response.Status = true;
                response.Data = resp;
            }
            catch (Exception ex)
            {
                response = ResponseBase.ResponseError(ex.Message);
            }
            return response;
        }

        [HttpPut]
        [Route("updatepj")]
        public ResponseBase UpdateSupplierPJ(SupplierPJDTO pj)
        {
            var response = new ResponseBase();
            try
            {
                var resp = _repo.UpdatePJ(pj);
                response.Status = true;
                response.Data = resp;
            }
            catch (Exception ex)
            {
                response = ResponseBase.ResponseError(ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Route("delete/{id}")]        
        public ActionResult<bool> DeleteSupplier(int id)
        {
            var resp = _repo.DeleteSupplier(id);
            return new ObjectResult(resp);
        }
    }
}
