namespace Kata.BankAccount;

public interface IStockageMouvements
{
    IReadOnlyCollection<Mouvement> ToutesLesTransactions { get; }
    void EnregistrerDepot(string date, int montant);
    void EnregistrerRetrait(string date, int montant);
}