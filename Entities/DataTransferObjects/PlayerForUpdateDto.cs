using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class PlayerForUpdateDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public int orderNumber { get; set; }
        public int type { get; set; }
        public int session_id { get; set; }
    }
}
