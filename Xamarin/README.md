# Xamarin & Twitter Mini-Hack
Dans ce mini-hack vous utiliserez l'API de Twitter pour rechercher et afficher des tweets dans une application multiplateforme Xamarin.

Le but est d'implémenter rapidement l'API Twitter et de jouer avec Xamarin.Forms pour les afficher sur toutes les plateformes.

Le tutoriel ci-dessous vous guidera pour récupérer tweets et utilisateurs, mais après cette base posée vous êtes libre de laisser votre imagination s'envoler et d'afficher vos tweets différemment. 
N'hésitez pas à tweeter [**@framinosona**](https://twitter.com/framinosona), [**@edwigeseminara**](https://twitter.com/edwigeseminara) ou [**@benjiiim**](https://twitter.com/benjiiim) pour tester vos clients twitter ;)

Pour ce challenge vous aurez besoin de soit :

- Visual Studio 2015 (Avec les outils Xamarin installés et à jour)
- Xamarin Studio

## Récupérer et ouvrir la solution
Pour bien commencer, il faut s'assurer que la solution de départ se lance correctement dans votre environnement. 
Pour cela :

1. Ouvrez ***TwitterClient.sln***
2. Sélectionnez le projet de démarrage et le device de déploiement
3. Démarrez le projet

![Twitter apps](/Xamarin/README_FILES/snip_20160928154306.png)
![Twitter apps](/Xamarin/README_FILES/OutputSelectIOS.png)
![Twitter apps](/Xamarin/README_FILES/OutputSelectDroid.png)

![Twitter apps](/Xamarin/README_FILES/snip_20160928154348.png)

![Twitter apps](/Xamarin/README_FILES/Start.png)

## Créer une app Twitter et récupérer ses credentials OAuth
Afin d'accéder aux APIs de Twitter il faut se procurer des identifiants auprès de Twitter :

