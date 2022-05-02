using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSocial.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set;}
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }

    }

    public class CommentDelta
    {
        public int PostDeltaId { get;set; }
        public int Sequence { get; set; }
        public DateTime UpdateDate { get; set; }
        public string OldText { get; set; }
        public string NewText { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }

    public class CommentReport
    {
        public int CommentReportId { get; set; }
        public string Reason { get; set; }
        public DateTime ReportDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}