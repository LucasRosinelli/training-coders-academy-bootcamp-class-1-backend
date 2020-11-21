using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.Repository
{
    /// <summary>
    /// Repository of musics.
    /// </summary>
    public class MusicRepository
    {
        private readonly MusicAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="MusicAppContext"/>.</param>
        public MusicRepository(MusicAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all musics.
        /// </summary>
        /// <returns>List of musics.</returns>
        public async Task<IEnumerable<Music>> GetAllAsync()
        {
            return await _context.Musics.ToListAsync();
        }

        /// <summary>
        /// Gets a music by Id.
        /// </summary>
        /// <param name="id">Id of the music.</param>
        /// <returns>The <see cref="Music"/>.</returns>
        public async Task<Music> GetByIdAsync(Guid id)
        {
            return await _context.Musics
                .Include(x => x.Album)
                .ThenInclude(x => x.Musics)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Creates a music.
        /// </summary>
        /// <param name="model">The <see cref="Music"/> to create.</param>
        /// <returns></returns>
        public async Task CreateAsync(Music model)
        {
            await _context.Musics.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a music.
        /// </summary>
        /// <param name="model">The <see cref="Music"/> to delete.</param>
        /// <returns></returns>
        public async Task DeleteAsync(Music model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
