namespace Kata.BankAccount;

public interface IAfficheurExtrait
{
    void AfficherExtrait(IEnumerable<Mouvement> mouvements);
}