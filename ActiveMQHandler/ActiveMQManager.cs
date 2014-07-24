using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;

namespace ActiveMQHandler
{
    public class ActiveMQManager:ActiveMQClient
    {
        public ActiveMQManager(string queueUrl, string queueName)
            : base(queueUrl, queueName) { }

        public Task DeleteQueueAsync()
        {
            return Task.Run(() =>
                {
                    DeleteQueue();
                });
        }

        public void DeleteQueue()
        {
            using (IConnection connection = _factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                session.DeleteQueue(_queueName);
            }
        }

        public Task CreateQueueAsync()
        {
            return Task.Run(() =>
                {
                    CreateQueue();
                });
        }
        public void CreateQueue()
        {
            ActiveMQWriter w = new ActiveMQWriter(this._queueUrl, this._queueName);
            w.WriteMessageToQueue("DEL", "__DEL__", false);

            ActiveMQReader r = new ActiveMQReader(this._queueUrl, this._queueName);
            r.ReadMessage("__DEL__");
        }
    }
}
