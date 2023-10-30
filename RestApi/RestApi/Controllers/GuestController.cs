using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApi.Models.Dtos;
using RestApi.Models.Entities;
using RestApi.Models.Validators;
using RestApi.Services;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
    {

        private readonly ILogger<GuestController> _logger;
        private readonly IElementService<GuestDto, GuestEntity> _elementService;

        public GuestController(ILogger<GuestController> logger, IElementService<GuestDto, GuestEntity> elementService)
        {
            _logger = logger;
            _elementService = elementService;
        }

        [HttpGet(Name = "GetPagedGuests")]
        public IActionResult Get(int page, int itemInPage = 10)
        {
            var result = _elementService.GetPagedElements(page, itemInPage);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost(Name = "AddGuest")]
        public IActionResult Post([FromBody] object data)
        {
            GuestDto elementAsDto = null;
            try
            {
                _logger.LogInformation(data.ToString());
                elementAsDto = JsonConvert.DeserializeObject<GuestDto>(data.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Le corps de la requête est vide ou une date renseignée est invalide");
            }

            var validationErrors = GuestValidator.Validate(elementAsDto);
            if (validationErrors == null || validationErrors.Count() == 0)
            {
                var result = _elementService.InsertElement(elementAsDto);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest(validationErrors);
            }
        }
    }
}