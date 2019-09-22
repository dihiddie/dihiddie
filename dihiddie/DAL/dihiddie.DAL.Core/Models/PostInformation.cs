using System;

namespace dihiddie.DAL.Post.Core.Models
{
    public class PostInformation
    {
        public int PostContentId { get; set; }

        public string PreviewImagePath { get; set; }

        public string PreviewText { get; set; }

        public bool IsBlogPost { get; set; }

        public bool IsDraft { get; set; }

        public byte[] PreviewImage { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }

        public Tag[] Tags { get; set; }

        public PostContent PostContent { get; set; }
    }
}
