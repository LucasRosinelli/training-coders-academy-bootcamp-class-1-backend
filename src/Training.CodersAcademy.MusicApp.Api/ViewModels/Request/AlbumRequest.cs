using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Request
{
    /// <summary>
    /// The request for an <see cref="Album"/>.
    /// </summary>
    public class AlbumRequest : IValidatableObject
    {
        /// <summary>
        /// Name of the album.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Description of the album.
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Backdrop of the album.
        /// </summary>
        [Required]
        public string Backdrop { get; set; }
        /// <summary>
        /// Band of the album.
        /// </summary>
        [Required]
        public string Band { get; set; }
        /// <summary>
        /// Musics of the album.
        /// </summary>
        [Required]
        public List<MusicRequest> Musics { get; set; }

        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResult = new List<ValidationResult>();

            if (Musics?.Any() == false)
            {
                validationResult.Add(new ValidationResult("Album must contain at least one music"));
            }
            else
            {
                foreach (var music in Musics)
                {
                    Validator.TryValidateObject(music, new ValidationContext(music), validationResult);
                }
            }

            return validationResult;
        }
    }
}
