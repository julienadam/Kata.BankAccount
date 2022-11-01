using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NFluent;
using Xunit;
using Xunit.Sdk;

namespace Kata.BankAccount.Tests
{
    public class CompteTests
    {
        private readonly Mock<IStockageMouvements> stockageMouvements = new();
        private readonly Compte compte;
        private Mock<IAfficheurExtrait> afficheur;
        private const string AUJOURDHUI = "31/12/2020";

        public CompteTests()
        {
            var horloge = new Mock<IHorloge>();
            afficheur = new Mock<IAfficheurExtrait>();

            horloge.SetupGet(h => h.DateDuJour).Returns(AUJOURDHUI);
            compte = new Compte(stockageMouvements.Object, horloge.Object, afficheur.Object);
        }

        [Fact]
        public void Deposer_cree_un_mouvement_de_depot()
        {
            compte.Deposer(100);

            stockageMouvements.Verify(s => s.EnregistrerDepot(AUJOURDHUI, 100));
        }

        [Fact]
        public void Retirer_cree_un_mouvement_de_retrait()
        {
            compte.Retirer(100);

            stockageMouvements.Verify(s => s.EnregistrerRetrait(AUJOURDHUI, 100));
        }

        [Fact]
        public void Afficher_un_extrait_cherche_les_mouvements_et_appelle_l_afficheur()
        {
            var mouvements = new List<Mouvement>();
            stockageMouvements
                .SetupGet(s => s.ToutesLesTransactions)
                .Returns(mouvements);

            compte.AfficherExtrait();

            afficheur
                .Verify(a =>
                    a.AfficherExtrait(mouvements));
        }
    }
}
