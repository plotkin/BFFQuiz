using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace BFFQuiz
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
            
            
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("token"))
            {
                App.AccessToken = (string)IsolatedStorageSettings.ApplicationSettings["token"];
                NavigationService.Navigate(new Uri("/Quiz.xaml", UriKind.Relative));
            }
        }

        private void Image_Tap_1(object sender,System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Facebook.xaml", UriKind.Relative));
        }
    }
}