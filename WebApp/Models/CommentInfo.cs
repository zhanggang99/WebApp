using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CommentInfo
    {
        public long CommentId { get; set; }
        public long BlogId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}