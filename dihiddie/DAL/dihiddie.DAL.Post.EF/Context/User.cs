﻿using System;
using System.Collections.Generic;
using System.Text;

namespace dihiddie.DAL.Post.EF.Context
{
    public partial class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

    }
}