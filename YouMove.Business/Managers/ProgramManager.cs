using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Business.Interfaces;
using YouMove.Data.Context;
using YouMove.Data.Models;

namespace YouMove.Business.Managers {
    public class ProgramManager:IProgramManager {
        private readonly GymTestContext _context;

        public ProgramManager(GymTestContext context) {
            _context = context;
        }
        public Program GetProgramByProgramCode(string ProgramCode) {
            return _context.Programs.FirstOrDefault(p=> p.ProgramCode == ProgramCode);
        }
        public bool AddProgram(Program program) {
          
            if (_context.Programs.Any(p => p.ProgramCode == program.ProgramCode)) return false;

            if (string.IsNullOrEmpty(program.ProgramCode) &&
                string.IsNullOrEmpty(program.Name) && 
               string.IsNullOrEmpty(program.Target) &&
               program.Startdate == null &&
               program.MaxMembers <= 0) return false;

            _context.Programs.Add(program);
            _context.SaveChanges();
            return true;

        }
       
        public bool UpdateProgram(string programCode,Program program) {
            
            var existingProgram = _context.Programs.FirstOrDefault(p => p.ProgramCode == programCode);
            
            if (string.IsNullOrEmpty(program.ProgramCode) &&
                string.IsNullOrEmpty(program.Name) &&
               string.IsNullOrEmpty(program.Target) &&
               program.Startdate == null &&
               program.MaxMembers <= 0) return false;

            if (existingProgram != null) {
                existingProgram.ProgramCode = programCode;
                existingProgram.Name = program.Name;
                existingProgram.Target = program.Target;
                existingProgram.Startdate = program.Startdate;
                existingProgram.MaxMembers = existingProgram.MaxMembers;

            }
            _context.SaveChanges();
            return true;
        }
        
    }
}
