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

        var solde = 0;
        mouvements
            .Select(mouvement =>
            {
                solde += mouvement.Montant;
                return FormatterLigne(mouvement, solde);
            })
            .Reverse()
            .ToList()
            .ForEach(l => terminal.AfficherLigne(l));
    }

    private static string FormatterLigne(Mouvement m, int solde)
    {
        return $"{m.Date} | {m.Montant:F2} | {solde:F2}";
    }
}