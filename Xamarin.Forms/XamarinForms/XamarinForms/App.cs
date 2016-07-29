using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinForms.Views;

namespace XamarinForms
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var tabbedPage = new TabbedPage();

            tabbedPage.Children.Add(new EventbriteViewPage());
            tabbedPage.Children.Add(new FoursquareViewPage());
            tabbedPage.Children.Add(new YoutubePage());
            tabbedPage.Children.Add(new TwitterPage());
            tabbedPage.Children.Add(new InstagramViewPage());
            tabbedPage.Children.Add(new FlickrViewPage());

            MainPage = tabbedPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
