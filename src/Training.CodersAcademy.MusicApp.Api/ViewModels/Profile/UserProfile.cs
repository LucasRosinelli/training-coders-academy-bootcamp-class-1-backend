using Training.CodersAcademy.MusicApp.Api.Models;
using Training.CodersAcademy.MusicApp.Api.ViewModels.Request;
using Training.CodersAcademy.MusicApp.Api.ViewModels.Response;

namespace Training.CodersAcademy.MusicApp.Api.ViewModels.Profile
{
    /// <summary>
    /// User profile.
    /// </summary>
    public class UserProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        public UserProfile()
        {
            CreateMap<FavoriteMusic, FavoriteMusicResponse>()
                .ForMember(d => d.Id, s => s.MapFrom(f => f.Id))
                .ForMember(d => d.MusicId, s => s.MapFrom(f => f.Music.Id))
                .ForMember(d => d.Name, s => s.MapFrom(f => f.Music.Name))
                .ForMember(d => d.Duration, s => s.MapFrom(f => f.Music.Duration))
                .ForMember(d => d.AlbumId, s => s.MapFrom(f => f.Music.Album.Id))
                .ForMember(d => d.AlbumName, s => s.MapFrom(f => f.Music.Album.Name))
                .ForMember(d => d.Description, s => s.MapFrom(f => f.Music.Album.Description))
                .ForMember(d => d.Backdrop, s => s.MapFrom(f => f.Music.Album.Backdrop))
                .ForMember(d => d.Band, s => s.MapFrom(f => f.Music.Album.Band));

            CreateMap<RegisterRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
