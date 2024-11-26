using YouMove.Data.Models;
using YouMove.Data.Repositories.Interfaces;
using YouMove.Data.Context;

namespace YouMove.Data.Repositories
{
    public class EquipmentRepository : IEquipmentRepository {
        private readonly GymTestContext _context;

        public EquipmentRepository(GymTestContext context) {
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
