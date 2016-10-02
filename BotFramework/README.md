# Bot Framework Mini-Hack
Le café étant une boisson très importante pour tout développeur, dans ce mini-hack vous utiliserez Bot Framework pour coder un bot permettant de commander un café.

Le but est de jouer avec Bot Framework et d’utiliser rapidement Azure pour déployer votre bot sur le cloud et l’invoquer dans des applications tierces.

Le tutoriel ci-dessous vous guidera pour construire un bot simple et le déployer, n’hésitez pas à laisser libre cours à votre imagination pour l’enrichir !

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
3.  Indiquer la taille de la boisson
4.	Préciser si la boisson doit être sucrée
5.	Lister les suppléments désirés : crème, lait, chocolat, caramel, etc.
6.	Indiquer le montant de la commande
7.	Récapituler la commande et demander si tout est correct
8.	Demander le nom de l’utilisateur
9.	Demander l’adresse de l’utilisateur
10.	Demander l’horaire de livraison souhaité
11. Demander à l'utilisateur d'évaluer le service
12. Remercier l'utilisateur pour sa commande

### Découvrir le code

L'ensemble de nos modifications vont être faites dans le fichier **CoffeeBot.cs**, ouvrez ce fichier.
Notez la présence de la classe **CoffeeOrder**. 

Vous remarquez :

* la présence de la propriété : 
```csharp 
public string Name { get; set; }
```

* la génération du formulaire : 
```csharp 
var builder = new FormBuilder<CoffeeOrder>()
                        .Message(DynamicCoffee.Welcome)
                        .AddRemainingFields();
```

Ce qu'il faut comprendre : 

* chaque question posée par le bot va être définie par une propriété similaire à la propriété Name
* dans le cas d'une question à choix multiple, les choix proposés à l'utilisateur sont définis par une enum
* la "boucle" du formulaire est tout simplement définie de manière chainée

Passons à l'action !

### Ajouter les enums

Dans le fichier **CoffeeBot.cs** (**en dehors** de la classe CoffeeOrder) : 

* Ajouter une enum pour le type de café : 
```csharp
    public enum CoffeeOptions
    {
        Coffee, CaramelMacchiato, Mocha
    };
```

* Ajouter une enum pour définir la température : 
```csharp
    public enum TemperatureOptions
    {
        Hot, Cold
    };
```

* Ajouter une enum pour spécifier la taile de votre boisson :
```csharp
    public enum SizeOptions
    {
        Ristretto, Short, Medium, Long, Big
    };
```

* Ajouter une enum pour connaitre la quantité de sucre souhaitée :
```csharp
    public enum SugarOptions
    {
        ALittleBitOfSugar, ALot
    };
```

* Ajouter une enum pour proposer des suppléments :
```csharp
    public enum ToppingOptions
    {
        [Terms("except", "but", "not", "no", "all", "everything")]
        Cream=1, Milk, Vanilla, Chocolate, Caramel, Everything
    };
```
Vous aurez probablement noté que nous faisons commencer les valeurs de cette enum à 1 avec **Cream=1** car cette la propriété associée sera optionnelle. La valeur 0 sera donc réservée pour gérer l'absence de réponse.

Ajoutons maintenant les propriétés nécessaires !

### Ajouter les propriétés

Toujours dans le fichier **CoffeeBot.cs**  (**dans** la classe CoffeeOrder) : 

* Ajouter une propriété pour le type de café : 
```csharp
    [Prompt("What kind of {&} would you like? {||}")]
    public CoffeeOptions? Coffee;
```

* Ajouter une propriété pour définir la température : 
```csharp
    [Prompt("Which temperature do you want? {||}")]
    public TemperatureOptions? Temperature;
```

* Ajouter une propriété pour spécifier la taile de votre boisson :
```csharp
    [Prompt("What size do you want? {||}")]
    public SizeOptions? Size;
```

* Ajouter une propriété pour connaitre la quantité de sucre souhaitée :
```csharp
    [Optional]
    [Prompt("Do you want some sugar ? {||}")]
    [Template(TemplateUsage.NoPreference, "None")]
    public SugarOptions? Sugar { get; set; }
```

* Ajouter une propriété pour proposer des suppléments :
```csharp
    [Optional]
    [Prompt("Choose your toppings ? {||}")]
    [Template(TemplateUsage.NoPreference, "None")]
    public List<ToppingOptions> Toppings { get; set; }
```

* Ajouter une propriété pour connaitre l'adresse de livraison :
```csharp
    public string DeliveryAddress;
```

* Ajouter une propriété pour demander le numéro de téléphone :
```csharp
    [Pattern(@"(\(\d{3}\))?\s*\d{3}(-|\s*)\d{4}")]
    public string PhoneNumber;
```

