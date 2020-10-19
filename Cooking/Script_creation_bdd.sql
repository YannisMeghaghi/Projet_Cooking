DROP DATABASE IF EXISTS Cooking;
CREATE database Cooking;
use  Cooking;

# script créé le : Mon Apr 06 19:54:48 CEST 2020 -   syntaxe MySQL ;  
# use  VOTRE_BASE_DE_DONNEE ;
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


#ALTER TABLE Client ADD CONSTRAINT FK_Client_id_cdr FOREIGN KEY (id_cdr) REFERENCES Createur_de_recette (id_cdr);
ALTER TABLE Createur_de_recette ADD CONSTRAINT FK_Createur_de_recette_id_client FOREIGN KEY (id_client) REFERENCES Client (id_client);
ALTER TABLE Recette ADD CONSTRAINT FK_Recette_id_cdr FOREIGN KEY (id_cdr) REFERENCES Createur_de_recette (id_cdr);
ALTER TABLE Recette ADD CONSTRAINT FK_Recette_id_client FOREIGN KEY (id_client) REFERENCES Client (id_client);
ALTER TABLE Gere ADD CONSTRAINT FK_Gere_nom_fournisseur FOREIGN KEY (nom_fournisseur) REFERENCES Fournisseur (nom_fournisseur);
ALTER TABLE Gere ADD CONSTRAINT FK_Gere_id_produit FOREIGN KEY (id_produit) REFERENCES Produit (id_produit);
ALTER TABLE Constitue ADD CONSTRAINT FK_Constitue_id_recette FOREIGN KEY (id_recette) REFERENCES Recette (id_recette);
ALTER TABLE Constitue ADD CONSTRAINT FK_Constitue_id_produit FOREIGN KEY (id_produit) REFERENCES Produit (id_produit);