using System;
using System.Collections.Generic;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Response
{
    /// <summary>
    /// The reponse for a <see cref="User"/>.
    /// </summary>
    public class UserResponse
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
        /// Photo of the user.
        /// </summary>
        public string Photo { get; set; }
        public IList<FavoriteMusicResponse> FavoriteMusics { get; set; }
    }
}
