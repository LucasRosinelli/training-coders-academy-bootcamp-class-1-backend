using Training.CodersAcademy.MusicApp.Api.Models;
using Training.CodersAcademy.MusicApp.Api.ViewModels.Request;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Profile
{
    /// <summary>
    /// Album profile.
    /// </summary>
    public class AlbumProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumProfile"/> class.
        /// </summary>
        public AlbumProfile()
        {
            CreateMap<AlbumRequest, Album>();
        }
    }
}
