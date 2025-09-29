using ChatApplication.Dommain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Infra.Context;

public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options) : base(options)
    {
    }

    public DbSet<Chat> Chat { get; set; }

    public DbSet<ChatUsers> chatUsers { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<UserFriend> UserFriend { get; set; }

    public DbSet<Mensage> Mensage { get; set; }

    public DbSet<MensageStatus> MensageStatus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ChatUsers>()
       .HasKey(cu => new { cu.ChatId, cu.UserId });

        modelBuilder.Entity<ChatUsers>()
            .HasOne(cu => cu.Chat)
            .WithMany(c => c.ChatUsers)
            .HasForeignKey(cu => cu.ChatId);

        modelBuilder.Entity<ChatUsers>()
            .HasOne(cu => cu.User)
            .WithMany(u => u.ChatUsers)
            .HasForeignKey(cu => cu.UserId);
    }
}
