using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

var service = new RentalService();

var student = new User("Ivan", "Dorokhov", "s33440@pjwstk.edu.pl", UserType.Student);
var employee = new User("Navi", "Vohkorod", "04433s@pjwstk.edu.pl", UserType.Employee);

service.AddUser(student);
service.AddUser(employee);

var laptop = new Laptop("Dell XPS", 16, 15);
var projector = new Projector("Epson", 3000, true);
var camera = new Camera("Canon", 24, "Zoom");

service.AddEquipment(laptop);
service.AddEquipment(projector);
service.AddEquipment(camera);

service.RentEquipment(student, laptop, 2);

try
{
    service.RentEquipment(student, projector, 2);
    service.RentEquipment(student, camera, 2);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

var rental = Singleton.Instance.Rentals.First();
rental = Singleton.Instance.Rentals.First();
rental.Return();

double penalty = service.ReturnEquipment(rental);
Console.WriteLine($"Penalty: {penalty}");

Console.WriteLine(service.GenerateReport());