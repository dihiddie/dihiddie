using System;
using System.Collections.Generic;

namespace dihiddie.DAL.Post.EF.Context
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public byte[] Content { get; set; }
        public string PreviewImagePath { get; set; }
        public string PreviewText { get; set; }
        public bool? IsBlogPost { get; set; }
    }
}
