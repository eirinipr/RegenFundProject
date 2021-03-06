// <auto-generated />
using System;
using FundProjectAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FundProjectAPI.Migrations
{
    [DbContext(typeof(FundContext))]
    [Migration("20211208213831_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackerProject", b =>
                {
                    b.Property<int>("BackersId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("BackersId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("BackerProject");
                });

            modelBuilder.Entity("FundProjectAPI.Model.Backer", b =>
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

            modelBuilder.Entity("FundProjectAPI.Model.Project", b =>
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

                    b.Property<int?>("ProjectCreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectCreatorId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("FundProjectAPI.Model.ProjectCreator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("ProjectCreator");
                });

            modelBuilder.Entity("FundProjectAPI.Model.RewardPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FundAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Reward")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RewardPackage");
                });

            modelBuilder.Entity("ProjectRewardPackage", b =>
                {
                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<int>("RewardPackagesId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsId", "RewardPackagesId");

                    b.HasIndex("RewardPackagesId");

                    b.ToTable("ProjectRewardPackage");
                });

            modelBuilder.Entity("BackerProject", b =>
                {
                    b.HasOne("FundProjectAPI.Model.Backer", null)
                        .WithMany()
                        .HasForeignKey("BackersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FundProjectAPI.Model.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FundProjectAPI.Model.Project", b =>
                {
                    b.HasOne("FundProjectAPI.Model.ProjectCreator", "ProjectCreator")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectCreatorId");

                    b.Navigation("ProjectCreator");
                });

            modelBuilder.Entity("ProjectRewardPackage", b =>
                {
                    b.HasOne("FundProjectAPI.Model.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FundProjectAPI.Model.RewardPackage", null)
                        .WithMany()
                        .HasForeignKey("RewardPackagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FundProjectAPI.Model.ProjectCreator", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
