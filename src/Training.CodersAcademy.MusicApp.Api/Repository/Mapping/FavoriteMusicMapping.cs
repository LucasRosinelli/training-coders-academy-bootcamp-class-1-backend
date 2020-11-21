using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.Repository.Mapping
{
    /// <summary>
    /// Favorite music mapping.
    /// </summary>
    public class FavoriteMusicMapping : IEntityTypeConfiguration<FavoriteMusic>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<FavoriteMusic> builder)
        {
            builder.ToTable("FavoriteMusics");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Music).WithOne().HasForeignKey<FavoriteMusic>(x => x.MusicId);
        }
    }
}
