using System.ComponentModel.DataAnnotations;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Request
{
    /// <summary>
    /// The request for a <see cref="User"/> registration.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// Name of the user.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Password of the user.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
