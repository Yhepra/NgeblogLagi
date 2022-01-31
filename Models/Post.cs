using System;

namespace NgeblogLagi.Models
{
    public class Post
    {
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public Category Category { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Update_Date { get; set; }
        public User User { get; set; }
    }
}
