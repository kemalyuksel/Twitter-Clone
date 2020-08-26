using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Dto.DTOs.MessageDtos
{
    public class MessageAddDto
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; } = false;
        public DateTime PostedTime { get; set; } = DateTime.Now;

        public int RefId { get; set; }

        public int AppUserId { get; set; }

    }
}
