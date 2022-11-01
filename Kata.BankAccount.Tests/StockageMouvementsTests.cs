using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using Xunit;

namespace Kata.BankAccount.Tests
{
    public class StockageMouvementsTests
    {
        private readonly StockageMouvements stockageMouvements;

        public StockageMouvementsTests()
        {
            stockageMouvements = new StockageMouvements();
        }

        [Fact]
        public void Un_depot_enregistre_apparait_dans_la_liste_des_transactions()
        {
            stockageMouvements.EnregistrerDepot("02/10/2021", 100);
            
            Check.That(stockageMouvements.ToutesLesTransactions).HasSize(1);
            Check
                .That(stockageMouvements.ToutesLesTransactions.First())
                .IsEqualTo(Mouvement.Depot("02/10/2021", 100));
        }
        
        [Fact]
        public void Un_retrait_enregistre_apparait_dans_la_liste_des_transactions()
        {
            stockageMouvements.EnregistrerRetrait("02/10/2021", 100);
            
            Check.That(stockageMouvements.ToutesLesTransactions).HasSize(1);
            Check
                .That(stockageMouvements.ToutesLesTransactions.First())
                .IsEqualTo(Mouvement.Retrait("02/10/2021", 100));
        }
    }
}
