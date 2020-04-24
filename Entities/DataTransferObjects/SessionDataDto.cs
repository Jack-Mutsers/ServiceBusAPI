using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SessionDataDto
    {
        public int id { get; set; }
        public bool active { get; set; } = true;
        public string session_code { get; set; }
        public TopicDataDto topicData { get; set; }
        public IEnumerable<PlayerDto> players { get; set; }
    }
}
