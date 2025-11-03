using ChatApplication.Dommain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

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
        // Definindo a chave primária composta para a entidade MensageStatus
        modelBuilder.Entity<MensageStatus>()
            .HasKey(ms => new { ms.MensageID, ms.UserId });

        // Definindo o relacionamento entre MensageStatus e Mensage
        modelBuilder.Entity<MensageStatus>()
            .HasOne<Mensage>()
            .WithMany()
            .HasForeignKey(ms => ms.MensageID)
            .OnDelete(DeleteBehavior.Restrict);

        // Definindo o relacionamento entre MensageStatus e User
        modelBuilder.Entity<MensageStatus>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(ms => ms.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Definindo a chave primária composta para a entidade UserFriend
        modelBuilder.Entity<UserFriend>()
            .HasKey(cu => new { cu.UserId, cu.FriendId });

        // Definindo o relacionamento entre UserFriend e User para UserId
        modelBuilder.Entity<UserFriend>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(cu => cu.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Definindo o relacionamento entre UserFriend e User para FriendId
        modelBuilder.Entity<UserFriend>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(uf => uf.FriendId)
            .OnDelete(DeleteBehavior.Restrict);

        // Definindo a chave primária composta para a entidade ChatUsers
        modelBuilder.Entity<ChatUsers>()
       .HasKey(cu => new { cu.ChatId, cu.UserId });

        // Definindo o a ChatID como uma chave estrangeira 
        modelBuilder.Entity<ChatUsers>()
            .HasOne(cu => cu.Chat)
            .WithMany(c => c.ChatUsers)
            .HasForeignKey(cu => cu.ChatId);

        // Definindo o a UserID como uma chave estrangeira
        modelBuilder.Entity<ChatUsers>()
            .HasOne(cu => cu.User)
            .WithMany(u => u.ChatUsers)
            .HasForeignKey(cu => cu.UserId);
    }
}
