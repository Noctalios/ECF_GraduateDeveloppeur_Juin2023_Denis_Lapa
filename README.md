# ECF_GraduateDeveloppeur_Juin2023_Denis_Lapa
Dépôt git de l'ECF de présentation au titre de Développeur web et web mobile
Ce projet Git est le code source de l'ECF Graduate Développeur Php/symfony : Sujet restaurant

## Lien GitHub :

https://github.com/Noctalios/ECF_GraduateDeveloppeur_Juin2023_Denis_Lapa

## Lien vers logiciel de gestion de projet Trello :

https://trello.com/b/sCwz42yV/ecf-d%C3%A9veloppeur-web-et-web-mobile

## Lien vers le site en ligne : 

https://ecfquaiantiquedenislapa.azurewebsites.net/


# Procédure d'installation en local : 

Pour l'installation du projet ECF Quai Antique en locale je recommande vivement l'utilisation de Visual Studio.

Dans un premier temps veuillez clonez le repos distant grâce au lien GitHub fournit ci-dessus.

Tout devrait fonctionner normalement. Si jamais l'ensemble des Nuget ne s'était pas installé directement je n'ai installer en plus que :

- MudBlazor 6.1.9 dont voici la doc pour l'installation https://mudblazor.com/getting-started/installation#prerequisites
-Microsoft.Data.SqlClient 5.1.0 accessible directement depuis le gestionnaire de package NuGet de Visual Studio

Maintenant que vous avez accès au projet il vous faudra également l'accès à une base de données.

L'application utilise des bases de données en SQL Server. De ce fait je vous recommande fortement l'utilisation de SSMS pour pouvoir avoir accès à vos bases de données.

Une fois la création de votre base de données locale effectuée pour créer l'ensemble des tables, procédures stockées...
Il vous suffira de double cliquer (click gauche) sur l'élément ECF_Quai_Antique.sln ce qui vous présenteras deux projets.

Dans le premier se situe tout le code relatif à l'appplication web en blazor et dans le second ce situe l'ensemble du projet de base de donnée.
Veuillez faire un click droit sur ce dernier puis faire comparaison de schéma ; il est également possible de passer par l'onglet du haut de votre écran Outils (Tools) > SQL Server > Comparaison de schéma (schema compare). 
Comme source veuillez choisir le projet sql server et comme cible votre base de données SQL Server.
Il est également possible de jouer une à une l'ensemble des requêtes du projet en étant directement dans SSMS.

1- Une fois votre table mise à jour il vous suffira de copier-coller le code ci-dessous pour injecter les données nécessaires à sa bonne exécution et avec quelques données supplémentaires comme des menus et des plats pour les tests.

INSERT INTO Roles (Label)
VALUES ('Administrateur'),
	   ('Client')

INSERT INTO Restaurant (Label, Guest)
VALUES ('Quai Antique', 35)

INSERT INTO dbo.Days ([Label])
VALUES 
	('Lundi'), 
	('Mardi'), 
	('Mercredi'),
	('Jeudi'), 
	('Vendredi'), 
	('Samedi'),
	('Dimanche')
	

INSERT INTO dbo.Periods ([DayId], [RestaurantId], [Open], [Close], [IsActive])
VALUES (0, 1, '2023-01-01 12:00:00.000', '2023-01-01 14:00:00.000', 1),
	   (0, 1, '2023-01-01 20:00:00.000', '2023-01-01 22:00:00.000', 1),
	   (1, 1, '2023-01-01 12:00:00.000', '2023-01-01 14:00:00.000', 1),
	   (1, 1, '2023-01-01 20:00:00.000', '2023-01-01 22:00:00.000', 1),
	   (2, 1, '2023-01-01 12:00:00.000', '2023-01-01 14:00:00.000', 1),
	   (2, 1, '2023-01-01 20:00:00.000', '2023-01-01 22:00:00.000', 1),
	   (3, 1, '2023-01-01 12:00:00.000', '2023-01-01 14:00:00.000', 1),
	   (3, 1, '2023-01-01 20:00:00.000', '2023-01-01 22:00:00.000', 1),
	   (4, 1, '2023-01-01 12:00:00.000', '2023-01-01 14:00:00.000', 1),
	   (4, 1, '2023-01-01 20:00:00.000', '2023-01-01 22:00:00.000', 1),
	   (5, 1, '2023-01-01 12:00:00.000', '2023-01-01 14:00:00.000', 1),
	   (5, 1, '2023-01-01 20:00:00.000', '2023-01-01 22:00:00.000', 1),
	   (6, 1, '2023-01-01 12:00:00.000', '2023-01-01 14:00:00.000', 1),
	   (6, 1, '2023-01-01 20:00:00.000', '2023-01-01 22:00:00.000', 1)

