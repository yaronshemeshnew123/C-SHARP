using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        //add more prop...

        public virtual ICollection<Forum> MyForums { set; get; }
        public virtual ICollection<Post> MyPosts { set; get; }
    }

    public class ApplicationUserConfiguration
    {
        public ApplicationUserConfiguration(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            //entityBuilder.ToTable("ForumSet");
            //entityBuilder.HasKey(c => c.Id);
            //entityBuilder.Property(c => c.Id).HasColumnName("Id");
            //entityBuilder.Property(c => c.Name)
            //.HasColumnName("Name")
            //.IsRequired()
            //.HasMaxLength(200);
            //entityBuilder.HasAlternateKey(x => x.Name);
            //entityBuilder.HasMany(c => c.MyPosts)
            //.WithOne(x => x.MyPublisher)
            //.OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasMany(c => c.MyForums)
            .WithOne(x => x.MyManager)
            .HasForeignKey(x=>x.ManagerID);

            entityBuilder.HasMany(u => u.MyPosts)
            .WithOne(p => p.MyPublisher)
            .OnDelete(new DeleteBehavior())
            .HasForeignKey(p => p.PublisherID);
        }
    }

}
