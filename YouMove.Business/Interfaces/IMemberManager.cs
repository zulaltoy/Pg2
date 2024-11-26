using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Data.Models;

namespace YouMove.Business.Interfaces {
    public interface IMemberManager {
        IEnumerable<Member> GetAllMembers();
        Member? GetMemberById(int id);
        bool AddMember(Member member);
        bool UpdateMember(int id, Member member);
    }
}
