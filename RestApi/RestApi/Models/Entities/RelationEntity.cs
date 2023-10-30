using Microsoft.EntityFrameworkCore;
using RestApi.Models.Dtos;

namespace RestApi.Models.Entities
{
    [PrimaryKey(nameof(GuestId), nameof(MovieId))]
    public class RelationEntity
    {
        public int GuestId { get; set; }
        public int MovieId { get; set; }

        public GuestEntity Guest { get; set; }
        public MovieEntity Movie { get; set; }

        public int Role { get; set; }

    }
}
