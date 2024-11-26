using YouMove.Data.Models;
using YouMove.Data.Repositories.Interfaces;
using YouMove.Data.Context;

namespace YouMove.Data.Repositories
{

    public class MemberRepository : IMemberRepository{
        private readonly GymTestContext _context;

        public MemberRepository(GymTestContext context) {
            _context = context;
        }

        public IEnumerable<Member> GetAllMembers() {
            return _context.Members.ToList();
        }

        public Member GetMemberById(int id) {
            return  _context.Members.FirstOrDefault(m=>m.MemberId == id);
        }
        public bool AddMember(Member member) {
            if (_context.Members.Any(m=> m.Email == member.Email)) return false;

            _context.Members.Add(member);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateMember(int id,Member member) {
          
            var existingMember=_context.Members.FirstOrDefault(m=>m.MemberId==id);
            if (existingMember == null) return false;

            existingMember.FirstName = member.FirstName;
            existingMember.LastName = member.LastName;
            existingMember.Email = member.Email;
            existingMember.Address = member.Address;
            existingMember.Birthday = member.Birthday;
            existingMember.Interests = member.Interests;
            existingMember.Membertype = member.Membertype;
            _context.SaveChanges();
            return true;
        }
    }
}
