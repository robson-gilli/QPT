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
    public class ActiveMQWriter:ActiveMQClient
    {

        public ActiveMQWriter(string queueUrl, string queueName)
            : base(queueUrl, queueName)
        {
        }

        /// <summary>
        ///     http://activemq.apache.org/nms/nms-simple-synchornous-consumer-example.html
        /// </summary>
        /// <param name="message"></param>
        /// <param name="id"></param>
        public void WriteMessageToQueue(string message, string id, bool persist)
        {
            ActiveMQConnectionManager cm = new ActiveMQConnectionManager(_queueUrl, _queueName);
            ActiveMQHandler.ActiveMQConnectionManager.ConnectionData cd = cm.getConnection();
            IConnection connection = cd.iconnection;
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);
                using (IMessageProducer producer = session.CreateProducer(destination))
                {
                    // Start the connection so that messages will be processed.
                    connection.Start();
                    if (persist)
                        producer.DeliveryMode = MsgDeliveryMode.Persistent;
                    else
                        producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

                    // Send a message
                    ITextMessage request = session.CreateTextMessage(message);
                    request.NMSCorrelationID = id;
                    request.NMSTimeToLive = new TimeSpan(0, 5, 0);
                    producer.Send(request);
                    connection.Stop();
                }
            }
            cm.ReleaseConnection(cd);
        }

        public async Task WriteMessageListToQueueAsync(List<Tuple<string, string>> messageList, bool persist)
        {
            using (IConnection connection = _factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);
                using (IMessageProducer producer = session.CreateProducer(destination))
                {
                    // Start the connection so that messages will be processed.
                    connection.Start();
                    if (persist)
                        producer.DeliveryMode = MsgDeliveryMode.Persistent;
                    else
                        producer.DeliveryMode = MsgDeliveryMode.NonPersistent;


                    ITextMessage request;
                    List<Task> tList = new List<Task>();
                    foreach (Tuple<string, string> tuple in messageList)
                    {
                        Tuple<string, string> t = Tuple.Create(tuple.Item1, tuple.Item2);

                        tList.Add(Task.Run(() =>
                        {
                            // Send a message
                            request = session.CreateTextMessage(t.Item2);
                            request.NMSCorrelationID = t.Item1;
                            request.NMSTimeToLive = new TimeSpan(0, 5, 0);
                            producer.Send(request);

                        }));
                    }
                    await Task.WhenAll(tList.ToArray());

                    connection.Close();
                }
            }
        }

        public void WriteMessageListToQueue(List<Tuple<string, string>> messageList, bool persist)
        {
            try
            {
                ActiveMQConnectionManager cm = new ActiveMQConnectionManager(_queueUrl, _queueName);
                ActiveMQHandler.ActiveMQConnectionManager.ConnectionData cd = cm.getConnection();
                IConnection connection = cd.iconnection;
                using (ISession session = connection.CreateSession())
                {
                    IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);
                    using (IMessageProducer producer = session.CreateProducer(destination))
                    {
                        // Start the connection so that messages will be processed.
                        connection.Start();
                        if (persist)
                            producer.DeliveryMode = MsgDeliveryMode.Persistent;
                        else
                            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;


                        ITextMessage request;
                        List<Task> tList = new List<Task>();
                        foreach (Tuple<string, string> t in messageList)
                        {
                            // Send a message
                            request = session.CreateTextMessage(t.Item2);
                            request.NMSCorrelationID = t.Item1;
                            request.NMSTimeToLive = new TimeSpan(0, 5, 0);
                            producer.Send(request);
                        }

                        connection.Stop();
                    }
                }
                cm.ReleaseConnection(cd);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        
    }
}
