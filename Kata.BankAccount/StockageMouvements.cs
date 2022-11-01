namespace Kata.BankAccount;

public class StockageMouvements : IStockageMouvements
{
    private readonly List<Mouvement> mouvements = new();
    public IReadOnlyCollection<Mouvement> ToutesLesTransactions => mouvements.AsReadOnly();

    public void EnregistrerDepot(string date, int montant)
    {
        mouvements.Add(Mouvement.Depot(date, montant));
    }

    public void EnregistrerRetrait(string date, int montant)
    {
        mouvements.Add(Mouvement.Retrait(date, montant));
    }
}