INSERT INTO DishType
VALUES	('Entrées'), 
		('Plats'), 
		('Desserts'), 
		('Boissons')

  INSERT INTO dbo.Dish (Label, DishTypeId, Description, Price)
  VALUES	('Camembert fondue', 1, 'Fromage fondue au feu de frêne et sa salade assaisonée', 8.95),
			('Oeufs Mimosas', 1, 'Oeufs de nos poules et mayonnaise maison', 4.95),
			('Chèvres chauds', 1, 'Salade de chèvre sur ses toasts dorés', 7.95),
			('Assiete de Charcuterie', 1, 'Assortiment de notre boucher', 14.95),
			('Tartiflette', 2, 'Pommes de terre, oignons lardons et accompagné de salade', 17.95),
			('Burger Savoyard', 2, 'Pains buns, oignons fondants, reblochons et ses frites', 15.95),
			('Fondue Savoyarde', 2, 'Fromage de notre sélection et vin blanc', 23.95),
			('Raclette de Savoie', 2, 'Demi meule avec ses accompagnements de charcuterie (4 personnes)', 114.95),
			('Omelette Forêstière', 2, 'Omelette aux champignons de montagne', 12.95),
			('Pot-au-feu', 2, 'Cuit depuis la veille, chaud et réconfortant', 16.95),
			('Entrecôte', 2, 'Cuisson à votre convenance avec ses légumes', 28.95),
			('Pierrade au boeuf', 2, 'Cuisson sur pierre (2 personnes)', 49.95),
			('Café Liégois', 3, 'Glace café, crème chantilly et coulis café', 6.95),
			('Chocolat Liégois', 3, 'Glace chocolat, crème chantilly et coulis chocolat', 6.95),
			('Dame Blanche', 3, 'Glace vanille crème chantilly et coulis café', 6.95),
			('Profiteroles', 3, 'Petits chous garni de crême avec coulis de chocolat chaud' ,9.95),
			('Soda', 4, 'Fanta, Orangina, Coca-cola et 7up', 4.95),
			('Vin Rouge', 4, 'Beaujolais', 18.95),
			('Vin Blanc', 4, 'Cépages avoisinants', 13.95),
			('Bières', 4, 'Pinte de Desperados, Heineken ou Leffe', 4.95)

INSERT INTO Formula (Description, Price)
VALUES ('Midi', 29.95),
		('Soir', 34.95)

INSERT INTO Formula_DishType (FormulaId, DishTypeId)
VALUES (1, 1),
	   (1, 2),
	   (2, 1),
	   (2, 2),
	   (2, 4)

INSERT INTO Menu (Label)
VALUES ('Gourmand'),
		('Enfant')

INSERT INTO Menu_Formula(MenuId, FormulaId)
VALUES (1, 1),
	   (1, 2),
	   (2, 1),

Pour créer un utilisateur en local il vous suffit après avoir effectué cette requête de créer un compte via l'application puis de jouer cette requête

UPDATE Users
SET Guest = NULL, RoleId = 1
WHERE Id = {insérez votre Id}

Pour l'application web il vous suffira de vous connecter avec les identifiants 'Examinateurs-ECF@test.com' en tant qu'Email et 'Ecf-ex@m1' et vous serez connecté à un compte administrateur

