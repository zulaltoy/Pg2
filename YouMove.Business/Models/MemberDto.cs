using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouMove.Business.Models
{
    public class MemberDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string Address { get; set; } = null!;

        public DateOnly Birthday { get; set; }

        public string? Interests { get; set; }

    }
}