* Ajouter une propriété pour spécifier l'heure de livraison souhaitée :
```csharp
    [Optional]
    [Template(TemplateUsage.StatusFormat, "{&}: {:t}", FieldCase = CaseNormalization.None)]
    public DateTime? DeliveryTime;
```

* Ajouter une propriété pour que l'utilisateur puisse évaluer le service :
```csharp
    [Numeric(1, 5)]
    [Optional]
    [Describe("your experience today")]
    public double? Rating;
```

Ce qu'il faut retenir : 

* l'attribut **Prompt** définit la phrase qui sera utilisée par le bot pour questionner l'utilisateur
* l'attribut **Optional** permet de rendre une question facultative et de donner la possibilité à l'utilisateur de ne pas répondre
* l'attribut **Pattern** définit le format de la réponse attendu
* l'attribut **Template** permet de spécifier le template à utiliser pour une propriété

Modifions maintenant le formulaire pour aboutir à notre scénario !

### Modifier le formulaire

Dans la méthode **BuildForm** de la classe **CoffeeOrder**, après la ligne **.Message(DynamicCoffee.Welcome)** : 

* Demander le type de boisson à commander : 
```csharp
.Field(nameof(Coffee))
```

* Demander si la boisson doit être chaude ou froide : 
```csharp
.Field(nameof(Temperature))
```

* Indiquer la taille de la boisson
```csharp
.Field(nameof(Size))
```

* Préciser si la boisson doit être sucrée : 
```csharp
.Field(nameof(Sugar)) 
```

* Proposer des suppléments :
```csharp
.Field(nameof(Toppings),
	validate: async (state, value) =>
	{
		if (value != null)
		{
			var values = ((List<object>)value).OfType<ToppingOptions>();
			var result = new ValidateResult { IsValid = true, Value = values };
			if (values != null && values.Contains(ToppingOptions.Everything))
			{
				result.Value = (from ToppingOptions topping in Enum.GetValues(typeof(ToppingOptions))
								where topping != ToppingOptions.Everything && !values.Contains(topping)
								select topping).ToList();
			}
			return result;
		}
		else
		{
			// To handle null value when choosing none in toppings
			var result = new ValidateResult { IsValid = true, Value = null };
			return result;
		}
	})
```

* Indiquer le montant de la commande
```csharp
.Confirm(async (state) =>
{
	var cost = 0.0;
	switch (state.Size)
	{
		case SizeOptions.Ristretto: cost = 2.0; break;
		case SizeOptions.Short: cost = 3.49; break;
		case SizeOptions.Medium: cost = 5.0; break;
		case SizeOptions.Long: cost = 6.49; break;
		case SizeOptions.Big: cost = 8.99; break;
	}
	total = cost;
	string message = string.Format(DynamicCoffee.Cost, $"{total:C2}");
	return new PromptAttribute(message);
})
```

* Récapituler la commande et demander si tout est correct : 
```csharp
.Confirm(async (state) =>
{
	string customMessage = DynamicCoffee.RepeartOrderPart1;
	if (state.Sugar != null || state.Toppings != null)
	{
		customMessage = string.Concat(customMessage, DynamicCoffee.RepeartOrderPart2);
	}
	customMessage = string.Concat(customMessage, "?");
	return new PromptAttribute(customMessage);
})
```

* Demander le nom de l'utilisateur, l'adresse, l'horaire de livraison et l'évaluation du service : 
```csharp
.AddRemainingFields()
```
Notez que la méthode **AddRemainingFields()** permet d'ajouter toutes les autres propriétés restantes (une ligne de code oui).

* Remercier l'utilisateur pour sa commande : 
```csharp
.Message(DynamicCoffee.ThankYou)
```

Compilez, éxécutez et testez le tout avec l'émulateur !


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

## Félicitations vous avez terminé ce challenge !

## Pour aller plus loin

Ces parties sont optionnelles dans le cadre du mini-hack, mais voici quelques idées pour aller plus loin :

* Localiser le bot pour qu’il gère plusieurs langues
* Ajouter un peu de cogntives services avec LUIS ou Recast.AI
* Gérer plus de boissons ou plus de type de boissons (pourquoi pas des cocktails ?)
* Développer une gestion des prix plus aboutie et plus dynamique (en se basant sur la présence de suppléments par exemple)

## Documentations

* **[Bot framework documentation](https://docs.botframework.com/en-us/)**
* **[Bot Builder for .NET](https://download.botframework.com/bf-v3/tools/emulator/publish.htm)**
* **[Bot Framework resources](https://docs.botframework.com/en-us/tools/bot-framework-emulator/#navtitle)**
