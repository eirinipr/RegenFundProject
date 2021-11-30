﻿// <auto-generated />
using System;
using FundProjects.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FundProjects.Migrations
{
    [DbContext(typeof(FundContext))]
    [Migration("20211127184612_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FundProjects.Model.Backer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Backer");
                });

            modelBuilder.Entity("FundProjects.Model.BackerProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BackerId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BackerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("BackerProject");
                });

            modelBuilder.Entity("FundProjects.Model.FundPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PackagePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Reward")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("FundPackage");
                });

            modelBuilder.Entity("FundProjects.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Goal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GoalGained")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProjectCreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectCreatorId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("FundProjects.Model.ProjectCreator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProjectCreator");
                });

            modelBuilder.Entity("FundProjects.Model.BackerProject", b =>
                {
                    b.HasOne("FundProjects.Model.Backer", "Backer")
                        .WithMany("BackerProjects")
                        .HasForeignKey("BackerId");

                    b.HasOne("FundProjects.Model.Project", "Project")
                        .WithMany("BackerProjects")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Backer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("FundProjects.Model.FundPackage", b =>
                {
                    b.HasOne("FundProjects.Model.Project", null)
                        .WithMany("FundPackages")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("FundProjects.Model.Project", b =>
                {
                    b.HasOne("FundProjects.Model.ProjectCreator", null)
                        .WithMany("Projects")
                        .HasForeignKey("ProjectCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FundProjects.Model.Backer", b =>
                {
                    b.Navigation("BackerProjects");
                });

            modelBuilder.Entity("FundProjects.Model.Project", b =>
                {
                    b.Navigation("BackerProjects");

                    b.Navigation("FundPackages");
                });

            modelBuilder.Entity("FundProjects.Model.ProjectCreator", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
