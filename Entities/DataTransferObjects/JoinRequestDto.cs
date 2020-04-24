using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class JoinRequestDto
    {
        PlayerForCreationDto player { get; set; }
        string session_Code { get; set; }
    }
}
