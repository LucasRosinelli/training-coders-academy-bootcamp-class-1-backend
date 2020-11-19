using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.CodersAcademy.MusicApp.Api.Repository;

namespace Training.CodersAcademy.MusicApp.Api.Controllers
{
    /// <summary>
    /// Manages albums.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly AlbumRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="repository">The <see cref="AlbumRepository"/>.</param>
        public AlbumsController(AlbumRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets a list of albums.
        /// </summary>
        /// <returns>The list of albums.</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _repository.GetAllAsync();

            return Ok(result);
        }
    }
}
