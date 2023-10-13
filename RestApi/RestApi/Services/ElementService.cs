using RestApi.DataAccessLayer;
using RestApi.Models.Dtos;
using RestApi.Models.Entities;

namespace RestApi.Services
{
    public class ElementService<TDto, TEntity> where TEntity : IEntity<TDto> where TDto : AbstractDto<TEntity>
    {
        private IDal<TEntity> _dal;
        public ElementService(IDal<TEntity> dal)
        {
            _dal = dal;
        }

        public async Task<TDto?> InsertElement(TDto element)
        {
            return (await _dal.Add(element.ToEntity())).ToDto();
        }

        public TDto? DeleteElement(int id)
        {
            var element = typeof(TDto).GetConstructor(new[] { typeof(int) })!.Invoke(new object[] { id }) as TDto;
            return _dal.Remove(element!.ToEntity()).ToDto();
        }

        public TDto? UpdateElement(TDto element)
        {
            return (_dal.Update(element.ToEntity())).ToDto();
        }

        public async Task<TDto?> GetElementById(int id)
        {
            var resultAsEntity = await _dal.GetOne(id);

            if(resultAsEntity == null)
                return default;
            else
                return resultAsEntity.ToDto();
        }

        public Page<TDto?> GetPagedElements(int page, int nbElementsPerPage)
        {
            var resultsAsEntity = _dal.GetAll();

            int previousPage = 0;

            if(page > 0)
                previousPage = page - 1;

            if (resultsAsEntity == null)
            {
                return new()
                {
                    Info = new Info()
                    {
                        PageNumber = page,
                        Size = 0,
                        PreviousPage = previousPage,
                    },
                };
            }
            else
            {
                var listOfResults = resultsAsEntity.Skip(page * nbElementsPerPage).Take(nbElementsPerPage).ToList().Select(x => x.ToDto()).ToList()!;

                int nextPage = page;

                if (resultsAsEntity.Skip((page + 1) * nbElementsPerPage).Take(nbElementsPerPage).ToList().Count() > 0)
                    nextPage = page + 1;

                return new()
                {
                    Info = new Info()
                    {
                        PageNumber = page,
                        Size = listOfResults.Count(),
                        NextPage = nextPage,
                        PreviousPage = previousPage
                    },
                    Result = listOfResults!
                };
            }
        }




    }
}
