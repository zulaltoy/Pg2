using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Data.Context;
using YouMove.Data.Models;
using YouMove.Data.Repositories.Interfaces;

namespace YouMove.Data.Repositories {
    public class ProgramRepository :IProgramRepository {
        private readonly GymTestContext _context;

        public ProgramRepository(GymTestContext context) {
            _context = context;
        }
        public Program GetProgramByProgramCode(string ProgramCode) {
           return _context.Programs.FirstOrDefault(p => p.ProgramCode == ProgramCode);

        }
        public bool AddProgram(Program program) {
            if(_context.Programs.Any(p => p.ProgramCode == program.ProgramCode)) return false;
            //if (_context.Programs.Any(p => p.Equals(program))) return false;
            _context.Programs.Add(program);
            _context.SaveChanges();
            return true;

        }
        public bool UpdateProgram(string programCode, Program program) {

            var existingProgram = _context.Programs.FirstOrDefault(p => p.ProgramCode == programCode);
            if(existingProgram == null) return false;

            existingProgram.ProgramCode = programCode;
            existingProgram.Name = program.Name;
            existingProgram.Target = program.Target;
            existingProgram.Startdate = program.Startdate;
            existingProgram.MaxMembers = program.MaxMembers;

            _context.Programs.Update(existingProgram);
            _context.SaveChanges(); 
            return true;
        }
    }
}
