using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.User
{
    public class UserAuthDetailsDTO
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
