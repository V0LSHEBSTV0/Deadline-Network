﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.App.Db.Contexts;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Server.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("disciplines_pkey");

                    b.HasIndex("GroupId");

                    b.ToTable("disciplines", (string)null);
                });

            modelBuilder.Entity("Server.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.HasKey("Id")
                        .HasName("groups_pkey");

                    b.ToTable("groups", (string)null);
                });

            modelBuilder.Entity("Server.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deadline");

                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("discipline_id");

                    b.Property<int>("WhoAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("who_added");

                    b.HasKey("Id")
                        .HasName("tasks_pkey");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("WhoAdded");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("Server.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("users_pkey");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Server.UserCredential", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login_hash");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.HasKey("UserId")
                        .HasName("user_credentials_pkey");

                    b.ToTable("user_credentials", (string)null);
                });

            modelBuilder.Entity("Server.UserGroup", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<bool>("IsOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_owner");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("user_group", (string)null);
                });

            modelBuilder.Entity("Server.Discipline", b =>
                {
                    b.HasOne("Server.Group", "Group")
                        .WithMany("Disciplines")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("disciplines_group_id_fkey");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Server.Task", b =>
                {
                    b.HasOne("Server.Discipline", "Discipline")
                        .WithMany("Tasks")
                        .HasForeignKey("DisciplineId")
                        .IsRequired()
                        .HasConstraintName("tasks_discipline_id_fkey");

                    b.HasOne("Server.User", "WhoAddedNavigation")
                        .WithMany("Tasks")
                        .HasForeignKey("WhoAdded")
                        .IsRequired()
                        .HasConstraintName("tasks_who_added_fkey");

                    b.Navigation("Discipline");

                    b.Navigation("WhoAddedNavigation");
                });

            modelBuilder.Entity("Server.UserCredential", b =>
                {
                    b.HasOne("Server.User", "User")
                        .WithOne("UserCredential")
                        .HasForeignKey("Server.UserCredential", "UserId")
                        .IsRequired()
                        .HasConstraintName("user_credentials_user_id_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.UserGroup", b =>
                {
                    b.HasOne("Server.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("user_group_group_id_fkey");

                    b.HasOne("Server.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("user_group_user_id_fkey");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.Discipline", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Server.Group", b =>
                {
                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("Server.User", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("UserCredential");
                });
#pragma warning restore 612, 618
        }
    }
}
