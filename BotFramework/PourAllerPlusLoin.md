# Pour aller plus loin

Félicitations ! Si vous êtes arrivés jusqu'ici c'est que vous avez terminé le challenge Bot Framework.

Voici les étapes à suivre pour déployer votre bot dans le cloud et l'enregistrer.

## Déployez votre bot dans le cloud

Maintenant que notre bot fonctionne correctement en local, nous allons le déployer sur le cloud. Pour suivez les étapes ci-dessous, il vous faut un abonnement Mcirosoft Azure. Si vous n'en possèdez pas, vous pouvez obtenir une version d'essai ici : azure.microsoft.com/en-us/

Suivez les étapes suivantes pour déployer votre bot dans le cloud :

1. Faites un clic droit sur le projet
2. Cliquez sur **Publish**
3. Sélectionnez **Microsoft Azure App Services** : 
![publishStep1](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step1.png)

4. Il faut ensuite créer votre service d'application. Cliquer sur le bouton **New** à droite de la fenêtre : 
![publishStep2](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step2.PNG)

5. Créez votre service d'application en remplissant les informations demandées. Veillez à bien choisir la zone **WestEurope**: 
![publishStep3](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step3.PNG)

6. Une fois que votre service d'application a été créé, cliquez sur **Create** pour obtenir la fenêtre suivante :
![publishStep3](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step4.PNG)

7. Cette fenêtre récapitule toutes les informations de connexion à votre service azure. Cliquez sur **validate connection** pour véfifier le bon établissement de la connexion. Cliquez sur **Next**
8. Veillez à ce que la configuration **Release** soit bien sélectionnée pour le déploiement, puis cliquez sur **Next** : 
![publishStep4](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step5.PNG)

9. Cliquer sur **Publish** : 

![publishStep5](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/publishbot_step6.PNG)

Bravo votre Bot est dans les nuages ! Il nous reste une toute petite étape pour finir...

## Enregistrez votre bot avec Microsoft Bot Framework

De même qu'une application mobile a besoin d'être enregistrée, vous devez enregistrer votre bot pour indiquer à Bot Connector comment appeler le service Web de votre Bot.

1. Connectez vous sur le portail de Microsoft Bot Framework avec votre compte Microsoft : https://dev.botframework.com 
2. Cliquez sur le bouton **Register a Bot** et remplissez le formulaire. Notez que plusieurs champs de ce formulaire peuvent être modifiés à nouveau plus tard en cas d'erreur : 
![registerStep1](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/registerbot_step1.PNG)

3. Cliquez sur **Create Microsoft App Id and password**. 
4. La plateforme vous demande de vous identifier à nouveau avec votre compre Microsoft, identifiez-vous
5. A l'issue de cela, votre identifiant d'application a été généré. Cliquez sur **Générer un mot de passe pour continuer** : 
![registerStep2](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/registerbot_step1bis.PNG)

6. La plateforme web affiche votre mot de passe. **Attention : ce sera la seule fois où il sera visible en clair, copiez-collez le dans un endroit sûr et noteez également votre Microsoft App Id !**
7. Cliquez ensuite sur **Terminez et revenir à Bot Framework** : 
![registerStep3](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/registerbot_step1ter.PNG)

8. A l'issue de tout cela, le champs **Microsoft App Id** a normalement été rempli automatiquement, si ce n'est pas le cas, complétez le avec un copié-collé
9. Remplissez le reste du formulaire en saisissant les informations adaptées dans les champs obligatoires : 
![registerStep4](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/registerbot_step2.PNG)

10. Puis cliquez sur le bouton **Register** après avoir coché la case au dessus dudit bouton : 
![registerStep5](https://github.com/EdwigeSeminara/Mini-Hacks/blob/master/BotFramework/README_files/registerbot_step3.PNG)

11. Modifiez ensuite le fichier **web.config** de votre projet en spécifiant votre Microsoft App Id et le mot de passe généré : 
```xml
<configuration>
  <appSettings>
    <!-- update these with your BotId, Microsoft App Id and your Microsoft App Password-->
    <add key="BotId" value="MiniHackBotApplication" />
    <add key="MicrosoftAppId" value="f83b8009-ff1f-4be7-bbc8-9e081142bed5" />
    <add key="MicrosoftAppPassword" value="zBc*********************" />
  </appSettings>
```

## Pour aller encore plus loin

Vous en voulez encore ? Voici d'autres idées pour aller encore plus loin : 

* Localiser le bot pour qu’il gère plusieurs langues
* Ajouter un peu de cogntives services avec LUIS ou Recast.AI
* Gérer plus de boissons ou plus de type de boissons (pourquoi pas des cocktails ?)
* Développer une gestion des prix plus aboutie et plus dynamique (en se basant sur la présence de suppléments par exemple)

## Laissez libre cours à votre imagination !


## Documentations

* **[Bot framework documentation](https://docs.botframework.com/en-us/)**
* **[Bot Builder for .NET](https://download.botframework.com/bf-v3/tools/emulator/publish.htm)**
* **[Bot Framework resources](https://docs.botframework.com/en-us/tools/bot-framework-emulator/#navtitle)**
