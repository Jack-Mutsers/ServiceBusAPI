using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPlayerRepository _player;
        private ISessionDataRepository _sessionData;
        private ITopicDataRepository _topicData;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IPlayerRepository Player
        {
            get
            {
                if (_player == null)
                {
                    _player = new PlayerRepository(_repoContext);
                }

                return _player;
            }
        }

        public ISessionDataRepository SessionData
        {
            get
            {
                if (_sessionData == null)
                {
                    _sessionData = new SessionDataRepository(_repoContext);
                }

                return _sessionData;
            }
        }

        public ITopicDataRepository TopicData
        {
            get
            {
                if (_topicData == null)
                {
                    _topicData = new TopicDataRepository(_repoContext);
                }

                return _topicData;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}