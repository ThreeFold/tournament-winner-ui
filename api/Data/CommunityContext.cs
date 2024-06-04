using Microsoft.EntityFrameworkCore;
using TournamentWinner.Api.Models;

namespace TournamentWinner.Api.Data
{
    public class CommunityContext : DbContext
    {
        public CommunityContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityGame> CommunityGames { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CommunityUser> CommunityUsers { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Community>().ToTable("communities")
                .Property(u => u.InsertDate)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Community>()
                .HasIndex(c => c.Name);
            modelBuilder.Entity<Community>()
                .HasIndex(c => c.Slug);
            modelBuilder.Entity<Community>().HasMany(e => e.CommunityGames)
                .WithOne(e => e.Community);
            modelBuilder.Entity<CommunityUser>()
                .ToTable("communityUsers")
                .Property(u => u.InsertDate)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<CommunityUser>()
                .HasOne(e => e.User)
                .WithMany(e => e.Communities)
                .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<CommunityUser>().HasOne(e => e.Community)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.CommunityId);

            modelBuilder.Entity<User>().ToTable("users")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>().ToTable("users")
            .Property(u => u.Id)
            .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<UserAuthMethod>().ToTable("userAuthMethods")
            .Property(u => u.Id)
            .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<Profile>().ToTable("profiles")
            .Property(p => p.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Profile>().ToTable("profiles")
            .Property(p => p.Id)
            .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<ProfileGame>().ToTable("userGames")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<ProfileGameCharacter>().ToTable("userCharacters")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Player>().ToTable("players")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Ranking>().ToTable("rankings")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Rank>().ToTable("ranks")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<CommunityGame>().ToTable("communityGames")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Bracket>().ToTable("brackets")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<GameSet>().ToTable("gameSets")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Game>().ToTable("games")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("character");
                entity.Property(u => u.InsertDate).HasDefaultValueSql("NOW()");
                entity.HasIndex(u => u.Name).IsUnique();
            });

            modelBuilder.Entity<CharacterGame>().ToTable("characterGame")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<League>().ToTable("leagues")
            .Property(u => u.InsertDate)
            .HasDefaultValueSql("NOW()");
        }
    }
}
