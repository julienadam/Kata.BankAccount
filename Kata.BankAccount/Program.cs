using Kata.BankAccount;

IStockageMouvements stockageMouvements = new StockageMouvements();
IHorloge horloge = new Horloge(() => DateTime.Today);
IAfficheurExtrait afficheur = new AfficheurExtrait(new Terminal());
var compte = new Compte(stockageMouvements, horloge, afficheur);

compte.Deposer(1000);
compte.Retirer(75);

compte.AfficherExtrait();

compte.Deposer(150);
compte.Retirer(5000);

compte.AfficherExtrait();

Console.ReadLine();