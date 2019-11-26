﻿// <auto-generated />
using System;
using AllInOne.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AllInOne.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20191125190835_add movie collectino - fix schema")]
    partial class addmoviecollectinofixschema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("AllInOne.Data.Entity.Bot.TelegramUser", b =>
                {
                    b.Property<long>("Id");

                    b.Property<long>("ChatId");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("LanguageCode")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<long?>("UserId");

                    b.Property<string>("Username")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TelegramUser","Bot");
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

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.Cast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Cast","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Country","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Genre","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.Language", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Language","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Awards")
                        .HasMaxLength(200);

                    b.Property<string>("BoxOffice")
                        .HasMaxLength(20);

                    b.Property<string>("DvdReleaseDate")
                        .HasMaxLength(20);

                    b.Property<string>("ImdbId")
                        .HasMaxLength(20);

                    b.Property<string>("ImdbRating")
                        .HasMaxLength(50);

                    b.Property<string>("ImdbVotes")
                        .HasMaxLength(50);

                    b.Property<string>("LocalPath")
                        .HasMaxLength(300);

                    b.Property<string>("Metascore")
                        .HasMaxLength(50);

                    b.Property<string>("Plot")
                        .HasMaxLength(1000);

                    b.Property<string>("Poster")
                        .HasMaxLength(300);

                    b.Property<string>("Production")
                        .HasMaxLength(50);

                    b.Property<string>("Rated")
                        .HasMaxLength(20);

                    b.Property<string>("Released")
                        .HasMaxLength(20);

                    b.Property<bool>("Seen");

                    b.Property<string>("SeriesId")
                        .HasMaxLength(20);

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.Property<string>("TotalSeasons")
                        .HasMaxLength(10);

                    b.Property<int>("Type");

                    b.Property<long>("UserId");

                    b.Property<string>("Website")
                        .HasMaxLength(100);

                    b.Property<string>("Year")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movie","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieCast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CastId");

                    b.Property<int>("CastType");

                    b.Property<long>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("CastId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCast","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieCollection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MovieCollection","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieCollectionDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MovieCollectionId");

                    b.Property<long>("MovieId");

                    b.Property<byte>("Number");

                    b.HasKey("Id");

                    b.HasIndex("MovieCollectionId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCollectionDetail","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieCountry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CountryId");

                    b.Property<long>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCountry","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieGenre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GenreId");

                    b.Property<long>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenre","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieLanguage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LanguageId");

                    b.Property<long>("MovieId");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieLanguage","Movie");
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.Rating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MovieId");

                    b.Property<string>("SourceName")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Rating","Movie");
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

            modelBuilder.Entity("AllInOne.Data.Entity.Bot.TelegramUser", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("TelegramUsers")
                        .HasForeignKey("UserId");
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

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.Movie", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Security.User", "User")
                        .WithMany("Movies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieCast", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Moive.Cast", "Cast")
                        .WithMany("MovieCasts")
                        .HasForeignKey("CastId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AllInOne.Data.Entity.Moive.Movie", "Movie")
                        .WithMany("MovieCasts")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieCollectionDetail", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Moive.MovieCollection", "MovieCollection")
                        .WithMany("MovieCollectionDetails")
                        .HasForeignKey("MovieCollectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AllInOne.Data.Entity.Moive.Movie", "Movie")
                        .WithMany("MovieCollectionDetails")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieCountry", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Moive.Country", "Country")
                        .WithMany("MovieCountries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AllInOne.Data.Entity.Moive.Movie", "Movie")
                        .WithMany("MovieCountries")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieGenre", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Moive.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AllInOne.Data.Entity.Moive.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.MovieLanguage", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Moive.Language", "Language")
                        .WithMany("MovieLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AllInOne.Data.Entity.Moive.Movie", "Movie")
                        .WithMany("MovieLanguages")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AllInOne.Data.Entity.Moive.Rating", b =>
                {
                    b.HasOne("AllInOne.Data.Entity.Moive.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
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
