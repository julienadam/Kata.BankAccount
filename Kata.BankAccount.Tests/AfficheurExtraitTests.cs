﻿using System;
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
        private readonly Mock<ITerminal> terminal = new();
        private readonly AfficheurExtrait afficheur;

        public AfficheurExtraitTests()
        {
            afficheur = new AfficheurExtrait(terminal.Object);
        }

        [Fact]
        public void Afficher_un_extrait_sans_transaction_affiche_l_entete()
        {
            afficheur.AfficherExtrait(Enumerable.Empty<Mouvement>());

            terminal.Verify(t => t.AfficherLigne("DATE | MONTANT | SOLDE"));
        }

        [Fact]
        public void Afficher_un_extrait_avec_un_depot_affiche_l_entete_et_le_depot()
        {
            var mouvements = new List<Mouvement> { Mouvement.Depot("27/01/2012", 50) };

            terminal.SetupSequence(t => t.AfficherLigne("DATE | MONTANT | SOLDE"));
            terminal.SetupSequence(t => t.AfficherLigne("27/01/2012 | 50.00 | 50.00"));

            afficheur.AfficherExtrait(mouvements);

            terminal.VerifyAll();
        }

        [Fact]
        public void Afficher_un_extrait_avec_un_depot_et_un_retrait_affiche_l_entete_puis_le_retrait_puis_le_depot()
        {
            var mouvements = new List<Mouvement>
            {
                Mouvement.Depot("27/01/2012", 50),
                Mouvement.Retrait("28/01/2012", 20)
            };

            terminal.SetupSequence(t => t.AfficherLigne("DATE | MONTANT | SOLDE"));
            terminal.SetupSequence(t => t.AfficherLigne("28/01/2012 | -20.00 | 30.00"));
            terminal.SetupSequence(t => t.AfficherLigne("27/01/2012 | 50.00 | 50.00"));

            afficheur.AfficherExtrait(mouvements);

            terminal.VerifyAll();
        }
    }
}