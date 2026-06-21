using System.Runtime.InteropServices.JavaScript;
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

        builder.Property(movie => movie.ReleaseDate).HasColumnType("date");

        builder
            .Property(movie => movie.Synopsis)
            .HasColumnType("varchar(max)")
            .HasColumnName("Plot");

        builder
            .HasOne(movie => movie.Genre)
            .WithMany(genre => genre.Movies)
            .HasPrincipalKey(genre => genre.Id)
            .HasForeignKey(movie => movie.MainGenreId);

        builder.HasData(
            new Movie
            {
                Identifier = 1,
                Title = "Fight Club",
                ReleaseDate = new DateTime(1999, 9, 10),
                Synopsis = "Ed Norton and Brad Pitt have a couple of fist fights with each other.",
                MainGenreId = 2,
            },
            new Movie
            {
                Identifier = 2,
                Title = "The Matrix",
                ReleaseDate = new DateTime(1999, 3, 31),
                Synopsis =
                    "Keanu Reeves chooses the red pill, learns kung fu from a screensaver, and dodges bullets because he forgot gravity exists.",
                MainGenreId = 5,
            },
            new Movie
            {
                Identifier = 3,
                Title = "Titanic",
                ReleaseDate = new DateTime(1997, 12, 19),
                Synopsis =
                    "Jack and Rose fall in love on a boat that was definitely not built by the lowest bidder. Spoiler: the iceberg wins.",
                MainGenreId = 6,
            },
            new Movie
            {
                Identifier = 4,
                Title = "Jurassic Park",
                ReleaseDate = new DateTime(1993, 6, 11),
                Synopsis =
                    "A billionaire opens a zoo with no fences, no backup power plan, and a lawyer who walks too slowly. Dinosaurs file a complaint.",
                MainGenreId = 4,
            },
            new Movie
            {
                Identifier = 5,
                Title = "Shrek",
                ReleaseDate = new DateTime(2001, 5, 18),
                Synopsis =
                    "An ogre just wants privacy. A donkey won't stop talking. The princess is also an ogre and somehow that's the plot twist.",
                MainGenreId = 8,
            },
            new Movie
            {
                Identifier = 6,
                Title = "The Godfather",
                ReleaseDate = new DateTime(1972, 3, 24),
                Synopsis =
                    "A man attends his daughter's wedding and spends the rest of the film making offers people can't refuse, including to a horse.",
                MainGenreId = 3,
            },
            new Movie
            {
                Identifier = 7,
                Title = "Inception",
                ReleaseDate = new DateTime(2010, 7, 16),
                Synopsis =
                    "Leonardo DiCaprio naps on the job so hard he dreams inside a dream inside a dream and still can't spin a top properly.",
                MainGenreId = 7,
            },
            new Movie
            {
                Identifier = 8,
                Title = "Jaws",
                ReleaseDate = new DateTime(1975, 6, 20),
                Synopsis =
                    "A shark eats tourists while the mayor insists the beach is safe because bad Yelp reviews hurt the local economy.",
                MainGenreId = 4,
            },
            new Movie
            {
                Identifier = 9,
                Title = "Frozen",
                ReleaseDate = new DateTime(2013, 11, 27),
                Synopsis =
                    "A princess with ice powers runs away and builds a castle because her sister kept borrowing her stuff without asking.",
                MainGenreId = 8,
            },
            new Movie
            {
                Identifier = 10,
                Title = "Star Wars",
                ReleaseDate = new DateTime(1977, 5, 25),
                Synopsis =
                    "A farm boy whines about sand, trusts a wizard, and blows up a planet-sized weapon because he got lucky with a torpedo.",
                MainGenreId = 5,
            }
        );
    }
}
