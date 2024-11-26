using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YouMove.Data.Models;
using YouMove.Business.Interfaces;
using YouMove.Business.Managers;

namespace YouMove.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase {


        private readonly IEquipmentManager _equipmentManager;

        public EquipmentController(IEquipmentManager equipmentManager) {
            _equipmentManager = equipmentManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Equipment>> GetAllEquipments() {
            try {
                return Ok(_equipmentManager.GetAllEquipment());

            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Equipment>> GetEquipmentById(int id) {
            var equipment = _equipmentManager.GetEquipmentById(id);
            if (equipment == null) {
                return NotFound();
            }
            return Ok(equipment);
        }
        [HttpPost]
        public ActionResult<Equipment> AddEquipment(Equipment equipment) {
            if (_equipmentManager.AddEquipment(equipment)) {
                return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.EquipmentId }, equipment); 
            }
            return BadRequest("A equipment with this id already exists."); 
        }
    }
}
