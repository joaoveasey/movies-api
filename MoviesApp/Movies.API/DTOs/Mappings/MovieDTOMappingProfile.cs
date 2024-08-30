using AutoMapper;
using movies_api.Model;

namespace movies_api.DTOs.Mappings
{
    public class MovieDTOMappingProfile : Profile
    {
        public MovieDTOMappingProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }
    }
}