1. Allez sur [**https://apps.twitter.com/**](https://apps.twitter.com/)
2. Cliquez sur **"Create New App"**
3. Renseignez le **nom** de votre application, sa **description** et un **website** *(ce champ n'est pas important)*
4. Vous arrivez sur la page de **gestion de votre App Twitter**.
5. Rendez-vous dans **Keys and Access Tokens**
6. Dans **Application Settings** copiez-collez sur votre bloc note favori les **Consumer Key (API Key)** et **Consumer Secret (API Secret)**
7. Plus bas dans la page, dans **Your access token**, cliquez sur **Create my access token**
8. Copiez-coller également les **Access Token**  et **Access Token Secret**

![Twitter apps](/Xamarin/README_FILES/snip_20160928153145.png)

![Twitter apps](/Xamarin/README_FILES/snip_20160928153232.png)

![Twitter apps](/Xamarin/README_FILES/snip_20160928153618.png)

![Twitter apps](/Xamarin/README_FILES/snip_20160928154001.png)

![Twitter apps](/Xamarin/README_FILES/snip_20160928153735.png)

![Twitter apps](/Xamarin/README_FILES/snip_20160928153821.png)

![Twitter apps](/Xamarin/README_FILES/snip_20160928153906.png)

## Ajoutez vos credentials Twitter à l'application
L'application a besoin de ces identifiants pour questionner l'API Twitter : 

1. Dans **TwitterClient**, ouvrez **TwitterCredentials.cs**
2. Renseignez vos informations récupérées aux étapes précédentes.

![Twitter apps](/Xamarin/README_FILES/snip_20160928155009.png)

Vous noterez l'appel dans **App.xaml.cs > OnStart()** de **TwitterApi.Instance.SetCredentials()** au démarrage de l'application.

## Utilisez la DLL TwitterAPI.dll

![Twitter apps](/Xamarin/README_FILES/snip_20160928154947.png)

Afin de simplifier cet exercice nous avons préparé cette DLL qui permet 3 types de requetes Twitter :

- **Rechercher des utilisateurs** *TwitterAPI.SearchUserAsync()*
- **Rechercher des tweets** *TwitterAPI.SearchTweetsAsync(ResultType)*
 - **Rechercher les tweets récents** *TwitterAPI.ResultType.Recent*
 - **Rechercher les tweets populaires** *TwitterAPI.ResultType.Popular*
 - **Rechercher un mélange des 2** *TwitterAPI.ResultType.Mixed*
- **Rechercher les tweets d'un utilisateur** *TwitterAPI.SearchTweetsOfUserAsync()*

Vous pouvez alors utiliser :
```csharp
// Récupérer les 30 derniers tweets avec le mot clé "Xamarin"
var Statuses = await TwitterAPI.TwitterApi.Instance.SearchTweetsAsync("Xamarin", 30, ResultType.Recent);
// Récupérer les 10 derniers tweets de l'utilisateur @Cellenza
var Statuses = await TwitterAPI.TwitterApi.Instance.SearchTweetsOfUserAsync("Cellenza", 10);
...
```
**Attention** : il y a des limitations en nombre d'appels. Nous vous invitons à vous en référer aux documentations ci-dessous et à ne pas lancer 3000 appels par seconde.

###### Documentations
- [**TWITTER : GET statuses/user_timeline**](https://dev.twitter.com/rest/reference/get/statuses/user_timeline)
- [**TWITTER : GET search/tweets**](https://dev.twitter.com/rest/reference/get/search/tweets)
- [**TWITTER :GET users/search**](https://dev.twitter.com/rest/reference/get/users/search)

## Ajouter la vue de son application -> MainPage
Si vous observez **MainPage.xaml** vous remarquerez que nous avons déjà changé *ContentPage* en *TabbedPage* pour vous. 
*(You're welcome ;) )*

![Twitter apps](/Xamarin/README_FILES/snip_20160928162052.png)

L'objectif est donc de faire une application qui permet :

- Dans le panneau **"Search"** de rechercher des tweets
- Dans le panneau **"User"** de rechercher des utilisateurs

### Search
##### XAML -> MainPage.xaml
Ajoutez à l'intérieur du *ContentPage* **"Search"** :
```xaml
    <StackLayout HorizontalOptions="Fill" VerticalOptions="Fill">
      <SearchBar x:Name="TweetsSearchBar"
                 HorizontalOptions="Fill"
                 SearchButtonPressed="RefreshSearch"></SearchBar>
      <ListView x:Name="TweetsList"
                HorizontalOptions="Fill"
                HasUnevenRows="True"
                IsPullToRefreshEnabled="True"
                Refreshing="RefreshSearch">
        <ListView.ItemTemplate>
          <DataTemplate>
            <ImageCell ImageSource="{Binding Path=User.ProfileImageUrl}"
                       Text="{Binding Path=Text}"
                        Detail="{Binding Path=User.ScreenName, StringFormat='@{0}'}"></ImageCell>
          </DataTemplate>
        </ListView.ItemTemplate>
      </ListView>
    </StackLayout>
```

###### Documentations
- [**TabbedPage**](https://developer.xamarin.com/guides/xamarin-forms/user-interface/navigation/tabbed-page/)
- [**StackLayout**](https://developer.xamarin.com/guides/xamarin-forms/user-interface/layouts/stack-layout/)
- [**SearchBar**](https://developer.xamarin.com/api/type/Xamarin.Forms.SearchBar/)
- [**ListView**](https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/)
- [**ImageCell**](https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/customizing-cell-appearance/)
- [**Binding**](https://developer.xamarin.com/guides/xamarin-forms/xaml/xaml-basics/data_binding_basics/)

##### C-Sharp -> MainPage.xaml.cs
Nous avons mis dans notre XAML des événements. *SearchButtonPressed* et *Refreshing* pour être précis. Ils appellent tous les deux *RefreshSearch*. Ajoutez donc dans votre **MainPage.xaml.cs** :
```csharp
        private async void RefreshSearch(object sender, EventArgs e)
        {
            TweetsList.IsRefreshing = true;
            // TODO : Récupérer la liste des tweets correspondant au TweetsSearchBar.Text et les ajouter à TweetsList.ItemsSource
            TweetsList.IsRefreshing = false;
        }
```
*(On vous laisse remplir ;) )*

### Users
##### XAML -> MainPage.xaml
Ajoutez à l'intérieur du *ContentPage* **"User"** :
```xaml
      <StackLayout HorizontalOptions="Fill" VerticalOptions="Fill">
        <SearchBar x:Name="UserSearchBar"
                   HorizontalOptions="Fill"
                   SearchButtonPressed="RefreshUsers"></SearchBar>
        <ListView x:Name="UsersList"
                  HorizontalOptions="Fill"
                  HasUnevenRows="True"
                  IsPullToRefreshEnabled="True"
                  Refreshing="RefreshUsers">
          <ListView.ItemTemplate>
            <DataTemplate>
              <ImageCell ImageSource="{Binding Path=ProfileImageUrl}"
                         Text="{Binding Path=ScreenName, StringFormat='@{0}'}"></ImageCell>
            </DataTemplate>
          </ListView.ItemTemplate>
        </ListView>
      </StackLayout>
```
##### C-Sharp -> MainPage.xaml.cs
Idem dans votre **MainPage.xaml.cs** :
```csharp
        private async void RefreshUsers(object sender, EventArgs e)
        {
            UsersList.IsRefreshing = true;
            // TODO : Récupérer la liste des utilisateurs correspondant au UserSearchBar.Text et les ajouter à UsersList.ItemsSource
            UsersList.IsRefreshing = false;
        }
```

## Résultat attendu

![Twitter apps](/Xamarin/README_FILES/FinishTweets.png)

![Twitter apps](/Xamarin/README_FILES/FinishUsers.png)

### Pour aller plus loin :

- Customisez votre application à fond !
 - Icone d'application
 - Couleurs & Fonds
 - Informations affichées dans les listes
- Faites la même chose en Xamarin.Android et Xamarin.iOS
- Au clic sur un utilisateur, naviguez vers une page affichant les informations de l'utilisateur et ses derniers tweets.
###### Documentation
- [**Hierarchical navigation**](https://developer.xamarin.com/guides/xamarin-forms/user-interface/navigation/hierarchical/)

### FAQ
> "This version of Xamarin.iOS requires the iOS 10.0 SDK (shipped with Xcode 8.0) when the managed linker is disabled. Either upgrade Xcode, or enable the managed linker."

Comme indiqué, le XCode détecté sur le Mac de déploiement n'est pas à jour. 2 solutions possibles :
- Mettre à jour XCode sur ce Mac
- Dans Solution iOS > Paramètres > iOS Build > Linker behavior sélectionner "Link SDK Assemblies Only"

> Tout le code de ma solution Android est rouge.

Il s'agit d'un bug connu lorsqu'on utilise VS et Xamarin. Fermez Visual Studio, aller jusqu'à la racine de votre projet et supprimez le dossier /.vs . Relancez VS et votre Android est compris.

![Twitter apps](/Xamarin/README_FILES/snip_20160928184108.png)

> "Resource.Layout.Tabbar" et "Resource.Layout.Toolbar" ne sont pas trouvés

Android a besoin d'une première compilation avant de pouvoir développer. Générez votre projet Android.

> Tout le code (y compris le XAML) est rouge.

Vous avez surement oublié de récupérer les pacquets NuGets. Rendez-vous dans Outils/Tools > Gestionnaire de packages NuGet/Nuget packages manager > Gérer les packages NuGet pour la solution .../Manage Nuget packages for solution ... et cliquez sur le bandeau jaune qui apparait.

![Twitter apps](/Xamarin/README_FILES/snip_20160928184033.png)

