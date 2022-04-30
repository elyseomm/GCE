using CGE.Core;
using CGE.Core.DTO;
using CGE.Core.Models;
using CGE.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public ActionResult<SupplierPFDTO> NewSupplierPF(SupplierPFDTO pf)
        {
            var resp = _repo.NewPF(pf);
            return new ObjectResult(resp);
        }

        [HttpPost]
        [Route("newpJ")]
        public ActionResult<SupplierPJDTO> NewSupplierPJ(SupplierPJDTO pj)
        {
            var resp = _repo.NewPJ(pj);
            return new ObjectResult(resp);
        }


        [HttpPatch]
        [Route("ativar/{id}")]
        public ActionResult<bool>ActivcateSupplier(int id)
        {
            var resp = _repo.AtivarSupplier(id);
            return new ObjectResult(resp);
        }

        [HttpPatch]
        [Route("desativar/{id}")]
        public ActionResult<bool> DeactivcateSupplier(int id)
        {
            var resp = _repo.DesativarSupplier(id);
            return new ObjectResult(resp);
        }

        [HttpPut]
        [Route("updatepf")]
        public ActionResult<SupplierPFDTO> UpdateSupplierPF(SupplierPFDTO pf)
        {
            var resp = _repo.UpdatePF(pf);
            return new ObjectResult(resp);
        }

        [HttpPut]
        [Route("updatepj")]
        public ActionResult<SupplierPFDTO> UpdateSupplierPj(SupplierPJDTO pj)
        {
            var resp = _repo.UpdatePJ(pj);
            return new ObjectResult(resp);
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
