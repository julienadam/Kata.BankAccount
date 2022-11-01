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
        private const string AUJOURDHUI = "02/10/2021";
        private readonly StockageMouvements stockageMouvements = new();

        [Fact]
        public void Un_depot_enregistre_apparait_dans_la_liste_des_transactions()
        {
            stockageMouvements.EnregistrerDepot(AUJOURDHUI, 100);
            
            Check.That(stockageMouvements.ToutesLesTransactions).HasSize(1);
            Check
                .That(stockageMouvements.ToutesLesTransactions.First())
                .IsEqualTo(Mouvement.Depot(AUJOURDHUI, 100));
        }
        
        [Fact]
        public void Un_retrait_enregistre_apparait_dans_la_liste_des_transactions()
        {
            stockageMouvements.EnregistrerRetrait(AUJOURDHUI, 100);
            
            Check.That(stockageMouvements.ToutesLesTransactions).HasSize(1);
            Check
                .That(stockageMouvements.ToutesLesTransactions.First())
                .IsEqualTo(Mouvement.Retrait(AUJOURDHUI, 100));
        }
    }
}
