using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Message
{
   public class CreateMessageDTO
    {
        public Guid ReceiverId { get; set; }
        public string Text { get; set; }
    }
}
