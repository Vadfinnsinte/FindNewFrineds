using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.Dtos.User
{
    public class ReadUserDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Age { get; set; }

        public string Bio { get; set; }

        public string City { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string Fullname { get; set; }

        public bool Lonely { get; set; }

        public string Interests { get; set; }

    }
}
