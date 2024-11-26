using YouMove.Data.Models;

namespace YouMove.Data.Repositories.Interfaces {

    public interface IEquipmentRepository {
        IEnumerable<Equipment> GetAllEquipment();
        Equipment? GetEquipmentById(int id);
        bool AddEquipment(Equipment equipment);
        
    }
}
