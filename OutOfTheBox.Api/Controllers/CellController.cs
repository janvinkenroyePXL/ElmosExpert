using Microsoft.AspNetCore.Mvc;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IServices;
using OutOfTheBox.Logic.Services;

namespace OutOfTheBox.Api.Controllers
{
    [Route("api/cells")]
    [ApiController]
    public class CellController : ControllerBase
    {
        private readonly IReadCellService _readCellService;
        private readonly IWriteCellService _writeCellService;

        public CellController(IReadCellService readCellService, IWriteCellService writeCellService)
        {
            _readCellService = readCellService;
            _writeCellService = writeCellService;
        }

        // GET api/cells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CellDto>>> GetAllCells()
        {
            var cells = await _readCellService.ReadAllAsync();
            return Ok(cells);
        }

        // GET api/cells/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CellDto>>> GetCell(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var cell = await _readCellService.ReadByKeyAsync(id);
            if (cell != null)
            {
                return Ok(cell);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/cells
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CellDto>>> PostCell([FromBody] CellCreateRequest cell)
        {
            var returnedDto = await _writeCellService.CreateAsync(cell);
            if (returnedDto == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetCell), new { returnedDto.Id }, null);
        }

        // PUT api/cells/<id>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCell(int id, [FromBody] CellUpdateRequest cell)
        {
            var returnedDto = await _writeCellService.UpdateAsync(cell, id);
            if (returnedDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/cells/<id>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCell(int id)
        {
            if (!await _writeCellService.DeleteAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
