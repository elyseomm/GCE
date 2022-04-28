using CGE.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CGE.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ApiControllerBase
    {
        public SuppliersController(ILogger<SuppliersController> logger,
            CGEContext db,
            IHttpContextAccessor accessor) : base(db, logger, accessor)
        {
        }

        [HttpGet]        
        public IEnumerable<Supplier> Get()
        {
            var list = _context.Suppliers.AsEnumerable();
            return list;
        }

        [HttpGet]
        [Route("getall")]
        public ObjectResult Get(int id)
        {
            return new ObjectResult(_context.Suppliers.Find(id));
        }
    }
}
