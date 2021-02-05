using Microsoft.AspNetCore.Mvc;
using SRContainerSample.Web.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRContainerSample.Web.Controllers
{
    [ApiController, Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [HttpGet("locations/{postalCode}")]
        public async Task<IActionResult> GetMexicoLocationsByPostalCode([RegularExpression("\\d\\d\\d\\d\\d")] string postalCode)
        {
            var items = await _weatherService.GetMexicoLocationsByPostalCodeAsync(postalCode);
            if (items.Any())
            {
                return Ok(items);
            }
            return NotFound();
        }
    }
}
