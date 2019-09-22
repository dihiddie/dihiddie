using System;
using System.Collections.Generic;

namespace dihiddie.DAL.Post.EF.Context
{
    public partial class TagPostLink
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int PostInformationId { get; set; }

        public virtual PostInformation PostInformation { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
