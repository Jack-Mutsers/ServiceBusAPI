using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class TopicDataForCreationDto
    {
        public string connectionString { get; set; }
        public string topic { get; set; }
        public string sessionCode { get; set; }
    }
}
