using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Dto.DTOs.TweetDtos
{
    public class TweetAdddto
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public DateTime PostedTime { get; set; }

        public int AppUserId { get; set; }

    }
}
