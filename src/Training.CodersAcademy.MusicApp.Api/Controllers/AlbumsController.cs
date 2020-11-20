using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.CodersAcademy.MusicApp.Api.Models;
using Training.CodersAcademy.MusicApp.Api.Repository;
using Training.CodersAcademy.MusicApp.Api.ViewModels.Request;

namespace Training.CodersAcademy.MusicApp.Api.Controllers
{
    /// <summary>
    /// Manages albums.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AlbumRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="mapper">The <see cref="IMapper"/>.</param>
        /// <param name="repository">The <see cref="AlbumRepository"/>.</param>
        public AlbumsController(IMapper mapper, AlbumRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Gets a list of albums.
        /// </summary>
        /// <returns>The list of albums.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();

            return Ok(result);
        }

        /// <summary>
        /// Gets an album by Id.
        /// </summary>
        /// <param name="id">The Id of the album.</param>
        /// <returns>The album.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Gets musics by an album Id.
        /// </summary>
        /// <param name="id">Id of the album.</param>
        /// <returns>List of musics of a given album.</returns>
        [HttpGet("{id}/Musics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByAlbumId(Guid id)
        {
            var result = await _repository.GetByAlbumIdAsync(id);

            if (result?.Any() == false)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Creates an album.
        /// </summary>
        /// <param name="request">The album to create.</param>
        /// <returns>The album created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(AlbumRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<Album>(request);
            await _repository.CreateAsync(model);

            return Created($"/{model.Id}", model);
        }

        /// <summary>
        /// Deletes an album.
        /// </summary>
        /// <param name="id">The Id of the album.</param>
        /// <returns>Empty content.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(result);

            return NoContent();
        }
    }
}
