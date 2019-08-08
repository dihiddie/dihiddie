using System;

namespace dihiddie.DAL.Post.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreateDateTime { get; set; }

        public byte[] Content { get; set; }

        public string PreviewImagePath { get; set; }

        public string PreviewText { get; set; }

        public bool IsBlogPost { get; set; }
    }
}
