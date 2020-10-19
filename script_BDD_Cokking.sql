DROP DATABASE IF EXISTS Cooking;
CREATE database Cooking;
use  Cooking;

# script créé le : Mon Apr 06 19:54:48 CEST 2020 -   syntaxe MySQL ;  
# use  VOTRE_BASE_DE_DONNEE ;studenttable
DROP TABLE IF EXISTS Client ;
CREATE TABLE Client (id_client varchar(45) NOT NULL, nom varchar(45), prenom varchar(45), adresse varchar(45), ville varchar(45), tel varchar(10), mail varchar(45), est_createur bool, compte int, mdp varchar(45), PRIMARY KEY (id_client) ) ENGINE=InnoDB;
DROP TABLE IF EXISTS Createur_de_recette;
CREATE TABLE Createur_de_recette (id_cdr varchar(45) NOT NULL, id_client varchar(45) NOT NULL, nbr_recette_vendue int, PRIMARY KEY (id_cdr) ) ENGINE=InnoDB;
DROP TABLE IF EXISTS Recette;
CREATE TABLE Recette (id_recette varchar(45) NOT NULL, type varchar(45), liste_produit varchar(150), liste_quantite varchar(150), descriptif varchar(250), remuneration int, prix_vente int, id_cdr varchar(45) NOT NULL, id_client varchar(45) NOT NULL, nbr_fois_vendue int, a_ete_up10 bool, a_ete_up50 bool, PRIMARY KEY (id_recette) ) ENGINE=InnoDB;
DROP TABLE IF EXISTS Fournisseur;
CREATE TABLE Fournisseur (nom_fournisseur varchar(45) NOT NULL, tel_fournisseur varchar(11), PRIMARY KEY (nom_fournisseur) ) ENGINE=InnoDB;
DROP TABLE IF EXISTS Produit ;
CREATE TABLE Produit (id_produit varchar(45) NOT NULL, categorie varchar(45), unite varchar(45), stock_actu int, stock_mini int, PRIMARY KEY (id_produit) ) ENGINE=InnoDB;
DROP TABLE IF EXISTS Gere ;
CREATE TABLE Gere (nom_fournisseur varchar(45) NOT NULL, id_produit varchar(45) NOT NULL, PRIMARY KEY (nom_fournisseur,  id_produit) ) ENGINE=InnoDB;
DROP TABLE IF EXISTS Constitue ;
CREATE TABLE Constitue (id_recette varchar(45) NOT NULL, id_produit varchar(45) NOT NULL, PRIMARY KEY (id_recette,  id_produit) ) ENGINE=InnoDB;
CREATE TABLE Commande(id_commande varchar(45) NOT NULL, id_recette varchar(45) NOT NULL, primary key (id_commande));

#ALTER TABLE Client ADD CONSTRAINT FK_Client_id_cdr FOREIGN KEY (id_cdr) REFERENCES Createur_de_recette (id_cdr);
ALTER TABLE Createur_de_recette ADD CONSTRAINT FK_Createur_de_recette_id_client FOREIGN KEY (id_client) REFERENCES Client (id_client);
ALTER TABLE Recette ADD CONSTRAINT FK_Recette_id_cdr FOREIGN KEY (id_cdr) REFERENCES Createur_de_recette (id_cdr);
ALTER TABLE Recette ADD CONSTRAINT FK_Recette_id_client FOREIGN KEY (id_client) REFERENCES Client (id_client);
ALTER TABLE Gere ADD CONSTRAINT FK_Gere_nom_fournisseur FOREIGN KEY (nom_fournisseur) REFERENCES Fournisseur (nom_fournisseur);
ALTER TABLE Gere ADD CONSTRAINT FK_Gere_id_produit FOREIGN KEY (id_produit) REFERENCES Produit (id_produit);
ALTER TABLE Constitue ADD CONSTRAINT FK_Constitue_id_recette FOREIGN KEY (id_recette) REFERENCES Recette (id_recette);
ALTER TABLE Constitue ADD CONSTRAINT FK_Constitue_id_produit FOREIGN KEY (id_produit) REFERENCES Produit (id_produit);

