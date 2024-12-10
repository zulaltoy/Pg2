using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Business.Models;
using YouMove.Data.Models;

namespace YouMove.Business.Interfaces {
    public interface IProgramManager {
        bool AddProgram(ProgramDto program);
        bool UpdateProgram(string programCode, ProgramDto program);
        ProgramDto GetProgramByProgramCode(string ProgramCode);
        IEnumerable<ProgramDto> GetAllPrograms();

    }
}
