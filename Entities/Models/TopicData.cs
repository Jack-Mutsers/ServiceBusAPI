using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("topicdata")]
    public class TopicData
    {
        public int id { get; set; }
        public string connectionString { get; set; }
        public string topic { get; set; }

        public string sessionCode { get; set; }
        public SessionData sessionData { get; set; }

    }
}
