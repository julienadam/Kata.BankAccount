using System;
using System.Collections.Generic;

namespace Kata.BankAccount;

public class AfficheurExtrait : IAfficheurExtrait
{
    private const string ENTETE_EXTRAIT = "DATE | MONTANT | SOLDE";
    private readonly ITerminal terminal;

    public AfficheurExtrait(ITerminal terminal)
    {
        this.terminal = terminal;
    }

    public void AfficherExtrait(IEnumerable<Mouvement> mouvements)
    {
        terminal.AfficherLigne(ENTETE_EXTRAIT);

        mouvements
            .Select(FormatterLigne)
            .ToList()
            .ForEach(l => terminal.AfficherLigne(l));
    }

    private static string FormatterLigne(Mouvement m)
    {
        return $"{m.Date} | {m.Montant:F2} | {m.Montant:F2}";
    }
}