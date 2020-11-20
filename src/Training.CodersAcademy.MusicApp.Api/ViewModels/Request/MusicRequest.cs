using System.ComponentModel.DataAnnotations;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Request
{
    /// <summary>
    /// The request for a <see cref="Music"/>.
    /// </summary>
    public class MusicRequest
    {
        /// <summary>
        /// Name of the music.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Duration of the music in seconds.
        /// </summary>
        [Required]
        public int Duration { get; set; }
    }
}
