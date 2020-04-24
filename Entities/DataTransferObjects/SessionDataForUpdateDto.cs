using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SessionDataForUpdateDto
    {
        public int id { get; set; }
        public bool active { get; set; } = true;
        public string session_code { get; set; }
    }
}
