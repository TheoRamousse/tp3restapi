using RestApi.Models.Dtos;
using RestApi.Models.Entities;

namespace RestApi.Services
{
    public interface IElementService<TDto, TEntity>
        where TDto : IDto<TEntity>
        where TEntity : IEntity<TDto>
    {
        public Task<TDto?> InsertElement(TDto element);

        public TDto? DeleteElement(int id);

        public Task<TDto?> UpdateElement(TDto element);

        public Task<TDto?> GetElementById(int id);

        public Page<TDto?> GetPagedElements(int page, int nbElementsPerPage, Dictionary<string, object> dico);

    }
}