using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Training.CodersAcademy.MusicApp.Api.Controllers
{
    /// <summary>
    /// Manages albums.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        /// <summary>
        /// Gets a list of albums.
        /// </summary>
        /// <returns>The list of albums.</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return await Task.FromResult(Ok(new[]
            {
                new { Title = "This is my album title", },
                new { Title = "This is another album title", },
            }));
        }
    }
}
