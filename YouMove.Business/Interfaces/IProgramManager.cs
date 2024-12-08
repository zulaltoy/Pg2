﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Data.Models;

namespace YouMove.Business.Interfaces {
    public interface IProgramManager {
        bool AddProgram(Program program);
        bool UpdateProgram(string programCode, Program program);
        Program GetProgramByProgramCode(string ProgramCode);
    }
}
