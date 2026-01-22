using Metro_Line_Management.Data.Models;
using Metro_Line_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metro_Line_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinesController : ControllerBase
    {

        private readonly Lines_Service _linesService;
        public LinesController(Lines_Service linesService)
        {
            _linesService = linesService;
        }


        [HttpGet]
        public async Task<IActionResult> GetLines()
        {
            try
            {
                var lines = await _linesService.GetAllLinesAsync();
                return Ok(lines);
            }
            catch (ArgumentException ex)
            {
                return BadRequest( new { message=ex.Message});
            }
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetLineWithStationsById(int id)
        {
            try
            {
                var line = await _linesService.GetLineWithStationByIdAsync(id);
                

                return Ok(new { line = line});
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddLine( Metro_Lines line)
        {
            try
            {
                await _linesService.AddLineAsync(line);
                return CreatedAtAction(nameof(AddLine), new { id = line.Id }, line);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
