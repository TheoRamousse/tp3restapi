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
    public class MovieController : ControllerBase
    {

        private readonly ILogger<MovieController> _logger;
        private readonly IElementService<MovieDto, MovieEntity> _elementService;

        public MovieController(ILogger<MovieController> logger, IElementService<MovieDto, MovieEntity> service)
        {
            _logger = logger;
            _elementService = service;
        }

        [HttpGet("", Name = "GetPagedMovies")]
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

        [HttpPost(Name = "AddMovie")]
        public IActionResult Post([FromBody] object data)
        {
            MovieDto? elementAsDto = null;
            try
            {
                _logger.LogInformation(data.ToString());
                elementAsDto = JsonConvert.DeserializeObject<MovieDto>(data.ToString());
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Le corps de la requête est vide ou une date renseignée est invalide");
            }

            var validationErrors = MovieValidator.Validate(elementAsDto);
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




        [HttpPatch(Name = "PatchMovie")]
        public IActionResult Patch([FromBody] object data)
        {
            MovieDto elementAsDto = null;
            try
            {
                _logger.LogInformation(data.ToString());
                elementAsDto = JsonConvert.DeserializeObject<MovieDto>(data.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Le corps de la requête est vide ou une date renseignée est invalide");
            }

            var validationErrors = MovieValidator.Validate(elementAsDto);
            if (validationErrors == null || validationErrors.Count() == 0)
            {
                var result = _elementService.UpdateElement(elementAsDto);
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


        [HttpDelete("{id}", Name = "DeleteMovie")]
        public IActionResult DeleteById(int id)
        {
            var result = _elementService.DeleteElement(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpGet("{id}", Name = "GetMovie")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _elementService.GetElementById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }
    }
}