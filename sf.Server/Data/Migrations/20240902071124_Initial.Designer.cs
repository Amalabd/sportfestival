﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sf.Server.Data.Sf;

#nullable disable

namespace sf.Server.Data.Migrations
{
    [DbContext(typeof(SfContext))]
    [Migration("20240902071124_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DisciplineStudent", b =>
                {
                    b.Property<Guid>("DisciplinesId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("char(36)");

                    b.HasKey("DisciplinesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("DisciplineStudent");
                });

            modelBuilder.Entity("sf.Server.Models.Auth.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("LastName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoleString")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<string>("RoleString").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("sf.Server.Models.Core.Entity<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<DateTime>("CreatedAt"));

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Entity<Guid>");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("sf.Server.Models.SF.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("DisciplineId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<double>("Score")
                        .HasColumnType("double");

                    b.Property<Guid?>("StudentId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("StudentId");

                    b.ToTable("Entries", (string)null);
                });

            modelBuilder.Entity("sf.Server.Models.SF.CampaignJudge", b =>
                {
                    b.HasBaseType("sf.Server.Models.Auth.User");

                    b.Property<Guid?>("DisciplineId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("char(36)");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("SchoolId");

                    b.HasDiscriminator().HasValue("CampaignJudge");
                });

            modelBuilder.Entity("sf.Server.Models.SF.CampaignManager", b =>
                {
                    b.HasBaseType("sf.Server.Models.Auth.User");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("char(36)");

                    b.HasIndex("SchoolId");

                    b.ToTable("Users", t =>
                        {
                            t.Property("SchoolId")
                                .HasColumnName("CampaignManager_SchoolId");
                        });

                    b.HasDiscriminator().HasValue("CampaignManager");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Student", b =>
                {
                    b.HasBaseType("sf.Server.Models.Auth.User");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("char(36)");

                    b.HasIndex("ClassId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Users", t =>
                        {
                            t.Property("SchoolId")
                                .HasColumnName("Student_SchoolId");
                        });

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Tutor", b =>
                {
                    b.HasBaseType("sf.Server.Models.Auth.User");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("char(36)");

                    b.HasIndex("SchoolId");

                    b.ToTable("Users", t =>
                        {
                            t.Property("ClassId")
                                .HasColumnName("Tutor_ClassId");

                            t.Property("SchoolId")
                                .HasColumnName("Tutor_SchoolId");
                        });

                    b.HasDiscriminator().HasValue("Tutor");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Class", b =>
                {
                    b.HasBaseType("sf.Server.Models.Core.Entity<System.Guid>");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<Guid?>("TutorId")
                        .HasColumnType("char(36)");

                    b.HasIndex("LocationId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("ShortName")
                        .IsUnique();

                    b.HasIndex("TutorId")
                        .IsUnique();

                    b.ToTable("Classes", (string)null);
                });

            modelBuilder.Entity("sf.Server.Models.SF.Discipline", b =>
                {
                    b.HasBaseType("sf.Server.Models.Core.Entity<System.Guid>");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<Guid?>("JudgeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasIndex("JudgeId")
                        .IsUnique();

                    b.HasIndex("LocationId");

                    b.HasIndex("ShortName")
                        .IsUnique();

                    b.ToTable("Disciplines", (string)null);
                });

            modelBuilder.Entity("sf.Server.Models.SF.Location", b =>
                {
                    b.HasBaseType("sf.Server.Models.Core.Entity<System.Guid>");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasIndex("ShortName")
                        .IsUnique();

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("sf.Server.Models.SF.School", b =>
                {
                    b.HasBaseType("sf.Server.Models.Core.Entity<System.Guid>");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.ToTable("Schools", (string)null);
                });

            modelBuilder.Entity("DisciplineStudent", b =>
                {
                    b.HasOne("sf.Server.Models.SF.Discipline", null)
                        .WithMany()
                        .HasForeignKey("DisciplinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf.Server.Models.SF.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sf.Server.Models.SF.Entry", b =>
                {
                    b.HasOne("sf.Server.Models.SF.Discipline", "Discipline")
                        .WithMany("Entries")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf.Server.Models.SF.Student", "Student")
                        .WithMany("Entries")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("sf.Server.Models.SF.CampaignJudge", b =>
                {
                    b.HasOne("sf.Server.Models.SF.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId");

                    b.HasOne("sf.Server.Models.SF.School", "School")
                        .WithMany("Judges")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("School");
                });

            modelBuilder.Entity("sf.Server.Models.SF.CampaignManager", b =>
                {
                    b.HasOne("sf.Server.Models.SF.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Student", b =>
                {
                    b.HasOne("sf.Server.Models.SF.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");

                    b.HasOne("sf.Server.Models.SF.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("School");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Tutor", b =>
                {
                    b.HasOne("sf.Server.Models.SF.School", "School")
                        .WithMany("Tutors")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Class", b =>
                {
                    b.HasOne("sf.Server.Models.Core.Entity<System.Guid>", null)
                        .WithOne()
                        .HasForeignKey("sf.Server.Models.SF.Class", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf.Server.Models.SF.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("sf.Server.Models.SF.Location", "Room")
                        .WithMany("Classes")
                        .HasForeignKey("RoomId");

                    b.HasOne("sf.Server.Models.SF.School", "School")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolId");

                    b.HasOne("sf.Server.Models.SF.Tutor", "Tutor")
                        .WithOne("Class")
                        .HasForeignKey("sf.Server.Models.SF.Class", "TutorId");

                    b.Navigation("Location");

                    b.Navigation("Room");

                    b.Navigation("School");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Discipline", b =>
                {
                    b.HasOne("sf.Server.Models.Core.Entity<System.Guid>", null)
                        .WithOne()
                        .HasForeignKey("sf.Server.Models.SF.Discipline", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf.Server.Models.SF.CampaignJudge", "Judge")
                        .WithOne()
                        .HasForeignKey("sf.Server.Models.SF.Discipline", "JudgeId");

                    b.HasOne("sf.Server.Models.SF.Location", "Location")
                        .WithMany("Disciplines")
                        .HasForeignKey("LocationId");

                    b.Navigation("Judge");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Location", b =>
                {
                    b.HasOne("sf.Server.Models.Core.Entity<System.Guid>", null)
                        .WithOne()
                        .HasForeignKey("sf.Server.Models.SF.Location", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sf.Server.Models.SF.School", b =>
                {
                    b.HasOne("sf.Server.Models.Core.Entity<System.Guid>", null)
                        .WithOne()
                        .HasForeignKey("sf.Server.Models.SF.School", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sf.Server.Models.SF.CampaignManager", "Manager")
                        .WithOne()
                        .HasForeignKey("sf.Server.Models.SF.School", "ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Student", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Tutor", b =>
                {
                    b.Navigation("Class");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Discipline", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("sf.Server.Models.SF.Location", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("sf.Server.Models.SF.School", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Judges");

                    b.Navigation("Students");

                    b.Navigation("Tutors");
                });
#pragma warning restore 612, 618
        }
    }
}
