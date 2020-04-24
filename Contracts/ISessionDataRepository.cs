using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ISessionDataRepository
    {
        bool ValidateIfActive(string sessionCode);
        int GetPlayerCount(string session_code);
        SessionData GetBySessionDataId(int session_id);
        SessionData GetBySessionCode(string session_code);
        SessionData GetBySessionCodeWithDetails(string session_code);
        void CreateSession(SessionData session);
        void UpdateSession(SessionData session);
        void DeleteSession(SessionData session);
    }
}
