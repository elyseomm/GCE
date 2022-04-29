using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.Core.Repositories
{
    public class BaseRepository
    {
        public readonly CGEContext _context;
        private readonly ILogger _logger;
        public BaseRepository(ILogger logger,CGEContext db)
        {
            this._logger = logger;
            this._context = db;
        }
    }
}
