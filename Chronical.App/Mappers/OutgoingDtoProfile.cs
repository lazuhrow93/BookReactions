using AutoMapper;
using Chronical.App.Models.OutgoingDto;
using Chronicle.Domain.Entity;

namespace Chronical.App.Mappers
{
    public class OutgoingDtoProfile : Profile
    {
        public OutgoingDtoProfile()
        {
            CreateMap<Book, BookCommentsDetailsDto>()
                .ForMember(d => d.BookId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CharacterComments, opt => opt.Ignore());

            CreateMap<Comment, CommentDetailsDto>()
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Value));
        }
    }
}
