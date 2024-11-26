using YouMove.Data.Models;

namespace YouMove.Data.Repositories.Interfaces {

    public interface IMemberRepository {

        IEnumerable<Member> GetAllMembers();
        Member? GetMemberById(int id);
        bool AddMember(Member member);
        bool UpdateMember(int id, Member member);
        //bool DeleteMember(int id);
    }
}
