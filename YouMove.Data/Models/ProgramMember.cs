using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouMove.Data.Models {
    public class ProgramMember {
        public int MemberId { get; set; }
        public string ProgramCode { get; set; } = null!;

        public virtual Member Member { get; set; }
        public virtual Program Program { get; set; }
    }
}
