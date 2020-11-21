using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.CodersAcademy.MusicApp.Api.Models;
using Training.CodersAcademy.MusicApp.Api.Repository;
using Training.CodersAcademy.MusicApp.Api.ViewModels.Request;
using Training.CodersAcademy.MusicApp.Api.ViewModels.Response;

namespace Training.CodersAcademy.MusicApp.Api.Controllers
{
    /// <summary>
    /// Manages users.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _repository;
        private readonly MusicRepository _musicRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="mapper">The <see cref="IMapper"/>.</param>
        /// <param name="repository">The <see cref="UserRepository"/>.</param>
        /// <param name="musicRepository">The <see cref="MusicRepository"/>.</param>
        public UsersController(IMapper mapper, UserRepository repository, MusicRepository musicRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _musicRepository = musicRepository;
        }

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="request">The credentials to authentication.</param>
        /// <returns>The authentication result.</returns>
        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var encodedPassword = EncodePassword(request.Password);
            var user = await _repository.GetByEmailPasswordAsync(request.Email, encodedPassword);

            if (user == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid credentials",
                });
            }

            var result = _mapper.Map<UserResponse>(user);

            return Ok(result);
        }

        /// <summary>
        /// Registers a user.
        /// </summary>
        /// <param name="request">The user to create.</param>
        /// <returns>The user created.</returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(request);
            user.Photo = $"https://robohash.org/{Guid.NewGuid()}.png?bgset=any";
            user.Password = EncodePassword(user.Password);

            await _repository.CreateAsync(user);

            var result = _mapper.Map<UserResponse>(user);

            return Created($"/{result.Id}", result);
        }

        /// <summary>
        /// Adds a music to favorite musics.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <param name="musicId">Id of the music.</param>
        /// <returns>Empty content.</returns>
        [HttpPost("{id}/favorite-music/{musicId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> AddFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await _musicRepository.GetByIdAsync(musicId);

            if (music == null)
            {
                return UnprocessableEntity(new
                {
                    Message = "Music not found."
                });
            }

            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                return UnprocessableEntity(new
                {
                    Message = "User not found."
                });
            }

            user.AddFavorite(music);
            await _repository.UpdateAsync(user);

            return Ok();
        }

        /// <summary>
        /// Removes a music from favorite musics.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <param name="musicId">Id of the music.</param>
        /// <returns>Empty content.</returns>
        [HttpDelete("{id}/favorite-music/{musicId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> RemoveFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await _musicRepository.GetByIdAsync(musicId);

            if (music == null)
            {
                return UnprocessableEntity(new
                {
                    Message = "Music not found."
                });
            }

            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                return UnprocessableEntity(new
                {
                    Message = "User not found."
                });
            }

            user.RemoveFavorite(music);
            await _repository.UpdateAsync(user);

            return Ok();
        }

        /// <summary>
        /// Encodes the password.
        /// </summary>
        /// <param name="plainTextPassword">The password (in plain text) to encode.</param>
        /// <returns>Encoded password.</returns>
        private string EncodePassword(string plainTextPassword)
        {
            using var sha256Hash = SHA256.Create();
            var hashBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
            var encodedPassword = Convert.ToBase64String(hashBytes);

            return encodedPassword;
        }
    }
}
