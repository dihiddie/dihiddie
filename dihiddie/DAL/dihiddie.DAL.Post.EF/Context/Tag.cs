using System;
using System.Collections.Generic;

namespace dihiddie.DAL.Post.EF.Context
{
    public partial class Tag
    {
        public Tag()
        {
            TagPostLink = new HashSet<TagPostLink>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TagPostLink> TagPostLink { get; set; }
    }
}
