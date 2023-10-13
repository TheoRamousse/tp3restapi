using RestApi.Models.Dtos;

namespace RestApi.Models.Entities
{
    public class GuestEntity: IEntity<GuestDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int Role { get; set; }


        public GuestDto ToDto()
        {
            return new GuestDto(this.Id)
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
            };
        }
    }
}
