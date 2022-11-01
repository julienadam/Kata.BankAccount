using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.BankAccount
{
    public class Compte
    {
        private readonly StockageMouvements stockageMouvements;

        public Compte(StockageMouvements stockageMouvements)
        {
            this.stockageMouvements = stockageMouvements;
        }

        public void Deposer(int montant)
        {
            stockageMouvements.EnregistrerDepot("01/01/2001", montant);
        }

        public void Retirer(int montant)
        {
            throw new NotImplementedException();
        }

        public void AfficherExtrait()
        {
            throw new NotImplementedException();
        }
    }
}
