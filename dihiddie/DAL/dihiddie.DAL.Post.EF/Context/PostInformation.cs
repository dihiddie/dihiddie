using System;
using System.Collections.Generic;

namespace dihiddie.DAL.Post.EF.Context
{
    public partial class PostInformation
    {
        public PostInformation()
        {
            TagPostLink = new HashSet<TagPostLink>();
        }

        public int Id { get; set; }
        public int PostId { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public byte[] PreviewImage { get; set; }
        public string PreviewText { get; set; }
        public bool? IsBlogPost { get; set; }
        public bool IsDraft { get; set; }
        public string Title { get; set; }

        public virtual PostContent Post { get; set; }
        public virtual ICollection<TagPostLink> TagPostLink { get; set; }
    }
}
