using System.ComponentModel.DataAnnotations;

namespace SimpleSocial.Models
{
    public class Post
    {
        public int ID { get;set; }
        public string Title { get;set; }
        public string Url { get;set; }
        public string Text { get;set;}
        public DateTime CreateDate { get;set; }
        public DateTime LastModifiedDate { get;set; }
    }

    public class PostReport
    {
        public int ID { get;set; }
    }
}