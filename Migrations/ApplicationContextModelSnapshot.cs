﻿// <auto-generated />
using System;
using AllInOne.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AllInOne.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AllInOne.Data.Entity.Accounting.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("InitialAmount");

                    b.Property<bool>("IsCredit");

                    b.Property<bool>("IsDebit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("OveralTotal");

                    b.Property<long?>("ParentAccountId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Account","Accounting");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Accounting.Plan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartDate");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Plane","Accounting");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Accounting.PlanDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Achieve");

                    b.Property<bool>("AllowOveral");

                    b.Property<double>("Amount");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("PlanId");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("PlanDetail","Accounting");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Accounting.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<long?>("DestinationAccountId");

                    b.Property<long?>("PlanDetailId");

                    b.Property<long?>("SourceAccountId");

                    b.Property<int>("Type");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DestinationAccountId");

                    b.HasIndex("PlanDetailId");

                    b.HasIndex("SourceAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Transaction","Accounting");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.LeitnerBox.Box", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Box","LeitnerBox");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.LeitnerBox.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BoxId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<byte>("FailCount");

                    b.Property<bool>("IsFinished");

                    b.Property<bool>("IsPending");

                    b.Property<byte>("MainStage");

                    b.Property<string>("Meaning")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte>("SubStage");

                    b.Property<string>("Vocabulary")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.ToTable("Question","LeitnerBox");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.LeitnerBox.QuestionHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<byte>("FromMainStage");

                    b.Property<byte>("FromSubStage");

                    b.Property<int>("HistoryActionType");

                    b.Property<long>("QuestionId");

                    b.Property<byte>("ToMainStage");

                    b.Property<byte>("ToSubStage");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionHistory","LeitnerBox");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Security.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasMaxLength(100);

                    b.Property<string>("Username")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("User","Security");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Todo.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Group","Todo");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Todo.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completed");

                    b.Property<DateTime?>("CompletedDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("ListId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.HasIndex("UserId");

                    b.ToTable("Item","Todo");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Todo.List", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("GroupId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("List","Todo");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Accounting.Account", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Accounting.Account", "ParentAccount")
                        .WithMany("ChildAccounts")
                        .HasForeignKey("ParentAccountId");

                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Accounting.Plan", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("Plans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Accounting.PlanDetail", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Accounting.Plan", "Plan")
                        .WithMany("PlanDetails")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Accounting.Transaction", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Accounting.Account", "DestinationAccount")
                        .WithMany()
                        .HasForeignKey("DestinationAccountId");

                    b.HasOne("AllInOne.Data.Entity.Accounting.PlanDetail", "PlanDetail")
                        .WithMany("Transactions")
                        .HasForeignKey("PlanDetailId");

                    b.HasOne("AllInOne.Data.Entity.Accounting.Account", "SourceAccount")
                        .WithMany()
                        .HasForeignKey("SourceAccountId");

                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.LeitnerBox.Box", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("Boxes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.LeitnerBox.Question", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.LeitnerBox.Box", "Box")
                        .WithMany("Questions")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.LeitnerBox.QuestionHistory", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.LeitnerBox.Question", "Question")
                        .WithMany("QuestionHistory")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Todo.Group", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Todo.Item", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Todo.List", "List")
                        .WithMany("Items")
                        .HasForeignKey("ListId");

                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("Items")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Todo.List", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Todo.Group", "Group")
                        .WithMany("Lists")
                        .HasForeignKey("GroupId");

                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("Lists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
