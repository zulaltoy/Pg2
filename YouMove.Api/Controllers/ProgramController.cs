using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YouMove.Business.Models;
using YouMove.Business.Managers;
using YouMove.Business.Interfaces;

namespace YouMove.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase {
        private readonly IProgramManager _programManager;

        public ProgramController(IProgramManager programManager) {
            _programManager = programManager;
        }
        [HttpGet]
        public ActionResult<ProgramDto> GetAllPrograms() {
            var program = _programManager.GetAllPrograms();
            
            return Ok(program);
        }
        [HttpGet("{programCode}")]
        public ActionResult<ProgramDto> GetProgramByProgramCode(string programCode) {
            var program = _programManager.GetProgramByProgramCode(programCode);
            if (program == null) {
                return NotFound();
            }
            return Ok(program);
        }
        [HttpPost]
        public ActionResult<ProgramDto> AddProgram(ProgramDto program) {
            if (_programManager.AddProgram(program)) {
                return CreatedAtAction(nameof(GetProgramByProgramCode), new { programCode = program.ProgramCode }, program);
            }
            return BadRequest("A program with this name already exists.");
        }
        [HttpPut("{programCode}")]
        public IActionResult UpdateProgram(string programCode, ProgramDto program) {
            if (!_programManager.UpdateProgram(programCode, program)) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
