using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using BFFQuiz.helper;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using WindowsPhonePostClient;
using System.IO.IsolatedStorage;

namespace BFFQuiz
{
    public partial class Quiz : PhoneApplicationPage
    {
        private HometownObject hometown;
        private MovieObject movie;
        private MusicObject music;
        private BookObject book;
        private PhotoObject photo;
        private string flag;
        private string answer;
        private string userAns;
        private Dictionary<string, object> postAnswer = new Dictionary<string, object>();
        public Quiz()
        {
            InitializeComponent();
            Loaded += Quiz_Loaded;
        }

        void Quiz_Loaded(object sender, RoutedEventArgs e)
        {
            getQuestions();
            setSettings();
        }

        private void setSettings()
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains("On"))
            {
                IsolatedStorageSettings.ApplicationSettings.Add("On", "yes");
                IsolatedStorageSettings.ApplicationSettings.Save();
                toggle.IsChecked = true;
            }
            else
            {
                App.Check = (string)IsolatedStorageSettings.ApplicationSettings["On"];
                if (App.Check == "yes")
                {
                    toggle.IsChecked = true;
                }
                else
                {
                    toggle.IsChecked = false;
                }
            }
        }

        private void getQuestions()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += wc_DownloadStringCompleted;
            wc.DownloadStringAsync(new Uri("http://facebookfriendsquiz.appspot.com/next?access_token=" + App.AccessToken));
            

        }

        void wc_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }
            var type = JObject.Parse(e.Result).SelectToken("type").ToString();
            var id = JObject.Parse(e.Result).SelectToken("id").ToString();
            postAnswer.Add("access_token", App.AccessToken);
            postAnswer.Add("id", id);
            switch (type)
            {
                case "hometown":
                hometown = JsonConvert.DeserializeObject<HometownObject>(e.Result);
                setHometown();
                break;

                case "music":
                music = JsonConvert.DeserializeObject<MusicObject>(e.Result);
                setMusic();
                break;

                case "book":
                book = JsonConvert.DeserializeObject<BookObject>(e.Result);
                setBook();
                break;

                case "movie":
                movie = JsonConvert.DeserializeObject<MovieObject>(e.Result);
                setMovie();
                break;

                case "photo":
                photo = JsonConvert.DeserializeObject<PhotoObject>(e.Result);
                setPhoto();
                break;
            }

        }

        private void setPhoto()
        {
            for (int j = 0; j < 3; j++)
            {
                if (photo.users[j].correct)
                {
                    answer = photo.users[j].id.ToString();
                }
                    
            }
                NameOne.Text = photo.users[0].name.Split(' ')[0] + " " + photo.users[0].name.Split(' ')[i(photo.type, 0)][0] + ".";
                NameTwo.Text = photo.users[1].name.Split(' ')[0] + " " + photo.users[1].name.Split(' ')[i(photo.type, 1)][0] + ".";
                NameThree.Text = photo.users[2].name.Split(' ')[0] + " " + photo.users[2].name.Split(' ')[i(photo.type, 2)][0] + ".";
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri(photo.photo.src_big));
                QuizPhoto.Fill = ib;
                TextQuestion.Text = photo.text;
                ImageBrush ib1 = new ImageBrush();
                ib1.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + photo.users[0].id + "/picture?width=100&height=100"));
                VarOne.Fill = ib1;
                ImageBrush ib2 = new ImageBrush();
                ib2.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + photo.users[1].id + "/picture?width=100&height=100"));
                VarTwo.Fill = ib2;
                ImageBrush ib3 = new ImageBrush();
                ib3.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + photo.users[2].id + "/picture?width=100&height=100"));
                VarThree.Fill = ib3;
                VarOne.Tag = photo.users[0].id.ToString();
                VarTwo.Tag = photo.users[1].id.ToString();
                VarThree.Tag = photo.users[2].id.ToString();
                RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private int i(string type, int i)
        {
            switch (type)
            {
                case "hometown":
                    {
                        return hometown.users[i].name.Split().Length - 1;
                    }
                case "photo":
                    {
                        return photo.users[i].name.Split().Length - 1;
                    }
                case "movie":
                    {
                        return movie.users[i].name.Split().Length - 1;
                    }
                case "music":
                    {
                        return music.users[i].name.Split().Length - 1;
                    }
                case "book":
                    {
                        return book.users[i].name.Split().Length - 1;
                    }
                default:
                    {
                        return 1;
                    }
            }
        }

        private void setMovie()
        {
            for (int j = 0; j < 3; j++)
            {
                if (movie.users[j].correct)
                {
                    answer = movie.users[j].id.ToString();
                }

            }
                NameOne.Text = movie.users[0].name.Split(' ')[0] + " " + movie.users[0].name.Split(' ')[i(movie.type, 0)][0] + ".";
                NameTwo.Text = movie.users[1].name.Split(' ')[0] + " " + movie.users[1].name.Split(' ')[i(movie.type, 1)][0] + ".";
                NameThree.Text = movie.users[2].name.Split(' ')[0] + " " + movie.users[2].name.Split(' ')[i(movie.type, 2)][0] + ".";
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + movie.movie.id + "/picture?width=280&height=280"));
                QuizPhoto.Fill = ib;
                TextQuestion.Text = movie.text;
                ImageBrush ib1 = new ImageBrush();
                ib1.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + movie.users[0].id + "/picture?width=100&height=100"));
                VarOne.Fill = ib1;
                ImageBrush ib2 = new ImageBrush();
                ib2.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + movie.users[1].id + "/picture?width=100&height=100"));
                VarTwo.Fill = ib2;
                ImageBrush ib3 = new ImageBrush();
                ib3.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + movie.users[2].id + "/picture?width=100&height=100"));
                VarThree.Fill = ib3;
                VarOne.Tag = movie.users[0].id.ToString();
                VarTwo.Tag = movie.users[1].id.ToString();
                VarThree.Tag = movie.users[2].id.ToString();
                RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void setBook()
        {
            for (int j = 0; j < 3; j++)
            {
                if (book.users[j].correct)
                {
                    answer = book.users[j].id.ToString();
                }

            }
                NameOne.Text = book.users[0].name.Split(' ')[0] + " " + book.users[0].name.Split(' ')[i(book.type, 0)][0] + ".";
                NameTwo.Text = book.users[1].name.Split(' ')[0] + " " + book.users[1].name.Split(' ')[i(book.type, 1)][0] + ".";
                NameThree.Text = book.users[2].name.Split(' ')[0] + " " + book.users[2].name.Split(' ')[i(book.type, 2)][0] + ".";
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + book.book.id + "/picture?width=280&height=280"));
                QuizPhoto.Fill = ib;
                TextQuestion.Text = book.text;
                ImageBrush ib1 = new ImageBrush();
                ib1.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + book.users[0].id + "/picture?width=100&height=100"));
                VarOne.Fill = ib1;
                ImageBrush ib2 = new ImageBrush();
                ib2.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + book.users[1].id + "/picture?width=100&height=100"));
                VarTwo.Fill = ib2;
                ImageBrush ib3 = new ImageBrush();
                ib3.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + book.users[2].id + "/picture?width=100&height=100"));
                VarThree.Fill = ib3;
                VarOne.Tag = book.users[0].id.ToString();
                VarTwo.Tag = book.users[1].id.ToString();
                VarThree.Tag = book.users[2].id.ToString();
                RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void setMusic()
        {
            for (int j = 0; j < 3; j++)
            {
                if (music.users[j].correct)
                {
                    answer = music.users[j].id.ToString();
                }

            }
            NameOne.Text = music.users[0].name.Split(' ')[0] + " " + music.users[0].name.Split(' ')[i(music.type, 0)][0] + ".";
            NameTwo.Text = music.users[1].name.Split(' ')[0] + " " + music.users[1].name.Split(' ')[i(music.type, 1)][0] + ".";
            NameThree.Text = music.users[2].name.Split(' ')[0] + " " + music.users[2].name.Split(' ')[i(music.type, 2)][0] + ".";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + music.music.id + "/picture?width=280&height=280"));
            QuizPhoto.Fill = ib;
            TextQuestion.Text = music.text;
            ImageBrush ib1 = new ImageBrush();
            ib1.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + music.users[0].id + "/picture?width=100&height=100"));
            VarOne.Fill = ib1;
            ImageBrush ib2 = new ImageBrush();
            ib2.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + music.users[1].id + "/picture?width=100&height=100"));
            VarTwo.Fill = ib2;
            ImageBrush ib3 = new ImageBrush();
            ib3.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + music.users[2].id + "/picture?width=100&height=100"));
            VarThree.Fill = ib3;
            VarOne.Tag = music.users[0].id.ToString();
            VarTwo.Tag = music.users[1].id.ToString();
            VarThree.Tag = music.users[2].id.ToString();
            RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void setHometown()
        {
            for (int j = 0; j < 3; j++)
            {
                if (hometown.users[j].correct)
                {
                    answer = hometown.users[j].id.ToString();
                }

            }
            NameOne.Text = hometown.users[0].name.Split(' ')[0] + " " + hometown.users[0].name.Split(' ')[i(hometown.type, 0)][0] + ".";
            NameTwo.Text = hometown.users[1].name.Split(' ')[0] + " " + hometown.users[1].name.Split(' ')[i(hometown.type, 1)][0] + ".";
            NameThree.Text = hometown.users[2].name.Split(' ')[0] + " " + hometown.users[2].name.Split(' ')[i(hometown.type, 2)][0] + ".";
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + hometown.hometown.id + "/picture?width=280&height=280"));
            QuizPhoto.Fill = ib;
            TextQuestion.Text = hometown.text;
            ImageBrush ib1 = new ImageBrush();
            ib1.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + hometown.users[0].id + "/picture?width=100&height=100"));
            VarOne.Fill = ib1;
            ImageBrush ib2 = new ImageBrush();
            ib2.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + hometown.users[1].id + "/picture?width=100&height=100"));
            VarTwo.Fill = ib2;
            ImageBrush ib3 = new ImageBrush();
            ib3.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + hometown.users[2].id + "/picture?width=100&height=100"));
            VarThree.Fill = ib3;
            VarOne.Tag = hometown.users[0].id.ToString();
            VarTwo.Tag = hometown.users[1].id.ToString();
            VarThree.Tag = hometown.users[2].id.ToString();
            RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (answer == userAns)
            {
                ToastPhoto.Source = new BitmapImage(new Uri("images/correct.png", UriKind.Relative));
                ToastPhoto.Visibility = Visibility.Visible;
                Story.Begin();
            }
            else 
            {
                ToastPhoto.Source = new BitmapImage(new Uri("images/incorrect.png", UriKind.Relative));
                ToastPhoto.Visibility = Visibility.Visible;
                Story.Begin();
            }
            postAnswer.Add("uid", userAns);
            postAnswer.Add("publish", App.Check);
            PostClient pc = new PostClient(postAnswer);
            pc.DownloadStringCompleted += pc_DownloadStringCompleted;
            pc.DownloadStringAsync(new Uri("http://facebookfriendsquiz.appspot.com/choose", UriKind.Absolute));
            VarOneFrame.Source = new BitmapImage(new Uri("images/photo.png", UriKind.Relative));
            VarTwoFrame.Source = new BitmapImage(new Uri("images/photo.png", UriKind.Relative));
            VarThreeFrame.Source = new BitmapImage(new Uri("images/photo.png", UriKind.Relative));
            nextButton.IsEnabled = false;
            postAnswer.Clear();
            getQuestions();

            
        }

        void pc_DownloadStringCompleted(object sender, WindowsPhonePostClient.DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result);
        }

        private void VarOne_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            nextButton.IsEnabled = true;
            userAns = (string)VarOne.Tag;
            VarOneFrame.Source = new BitmapImage(new Uri("images/photo_chose.png", UriKind.Relative));
            VarTwoFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
            VarThreeFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
        }

        private void VarTwo_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            nextButton.IsEnabled = true;
            userAns = (string)VarTwo.Tag;
            VarTwoFrame.Source = new BitmapImage(new Uri("images/photo_chose.png", UriKind.Relative));
            VarOneFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
            VarThreeFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
        }

        private void VarThree_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            nextButton.IsEnabled = true;
            userAns = (string)VarThree.Tag;
            VarThreeFrame.Source = new BitmapImage(new Uri("images/photo_chose.png", UriKind.Relative));
            VarTwoFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
            VarOneFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
        }

        private void Pivot_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            getLeaderboard();
        }

        private void getLeaderboard()
        {
            WebClient _wc = new WebClient();
            _wc.DownloadStringCompleted += _wc_DownloadStringCompleted;
            Uri uri = new Uri("http://facebookfriendsquiz.appspot.com/leaderboard?access_token=" + App.AccessToken);
            _wc.DownloadStringAsync(uri);
        }

        void _wc_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            if(e.Error==null)
            MessageBox.Show(e.Result); 
        }

        private void ToggleSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["On"] = "yes";
            IsolatedStorageSettings.ApplicationSettings.Save();
            App.Check = "yes";
        }

        private void ToggleSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["On"] = "no";
            IsolatedStorageSettings.ApplicationSettings.Save();
            App.Check = "no";
        }



    }
}