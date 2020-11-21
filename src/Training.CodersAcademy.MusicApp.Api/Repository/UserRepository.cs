using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.Repository
{
    /// <summary>
    /// Repository of users.
    /// </summary>
    public class UserRepository
    {
        private readonly MusicAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="MusicAppContext"/>.</param>
        public UserRepository(MusicAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets an user by Id.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <returns>The <see cref="User"/>.</returns>
        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .Include(x => x.FavoriteMusics)
                .ThenInclude(x => x.Music)
                .ThenInclude(x => x.Album)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Gets an user by email and password.
        /// </summary>
        /// <param name="email">Email of the user.</param>
        /// <param name="encodedPassword">Encoded password.</param>
        /// <returns>The <see cref="User"/>.</returns>
        public async Task<User> GetByEmailPasswordAsync(string email, string encodedPassword)
        {
            return await _context.Users
                .Include(x => x.FavoriteMusics)
                .ThenInclude(x => x.Music)
                .ThenInclude(x => x.Album)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == encodedPassword);
        }

        /// <summary>
        /// Creates an user.
        /// </summary>
        /// <param name="model">The <see cref="User"/> to create.</param>
        /// <returns></returns>
        public async Task CreateAsync(User model)
        {
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an user.
        /// </summary>
        /// <param name="model">The <see cref="User"/> to update.</param>
        /// <returns></returns>
        public async Task UpdateAsync(User model)
        {
            _context.Users.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
