﻿// <auto-generated />
using System;
using ApiWebLichSu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    [DbContext(typeof(MyDbcontext))]
    [Migration("20240330082443_drop_column")]
    partial class drop_column
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiWebLichSu.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.AnswerQuest", b =>
                {
                    b.Property<int>("id_Answer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_Answer"), 1L, 1);

                    b.Property<int>("Id_quest")
                        .HasColumnType("int");

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_Answer");

                    b.HasIndex("Id_quest")
                        .IsUnique();

                    b.ToTable("AnswerQuest", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Catogery", b =>
                {
                    b.Property<int>("ID_CATOGERY")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_CATOGERY"), 1L, 1);

                    b.Property<string>("NAME_CATOGERY")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID_CATOGERY");

                    b.ToTable("Catogery", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Comment", b =>
                {
                    b.Property<int>("COMNENT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("COMNENT_ID"), 1L, 1);

                    b.Property<string>("CONTENT_COMMENT")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_USER")
                        .HasColumnType("int");

                    b.HasKey("COMNENT_ID");

                    b.HasIndex("ID_USER");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.History", b =>
                {
                    b.Property<int>("ID_HISTORY")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_HISTORY"), 1L, 1);

                    b.Property<string>("CONTENT")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DATESUBMIT")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_CATOGERY")
                        .HasColumnType("int");

                    b.Property<int>("ID_USER")
                        .HasColumnType("int");

                    b.Property<string>("TITLE")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_HISTORY");

                    b.HasIndex("ID_CATOGERY");

                    b.HasIndex("ID_USER");

                    b.ToTable("History", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Permission", b =>
                {
                    b.Property<int>("PER_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PER_ID"), 1L, 1);

                    b.Property<string>("CONTENT_PERMISSION")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ID_USER")
                        .HasColumnType("int");

                    b.HasKey("PER_ID");

                    b.HasIndex("ID_USER");

                    b.ToTable("Permission", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Quest", b =>
                {
                    b.Property<int>("Id_quest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_quest"), 1L, 1);

                    b.Property<int>("ID_USER")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_questcollection")
                        .HasColumnType("int");

                    b.HasKey("Id_quest");

                    b.HasIndex("ID_USER");

                    b.HasIndex("id_questcollection");

                    b.ToTable("Quest", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.QuestCollection", b =>
                {
                    b.Property<int>("id_questcollection")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_questcollection"), 1L, 1);

                    b.Property<string>("image_quest")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title_collection")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_questcollection");

                    b.ToTable("QuestCollection", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Question", b =>
                {
                    b.Property<int>("Id_Question")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Question"), 1L, 1);

                    b.Property<int>("AnswerQuestid_Answer")
                        .HasColumnType("int");

                    b.Property<int>("Id_quest")
                        .HasColumnType("int");

                    b.Property<string>("Question_quest")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_Answer")
                        .HasColumnType("int");

                    b.HasKey("Id_Question");

                    b.HasIndex("AnswerQuestid_Answer");

                    b.HasIndex("Id_quest");

                    b.ToTable("Question", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Users", b =>
                {
                    b.Property<int>("ID_USER")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_USER"), 1L, 1);

                    b.Property<string>("NAME_USER")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PASSWORD_USER")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("USERNAME")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID_USER");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ApiWebLichSu.Model.AnswerQuest", b =>
                {
                    b.HasOne("ApiWebLichSu.Model.Quest", "quest")
                        .WithOne("Answer")
                        .HasForeignKey("ApiWebLichSu.Model.AnswerQuest", "Id_quest")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("quest");
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Comment", b =>
                {
                    b.HasOne("ApiWebLichSu.Model.Users", "USER")
                        .WithMany("Comments")
                        .HasForeignKey("ID_USER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("USER");
                });

            modelBuilder.Entity("ApiWebLichSu.Model.History", b =>
                {
                    b.HasOne("ApiWebLichSu.Model.Catogery", "CATOGERY")
                        .WithMany("HISTORY")
                        .HasForeignKey("ID_CATOGERY")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiWebLichSu.Model.Users", "USERS")
                        .WithMany("Historys")
                        .HasForeignKey("ID_USER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CATOGERY");

                    b.Navigation("USERS");
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Permission", b =>
                {
                    b.HasOne("ApiWebLichSu.Model.Users", "Users")
                        .WithMany("Permissions")
                        .HasForeignKey("ID_USER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Quest", b =>
                {
                    b.HasOne("ApiWebLichSu.Model.Users", "Users")
                        .WithMany("quests")
                        .HasForeignKey("ID_USER")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiWebLichSu.Model.QuestCollection", "questCollection")
                        .WithMany("Quests")
                        .HasForeignKey("id_questcollection")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Users");

                    b.Navigation("questCollection");
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Question", b =>
                {
                    b.HasOne("ApiWebLichSu.Model.AnswerQuest", "AnswerQuest")
                        .WithMany()
                        .HasForeignKey("AnswerQuestid_Answer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiWebLichSu.Model.Quest", "Quest")
                        .WithMany("Questions")
                        .HasForeignKey("Id_quest")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AnswerQuest");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ApiWebLichSu.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ApiWebLichSu.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiWebLichSu.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ApiWebLichSu.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Catogery", b =>
                {
                    b.Navigation("HISTORY");
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Quest", b =>
                {
                    b.Navigation("Answer")
                        .IsRequired();

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ApiWebLichSu.Model.QuestCollection", b =>
                {
                    b.Navigation("Quests");
                });

            modelBuilder.Entity("ApiWebLichSu.Model.Users", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Historys");

                    b.Navigation("Permissions");

                    b.Navigation("quests");
                });
#pragma warning restore 612, 618
        }
    }
}
