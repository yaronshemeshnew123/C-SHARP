using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{

    public class Forum
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public Guid ManagerID { set; get; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Post> MyPosts { set; get; }
        public virtual ApplicationUser MyManager { get; set; }

    }


    public class ForumConfiguration
    {
        public ForumConfiguration(EntityTypeBuilder<Forum> entityBuilder)
        {
            entityBuilder.HasMany(c => c.MyPosts)

            .WithOne(x => x.ForumPosts)
            .OnDelete(new DeleteBehavior())
            .HasForeignKey(x => x.ForumID);


        }
    }
}