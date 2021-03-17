using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Sound> Sounds { get; set; }
        public ApplicationDbContext(DbContextOptions option) : base(option) { }
    }
}
