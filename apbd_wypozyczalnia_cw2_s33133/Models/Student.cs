namespace apbd_wypozyczalnia_cw2_s33133.Models;

public class Student : User
{
    public Student(int id, string firstName, string lastName)
        : base(id, firstName, lastName) { }

    public override int GetRentalLimit() => 2;
}