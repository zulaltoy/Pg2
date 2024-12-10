using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Business.Models;
using YouMove.Data.Models;

namespace YouMove.Business.Interfaces {
    public interface IMemberManager {
        IEnumerable<MemberDto> GetAllMembers();
        MemberDto? GetMemberById(int id);
        bool AddMember(MemberDto member);
        bool UpdateMember(int id, MemberDto member);
    }
}
