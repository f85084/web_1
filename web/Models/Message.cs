using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace web.Models
{
    [Table("Message", Schema = "dbo")]
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Context { get; set; }
        public DateTime CreatDate { get; set; }
    }
}
