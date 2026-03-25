namespace apbd_wypozyczalnia_cw2_s33133.Models;

public class Laptop : Equipment
{
    public string Processor { get; set; }
    public int RamGb { get; set; }

    public Laptop(int id, string name, string processor, int ramGb)
        : base(id, name)
    {
        Processor = processor;
        RamGb = ramGb;
    }

    public override string ToString()
    {
        return base.ToString() + $", Processor: {Processor}, RAM: {RamGb}GB";
    }
}