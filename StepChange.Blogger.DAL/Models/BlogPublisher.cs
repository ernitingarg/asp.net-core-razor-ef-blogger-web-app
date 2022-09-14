using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace StepChange.Blogger.DAL.Models
{
    [Table("BlogPublishers")]
    public class BlogPublisher
    {
        /// <summary>
        /// Unique publisher id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Publisher name
        /// Max 20 characters are allowed.
        /// </summary>
        [Required]
        [StringLength(20,
            ErrorMessage = "Publisher name can not be more than 20 characters.")]
        public string Publisher { get; set; }

        /// <summary>
        /// Hash of plain password using <see cref="DbUtils.GetHashPassword"/>
        /// </summary>
        [Required]
        [JsonIgnore]
        public string HashPassword { get; set; }

        /// <summary>
        /// Role of the publisher
        /// </summary>
        public Role Role { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }

        [ForeignKey(nameof(Role))]
        public PublisherRole PublisherRole { get; set; }
    }
}
