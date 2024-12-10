using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouMove.Business.Models {
    public class ProgramDto {
        public string ProgramCode { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Target { get; set; } = null!;

        public DateTime Startdate { get; set; }

        public int MaxMembers { get; set; }
    }
}
