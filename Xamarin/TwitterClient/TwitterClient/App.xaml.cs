using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterAPI;
using Xamarin.Forms;

namespace TwitterClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TwitterClient.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            TwitterApi.Instance.SetCredentials(
                TwitterCredentials.OAuthAccessToken,
                TwitterCredentials.OAuthAccessTokenSecret,
                TwitterCredentials.ConsumerKey,
                TwitterCredentials.ConsumerSecret
                );
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
