using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Disco.DAL.EF
{
    public class ApiDbContext : IdentityDbContext<User,Role,int>, IDesignTimeDbContextFactory<ApiDbContext>
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostSong> PostSongs { get; set; }
        public DbSet<PostVideo> PostVideos { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryImage> StoriesImages { get; set; }
        public DbSet<StoryVideo> StoryVideos { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public ApiDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(u => u.User)
                .HasForeignKey<Profile>(p => p.UserId);
            builder.Entity<Profile>()
                .HasMany(f => f.Friends)
                .WithOne(p => p.UserProfile)
                .HasForeignKey(f => f.UserProfileId);

            //builder.Entity<Story>()
            //    .HasMany(s => s.StoryImages)
            //    .WithOne(s => s.Story)
            //    .HasForeignKey(s => s.StoryId);

            //builder.Entity<Story>()
            //    .HasMany(v => v.StoryVideos)
            //    .WithOne(s => s.Story)
            //    .HasForeignKey(s => s.StoryId);
        }

        public ApiDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApiDbContext>();
            builder.UseSqlServer("Server=tcp:disco-dev-sql-srv.database.windows.net,1433;Initial Catalog=disco-dev-sql-db;Persist Security Info=False;User ID=discosa;Password=cJM23H87;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApiDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new ApiDbContext(builder.Options);
        }
    }
}
