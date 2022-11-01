Outside-In TDD par les tests de recette
=======================================

### Objectifs

Pratiquer la double boucle du TDD "Outside-In"
Tester l'application depuis l'extérieur, identifier les effets de bord
 
### Description du problème, le kata compte bancaire

Créer une application de gestion de compte bancaire simple avec les fonctionnalités suivantes :

- Déposer un montant sur un compte
- Retirer un montant sur un compte
- Imprimer un extrait de compte dans la console
 
## Résultats attendus

- L'extrait de compte doit présenter les mouvements dans le format suivant :

```
DATE       | MONTANT | SOLDE
27/08/2021 |  500.00 | 1400.00
06/08/2021 | -100.00 |  900.00
01/08/2021 | 1000.00 | 1000.00
```

## Point de départ et contraintes

- On démarrera avec la classe suivante :

```cs
public class Compte 
{
    public void Deposer(int montant) {}

    public void Retirer(int montant) {}

    public void AfficherExtrait() {}
}
```

- **Il est interdit d'ajouter des méthodes publiques à cette classe ou de modifier les signatures !!**
- Pour simplifier l'exercice:
  - on utilisera des entiers pour les montants et des chaînes de caractères pour les dates
  - le formattage exact des colonnes (espaces, alignement etc) n'est pas important

## Premiers pas

- Ecrivez un test de recette basé sur l'exemple d'extrait de compte fourni dans l'énoncé
  - Introduisez le minimum de collaborateurs nécessaires pour écrire un test qui échoue pour de bonnes raisons
    - Il teste réellement le résultat attendu
    - Il ne passe pas car l'implémentation n'existe pas
- Lancez le test de recette et identifiez la raison de l'échec
    - Déterminez le premier collaborateur à introduire
    - Démarrez une première boucle interne TDD
      - Construisez le collaborateur en suivant les règles du TDD : rouge, vert, refactoring
- Lorsque le collaborateur est construit, relancez le test de recette et identifiez la raison du nouvel échec
    - Démarrez une deuxième boucle interne TDD
- Etc. jusqu'à obtenir une solution complète
