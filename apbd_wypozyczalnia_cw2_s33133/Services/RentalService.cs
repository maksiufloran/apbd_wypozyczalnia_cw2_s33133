namespace apbd_wypozyczalnia_cw2_s33133.Services;

public class RentalService
{
    private readonly List<User> _users = new();
    private readonly List<Equipment> _equipment = new();
    private readonly List<Rental> _rentals = new();

    private int _nextUserId = 1;
    private int _nextEquipmentId = 1;

    private const decimal DailyPenaltyRate = 10m;

    public Student AddStudent(string firstName, string lastName)
    {
        var student = new Student(_nextUserId++, firstName, lastName);
        _users.Add(student);
        return student;
    }

    public Employee AddEmployee(string firstName, string lastName)
    {
        var employee = new Employee(_nextUserId++, firstName, lastName);
        _users.Add(employee);
        return employee;
    }

    public Laptop AddLaptop(string name, string processor, int ramGb)
    {
        var laptop = new Laptop(_nextEquipmentId++, name, processor, ramGb);
        _equipment.Add(laptop);
        return laptop;
    }

    public Projector AddProjector(string name, int brightness, string resolution)
    {
        var projector = new Projector(_nextEquipmentId++, name, brightness, resolution);
        _equipment.Add(projector);
        return projector;
    }

    public Camera AddCamera(string name, int megapixels, bool hasZoom)
    {
        var camera = new Camera(_nextEquipmentId++, name, megapixels, hasZoom);
        _equipment.Add(camera);
        return camera;
    }

    public List<Equipment> GetAllEquipment() => _equipment;
    public List<Equipment> GetAvailableEquipment() =>
        _equipment.Where(e => e.Status == EquipmentStatus.Available).ToList();

    public List<Rental> GetUserActiveRentals(int userId) =>
        _rentals.Where(r => r.User.Id == userId && r.IsActive).ToList();

    public List<Rental> GetOverdueRentals() =>
        _rentals.Where(r => r.IsOverdue).ToList();

    public void MarkEquipmentUnavailable(int equipmentId)
    {
        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);
        if (equipment == null)
            throw new Exception("Equipment not found.");

        equipment.Status = EquipmentStatus.Unavailable;
    }

    public void RentEquipment(int userId, int equipmentId, int days)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
            throw new Exception("User not found.");

        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);
        if (equipment == null)
            throw new Exception("Equipment not found.");

        if (equipment.Status != EquipmentStatus.Available)
            throw new Exception("Equipment is not available.");

        int activeRentalsCount = _rentals.Count(r => r.User.Id == userId && r.IsActive);
        if (activeRentalsCount >= user.GetRentalLimit())
            throw new Exception("User exceeded rental limit.");

        var rental = new Rental(user, equipment, DateTime.Now, days);
        _rentals.Add(rental);
        equipment.Status = EquipmentStatus.Rented;
    }

    public void ReturnEquipment(int equipmentId, DateTime returnDate)
    {
        var rental = _rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && r.IsActive);
        if (rental == null)
            throw new Exception("Active rental not found.");

        rental.ReturnEquipment(returnDate, DailyPenaltyRate);
        rental.Equipment.Status = EquipmentStatus.Available;
    }

    public List<User> GetUsers() => _users;
    public List<Rental> GetRentals() => _rentals;
}