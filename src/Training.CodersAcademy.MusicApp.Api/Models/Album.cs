using System;
using System.Collections.Generic;

namespace Training.CodersAcademy.MusicApp.Api.Models
{
    /// <summary>
    /// Album model.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Id of the album.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the album.
        /// </summary>
        public string Name { get; set; }
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
        /// <summary>
        /// Musics of the album.
        /// </summary>
        public IList<Music> Musics { get; set; }
    }
}
