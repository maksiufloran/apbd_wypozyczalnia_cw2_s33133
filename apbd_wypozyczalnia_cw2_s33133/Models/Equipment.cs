namespace apbd_wypozyczalnia_cw2_s33133.Models;

public class Equipment
{
    public int Id { get; }
    public string Name { get; set; }
    public EquipmentStatus Status { get; set; }

    protected Equipment(int id, string name)
    {
        Id = id;
        Name = name;
        Status = EquipmentStatus.Available;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Status: {Status}";
    }
}