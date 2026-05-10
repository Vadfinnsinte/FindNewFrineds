using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Events
{
    public class AdminEditEventDTO
    {
        public string Name { get; set; }
        public DateTime DateOfEvent { get; set; }

        public string City { get; set; }
        public string Adress { get; set; }
        public string Category { get; set; }
    }
}