using System;
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
    /// Manages musics.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MusicRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicsController"/> class.
        /// </summary>
        /// <param name="mapper">The <see cref="IMapper"/>.</param>
        /// <param name="repository">The <see cref="MusicRepository"/>.</param>
        public MusicsController(IMapper mapper, MusicRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Gets a list of musics.
        /// </summary>
        /// <returns>The list of musics.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();

            return Ok(result);
        }

        /// <summary>
        /// Gets a music by Id.
        /// </summary>
        /// <param name="id">The Id of the music.</param>
        /// <returns>The music.</returns>
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
        /// Creates a music.
        /// </summary>
        /// <param name="request">The music to create.</param>
        /// <returns>The music created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(MusicRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<Music>(request);
            await _repository.CreateAsync(model);

            return Created($"/{model.Id}", model);
        }

        /// <summary>
        /// Deletes a music.
        /// </summary>
        /// <param name="id">The Id of the music.</param>
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

            if (result.Album.Musics.Count == 1)
            {
                return UnprocessableEntity();
            }

            await _repository.DeleteAsync(result);

            return NoContent();
        }
    }
}
