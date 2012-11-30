using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
}
