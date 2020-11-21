using System.ComponentModel.DataAnnotations;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Request
{
    /// <summary>
    /// The request for a <see cref="User"/> authentication.
    /// </summary>
    public class AuthenticateRequest
    {
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
