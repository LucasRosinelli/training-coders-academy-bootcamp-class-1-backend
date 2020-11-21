using System;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Response
{
    /// <summary>
    /// The reponse for a <see cref="FavoriteMusic"/>.
    /// </summary>
    public class FavoriteMusicResponse
    {
        /// <summary>
        /// Id of the favorite music.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Id of the music that is a favorite.
        /// </summary>
        public Guid MusicId { get; set; }
        /// <summary>
        /// Name of the music.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Duration of the music in seconds.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Id of the album that is a favorite.
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        /// Name of the album.
        /// </summary>
        public string AlbumName { get; set; }
        /// <summary>
        /// Description of the album.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Backdrop of the album.
        /// </summary>
        public string Backdrop { get; set; }
        /// <summary>
        /// Band of the album.
        /// </summary>
        public string Band { get; set; }
    }
}
