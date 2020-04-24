using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("sessiondata")]
    public class SessionData
    {
        [Key]
        public int id { get; set; }
        public bool active { get; set; } = true;

        [Required(ErrorMessage = "session code is required")]
        public string session_code { get; set; }
        public TopicData topicData { get; set; }

        public ICollection<Player> players { get; set; }
    }
}
