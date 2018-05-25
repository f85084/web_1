﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace web.Models
{
    [Table("Reply", Schema = "dbo")]
    public class Reply
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public string UserName { get; set; }
        public string Context { get; set; }
        public DateTime CreatDate { get; set; }
    }
}
