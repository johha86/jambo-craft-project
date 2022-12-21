using Microsoft.AspNetCore.Mvc;
using TripPlannerApi.BussinesLayer;
using TripPlannerApi.Models.DTOs;

namespace TripPlannerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly ITripPlannerProvider _tripProvider;

        public CityController(ILogger<CityController> logger, ITripPlannerProvider tripProvider)
        {
            _logger = logger;
            _tripProvider = tripProvider;
        }

        [HttpGet]
        public async Task<ActionResult<TripPlannerDto>> Get()
        {
            try
            {
                _logger.LogInformation("Getting all the cities");
                var result = new TripPlannerDto()
                {
                    CitiesInfo = await _tripProvider.GetCitiesAsync()
                };
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to retrieving the cities.");
                return Problem(e.Message);
            }
        }
    }
}