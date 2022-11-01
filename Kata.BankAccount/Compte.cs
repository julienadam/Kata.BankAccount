using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.BankAccount
{
    public class Compte
    {
        private readonly IStockageMouvements stockageMouvements;
        private readonly IHorloge horloge;
        private readonly IAfficheurExtrait afficheurExtrait;

        public Compte(IStockageMouvements stockageMouvements, IHorloge horloge, IAfficheurExtrait afficheurExtrait)
        {
            this.stockageMouvements = stockageMouvements;
            this.horloge = horloge;
            this.afficheurExtrait = afficheurExtrait;
        }

        public void Deposer(int montant)
        {
            stockageMouvements.EnregistrerDepot(horloge.DateDuJour, montant);
        }

        public void Retirer(int montant)
        {
            stockageMouvements.EnregistrerRetrait(horloge.DateDuJour, montant);
        }

        public void AfficherExtrait()
        {
            afficheurExtrait.AfficherExtrait(stockageMouvements.ToutesLesTransactions);
        }
    }
}
