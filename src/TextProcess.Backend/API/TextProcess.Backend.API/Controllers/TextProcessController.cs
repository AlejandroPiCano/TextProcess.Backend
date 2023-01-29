using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextProcess.Backend.Application.DTOs;
using TextProcess.Backend.Application.Services;

namespace TextProcess.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextProcessController : ControllerBase
    {
        private const int INTERNAL_SERVER_ERROR = 500;
        private readonly IOrderOptionsService orderOptionsService;
        private readonly IOrderProcessApplicationService orderProcessApplicationService;
        private readonly ILogger<TextProcessController> logger;

        public TextProcessController(IOrderOptionsService orderOptionsService, IOrderProcessApplicationService orderProcessApplicationService, ILogger<TextProcessController> logger)
        {
            this.orderOptionsService = orderOptionsService;
            this.orderProcessApplicationService = orderProcessApplicationService;
            this.logger = logger;
        }

        // GET: api/TextProcessController
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            try
            {
                return Ok(await orderOptionsService.GetOrderOptions());
            }
            catch (System.Exception e)
            {
                logger.LogInformation(e.Message);

                return StatusCode(INTERNAL_SERVER_ERROR, e.Message);
            }
        }
    }
}
