namespace APBD_TASK2.Models
{
    public class Rental
    {
        public User User { get; }
        public Equipment Equipment { get; }
        public DateTime RentDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnDate { get; private set; }
        public Rental(User user, Equipment equipment, int days)
        {
            User = user;
            Equipment = equipment;
            RentDate = DateTime.Now;
            DueDate = RentDate.AddDays(days);
        }

        public void Return()
        {
            ReturnDate = DateTime.Now;
        }

        public bool IsActive => ReturnDate == null;

        public bool IsOverdue => ReturnDate == null && DateTime.Now > DueDate;
    }
}