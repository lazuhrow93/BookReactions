using AutoMapper;
using Chronicle.Domain.Entity;

namespace Chronical.App.Mappers
{
    public static class MapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreId<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mapper)
            where TDestination : IEntity
            where TSource : class
        {
            mapper.ForMember(d => d.Id, opt => opt.Ignore());
            return mapper;
        }
    }
}
