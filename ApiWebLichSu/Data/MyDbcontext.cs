using ApiWebLichSu.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiWebLichSu.Data
{
    public class MyDbcontext : IdentityDbContext<ApplicationUser>
    {
        public MyDbcontext(DbContextOptions options) : base(options) { }

        #region Dbset

        public DbSet<Permission> Permission { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Catogery> Catogery { get; set; }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<Quest> Quest { get; set; }
        public DbSet<AnswerQuest> AnswerQuest { get; set; }
        public DbSet<Question> Question { get; set; }

        public DbSet<QuestCollection> QuestCollection { get; set; }
        public DbSet<ApplicationUser> Appuser { get;set; }
        public DbSet<ApplicationRoles> Roles { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            //table Permission
            modelBuilder.Entity<Permission>().ToTable("Permission").HasKey(e => e.PER_ID);
            modelBuilder.Entity<Permission>().Property(e => e.PER_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Permission>().Property(e => e.CONTENT_PERMISSION).HasMaxLength(10);
            modelBuilder.Entity<Permission>().HasOne(e => e.Users).WithMany(e => e.Permissions).HasForeignKey(e => e.ID_USER).OnDelete(DeleteBehavior.Cascade);
            //table History
            modelBuilder.Entity<History>().ToTable("History").HasKey(e => e.ID_HISTORY);
            modelBuilder.Entity<History>().Property(e => e.ID_HISTORY).ValueGeneratedOnAdd();
            modelBuilder.Entity<History>().Property(e => e.DATESUBMIT).HasMaxLength(100);
            modelBuilder.Entity<History>().Property(e => e.CONTENT).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<History>().Property(e => e.TITLE).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<History>().HasOne(e => e.CATOGERY).WithMany(e => e.HISTORY).HasForeignKey(e => e.ID_CATOGERY).OnDelete(DeleteBehavior.Cascade); ;
            //table Catogery
            modelBuilder.Entity<Catogery>().ToTable("Catogery").HasKey(e => e.ID_CATOGERY);
            modelBuilder.Entity<Catogery>().Property(e => e.NAME_CATOGERY).HasMaxLength(100);
            //table comment
            modelBuilder.Entity<Comment>().ToTable("Comment").HasKey(e => e.COMNENT_ID);
            modelBuilder.Entity<Comment>().Property(e => e.CONTENT_COMMENT).HasMaxLength(int.MaxValue);
            //table quest 
            modelBuilder.Entity<Quest>().ToTable("Quest").HasKey(e => e.Id_quest);
            modelBuilder.Entity<Quest>().Property(e => e.Id_quest).ValueGeneratedOnAdd();
            modelBuilder.Entity<Quest>().Property(e => e.Question).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Quest>().HasOne(e => e.questCollection).WithMany(e => e.Quests).HasForeignKey(e => e.id_questcollection).OnDelete(DeleteBehavior.Restrict);
            // table Question
            modelBuilder.Entity<Question>().ToTable("Question").HasKey(e => e.Id_Question);
            modelBuilder.Entity<Question>().Property(e => e.Id_Question).ValueGeneratedOnAdd();
            modelBuilder.Entity<Question>().Property(e => e.Question_quest).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Question>().HasOne(e => e.Quest).WithMany(e => e.Questions).HasForeignKey(e => e.Id_quest).OnDelete(DeleteBehavior.Restrict);
            // table answerquest
            modelBuilder.Entity<AnswerQuest>().ToTable("AnswerQuest").HasKey(e => e.id_Answer);
            modelBuilder.Entity<AnswerQuest>().Property(e => e.id_Answer).ValueGeneratedOnAdd();
            modelBuilder.Entity<AnswerQuest>().Property(e => e.answer).HasMaxLength(int.MaxValue);
           // modelBuilder.Entity<AnswerQuest>().HasOne(aq => aq.quest).WithOne(q => q.Answer).HasForeignKey<AnswerQuest>(q => q.Id_quest).OnDelete(DeleteBehavior.Restrict);
            // table questcollection
            modelBuilder.Entity<QuestCollection>().ToTable("QuestCollection").HasKey(e => e.id_questcollection);
            modelBuilder.Entity<QuestCollection>().Property(e => e.id_questcollection).ValueGeneratedOnAdd();
            modelBuilder.Entity<QuestCollection>().Property(e => e.title_collection).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<QuestCollection>().Property(e => e.image_quest).HasMaxLength(int.MaxValue);
           
        }
    }
}
