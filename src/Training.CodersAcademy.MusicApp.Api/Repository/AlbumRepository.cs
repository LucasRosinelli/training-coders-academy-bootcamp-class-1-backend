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
            return await _context.Albums.ToListAsync();
        }
    }
}
