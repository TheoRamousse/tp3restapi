using Microsoft.EntityFrameworkCore;
using RestApi.Models.Dtos;

namespace RestApi.Models.Entities
{
    [PrimaryKey(nameof(GuestsId), nameof(MoviesId))]
    public class RelationEntity
    {
        public int GuestsId { get; set; }
        public int MoviesId { get; set; }

        public int Role { get; set; }

    }
}
