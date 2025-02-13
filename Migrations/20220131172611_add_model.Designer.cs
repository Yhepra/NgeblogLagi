﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NgeblogLagi.Data;

namespace NgeblogLagi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220131172611_add_model")]
    partial class add_model
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("NgeblogLagi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NgeblogLagi.Models.Post", b =>
                {
                    b.Property<string>("PostId")
                        .HasColumnType("varchar(767)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Create_Date")
                        .HasColumnType("datetime");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("Update_Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(767)");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Username");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("NgeblogLagi.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("NgeblogLagi.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Username");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NgeblogLagi.Models.Post", b =>
                {
                    b.HasOne("NgeblogLagi.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("NgeblogLagi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NgeblogLagi.Models.User", b =>
                {
                    b.HasOne("NgeblogLagi.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
