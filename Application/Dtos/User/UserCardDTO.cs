namespace Application.Dtos.User
{
    public class UserCardDTO
    {
        public Guid Id { get; set; }

        public string Fullname { get; set; }

        public int Age { get; set; }

        public string Bio { get; set; }

        public string City { get; set; }

        public string Interests { get; set; }
    }
}