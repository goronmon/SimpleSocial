using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleSocial.Data;

namespace SimpleSocial.Models
{
    public class Post : IDateCreateAndModified
    {
        public int PostId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Url { get; set; }
        public string Text { get; set;}
        public bool IsDeleted { get; set; } = false;
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User? User { get; set; } = null;

        public List<Comment>? Comments { get; set; } = null;
    }

    public class PostDelta
    {
        public int PostDeltaId { get;set; }
        [Required]
        public int Sequence { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        public string OldTitle { get; set; }
        public string NewTitle { get; set; }
        public string OldText { get; set; }
        public string NewText { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }

    public class PostReport
    {
        public int PostReportId { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}