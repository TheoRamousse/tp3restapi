﻿using RestApi.DataAccessLayer;
using RestApi.Models.Dtos;
using RestApi.Models.Entities;

namespace RestApi.Services
{
    public class MovieService : IElementService<MovieDto, MovieEntity>
    {
        private readonly IDal<MovieEntity> _dal;
        private readonly IDal<RelationEntity> _dalRelation;
        private readonly IDal<GuestEntity> _dalGuest;
        public MovieService(IDal<MovieEntity> dal, IDal<RelationEntity> dalRelation, IDal<GuestEntity> dalGuest)
        {
            _dal = dal;
            _dalRelation = dalRelation;
            _dalGuest = dalGuest;
        }

        public async Task<MovieDto?> InsertElement(MovieDto element)
        {
            var entity = element.ToEntity();

            return (await _dal.Add(entity)).ToDto();
        }

        public MovieDto? DeleteElement(int id)
        {
            var element = new MovieDto()
            {
                Id = id,
            };
            return _dal.Remove(element!.ToEntity()).ToDto();
        }

        public async Task<MovieDto?> UpdateElement(MovieDto element)
        {
            var entity = element.ToEntity();

            entity.Relations.Clear();

            element.Guests.ForEach(async x =>
            {
                entity.Relations.Add(new RelationEntity()
                {
                    Guest = await _dalGuest.GetOne((int)x.Id),
                    Movie = entity,
                    Role = (int)x.Role
                });
            });

            return (_dal.Update(entity)).ToDto();
        }

        public async Task<MovieDto?> GetElementById(int id)
        {
            var resultAsEntity = await _dal.GetOne(id);

            if(resultAsEntity == null)
                return default;
            else
                return resultAsEntity.ToDto();
        }

        public Page<MovieDto?> GetPagedElements(int page, int nbElementsPerPage)
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
                var toto = _dalRelation.GetAll().ToList();

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
