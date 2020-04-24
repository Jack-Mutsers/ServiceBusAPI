using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logics
{
    public class TopicCreator
    {
        public TopicData CreateNewTopic()
        {
            TopicData data = new TopicData();

            data.connectionString = "Endpoint=sb://fontysaquadis.servicebus.windows.net/;SharedAccessKeyName=fullcontroll;SharedAccessKey=5aT8daAKDusPqvesKYeWa2Y9GbTB8rmmh6lVVzS1MaU=;";
            data.topic = "nonsessionchat";
            //data.subscription = Subscriptions.ChannelOne;

            return data;
        }

    }
}
