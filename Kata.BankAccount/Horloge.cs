namespace Kata.BankAccount;

public class Horloge : IHorloge
{
    private const string FormatDate = "dd/MM/yyyy";
    private readonly Func<DateTime> dateGetter;

    public Horloge(Func<DateTime> dateGetter)
    {
        this.dateGetter = dateGetter;
    }

    public string DateDuJour => dateGetter().ToString(FormatDate);
}