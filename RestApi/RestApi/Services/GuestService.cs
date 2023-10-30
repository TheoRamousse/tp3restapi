using RestApi.DataAccessLayer;
using RestApi.Models.Dtos;
using RestApi.Models.Entities;

namespace RestApi.Services
{
    public class GuestService : IElementService<GuestDto, GuestEntity>
    {
        private readonly IDal<GuestEntity> _dal;
        private readonly IDal<RelationEntity> _dalRelation;
        public GuestService(IDal<GuestEntity> dal, IDal<RelationEntity> dalRelation)
        {
            _dal = dal;
            _dalRelation = dalRelation;
        }

        public async Task<GuestDto?> InsertElement(GuestDto element)
        {
            var entity = element.ToEntity();

            return (await _dal.Add(entity)).ToDto();
        }

        public GuestDto? DeleteElement(int id)
        {
            var element = new GuestDto()
            {
                Id = id,
            };
            return _dal.Remove(element!.ToEntity()).ToDto();
        }

        public Task<GuestDto?> UpdateElement(GuestDto element)
        {
            //return (_dal.Update(element.ToEntity())).ToDto();
            return null;
        }

        public async Task<GuestDto?> GetElementById(int id)
        {
            var resultAsEntity = await _dal.GetOne(id);

            if(resultAsEntity == null)
                return default;
            else
                return resultAsEntity.ToDto();
        }

        public Page<GuestDto?> GetPagedElements(int page, int nbElementsPerPage)
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
