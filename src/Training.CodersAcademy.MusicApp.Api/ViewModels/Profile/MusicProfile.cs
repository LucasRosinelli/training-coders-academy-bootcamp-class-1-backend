using Training.CodersAcademy.MusicApp.Api.Models;
using Training.CodersAcademy.MusicApp.Api.ViewModels.Request;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Profile
{
    /// <summary>
    /// Music profile.
    /// </summary>
    public class MusicProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicProfile"/> class.
        /// </summary>
        public MusicProfile()
        {
            CreateMap<MusicRequest, Music>();
        }
    }
}
