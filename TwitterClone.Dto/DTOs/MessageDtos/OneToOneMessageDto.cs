using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.Dto.DTOs.MessageDtos
{
    public class OneToOneMessageDto
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public int RefId { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


    }
}
