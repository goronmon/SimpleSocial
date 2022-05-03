using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSocial.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set;}
        public bool IsDeleted { get; set; } = false;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastModifiedDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        
        [ForeignKey("Comment")]
        public int ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }

        public List<Comment> Comments { get; set; }
    }

    public class CommentDelta
    {
        public int PostDeltaId { get;set; }
        [Required]
        public int Sequence { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UpdateDate { get; set; }
        public string OldText { get; set; }
        public string NewText { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }

    public class CommentReport
    {
        public int CommentReportId { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ReportDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}