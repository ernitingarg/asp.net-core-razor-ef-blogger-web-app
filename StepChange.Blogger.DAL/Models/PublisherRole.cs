using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StepChange.Blogger.DAL.Models
{
    [Table("PublisherRoles")]
    public class PublisherRole
    {
        /// <summary>
        /// A enum string which represents the role <see cref="Role"/>
        /// </summary>
        [Key]
        public Role Id { get; set; }

        /// <summary>
        /// A description of the role
        /// What the role allows to do.
        /// </summary>
        public string Description { get; set; }

        public ICollection<BlogPublisher> BlogPublishers { get; set; }
    }

    public enum Role
    {
        [Description("Can create and edit all blog posts.")]
        Admin,
        [Description("Can create, edit and delete all blog posts.")]
        SuperAdmin
    }
}
