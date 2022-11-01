using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Kata.BankAccount.Tests
{
    public class AfficheurExtraitTests
    {
        [Fact]
        public void Afficher_un_extrait_sans_transaction_affiche_l_entete()
        {
            var terminal = new Mock<ITerminal>();

            AfficheurExtrait afficheur = new AfficheurExtrait(terminal.Object);
            
            afficheur.AfficherExtrait(Enumerable.Empty<Mouvement>());

            terminal.Verify(t => t.AfficherLigne("DATE | MONTANT | SOLDE"));
        }

        [Fact]
        public void Afficher_un_extrait_avec_un_depot_affiche_l_entete_et_le_depot()
        {
            var terminal = new Mock<ITerminal>();
            var afficheur = new AfficheurExtrait(terminal.Object);
            var mouvements = new List<Mouvement> { Mouvement.Depot("27/01/2012", 50) };

            terminal.SetupSequence(t => t.AfficherLigne("DATE | MONTANT | SOLDE"));
            terminal.SetupSequence(t => t.AfficherLigne("27/01/2012 | 50.00 | 50.00"));

            afficheur.AfficherExtrait(mouvements);

            terminal.VerifyAll();
        }
    }
}
