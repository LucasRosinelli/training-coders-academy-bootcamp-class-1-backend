using System;
using System.Collections.Generic;
using System.Linq;

namespace Training.CodersAcademy.MusicApp.Api.Models
{
    /// <summary>
    /// User model.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id of the user.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Email of the user.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of the user.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Proto of the user.
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// Favorite musics of the user.
        /// </summary>
        public IList<FavoriteMusic> FavoriteMusics { get; set; }

        /// <summary>
        /// Adds a music to favorite musics.
        /// </summary>
        /// <param name="music">Music to add to favorite musics.</param>
        public void AddFavorite(Music music)
        {
            FavoriteMusics ??= new List<FavoriteMusic>();

            if (FavoriteMusics.Any(x => x.MusicId == music.Id))
            {
                return;
            }

            FavoriteMusics.Add(new FavoriteMusic()
            {
                MusicId = music.Id,
                Music = music,
                User = this,
            });
        }

        /// <summary>
        /// Removes a music from favorite musics.
        /// </summary>
        /// <param name="music">Music to remove from favorite musics.</param>
        public void RemoveFavorite(Music music)
        {
            var favoriteMusic = FavoriteMusics?.FirstOrDefault(x => x.MusicId == music?.Id);

            if (favoriteMusic is not null)
            {
                FavoriteMusics.Remove(favoriteMusic);
            }
        }
    }
}
