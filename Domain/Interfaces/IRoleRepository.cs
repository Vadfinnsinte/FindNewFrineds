using Domain.Models.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{

        public interface IRoleRepository
        {
            Task<Role?> GetByNameAsync(string name);
        }
    
}
