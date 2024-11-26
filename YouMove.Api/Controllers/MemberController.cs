using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YouMove.Data.Models;
using YouMove.Business.Interfaces;
using YouMove.Business.Managers;
namespace YouMove.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase {
        private readonly IMemberManager _memberManager;

        public MemberController(IMemberManager memberManager) {
            _memberManager = memberManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetAllMembers() {
            var members = _memberManager.GetAllMembers();
            return Ok(members);
        }
        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id) {
            var member = _memberManager.GetMemberById(id);
            if (member == null) {
                return NotFound(); 
            }
            return Ok(member); 
        }
        [HttpPost]
        public ActionResult<Member> AddMember(Member member) {
            if (_memberManager.AddMember(member)) {
                return CreatedAtAction(nameof(GetMemberById), new { id = member.MemberId }, member); 
            }
            return BadRequest("A member with this email already exists."); 
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, Member member) {
            if (!_memberManager.UpdateMember(id, member)) {
                return NotFound(); 
            }
            return NoContent(); 
        }
    }
}
