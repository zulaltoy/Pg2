using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Business.Interfaces;
using YouMove.Business.Models;
using YouMove.Data.Context;
using YouMove.Business.Models;
using YouMove.Data.Models;


namespace YouMove.Business.Managers {
    public class ProgramManager:IProgramManager {
        private readonly GymTestContext _context;

        public ProgramManager(GymTestContext context) {
            _context = context;
        }
        public IEnumerable<ProgramDto> GetAllPrograms() {
            return _context.Programs
            .Select(p => new ProgramDto {
                ProgramCode = p.ProgramCode,
                Name = p.Name,
                Target = p.Target,
                Startdate = p.Startdate,
                MaxMembers = p.MaxMembers
            }).ToList();
        }
        public ProgramDto GetProgramByProgramCode(string ProgramCode) {
            var program= _context.Programs.FirstOrDefault(p=> p.ProgramCode == ProgramCode);
            if (program == null) return null;
            return new ProgramDto {
                
                Name = program.Name,
                Target = program.Target,
                Startdate = program.Startdate,
                MaxMembers = program.MaxMembers
            };
        }
        public bool AddProgram(ProgramDto program) {
          
            if (_context.Programs.Any(p => p.ProgramCode == program.ProgramCode)) return false;

            if (string.IsNullOrEmpty(program.ProgramCode) ||
                string.IsNullOrEmpty(program.Name) || 
               string.IsNullOrEmpty(program.Target) ||
               program.Startdate == null ||
               program.MaxMembers <= 0) return false;

            var ProgramEntity = new Program {
                ProgramCode = program.ProgramCode,
                Name = program.Name,
                Target = program.Target,
                Startdate = program.Startdate,
                MaxMembers = program.MaxMembers
            };
            _context.Programs.Add(ProgramEntity);
            _context.SaveChanges();
            return true;

        }
       
        public bool UpdateProgram(string programCode, ProgramDto program) {
            
            var existingProgram = _context.Programs.FirstOrDefault(p => p.ProgramCode == programCode);
            
            if (existingProgram != null) return false;
            
            if (string.IsNullOrEmpty(program.ProgramCode) ||
                string.IsNullOrEmpty(program.Name) ||
               string.IsNullOrEmpty(program.Target) ||
               program.Startdate == null ||
               program.MaxMembers <= 0) return false;

           
                existingProgram.ProgramCode = programCode;
                existingProgram.Name = program.Name;
                existingProgram.Target = program.Target;
                existingProgram.Startdate = program.Startdate;
                existingProgram.MaxMembers = existingProgram.MaxMembers;

         
            _context.SaveChanges();
            return true;
        }
        
    }
}
