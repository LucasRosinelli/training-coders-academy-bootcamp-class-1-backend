using System;

namespace Training.CodersAcademy.MusicApp.Api.Models
{
    /// <summary>
    /// Music model.
    /// </summary>
    public class Music
    {
        /// <summary>
        /// Id of the music.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the music.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Duration of the music in seconds.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// The album which the music belongs to.
        /// </summary>
        public Album Album { get; set; }
    }
}
