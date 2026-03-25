namespace apbd_wypozyczalnia_cw2_s33133.Models;

public abstract class User
{
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected User(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract int GetRentalLimit();

    public override string ToString()
    {
        return $"ID: {Id}, {FirstName} {LastName}";
    }
}