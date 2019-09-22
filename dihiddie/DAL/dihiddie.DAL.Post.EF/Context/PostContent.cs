using System;
using System.Collections.Generic;

namespace dihiddie.DAL.Post.EF.Context
{
    public partial class PostContent
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public byte[] Content { get; set; }

        public virtual PostInformation PostInformation { get; set; }
    }
}
