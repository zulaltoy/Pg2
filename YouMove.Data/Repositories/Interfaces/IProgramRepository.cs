using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Data.Models;

namespace YouMove.Data.Repositories.Interfaces {
    public interface IProgramRepository {
        bool AddProgram(Program program);
        bool UpdateProgram(string programCode, Program program);
        Program GetProgramByProgramCode(string ProgramCode);
    }
}
