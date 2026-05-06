using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.User
{
    public class UpdateUserDTO
    {
        public int Age { get; set; }

        public string Bio { get; set; }

        public string City { get; set; }

        public string Fullname { get; set; }

        public bool Lonely { get; set; }

        public string Interests { get; set; }

    }
}
