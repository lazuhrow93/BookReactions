using AutoMapper;
using Chronical.App.Controllers;
using Chronical.App.Models.Dto;
using Chronicle.Domain.Entity;

namespace Chronical.App.Mappers
{
    public class ChapterProfile : Profile
    {
        public ChapterProfile()
        {
            CreateMap<AddCommentsDto, Comment>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Comment))
                .ForMember(d => d.SubText, opt => opt.MapFrom(s => s.SubText))
                .IgnoreId();
        }
    }
}
