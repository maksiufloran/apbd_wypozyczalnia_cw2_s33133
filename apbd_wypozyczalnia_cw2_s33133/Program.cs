using apbd_wypozyczalnia_cw2_s33133.Services;



class Program
{
    static void Main(string[] args)
    {
        var rentalService = new RentalService();
        var reportService = new ReportService();

        var student = rentalService.AddStudent("Jan", "Kowalski");
        var employee = rentalService.AddEmployee("Anna", "Nowak");

        var laptop = rentalService.AddLaptop("Dell Latitude", "Intel i5", 16);
        var projector = rentalService.AddProjector("Epson X1", 3500, "1920x1080");
        var camera = rentalService.AddCamera("Canon EOS", 24, true);

        Console.WriteLine("=== AVAILABLE EQUIPMENT ===");
        foreach (var eq in rentalService.GetAvailableEquipment())
            Console.WriteLine(eq);

        Console.WriteLine("\n=== CORRECT RENTAL ===");
        rentalService.RentEquipment(student.Id, laptop.Id, 7);
        Console.WriteLine("Laptop rented successfully.");

        Console.WriteLine("\n=== INVALID OPERATION ===");
        try
        {
            rentalService.RentEquipment(employee.Id, laptop.Id, 5);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\n=== RETURN ON TIME ===");
        rentalService.ReturnEquipment(laptop.Id, DateTime.Now.AddDays(5));
        Console.WriteLine("Laptop returned on time.");

        Console.WriteLine("\n=== LATE RETURN WITH PENALTY ===");
        rentalService.RentEquipment(employee.Id, camera.Id, 3);
        rentalService.ReturnEquipment(camera.Id, DateTime.Now.AddDays(6));
        Console.WriteLine("Camera returned late.");

        Console.WriteLine("\n=== FINAL REPORT ===");
        reportService.PrintSummary(rentalService);
    }
}