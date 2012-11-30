using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Facebook;
using System.Windows.Media;
using System.IO.IsolatedStorage;

namespace BFFQuiz
{
    public partial class Facebook : PhoneApplicationPage
    {
        private const string AppID = "229759160484670";
        private const string ExtendedPermissions = "friends_likes, friends_photos, friends_hometown, publish_actions, offline_access";
        private readonly FacebookClient fb = new FacebookClient();
        public Facebook()
        {
            InitializeComponent();
        }
        private void wb_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FacebookOAuthResult res;
            if (!fb.TryParseOAuthCallbackUrl(e.Uri, out res))
            {
                return;
            }

            if (res.IsSuccess) 
            {
                App.AccessToken = res.AccessToken;
                IsolatedStorageSettings.ApplicationSettings["token"] = res.AccessToken;
                IsolatedStorageSettings.ApplicationSettings.Save();
                NavigationService.Navigate(new Uri("/Quiz.xaml", UriKind.Relative));
            }

            else
            {
                MessageBox.Show("Something wrong...");
            }
        }
        private void wb_Loaded(object sender, RoutedEventArgs e)
        {
            Uri uri = GetFacebookLoginUrl(AppID, ExtendedPermissions);
            wb.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(wb_Navigated);
            wb.Navigate(uri);
        }

        private Uri GetFacebookLoginUrl(string AppID, string ExtendedPermissions)
        {
            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = AppID;
            parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            parameters["response_type"] = "token";
            parameters["display"] = "touch";
            parameters["scope"] = ExtendedPermissions;
            return fb.GetLoginUrl(parameters);
        }
    }
}