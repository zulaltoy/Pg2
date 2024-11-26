using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Business.Interfaces;
using YouMove.Data.Context;
using YouMove.Data.Models;

namespace YouMove.Business.Managers {
    public class EquipmentManager :IEquipmentManager{
        private readonly GymTestContext _context;

        public EquipmentManager(GymTestContext context) {
            _context = context;
        }
        public IEnumerable<Equipment> GetAllEquipment() {
            return _context.Equipment.ToList();
        }
        public Equipment GetEquipmentById(int id) {
            return _context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
        }
        public bool AddEquipment(Equipment equipment) {
            if (_context.Equipment.Any(e => e.EquipmentId == equipment.EquipmentId)) return false;

            _context.Equipment.Add(equipment);
            _context.SaveChanges();
            return true;
        }
    }
}
