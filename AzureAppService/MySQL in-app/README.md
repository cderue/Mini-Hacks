## 3) Ajouter une base de données MySQL dans une application web avec Azure App Service MySQL in-app

### 3.1) Quelques mots sur MySQL In App

MySQL in-app est une nouvelle fonctionnalité (en preview pour l'instant) conçue por permettre l'exécution d'une base de données MySQL sur une instance Azure App Service.
Cette fonctionnalité permet au développeur qui a besoin d'une base de données clé en main de gagner du temps.
MySQL in-app n'est pas prévu pour être utilisé en production.

### 3.2) Activer MySQL In App

Pour activer la fonctionnalité MySQL In App au niveau d'une application web Azure :
- Rendez-vous sur le [portail Azure](http://portal.azure.com)
- Cliquez sur l'application web (épinglée normalement sur le tableau de bord du portail)
- Cliquez sur MySQL in-app(Preview)
- Activez MySQL In App
- Désactivez le journal des requêtes lentes MySQL (désactivé par défaut)
- Désactivez le journal général MySQL (désactivé par défaut)
- Cliquez sur Enregistrer pour enregistrer les paramètres MySQL In App

### 3.3) Ouvrir phpMyAdmin

- Cliquez sur Gérer pour ouvrir phpMyAdmin commme le montre la figure ci-dessous :

![MySQL In App](Screenshots/MySQL1.png)

Dans le formulaire de connexion à phpMyAdmin :
- Saisissez __azure__ comme identifiant utilisateur
- Saisissez __password__ comme mot de passe
- Cliquez sur __Login__

![MySQL In App](Screenshots/phpMyAdmin1.png)

La base de données créée par Azure se nomme __azuredb__ commme le montre la figure ci-dessous :

![MySQL In App](Screenshots/phpMyAdmin2.png)

Le répertoire __Sources__ du mini-hack contient un script SQL nommé __script.sql__. 
Ce script contient une requête de création de table et une requête d'insertion dans cette table.

Nous allons maintenant exécuter le contenu de ce fichier dans phpMyAdmin :
- Ouvrez le fichier dans l'éditeur de code de votre choix
- Copiez le contenu du fichier dans l'onglet SQL de phpMyAdmin
- Cliquez sur Go pour lancer l'exécution de la requête

![MySQL In App](Screenshots/phpMyAdmin3.png)

### 3.4) Configurer la connexion à MySQL dans une application Symfony

```bash
# app/config/parameters.yml
parameters:
    database_host:      127.0.0.1
    database_name:      azuredb
    database_user:      azure
    database_password:  password

# ... 
```