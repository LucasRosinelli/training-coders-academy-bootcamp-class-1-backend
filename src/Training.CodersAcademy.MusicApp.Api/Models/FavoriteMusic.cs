using System;
using System.Text.Json.Serialization;

namespace Training.CodersAcademy.MusicApp.Api.Models
{
    /// <summary>
    /// Favorite music model.
    /// </summary>
    public class FavoriteMusic
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
        /// Id of the user this favorite music belongs to.
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// The music that is a favorite.
        /// </summary>
        public Music Music { get; set; }
        /// <summary>
        /// The user this favorite music belongs to.
        /// </summary>
        [JsonIgnore]
        public User User { get; set; }
    }
}
