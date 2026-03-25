namespace apbd_wypozyczalnia_cw2_s33133.Services;

public class ReportService
{
    public void PrintSummary(RentalService rentalService)
    {
        Console.WriteLine("=== RENTAL SUMMARY ===");

        Console.WriteLine("\nAll equipment:");
        foreach (var equipment in rentalService.GetAllEquipment())
            Console.WriteLine(equipment);

        Console.WriteLine("\nOverdue rentals:");
        foreach (var rental in rentalService.GetOverdueRentals())
            Console.WriteLine(rental);

        Console.WriteLine("\nAll rentals:");
        foreach (var rental in rentalService.GetRentals())
            Console.WriteLine(rental);
    }
}