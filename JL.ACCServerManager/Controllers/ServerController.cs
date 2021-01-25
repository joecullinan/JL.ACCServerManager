using JL.ACCServerManager.LocalMachineFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JL.ACCServerManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {

        private readonly ILogger<ServerController> _logger;
        private ILocalServerService _localServerService;


        public ServerController(ILogger<ServerController> logger, ILocalServerService localServerService)
        {
            _logger = logger;
            _localServerService = localServerService;
        }


    }
}
