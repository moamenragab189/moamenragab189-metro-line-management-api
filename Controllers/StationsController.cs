using Metro_Line_Management.Data.Models;
using Metro_Line_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro_Line_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly Stations_Service _stationsService;

        public StationsController(Stations_Service Service)
        {
            _stationsService = Service;
        }

        [HttpPost]
        public async Task<IActionResult> AddStation(Metro_Stations station)
        {
            try {
                await _stationsService.AddStationAsync(station);
                return CreatedAtAction(nameof(AddStation), new { id = station.Id },station);
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(new { message= ex.Message });
            }
        }


        [HttpGet("line/{id}")]
        public async Task<IActionResult> GetStationsByLineId(int id)
        {
            try
            {
                var station = await _stationsService.GetStationsByLineIdAsync(id);
                return Ok(station);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message= ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStationById(int id)
        {
            try
            {
                var station = await _stationsService.GetStationByIdAsync(id);
                return Ok(station);
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
