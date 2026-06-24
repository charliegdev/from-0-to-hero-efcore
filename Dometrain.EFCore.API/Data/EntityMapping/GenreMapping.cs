using Dometrain.EFCore.API.Data.ValueGenerators;
using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dometrain.EFCore.API.Data.EntityMapping;

public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(genre => genre.CreatedDate).HasValueGenerator<CreatedDateGenerator>();

        builder.HasData(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Comedy" },
            new Genre { Id = 3, Name = "Drama" },
            new Genre { Id = 4, Name = "Horror" },
            new Genre { Id = 5, Name = "Sci-Fi" },
            new Genre { Id = 6, Name = "Romance" },
            new Genre { Id = 7, Name = "Thriller" },
            new Genre { Id = 8, Name = "Animation" },
            new Genre { Id = 9, Name = "Documentary" },
            new Genre { Id = 10, Name = "Fantasy" }
        );
    }
}
