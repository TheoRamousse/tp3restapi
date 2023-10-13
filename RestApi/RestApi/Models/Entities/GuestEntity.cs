namespace RestApi.Models.Entities
{
    public class GuestEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int Role { get; set; }
    }
}
