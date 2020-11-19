using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.Repository.Mapping
{
    /// <summary>
    /// Music mapping.
    /// </summary>
    public class MusicMapping : IEntityTypeConfiguration<Music>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Musics");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Duration).IsRequired();
        }
    }
}
