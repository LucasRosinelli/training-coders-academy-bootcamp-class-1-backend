using Microsoft.EntityFrameworkCore;
using Training.CodersAcademy.MusicApp.Api.Models;
using Training.CodersAcademy.MusicApp.Api.Repository.Mapping;

namespace Training.CodersAcademy.MusicApp.Api.Repository
{
    /// <summary>
    /// MusicApp context.
    /// </summary>
    public class MusicAppContext : DbContext
    {
        /// <summary>
        /// Albums.
        /// </summary>
        public DbSet<Album> Albums { get; set; }
        /// <summary>
        /// Musics.
        /// </summary>
        public DbSet<Music> Musics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicAppContext"/> class.
        /// </summary>
        /// <param name="options">The context options.</param>
        public MusicAppContext(DbContextOptions<MusicAppContext> options)
            : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumMapping());
            modelBuilder.ApplyConfiguration(new MusicMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
