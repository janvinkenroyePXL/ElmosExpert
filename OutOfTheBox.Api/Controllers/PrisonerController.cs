using Microsoft.AspNetCore.Mvc;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;
using OutOfTheBox.Logic.Services;

namespace OutOfTheBox.Api.Controllers
{
    [Route("api/prisoners")]
    [ApiController]
    public class PrisonerController : ControllerBase
    {
        private readonly IReadPrisonerService _readPrisonerService;
        private readonly IWritePrisonerService _writePrisonerService;

        public PrisonerController(IReadPrisonerService readPrisonerService, IWritePrisonerService writePrisonerService)
        {
            _readPrisonerService = readPrisonerService;
            _writePrisonerService = writePrisonerService;
        }

        // GET api/prisoners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrisonerDto>>> GetAllPrisoners()
        {
            var prisoners = await _readPrisonerService.ReadAllAsync();
            return Ok(prisoners);
        }

        // GET api/prisoners/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PrisonerDto>>> GetPrisoner(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var prisoner = await _readPrisonerService.ReadByKeyAsync(id);
            if (prisoner != null)
            {
                return Ok(prisoner);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/prisoners
        [HttpPost]
        public async Task<ActionResult<IEnumerable<PrisonerDto>>> PostPrisoner([FromBody] PrisonerCreateRequest prisoner)
        {
            var returnedDto = await _writePrisonerService.CreateAsync(prisoner);
            if (returnedDto == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetPrisoner), new { returnedDto.Id }, null);
        }

        // PUT api/prisoners/<id>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrisoner(int id, [FromBody] PrisonerUpdateRequest prisoner)
        {
            var returnedDto = await _writePrisonerService.UpdateAsync(prisoner, id);
            if (returnedDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/prisoners/<id>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrisoner(int id)
        {
            if (!await _writePrisonerService.DeleteAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
