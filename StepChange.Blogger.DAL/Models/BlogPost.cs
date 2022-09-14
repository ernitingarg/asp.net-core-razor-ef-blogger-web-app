using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StepChange.Blogger.DAL.Models
{
    [Table("BlogPosts")]
    public class BlogPost
    {
        /// <summary>
        /// Unique Blog Id for each post.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Title for the blog.
        /// Max 50 characters are allowed.
        /// </summary>
        [Required]
        [StringLength(50,
            ErrorMessage = "Blog title can not be more than 50 characters.")]
        public string Title { get; set; }

        /// <summary>
        /// Blog content, description, URL (free text).
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// Blog creation date.
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Blog modified date.
        /// </summary>
        public DateTime ModificationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Publisher id of the blog.
        /// </summary>
        public Guid PublisherId { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public BlogPublisher BlogPublisher { get; set; }
    }
}
