using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SessionDataRepository : RepositoryBase<SessionData>, ISessionDataRepository
    {
        public SessionDataRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateSession(SessionData session)
        {
            Create(session);
        }

        public void DeleteSession(SessionData session)
        {
            Delete(session);
        }

        public SessionData GetBySessionCode(string session_code)
        {
            return FindByCondition(s => s.session_code == session_code).FirstOrDefault();
        }

        public SessionData GetBySessionCodeWithDetails(string session_code)
        {
            return FindByCondition(s => s.session_code == session_code).Include(s => s.players).Include(s => s.topicData).FirstOrDefault();
        }

        public SessionData GetBySessionDataId(int session_id)
        {
            return FindByCondition(s => s.id == session_id).FirstOrDefault();
        }

        public int GetPlayerCount(string session_code)
        {
            return FindByCondition(s => s.session_code == session_code).Include(s => s.players).Include(s => s.topicData).FirstOrDefault().players.Count();
        }

        public void UpdateSession(SessionData session)
        {
            Update(session);
        }

        public bool ValidateIfActive(string sessionCode)
        {
            return FindByCondition(s => s.session_code == sessionCode && s.active == true).Count() > 0 ? true : false;
        }
    }
}
