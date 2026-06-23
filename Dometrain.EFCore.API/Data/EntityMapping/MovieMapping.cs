using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dometrain.EFCore.API.Data.EntityMapping;

public class MovieMapping : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Pictures").HasKey(movie => movie.Identifier);

        builder
            .Property(movie => movie.Title)
            .HasColumnType("varchar")
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(movie => movie.ReleaseDate)
            .HasColumnType("char(8)")
            .HasConversion(new DateTimeToChar8Converter());

        builder
            .Property(movie => movie.Synopsis)
            .HasColumnType("varchar(max)")
            .HasColumnName("Plot");

        builder
            .HasOne(movie => movie.Genre)
            .WithMany(genre => genre.Movies)
            .HasPrincipalKey(genre => genre.Id)
            .HasForeignKey(movie => movie.MainGenreId);

        builder.OwnsOne(movie => movie.Director).ToTable("Movie_Directors");

        builder.OwnsMany(movie => movie.Actors).ToTable("Movie_Actors");

        builder.HasData(
            new Movie
            {
                Identifier = 1,
                Title = "Fight Club",
                ReleaseDate = new DateTime(1999, 9, 10),
                Synopsis = "Ed Norton and Brad Pitt have a couple of fist fights with each other.",
                MainGenreId = 2,
                AgeRating = AgeRating.Adolescent,
            },
            new Movie
            {
                Identifier = 2,
                Title = "The Matrix",
                ReleaseDate = new DateTime(1999, 3, 31),
                Synopsis =
                    "Keanu Reeves chooses the red pill, learns kung fu from a screensaver, and dodges bullets because he forgot gravity exists.",
                MainGenreId = 5,
                AgeRating = AgeRating.Adolescent,
            },
            new Movie
            {
                Identifier = 3,
                Title = "Titanic",
                ReleaseDate = new DateTime(1997, 12, 19),
                Synopsis =
                    "Jack and Rose fall in love on a boat that was definitely not built by the lowest bidder. Spoiler: the iceberg wins.",
                MainGenreId = 6,
                AgeRating = AgeRating.HighSchool,
            },
            new Movie
            {
                Identifier = 4,
                Title = "Jurassic Park",
                ReleaseDate = new DateTime(1993, 6, 11),
                Synopsis =
                    "A billionaire opens a zoo with no fences, no backup power plan, and a lawyer who walks too slowly. Dinosaurs file a complaint.",
                MainGenreId = 4,
                AgeRating = AgeRating.HighSchool,
            },
            new Movie
            {
                Identifier = 5,
                Title = "Shrek",
                ReleaseDate = new DateTime(2001, 5, 18),
                Synopsis =
                    "An ogre just wants privacy. A donkey won't stop talking. The princess is also an ogre and somehow that's the plot twist.",
                MainGenreId = 8,
                AgeRating = AgeRating.ElementarySchool,
            },
            new Movie
            {
                Identifier = 6,
                Title = "The Godfather",
                ReleaseDate = new DateTime(1972, 3, 24),
                Synopsis =
                    "A man attends his daughter's wedding and spends the rest of the film making offers people can't refuse, including to a horse.",
                MainGenreId = 3,
                AgeRating = AgeRating.Adult,
            },
            new Movie
            {
                Identifier = 7,
                Title = "Inception",
                ReleaseDate = new DateTime(2010, 7, 16),
                Synopsis =
                    "Leonardo DiCaprio naps on the job so hard he dreams inside a dream inside a dream and still can't spin a top properly.",
                MainGenreId = 7,
                AgeRating = AgeRating.Adolescent,
            },
            new Movie
            {
                Identifier = 8,
                Title = "Jaws",
                ReleaseDate = new DateTime(1975, 6, 20),
                Synopsis =
                    "A shark eats tourists while the mayor insists the beach is safe because bad Yelp reviews hurt the local economy.",
                MainGenreId = 4,
                AgeRating = AgeRating.HighSchool,
            },
            new Movie
            {
                Identifier = 9,
                Title = "Frozen",
                ReleaseDate = new DateTime(2013, 11, 27),
                Synopsis =
                    "A princess with ice powers runs away and builds a castle because her sister kept borrowing her stuff without asking.",
                MainGenreId = 8,
                AgeRating = AgeRating.ElementarySchool,
            },
            new Movie
            {
                Identifier = 10,
                Title = "Star Wars",
                ReleaseDate = new DateTime(1977, 5, 25),
                Synopsis =
                    "A farm boy whines about sand, trusts a wizard, and blows up a planet-sized weapon because he got lucky with a torpedo.",
                MainGenreId = 5,
                AgeRating = AgeRating.ElementarySchool,
            }
        );

        builder
            .OwnsOne(movie => movie.Director)
            .HasData(
                new
                {
                    MovieIdentifier = 1,
                    FirstName = "David",
                    LastName = "Fincher",
                },
                new
                {
                    MovieIdentifier = 2,
                    FirstName = "Lana",
                    LastName = "Wachowski",
                },
                new
                {
                    MovieIdentifier = 3,
                    FirstName = "James",
                    LastName = "Cameron",
                },
                new
                {
                    MovieIdentifier = 4,
                    FirstName = "Steven",
                    LastName = "Spielberg",
                },
                new
                {
                    MovieIdentifier = 5,
                    FirstName = "Andrew",
                    LastName = "Adamson",
                },
                new
                {
                    MovieIdentifier = 6,
                    FirstName = "Francis Ford",
                    LastName = "Coppola",
                },
                new
                {
                    MovieIdentifier = 7,
                    FirstName = "Christopher",
                    LastName = "Nolan",
                },
                new
                {
                    MovieIdentifier = 8,
                    FirstName = "Steven",
                    LastName = "Spielberg",
                },
                new
                {
                    MovieIdentifier = 9,
                    FirstName = "Chris",
                    LastName = "Buck",
                },
                new
                {
                    MovieIdentifier = 10,
                    FirstName = "George",
                    LastName = "Lucas",
                }
            );

        builder
            .OwnsMany(movie => movie.Actors)
            .HasData(
                new
                {
                    MovieIdentifier = 1,
                    Id = 1,
                    FirstName = "Edward",
                    LastName = "Norton",
                },
                new
                {
                    MovieIdentifier = 1,
                    Id = 2,
                    FirstName = "Brad",
                    LastName = "Pitt",
                },
                new
                {
                    MovieIdentifier = 2,
                    Id = 1,
                    FirstName = "Keanu",
                    LastName = "Reeves",
                },
                new
                {
                    MovieIdentifier = 2,
                    Id = 2,
                    FirstName = "Carrie-Anne",
                    LastName = "Moss",
                },
                new
                {
                    MovieIdentifier = 3,
                    Id = 1,
                    FirstName = "Leonardo",
                    LastName = "DiCaprio",
                },
                new
                {
                    MovieIdentifier = 3,
                    Id = 2,
                    FirstName = "Kate",
                    LastName = "Winslet",
                },
                new
                {
                    MovieIdentifier = 4,
                    Id = 1,
                    FirstName = "Sam",
                    LastName = "Neill",
                },
                new
                {
                    MovieIdentifier = 4,
                    Id = 2,
                    FirstName = "Laura",
                    LastName = "Dern",
                },
                new
                {
                    MovieIdentifier = 5,
                    Id = 1,
                    FirstName = "Mike",
                    LastName = "Myers",
                },
                new
                {
                    MovieIdentifier = 5,
                    Id = 2,
                    FirstName = "Eddie",
                    LastName = "Murphy",
                },
                new
                {
                    MovieIdentifier = 6,
                    Id = 1,
                    FirstName = "Marlon",
                    LastName = "Brando",
                },
                new
                {
                    MovieIdentifier = 6,
                    Id = 2,
                    FirstName = "Al",
                    LastName = "Pacino",
                },
                new
                {
                    MovieIdentifier = 7,
                    Id = 1,
                    FirstName = "Leonardo",
                    LastName = "DiCaprio",
                },
                new
                {
                    MovieIdentifier = 7,
                    Id = 2,
                    FirstName = "Marion",
                    LastName = "Cotillard",
                },
                new
                {
                    MovieIdentifier = 8,
                    Id = 1,
                    FirstName = "Roy",
                    LastName = "Scheider",
                },
                new
                {
                    MovieIdentifier = 8,
                    Id = 2,
                    FirstName = "Robert",
                    LastName = "Shaw",
                },
                new
                {
                    MovieIdentifier = 9,
                    Id = 1,
                    FirstName = "Kristen",
                    LastName = "Bell",
                },
                new
                {
                    MovieIdentifier = 9,
                    Id = 2,
                    FirstName = "Idina",
                    LastName = "Menzel",
                },
                new
                {
                    MovieIdentifier = 10,
                    Id = 1,
                    FirstName = "Mark",
                    LastName = "Hamill",
                },
                new
                {
                    MovieIdentifier = 10,
                    Id = 2,
                    FirstName = "Harrison",
                    LastName = "Ford",
                }
            );
    }
}
