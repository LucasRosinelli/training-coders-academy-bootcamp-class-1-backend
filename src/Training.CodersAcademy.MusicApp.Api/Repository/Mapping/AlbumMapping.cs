using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.Repository.Mapping
{
    /// <summary>
    /// Album mapping.
    /// </summary>
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Backdrop).IsRequired();
            builder.Property(x => x.Band).IsRequired().HasMaxLength(200);

            builder.HasMany(x => x.Musics).WithOne(x => x.Album).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
