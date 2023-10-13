using RestApi.Models.Dtos;

namespace RestApi.Models.Entities
{
    public class MovieEntity: IEntity<MovieDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<GuestEntity> Guests { get; set; }

        public MovieDto ToDto()
        {
            return new MovieDto(this.Id)
            {
                Name = this.Name,
                Description = this.Description,
                Guests = this.Guests.Select(g => g.ToDto()).ToList()
            };
        }
    }
}
