using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using TextProcess.Backend.Application.DTOs;
using TextProcess.Backend.Application.Services;

namespace TextProcess.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextProcessController : ControllerBase
    {
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
            catch (System.Exception exception)
            {
                logger.LogInformation(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        // POST: api/TextProcessController/Order?orderOption={orderOption}
        [HttpPost("Order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<string>> Post([Required, FromBody] string textToOrder, [Required] OrderOptionDTO orderOption)
        {
            try
            {
                return Ok(orderProcessApplicationService.GetOrderedText(textToOrder, orderOption));
            }
            catch (ArgumentException argumentException)
            {
                logger.LogError(argumentException.Message);

                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        // Post: api/TextProcessController/Analize
        [HttpPost("Analize")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TextStatisticsDTO> Post([Required, FromBody] string textToAnalize)
        {
            try
            {
                return Ok(orderProcessApplicationService.GetStatistics(textToAnalize));
            }
            catch (ArgumentException argumentException)
            {
                logger.LogError(argumentException.Message);

                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
