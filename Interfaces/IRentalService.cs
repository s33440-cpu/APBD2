using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Interfaces
{
    public interface IRentalService
    {
        void AddUser (User user);
        void AddEquipment(Equipment equipment);
        void RentEquipment(User user, Equipment equipment, int days);
        double ReturnEquipment(Rental rental);

        List<Equipment> GetAllEquipment();
        List<Equipment> GetAllAvailableEquipment();

        string GenerateReport();
    }
}
