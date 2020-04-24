using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ITopicDataRepository
    {
        TopicData GetTopicDataById(int Topic_id);
        void CreateTopic(TopicData topicData);
        void UpdateTopic(TopicData topicData);
        void DeleteTopic(TopicData topicData);
    }
}
