using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Training.CodersAcademy.MusicApp.Api.Models;
using Training.CodersAcademy.MusicApp.Api.Repository.Mapping;

namespace Training.CodersAcademy.MusicApp.Api.Repository
{
    /// <summary>
    /// MusicApp context.
    /// </summary>
    public class MusicAppContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// Albums.
        /// </summary>
        public DbSet<Album> Albums { get; set; }
        /// <summary>
        /// Musics.
        /// </summary>
        public DbSet<Music> Musics { get; set; }
        /// <summary>
        /// Musics.
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Musics.
        /// </summary>
        public DbSet<FavoriteMusic> FavoriteMusics { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicAppContext"/> class.
        /// </summary>
        /// <param name="options">The context options.</param>
        public MusicAppContext(DbContextOptions<MusicAppContext> options)
            : base(options)
        {
            _loggerFactory = LoggerFactory.Create(x => x.AddConsole());
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumMapping());
            modelBuilder.ApplyConfiguration(new MusicMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new FavoriteMusicMapping());

            base.OnModelCreating(modelBuilder);
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
