namespace Kata.BankAccount
{
    public class Terminal : ITerminal
    {
        public void AfficherLigne(string ligne)
        {
            Console.WriteLine(ligne);
        }
    }
}
