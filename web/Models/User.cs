﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserAccount { get; set; }
        public string UserClass { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime MofiyDate { get; set; }
    }
}