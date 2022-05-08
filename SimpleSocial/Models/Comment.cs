using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleSocial.Data;

namespace SimpleSocial.Models
{
    public class Comment : IDateCreateAndModified
    {
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set;}
        public bool IsDeleted { get; set; } = false;
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int? PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey("Comment")]
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }

        public List<Comment> Comments { get; set; }
    }

    public class CommentDelta
    {
        public int CommendDeltaId { get;set; }
        [Required]
        public int Sequence { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        public string OldText { get; set; }
        public string NewText { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User? User { get; set; }
    }

    public class CommentReport
    {
        public int CommentReportId { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
    }
}