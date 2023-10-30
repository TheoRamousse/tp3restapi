using RestApi.Models.Dtos;

namespace RestApi.Models.Entities
{
    public class MovieEntity: IEntity<MovieDto>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public List<RelationEntity> Relations { get; } = new();


        public MovieDto ToDto()
        {
            var result =  new MovieDto()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                ReleaseDate = this.ReleaseDate,
                
            };

            var guests = new List<GuestSimplifiedDto>();

            for(int i = 0; i < Relations.Count; i++)
            {
                guests.Add(new GuestSimplifiedDto()
                {
                    Id = Relations[i].Guest.Id,
                    FirstName = Relations[i].Guest.FirstName,
                    LastName = Relations[i].Guest.LastName,
                    BirthDate = Relations[i].Guest.BirthDate,
                    Role = (RoleDto)Relations[i].Role,
                });
            }

            result.Guests = guests;

            return result;
        }
    }
}
