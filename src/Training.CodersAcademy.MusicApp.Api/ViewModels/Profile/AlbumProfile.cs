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
            CreateMap<AlbumRequest, Album>()
                .ForMember(d => d.Name, s => s.MapFrom(f => f.Name))
                .ForMember(d => d.Description, s => s.MapFrom(f => f.Description))
                .ForMember(d => d.Backdrop, s => s.MapFrom(f => f.Backdrop))
                .ForMember(d => d.Band, s => s.MapFrom(f => f.Band))
                .ForMember(d => d.Musics, s => s.MapFrom(f => f.Musics));
        }
    }
}
