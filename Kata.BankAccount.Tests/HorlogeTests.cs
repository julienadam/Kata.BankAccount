using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFluent;
using Xunit;

namespace Kata.BankAccount.Tests
{
    public class HorlogeTests
    {
        [Fact]
        public void Horloge_retourne_la_date_du_jour_correctement_formattee()
        {
            var horloge = new Horloge(() => new DateTime(2021, 02, 27));
            Check.That(horloge.DateDuJour).IsEqualTo("27/02/2021");
        }
    }
}
