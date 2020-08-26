using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dto.DTOs.MessageDtos
{
    public class UserMessagesDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;

        public int RefId { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
