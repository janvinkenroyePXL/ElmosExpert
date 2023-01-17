using Microsoft.AspNetCore.Mvc;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Api.Controllers
{
    [Route("api/prisons")]
    [ApiController]
    public class PrisonController : ControllerBase
    {
        private readonly IReadPrisonService _readPrisonService;
        private readonly IWritePrisonService _writePrisonService;

        public PrisonController(IReadPrisonService readPrisonService, IWritePrisonService writePrisonService)
        {
            _readPrisonService = readPrisonService;
            _writePrisonService = writePrisonService;
        }

        // GET api/prisons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrisonDto>>> GetAllPrisons()
        {
            var prisons = await _readPrisonService.ReadAllAsync();
            return Ok(prisons);
        }

        // GET api/prisons/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PrisonDto>>> GetPrison(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var prison = await _readPrisonService.ReadByKeyAsync(id);
            if (prison != null)
            {
                return Ok(prison);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/prisons
        [HttpPost]
        public async Task<ActionResult<IEnumerable<PrisonDto>>> PostPrison([FromBody] PrisonCreateRequest prison)
        {
            var returnedDto = await _writePrisonService.CreateAsync(prison);
            if (returnedDto == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetPrison), new { returnedDto.Id }, null);
        }

        // PUT api/prisons/<id>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrison(int id, PrisonUpdateRequest prison)
        {
            var returnedDto = await _writePrisonService.UpdateAsync(prison, id);
            if (returnedDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/prisons/<id>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrison(int id)
        {
            if (! await _writePrisonService.DeleteAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
