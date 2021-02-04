using System;

namespace dihiddie.Utils.GoogleBlogpostsLoader.Models
{
    public class BlogPost
    {
        // public string id { get; set; }

        public DateTime published { get; set; }

        public DateTime updated { get; set; }

        public string title { get; set; }

        public string content { get; set; }
    }

}
