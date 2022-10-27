using CityPopulation.Models;
using CityPopulation.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityPopulation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityPopulationController : ControllerBase
    {
       
        public CityPopulationController()
        {
           
        }

        [HttpGet]
        [Route("TopTen")]
        public IActionResult GetTopTenCityPopulation()
        {
            return Ok(CityPopulationService.GetTopTenCityPopulation());
        }

        [HttpGet]
        [Route("{city}")]
        public IActionResult GetPopulationByCity(string city)
        {
            List<City> populations = CityPopulationService.GetPopulationByCity(city);

            if(populations.Count == 0) return NotFound();

            return Ok(populations.First());
        }
    }
}