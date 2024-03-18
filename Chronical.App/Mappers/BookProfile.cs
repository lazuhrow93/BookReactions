using AutoMapper;
using Chronical.App.Models.Dto;
using Chronicle.Domain.Entity;

namespace Chronical.App.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<AddBookDto, Book>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Author, opt => opt.MapFrom(s => s.Author))
                .IgnoreId();
        }
    }
}
