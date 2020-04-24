using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SessionDataForCreationDto
    {
        public bool active { get; set; } = true;
        public string session_code { get; set; }
    }
}
