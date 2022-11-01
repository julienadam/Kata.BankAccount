namespace Kata.BankAccount;

public record Mouvement
{
    public string Date { get; init; }
    public int Montant { get; init; }

    public static Mouvement Retrait(string date, int montant)
    {
        return new Mouvement { Date = date, Montant = montant };
    }

    public static Mouvement Depot(string date, int montant)
    {
        return new Mouvement { Date = date, Montant = -montant };
    }
}