using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training.CodersAcademy.MusicApp.Api.Models;

namespace Training.CodersAcademy.MusicApp.Api.Repository
{
    /// <summary>
    /// Repository of albums.
    /// </summary>
    public class AlbumRepository
    {
        private readonly MusicAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="MusicAppContext"/>.</param>
        public AlbumRepository(MusicAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all albums.
        /// </summary>
        /// <returns>List of albums.</returns>
        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums.Include(x => x.Musics).ToListAsync();
        }

        /// <summary>
        /// Gets an album by Id.
        /// </summary>
        /// <param name="id">Id of the album.</param>
        /// <returns>The <see cref="Album"/>.</returns>
        public async Task<Album> GetByIdAsync(Guid id)
        {
            return await _context.Albums.Include(x => x.Musics).FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Creates an album.
        /// </summary>
        /// <param name="model">The <see cref="Album"/> to create.</param>
        public async Task CreateAsync(Album model)
        {
            await _context.Albums.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an album.
        /// </summary>
        /// <param name="model">The <see cref="Album"/> to delete.</param>
        /// <returns></returns>
        public async Task DeleteAsync(Album model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
