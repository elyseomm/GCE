using CGE.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace CGE.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ApiControllerBase : ControllerBase
    {
        public readonly CGEContext _context;
        private readonly ILogger<ApiControllerBase> _logger;
        private readonly IHttpContextAccessor _accessor;

        public ApiControllerBase(CGEContext context, ILogger<ApiControllerBase> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _context = context;
            _accessor = accessor;
        }

        protected ActionResult JsonResponse(object obj)
        {
            var jobj = JObject.FromObject(obj);

            return new ObjectResult(jobj.ToString());
        }
    }
}
