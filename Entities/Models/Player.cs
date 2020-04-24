using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("player")]
    public class Player
    {
        public Guid id { get; set; }

        [Required(ErrorMessage = "player name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "player order is required")]
        public int orderNumber { get; set; }
        
        [Required(ErrorMessage = "player type is required")]
        public int type { get; set; }

        [ForeignKey(nameof(sessionData))]
        public int session_id { get; set; }

        public SessionData sessionData { get; set; }
    }
}
