using AutoMapper;
using FavBooks.Core.Entities;
using FavBooks.Models.Books;
using FavBooks.Models.Favourites;

namespace FavBooks.Web.Infrastructure.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Book, BookModel>();

            CreateMap<Favourite, DetailedFavouriteModel>()
               .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Book.Authors))
               .ForMember(dest => dest.CoverThumb, opt => opt.MapFrom(src => src.Book.CoverThumb))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Book.Description))
               .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Book.Subjects))
               .ForMember(dest => dest.Subtitle, opt => opt.MapFrom(src => src.Book.Subtitle))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title));
        }
    }
}