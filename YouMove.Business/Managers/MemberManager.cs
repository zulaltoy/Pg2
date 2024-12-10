using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Business.Interfaces;
using YouMove.Data.Context;
using YouMove.Data.Models;
using YouMove.Business.Models;


namespace YouMove.Business.Managers {
    public class MemberManager :IMemberManager{
        private readonly GymTestContext _context;

        public MemberManager(GymTestContext context) {
            _context = context;
        }

        public IEnumerable<MemberDto> GetAllMembers() {
            return _context.Members
             .Select(p => new MemberDto {
                 FirstName = p.FirstName,
                 LastName = p.LastName,
                 Email = p.Email,
                 Address = p.Address,
                 Birthday = p.Birthday,
                 Interests = p.Interests,
             }).ToList();
        }

        public Member GetMemberById(int id) {
            var Member = _context.Members.FirstOrDefault(m => m.MemberId == id);
            if (Member == null) return null;
            //return new MemberDto {
            //    FirstName = Member.FirstName,
            //    LastName = Member.LastName,
            //    Email = Member.Email,
            //    Address = Member.Address,
            //    Birthday = Member.Birthday,
            //    Interests = Member.Interests,
            //};
        }
        public bool AddMember(Member member) {
            if (string.IsNullOrEmpty(member.FirstName) || string.IsNullOrEmpty(member.LastName) ||
                string.IsNullOrEmpty(member.Address) || member.Birthday == default(DateOnly) ||
                string.IsNullOrEmpty(member.Membertype) || string.IsNullOrEmpty(member.Email))   return false;
            
            if (!string.IsNullOrEmpty(member.Email) && _context.Members.Any(m => m.Email == member.Email)) return false;
            
            _context.Members.Add(member);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateMember(int id, Member member) {

            var existingMember = _context.Members.FirstOrDefault(m => m.MemberId == id);
            if (string.IsNullOrEmpty(member.FirstName) && string.IsNullOrEmpty(member.LastName) &&
               string.IsNullOrEmpty(member.Address) && member.Birthday == default(DateOnly) &&
               string.IsNullOrEmpty(member.Membertype) && string.IsNullOrEmpty(member.Email)) return false;

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
