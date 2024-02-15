using Disco.Domain.Data.Seeds;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Disco.Domain.EF
{
    public class ApiDbContext : IdentityDbContext<User,Role,int>, IDesignTimeDbContextFactory<ApiDbContext>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostSong> PostSongs { get; set; }
        public DbSet<PostVideo> PostVideos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryImage> StoryImages { get; set; }
        public DbSet<StoryVideo> StoryVideos { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketAccount> TicketAccounts { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<PostReating> PostReatings { get; set; }
        public DbSet<AccountReating> AccountReatings { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public ApiDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Account)
                .WithOne(u => u.User)
                .HasForeignKey<Account>(p => p.UserId);

            modelBuilder.Entity<UserFollower>(builder =>
            {
                builder.HasOne(u => u.FollowerAccount)
                    .WithMany(f => f.Following)
                    .HasForeignKey(f => f.FollowerAccountId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(f => f.FollowingAccount)
                    .WithMany(f => f.Followers)
                    .HasForeignKey(f => f.FollowingAccountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Account)
                .WithMany(a => a.Likes)
                .HasForeignKey(f => f.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Comment>()
                .HasOne(s => s.Account)
                .WithMany(c => c.Comments)
                .HasForeignKey(f => f.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>()
                .HasOne(o => o.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(account => account.AccountStatus)
                .WithOne(a => a.Account)
                .HasForeignKey<AccountStatus>(accountStatus => accountStatus.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountGroups)
                .WithOne(g => g.Account)
                .HasForeignKey(g => g.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.AccountGroups)
                .WithOne(a => a.Group)
                .HasForeignKey(a => a.GroupId)
                .HasPrincipalKey(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Group)
                .WithMany(g => g.Messages)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Messages)
                .WithOne(m => m.Account)
                .HasForeignKey(m => m.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Account)
                .WithMany(a => a.Messages)
                .HasForeignKey(m => m.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.AccountGroups)
                .WithOne(g => g.Group)
                .HasForeignKey(g => g.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Group>()
                .HasMany(m => m.Messages)
                .WithOne(g => g.Group)
                .HasForeignKey(g => g.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Notifications)
                .WithOne(m => m.Account)
                .HasForeignKey(m => m.AccountId) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasMany(x => x.CreatedTickets)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Account>()
                .HasMany(x => x.TicketAccounts)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TicketAccount>()
                .HasOne(x => x.Account)
                .WithMany(x => x.TicketAccounts)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasMany(x => x.TicketMessages)
                .WithOne(x => x.Ticket)
                .HasForeignKey(x => x.TicketId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Account>()
                .HasMany(x => x.TicketMessages)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostReating>()
                .HasOne(x => x.Post)
                .WithMany(x => x.PostReating)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PostReating>()
                .HasOne(x => x.Account)
                .WithMany(x => x.PostReatings)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AccountReating>()
                .HasOne(x => x.Account)
                .WithMany(x => x.AccountReatings)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Account>()
            //    .HasMany(x => x.RecommendedToFollow)
            //    .WithOne(x => x.Account)
            //    .HasForeignKey(x => x.AccountId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<AccountReating>()
            //    .HasOne(x => x.AccountRecommended)
            //    .WithMany(x => x.AccountReatings)
            //    .HasForeignKey(x => x.AccountRecommendedId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Account>()
            //    .HasMany(x => x.AccountReatings)
            //    .WithOne(x => x.AccountRecommended)
            //    .HasForeignKey(x => x.AccountRecommendedId)
            //    .OnDelete(DeleteBehavior.Restrict);

            AddSeeds(modelBuilder, this);
        }

        private void AddSeeds(ModelBuilder modelBuilder, ApiDbContext context)
        {
            RoleSeed.AddRoleSeed(modelBuilder);
            StatusSeed.AddStatusSeed(modelBuilder);
            TicketStatusSeed.AddTicketStatusSeed(modelBuilder);
            TicketPrioritySeed.AddTicketPrioritySeed(modelBuilder);
        }

        public ApiDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApiDbContext> optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            var options = optionsBuilder
                .UseSqlServer("Server=tcp:disco-dev-sql-srv.database.windows.net,1433;Initial Catalog=disco-dev-sql-db;Persist Security Info=False;User ID=disco-dev-sa;Password=StasZeus2021!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;").Options;

            return new ApiDbContext(options);
        }
    }
}
