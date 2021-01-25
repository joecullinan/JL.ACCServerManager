using JL.ACCServerManager.LocalMachineFunctions;
using JL.ACCServerManager.Models;
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

        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> StartServer()
        {
            try
            {
                await _localServerService.startServer();
                return Ok();
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        [Route("stop")]

        public async Task<IActionResult> StopServer()
        {
            try
            {
                await _localServerService.stopServer();
                return Ok();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet]
        [Route("eventConfig")]
        public async Task<IActionResult> GetEventConfig()
        {
            try
            {
                var eventConfig = await _localServerService.getEventConfig();
                return Ok(eventConfig);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
        [HttpPost]
        [Route("eventConfig")]
        public async Task<IActionResult> PostEventConfig(Event eventConfig)
        {
            try
            {
                var eventConfigResult = await _localServerService.writeEventConfig(eventConfig);
                return Ok(eventConfigResult);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

    }
}
