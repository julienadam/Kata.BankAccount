Outside-In TDD par les tests de recette
=======================================

### Objectifs

Pratiquer la double boucle du TDD "Outside-In"
Tester l'application depuis l'ext�rieur, identifier les effets de bord
 
### Description du probl�me, le kata compte bancaire

Cr�er une application de gestion de compte bancaire simple avec les fonctionnalit�s suivantes :

- D�poser un montant sur un compte
- Retirer un montant sur un compte
- Imprimer un extrait de compte dans la console
 
## R�sultats attendus

- L'extrait de compte doit pr�senter les mouvements dans le format suivant :

```
DATE       | MONTANT | SOLDE
27/08/2021 |  500.00 | 1400.00
06/08/2021 | -100.00 |  900.00
01/08/2021 | 1000.00 | 1000.00
```

## Point de d�part et contraintes

- On d�marrera avec la classe suivante :

```cs
public class Compte 
{
    public void Deposer(int montant) {}

    public void Retirer(int montant) {}

    public void AfficherExtrait() {}
}
```

- **Il est interdit d'ajouter des m�thodes publiques � cette classe ou de modifier les signatures !!**
- Pour simplifier l'exercice:
  - on utilisera des entiers pour les montants et des cha�nes de caract�res pour les dates
  - le formattage exact des colonnes (espaces, alignement etc) n'est pas important

## Premiers pas

- Ecrivez un test de recette bas� sur l'exemple d'extrait de compte fourni dans l'�nonc�
  - Introduisez le minimum de collaborateurs n�cessaires pour �crire un test qui �choue pour de bonnes raisons
    - Il teste r�ellement le r�sultat attendu
    - Il ne passe pas car l'impl�mentation n'existe pas
- Lancez le test de recette et identifiez la raison de l'�chec
    - D�terminez le premier collaborateur � introduire
    - D�marrez une premi�re boucle interne TDD
      - Construisez le collaborateur en suivant les r�gles du TDD : rouge, vert, refactoring
- Lorsque le collaborateur est construit, relancez le test de recette et identifiez la raison du nouvel �chec
    - D�marrez une deuxi�me boucle interne TDD
- Etc. jusqu'� obtenir une solution compl�te