INSERT INTO cooking.client values("Junaifu","Zhou","Tony","2 rue de la boulangerie","Paris","0612345678","tony@hotmail.fr",TRUE,5000,"tonymdp");
INSERT INTO cooking.client values("Saberisme","Zahhar","Saber","7 avenue du luth","Gennevilliers","0645875213","saber@hotmail.fr",TRUE,50,"sabermdp");
INSERT INTO cooking.client values("Bigben","Jonhson","Benjamin","28 impasse du jardin","Gennevilliers","0687954210","benji@hotmail.fr",TRUE,50,"benjimdp");
INSERT INTO cooking.client values("Zeirin","Meghaghi","Yannis","8 rue du stade","Gennevilliers","0635251415","yannis@hotmail.fr",TRUE,50,"yannismdp");
INSERT INTO cooking.client values("Vlaxx","Huang","Michel","38 boulevard de l'inconnu","Paris","0698587481","michel@hotmail.fr",FALSE,50,"michelmdp");
INSERT INTO cooking.createur_de_recette values("Junaifu","Junaifu",5);
INSERT INTO cooking.createur_de_recette values("Saberisme","Saberisme",4);
INSERT INTO cooking.createur_de_recette values("Bigben","Bigben",3);
INSERT INTO cooking.createur_de_recette values("Zeirin","Zeirin",2);


INSERT INTO cooking.recette values("Burrito","plat","pain salade steak sauce-tomate","1 1 3 2","Plat idéal pour une soirée TV",2,15,"Junaifu","Junaifu",0,False,False);
INSERT INTO cooking.recette values("Pizza","plat","pain champignons steak sauce-tomate","1 7 2 1","Plat à partager",2,20,"Junaifu","Junaifu",0,False,False);
INSERT INTO cooking.recette values("Salade-piemontaise","entrée","pomme-de-terre mayonnaise cornichons oeuf","6 1 10 4","Entrée rafraîchissante",2,10,"Junaifu","Junaifu",0,False,False);
INSERT INTO cooking.recette values("Soupe","plat","potiron carotte ","4 4","Réchauffe pour l'hiver et fais grandir",2,8,"Junaifu","Junaifu",0,False,False);
INSERT INTO cooking.recette values("Gateau","dessert","oeuf farine sucre","3 100 60","Aurecette goûter ou en dessert c'est toujours bon",2,20,"Junaifu","Junaifu",0,False,False);


INSERT INTO cooking.produit values("pain","féculent","kg",200,50);
INSERT INTO cooking.produit values("salade","légume","kg",75,50);
INSERT INTO cooking.produit values("steak","viande","kg",400,50);
INSERT INTO cooking.produit values("sauce-tomate","sauce","L",150,50);
INSERT INTO cooking.produit values("Champignons","légume","kg",100,50);
INSERT INTO cooking.produit values("pomme-de-terre","féculent","kg",400,50);
INSERT INTO cooking.produit values("cornichons","légume","kg",70,50);
INSERT INTO cooking.produit values("oeuf","oeuf","kg",400,50);
INSERT INTO cooking.produit values("farine","farine","kg",300,50);
INSERT INTO cooking.produit values("sucre","sucre","kg",200,50);
INSERT INTO cooking.produit values("potiron","légumes","kg",400,50);
INSERT INTO cooking.produit values("carotte","légumes","kg",80,50);


INSERT INTO cooking.fournisseur values ("METRO","0123456789");

INSERT INTO cooking.commande values("commande1","burrito");

SELECT * FROM client;
SELECT * FROM createur_de_recette;
SELECT * FROM recette;
SELECT * FROM produit;
SELECT * FROM fournisseur;
