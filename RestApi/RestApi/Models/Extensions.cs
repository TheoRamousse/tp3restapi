using RestApi.Models.Dtos;
using RestApi.Models.Entities;
using System.Linq;

namespace RestApi.Models
{
    public static class MovieEntityExtension
    {
        public static MovieDto ToDto(this MovieEntity entity)
        {
            return new MovieDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Guests = entity.Guests.Select(g => g.ToDto()).ToList()
            };
        }
    }

    public static class GuestEntityExtension
    {
        public static GuestDto ToDto(this GuestEntity entity) {
            return new GuestDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate,
            };
        }
    }

    public static class GuestDtoExtension
    {
        public static GuestEntity ToEntity(this GuestDto dto)
        {
            return new GuestEntity()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate
            };
        }
    }

    public static class MovieDtoExtension
    {
        public static MovieEntity ToEntity(this MovieDto dto)
        {
            return new MovieEntity()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Guests = dto.Guests.Select(g => g.ToEntity()).ToList()
            };
        }
    }
}
