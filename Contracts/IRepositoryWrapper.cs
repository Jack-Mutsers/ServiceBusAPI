using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IPlayerRepository Player { get; }
        ISessionDataRepository SessionData { get; }
        ITopicDataRepository TopicData { get; }

        void Save();
    }
}
