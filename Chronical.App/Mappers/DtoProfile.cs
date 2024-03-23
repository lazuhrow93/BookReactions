using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutogingDto;
using Chronicle.Domain.Entity;

namespace Chronical.App.Mappers
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<ChapterDto, Chapter>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Number, opt => opt.MapFrom(s => s.ChapterNumber))
                .IgnoreId();

            CreateMap<CommentDto, Comment>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Comment))
                .ForMember(d => d.SubText, opt => opt.MapFrom(s => s.SubText))
                .IgnoreId();

            CreateMap<BookDto, Book>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d=>d.AuthorId, opt=>opt.Ignore())
                .IgnoreId();

            CreateMap<Book, BookDetailsDto>()
                .ForMember(d => d.BookId, opt => opt.MapFrom(s => s.Id));


        }
    }
}
