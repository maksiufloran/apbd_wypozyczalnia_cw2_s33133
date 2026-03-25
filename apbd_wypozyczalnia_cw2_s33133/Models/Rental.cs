namespace apbd_wypozyczalnia_cw2_s33133.Models;

public class Rental
{
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime BorrowDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal Penalty { get; private set; }

    public bool IsActive => ReturnDate == null;
    public bool IsOverdue => IsActive && DateTime.Now > DueDate;

    public Rental(User user, Equipment equipment, DateTime borrowDate, int days)
    {
        User = user;
        Equipment = equipment;
        BorrowDate = borrowDate;
        DueDate = borrowDate.AddDays(days);
    }

    public void ReturnEquipment(DateTime returnDate, decimal dailyPenaltyRate)
    {
        ReturnDate = returnDate;

        if (returnDate > DueDate)
        {
            int lateDays = (returnDate.Date - DueDate.Date).Days;
            Penalty = lateDays * dailyPenaltyRate;
        }
        else
        {
            Penalty = 0;
        }
    }

    public override string ToString()
    {
        return $"{User.FirstName} {User.LastName} -> {Equipment.Name}, Borrowed: {BorrowDate:d}, Due: {DueDate:d}, Returned: {(ReturnDate.HasValue ? ReturnDate.Value.ToShortDateString() : "Not yet")}, Penalty: {Penalty}";
    }
}