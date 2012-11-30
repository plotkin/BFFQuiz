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
        public Quiz()
        {
            InitializeComponent();
            Loaded += Quiz_Loaded;
        }

        void Quiz_Loaded(object sender, RoutedEventArgs e)
        {
            getQuestions();
        }

        private void getQuestions()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += wc_DownloadStringCompleted;
            wc.DownloadStringAsync(new Uri("http://facebookfriendsquiz.appspot.com/next?access_token=" + App.AccessToken));
            

        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }
            var type = JObject.Parse(e.Result).SelectToken("type").ToString();
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
            NameOne.Text = photo.users[0].name.Split(' ')[0] + " " + photo.users[0].name.Split(' ')[1][0] + ".";
            NameTwo.Text = photo.users[1].name.Split(' ')[0] + " " + photo.users[1].name.Split(' ')[1][0] + ".";
            NameThree.Text = photo.users[2].name.Split(' ')[0] + " " + photo.users[2].name.Split(' ')[1][0] + ".";
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
            RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void setMovie()
        {
            NameOne.Text = movie.users[0].name.Split(' ')[0] + " " + movie.users[0].name.Split(' ')[1][0] + ".";
            NameTwo.Text = movie.users[1].name.Split(' ')[0] + " " + movie.users[1].name.Split(' ')[1][0] + ".";
            NameThree.Text = movie.users[2].name.Split(' ')[0] + " " + movie.users[2].name.Split(' ')[1][0] + ".";
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
            RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void setBook()
        {
            NameOne.Text = book.users[0].name.Split(' ')[0] + " " + book.users[0].name.Split(' ')[1][0] + ".";
            NameTwo.Text = book.users[1].name.Split(' ')[0] + " " + book.users[1].name.Split(' ')[1][0] + ".";
            NameThree.Text = book.users[2].name.Split(' ')[0] + " " + book.users[2].name.Split(' ')[1][0] + ".";
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
            RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void setMusic()
        {
            NameOne.Text = music.users[0].name.Split(' ')[0] + " " + music.users[0].name.Split(' ')[1][0] + ".";
            NameTwo.Text = music.users[1].name.Split(' ')[0] + " " + music.users[1].name.Split(' ')[1][0] + ".";
            NameThree.Text = music.users[2].name.Split(' ')[0] + " " + music.users[2].name.Split(' ')[1][0] + ".";
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
            RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void setHometown()
        {
            NameOne.Text = hometown.users[0].name.Split(' ')[0]+ " " + hometown.users[0].name.Split(' ')[1][0] + ".";
            NameTwo.Text = hometown.users[1].name.Split(' ')[0] + " " + hometown.users[1].name.Split(' ')[1][0] + ".";
            NameThree.Text = hometown.users[2].name.Split(' ')[0] + " " + hometown.users[2].name.Split(' ')[1][0] + ".";
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
            RectPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            getQuestions();
        }

        private void VarOne_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

            VarOneFrame.Source = new BitmapImage(new Uri("images/photo_chose.png", UriKind.Relative));
            VarTwoFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
            VarThreeFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
        }

        private void VarTwo_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            VarTwoFrame.Source = new BitmapImage(new Uri("images/photo_chose.png", UriKind.Relative));
            VarOneFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
            VarThreeFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
        }

        private void VarThree_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            VarThreeFrame.Source = new BitmapImage(new Uri("images/photo_chose.png", UriKind.Relative));
            VarTwoFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
            VarOneFrame.Source = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
        }


    }
}