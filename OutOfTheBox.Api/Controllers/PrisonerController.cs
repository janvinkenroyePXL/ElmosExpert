using Microsoft.AspNetCore.Mvc;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Api.Controllers
{
    [Route("api/prisoners")]
    [ApiController]
    public class PrisonerController : ControllerBase
    {
        private readonly IReadPrisonerService _readPrisonerService;
        private readonly IWritePrisonerService _writePrisonerService;
        private readonly IIsolationService _isolationService;
        private readonly IVisitationService _visitationService;
        private readonly IReleaseService _releaseService;

        public PrisonerController(IReadPrisonerService readPrisonerService, IWritePrisonerService writePrisonerService,
            IIsolationService isolationService, IVisitationService visitationService, IReleaseService releaseService)
        {
            _readPrisonerService = readPrisonerService;
            _writePrisonerService = writePrisonerService;
            _isolationService = isolationService;
            _visitationService = visitationService;
            _releaseService = releaseService;
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

        // POST api/prisoners/<id>/visitation-start
        [HttpPost("{id}/visitation-star")]
        public async Task<IActionResult> StartVisitation(int id)
        {
            var returnedDto = await _visitationService.StartVisitation(id);
            if (returnedDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST api/prisoners/<id>/visitation-stop
        [HttpPost("{id}/visitation-stop")]
        public async Task<IActionResult> StopVisitation(int id)
        {
            var returnedDto = await _visitationService.StopVisitation(id);
            if (returnedDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST api/prisoners/<id>/isolation-start
        [HttpPost("{id}/isolation-start")]
        public async Task<IActionResult> StartIsolation(int id)
        {
            var returnedDto = await _isolationService.StartIsolation(id);
            if (returnedDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST api/prisoners/<id>/isolation-stop
        [HttpPost("{id}/isolation-stop")]
        public async Task<IActionResult> StopIsolation(int id)
        {
            var returnedDto = await _isolationService.StopIsolation(id);
            if (returnedDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST api/prisoners/<id>/release-early
        [HttpPost("{id}/release-early")]
        public async Task<IActionResult> ReleaseEarly(int id)
        {
            var returnedDto = await _releaseService.ReleaseEarly(id);
            if (returnedDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
