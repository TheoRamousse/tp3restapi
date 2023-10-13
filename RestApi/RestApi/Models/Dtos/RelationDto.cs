using RestApi.Models.Entities;

namespace RestApi.Models.Dtos
{
    public class RelationDto : IDto<RelationEntity>
    {
        public GuestDto Guest { get; set; }
        public MovieDto Movie { get; set; }
        public RoleDto Role { get; set; }

        public RelationEntity ToEntity()
        {
            return new RelationEntity()
            {
                GuestsId = (int)Guest.Id,
                MoviesId = (int)Movie.Id,
                Role = ((int)Role)
            };
        }
    }
}
