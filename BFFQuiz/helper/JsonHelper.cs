using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BFFQuiz.helper
{
        public class Hometown
        {
            public string city { get; set; }
            public string name { get; set; }
            public string zip { get; set; }
            public string country { get; set; }
            public string state { get; set; }
            public long id { get; set; }
        }

        public class HometownObject
        {
            public List<User> users { get; set; }
            public int friends_count { get; set; }
            public Hometown hometown { get; set; }
            public string text { get; set; }
            public string type { get; set; }
            public string id { get; set; }
        }
        public class Movie
        {
            public string category { get; set; }
            public string created_time { get; set; }
            public string name { get; set; }
            public string id { get; set; }
        }

        public class User
        {
            public bool correct { get; set; }
            public string name { get; set; }
            public long id { get; set; }
        }

        public class MovieObject
        {
            public Movie movie { get; set; }
            public string text { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public List<User> users { get; set; }
        }
        public class Book
        {
            public string category { get; set; }
            public string created_time { get; set; }
            public string name { get; set; }
            public string id { get; set; }
        }
        public class BookObject
        {
            public string text { get; set; }
            public Book book { get; set; }
            public string type { get; set; }
            public List<User> users { get; set; }
            public string id { get; set; }
        }
        public class Music
        {
            public string category { get; set; }
            public string created_time { get; set; }
            public string name { get; set; }
            public string id { get; set; }
        }

        public class MusicObject
        {
            public string type { get; set; }
            public string text { get; set; }
            public Music music { get; set; }
            public string id { get; set; }
            public List<User> users { get; set; }
        }

        public class Photo
        {
            public string pid { get; set; }
            public string src_big { get; set; }
        }

        public class PhotoObject
        {
            public List<User> users { get; set; }
            public int friends_count { get; set; }
            public Photo photo { get; set; }
            public string text { get; set; }
            public string type { get; set; }
            public string id { get; set; }
        }
        public class Board
        {
            public int bad { get; set; }
            public int good { get; set; }
            public double ratio { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Bottom
        {
            public int bad { get; set; }
            public int good { get; set; }
            public double ratio { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class LeaderboardObject
        {
            public List<Board> board { get; set; }
            public List<Bottom> bottom { get; set; }
        }
        public class LeaderboardAll
        {
            public int bad { get; set; }
            public int good { get; set; }
            public double ratio { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public ImageBrush idBrush { get; set; }
            public BitmapImage position { get;set; }
            public LeaderboardAll(int bad, int good, double ratio, string id, string name, string pos)
            {
                this.bad = bad;
                this.good = good;
                this.ratio = Math.Round(ratio, 2) * 100 * 3;
                this.id = id;
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri("http://graph.facebook.com/" + id + "/picture?width=100&height=100", UriKind.Absolute));
                this.idBrush = ib;
                this.name = name.Split(' ')[0] + " " + name.Split(' ')[name.Split().Length - 1][0] + ".";
                if (pos == "t")
                {
                    position = new BitmapImage(new Uri("images/photo_chose.png", UriKind.Relative));
                }
                else
                {
                    position = new BitmapImage(new Uri("images/photo_nochose.png", UriKind.Relative));
                }
            }
        }
}
