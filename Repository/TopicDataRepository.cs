using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TopicDataRepository : RepositoryBase<TopicData>, ITopicDataRepository
    {
        public TopicDataRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateTopic(TopicData topicData)
        {
            Create(topicData);
        }

        public void DeleteTopic(TopicData topicData)
        {
            Delete(topicData);
        }

        public TopicData GetTopicDataById(int Topic_id)
        {
            return FindByCondition(t => t.id == Topic_id).FirstOrDefault();
        }

        public void UpdateTopic(TopicData topicData)
        {
            Update(topicData);
        }
    }
}
