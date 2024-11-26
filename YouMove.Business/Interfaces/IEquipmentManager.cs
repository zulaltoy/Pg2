using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouMove.Data.Context;
using YouMove.Data.Models;

namespace YouMove.Business.Interfaces {
    public interface IEquipmentManager {

        IEnumerable<Equipment> GetAllEquipment();
        Equipment? GetEquipmentById(int id);
        bool AddEquipment(Equipment equipment);

    }
}
