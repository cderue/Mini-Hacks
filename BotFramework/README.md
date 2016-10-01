# Bot Framework Mini-Hack
Le café étant une boisson très importante pour tout développeur, dans ce mini-hack vous utiliserez Bot Framework pour coder un bot permettant de commander un café.

Le but est d’utiliser rapidement Azure et de jouer avec Bot Framework pour déployer votre bot sur le cloud et l’invoquer dans des applications tierces.

Le tutoriel ci-dessous vous guidera pour construire un bot simple et le déployer, n’hésitez pas à laisser libre cours à votre imagination pour l’enrichier !

## Prérequis

Pour ce challenge vous aurez besoin de : 

*	Visual Studio 2015 à jour
*	Microsoft Bot Framework Channel Emulator, téléchargeable ici : https://download.botframework.com/bf-v3/tools/emulator/publish.htm
* Microsoft Azure SDK à jour

## Récupérer, ouvrir et exécuter la solution
Pour bien commencer, il faut s'assurer que la solution de départ se lance correctement dans votre environnement. 
Pour cela :

1.  Ouvrez la solution **MiniHack.BotApplication.sln**
2.  Exécutez le projet
3.  Une page de votre navigateur internet s’ouvre, notez le **port** indiqué dans l’url : 
![localhostimage](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/localhosturl.PNG)

4.  Pour interagir avec le bot nous avons besoin d'un émulateur. Lancez Microsoft Bot Framework Channel Emulator (si vous ne l’avez pas installé, téléchargez le **[ici](https://download.botframework.com/bf-v3/tools/emulator/publish.htm)** et installez le)
5.	Dans le champs **« Bot Url »** reportez le port que vous avez noté à l’étape 3
6.	Ne modifiez pas les autres champs
7.	Dans la zone de texte située en bas de l’émulateur, tapez **hello**
8.	Votre **hello** s’affiche dans la zone **chat** 
9.  Le bot répond en vous souhaitant la bienvenue et demande votre nom 
10. Saisissez votre nom. Le bot affiche le message **Processed your order !** : 

![localhostimage](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/debugresult.PNG)

Nous allons compléter le code pour construire le scénario souhaité.

## Créer un bot

Notre objectif va être de coder un bot permettant de prendre votre commande de café, avec des étapes similaires à celles d’une célèbre enseigne de vente de café à emporter.

Ajoutons le nécessaire pour étendre les fonctionnalités de ce bot au scénario ci-dessous :

1.	Spécifier le type de boisson à commander : café, chocolat, mocha, etc.
2.	Spécifier si la boisson doit être chaude ou froide
3.	Préciser si la boisson doit être sucrée
4.	Lister les suppléments désirés : crème, lait, chocolat, caramel, etc.
5.	Récapituler la commande et demander si tout est correct
6.	Indiquer le montant de la commande
7.	Demander le nom de l’utilisateur
8.	Demander l’adresse de l’utilisateur
9.	Demander l’horaire de livraison souhaité
10. Remercier l'utilisateur pour sa commande



## Déployez votre bot dans le cloud

Maintenant que notre bot fonctionne correctement en local, nous allons le déployer sur le cloud : 

1. Faites un clic droit sur le projet
2. Cliquez sur **Publish**
3. Sélectionnez **Microsoft Azure App Services** : 
![localhostimage](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step1.PNG)

4. Il faut ensuite créer votre service d'application. Cliquer sur le bouton **New** à droite de la fenêtre : 
![localhostimage](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step2.PNG)

5. Créez votre service d'application en remplissant les informations demandées. Veillez à bien choisir la zone **WestEurope** : 
![localhostimage](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step3.PNG)

6. Une fois que votre service d'application a été créé cliquez sur **Create** pour obtenir la fenêtre suivante :
![localhostimage](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step4.PNG)

7. Cette fenêtre récapitule toutes les informations de connexion à votre service azure, cliquez sur **validate connection** pour véfifier le bon établissement de la connexion. Cliquez sur **Next**
8. Veillez à ce que la configuration **Release** soit bien sélectionnée pour le déploiement, puis cliquez sur **Next** : 
![localhostimage](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step5.PNG)

9. Cliquer sur **Publish** : 
![localhostimage](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step6.PNG)

Félicitations votre Bot est sur le cloud ! Il nous reste une toute petite étape pour finir...

## Enregistrez votre bot



## Pour aller plus loin

Ces parties sont optionnelles dans le cadre du mini-hack, mais voici quelques idées pour aller plus loin :

* Localiser le bot pour qu’il gère plusieurs langues
* Ajouter un peu de cogntives services avec LUIS ou Recast.AI
* Gérer plus de boissons ou plus de type de boissons (pourquoi pas des cocktails ?)
* Améliorer le design du formulaire

## Documentations

* **[Bot framework documentation](https://docs.botframework.com/en-us/)**
* **[Bot Builder for .NET](https://download.botframework.com/bf-v3/tools/emulator/publish.htm)**
* **[Bot Framework resources](https://docs.botframework.com/en-us/tools/bot-framework-emulator/#navtitle)**
