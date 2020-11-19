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
    }
}
