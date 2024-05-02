using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Models.OutogingDto;
using Chronicle.Domain.Entity;

namespace Chronical.App.Mappers
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {

            #region Author

            CreateMap<AuthorDto, Author>();

            #endregion

            #region Chapter

            CreateMap<ChapterDto, Chapter>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Number, opt => opt.MapFrom(s => s.ChapterNumber))
                .ForMember(d => d.BookId, opt => opt.MapFrom(s => s.BookId))
                .IgnoreId();

            #endregion

            #region Comment

            CreateMap<CommentDto, Comment>()
                .ForMember(d => d.ChapterNumber, opt => opt.MapFrom(s => s.ChapterNumber))
                .IgnoreId();

            CreateMap<Comment, CommentDetailsDto>()
                .ForMember(d => d.ChapterNumber, opt => opt.MapFrom(s => s.ChapterNumber))
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Value));

            #endregion

            #region Book

            CreateMap<BookDto, Book>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.AuthorId, opt => opt.Ignore())
                .IgnoreId();

            CreateMap<Book, BookDetailsDto>()
                .ForMember(d => d.BookId, opt => opt.MapFrom(s => s.Id));

            #endregion

            #region Character

            CreateMap<CharacterDto, Character>()
                .IgnoreId()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.BookId, opt => opt.MapFrom(s => s.BookId));

            CreateMap<Character, CharacterCommentsDto>()
                .ForMember(d => d.CharacterId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CharacterName, opt => opt.MapFrom(s => s.FullName))
                .ForMember(d => d.Comments, opt => opt.Ignore());

            #endregion
        }
    }
}
