using RestApi.Models.Dtos;

namespace RestApi.Models.Entities
{
    public class GuestEntity: IEntity<GuestDto>
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public List<RelationEntity> Relations { get; } = new();
        public List<MovieEntity> Movies { get; } = new();



        public GuestDto ToDto()
        {
            var result = new GuestDto()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
            };

            for(int i = 0; i < Relations.Count; i++)
            {
                result.Movies.Add(new MovieSimplifiedDto()
                {
                    Name = Movies[i].Name,
                    ReleaseDate = Movies[i].ReleaseDate,
                    Id = Movies[i].Id,
                    Role = (RoleDto)Relations[i].Role
                });
            }

            return result;
        }
    }
}
