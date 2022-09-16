using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactNet.Models;
using ReactNet.Services;

namespace ReactNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private CityService _cityService;
        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var cities = _cityService.GetAll();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            try
            {
                var city = _cityService.GetCityById(id);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCity([FromBody] CityForm model)
        {
            _cityService.CreateCity(model);
            return Ok(new { message = "City created" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, CityForm model)
        {
            _cityService.UpdateCity(id, model);
            return Ok(new { message = "City updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cityService.DeleteCity(id);
            return Ok(new { message = "City deleted" });
        }
    }
}
