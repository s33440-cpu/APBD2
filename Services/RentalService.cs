using APBD_TASK2.Database;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Services
{
    public class RentalService : IRentalService
    {
        private readonly Singleton _db = Singleton.Instance;
        public void AddEquipment(Equipment equipment)
        {
            _db.Equipment.Add(equipment);
        }

        public void AddUser(User user)
        {
            _db.Users.Add(user);
        }

        public void RentEquipment(User user, Equipment equipment, int days)
        {
            if (equipment.Status != Enum.EquipmentStatus.Available)
            throw new Exception("Equipment is not available.");

            int activeRentals = _db.Rentals.Count(r => r.User == user && r.IsActive);
            int limit = user.Type == Enum.UserType.Student ? 2 : 5;

            if (activeRentals >= limit)
            throw new Exception("User exceeded rental limit.");

            var rental = new Rental(user, equipment, days);
            _db.Rentals.Add(rental);
            equipment.Status = Enum.EquipmentStatus.Unavailable;
        }

        public double ReturnEquipment(Rental rental)
        {
            rental.Return();
            rental.Equipment.Status = Enum.EquipmentStatus.Available;

            if (rental.ReturnDate <= rental.DueDate)
                return 0;

            int lateDays = (rental.ReturnDate.Value - rental.DueDate).Days;
            return lateDays * 5;
        }


        public List<Equipment> GetAllAvailableEquipment()
        {
            return _db.Equipment.Where(e => e.Status == Enum.EquipmentStatus.Available).ToList();
        }

        public List<Equipment> GetAllEquipment()
        {
            return _db.Equipment;
        }

        public string GenerateReport()
        {
            throw new NotImplementedException();
        }
    }
}
