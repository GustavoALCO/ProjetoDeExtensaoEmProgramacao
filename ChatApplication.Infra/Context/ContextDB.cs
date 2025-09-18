using ChatApplication.Dommain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Infra.Context;

public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options) : base(options)
    {
    }

    public DbSet<Chat> Chat { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<UserFriend> UserFriend { get; set; }

    public DbSet<Mensage> Mensage { get; set; }

    public DbSet<MensageStatus> MensageStatus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>()
                .HasMany(c => c.Users);

        modelBuilder.Entity<Chat>()
                .HasMany(c => c.Mensages);
                

    }
}
