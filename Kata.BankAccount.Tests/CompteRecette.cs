using System;
using Moq;
using Xunit;

namespace Kata.BankAccount.Tests;

public class CompteRecette
{
    [Fact]
    public void L_extrait_de_compte_affiche_les_transactions_dans_l_ordre_chronologique_inverse()
    {
        var console = new Mock<Terminal>();
        var stockageMouvements = new StockageMouvements();
        var horloge = new Horloge(() => DateTime.Today);
        var afficheur = new AfficheurExtrait();
        var account = new Compte(stockageMouvements, horloge, afficheur);
        account.Deposer(1000);
        account.Retirer(100);
        account.Deposer(500);

        account.AfficherExtrait();

        console.SetupSequence(c => c.AfficherLigne("DATE | MONTANT | SOLDE"));
        console.SetupSequence(c => c.AfficherLigne("27/08/2021 | 500.00 | 1400.00"));
        console.SetupSequence(c => c.AfficherLigne("06/08/2021 | -100.00 | 900.00"));
        console.SetupSequence(c => c.AfficherLigne("01/08/2021 | 1000.00 | 1000.00"));
    }
}