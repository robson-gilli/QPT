using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;
using System.Collections;

namespace ActiveMQHandler
{
    public class ActiveMQReader: ActiveMQClient
    {

        public ActiveMQReader(string queueUrl, string queueName)
            : base(queueUrl, queueName)
        {
        }

        public async Task<Tuple<string, string>> ReadMessageAsync(string messageId)
        {
            Tuple<string, string> ret = null;
            Task t = Task.Run(() =>
                {
                    ret = ReadMessage(messageId);
                });
            await t;
            return ret;
        }

        //public static Tuple<string, string> ReadMessage(string messageId, IMessageConsumer consumer)
        //{

        //    Tuple<string, string> message;
        //    // Consume a message
        //    ITextMessage textMessage = consumer.Receive(new TimeSpan(0, 0, 2)) as ITextMessage;

        //    if (textMessage == null)
        //    {
        //        message = Tuple.Create<string, string>(null, "No messages found");
        //    }
        //    else
        //    {
        //        message = Tuple.Create<string, string>(textMessage.NMSCorrelationID, textMessage.Text);
        //    }

        //    return message;
        //}


        public Tuple<string,string>ReadMessage(string messageId)
        {
            ActiveMQConnectionManager cm = new ActiveMQConnectionManager(_queueUrl, _queueName);
            Tuple<string,string> message;

            ActiveMQHandler.ActiveMQConnectionManager.ConnectionData cd = cm.getConnection();
            IConnection connection = cd.iconnection;
            try
            {
                //using (IConnection connection = _factory.CreateConnection())
                using (ISession session = connection.CreateSession())
                {
                    IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);

                    string selector = messageId == string.Empty ? "" : "JMSCorrelationID = '" + messageId + "'";
                    using (IMessageConsumer consumer = selector.Equals(string.Empty) ? session.CreateConsumer(destination) : session.CreateConsumer(destination, selector, false))
                    {
                        // Start the connection so that messages will be processed.
                        connection.Start();

                        // Consume a message
                        ITextMessage textMessage = consumer.Receive(new TimeSpan(0, 0, 2)) as ITextMessage;

                        if (textMessage == null)
                        {
                            message = Tuple.Create<string, string>(null, "No messages found");
                        }
                        else
                        {
                            message = Tuple.Create<string, string>(textMessage.NMSCorrelationID, textMessage.Text);
                        }

                        connection.Stop();
                    }
                }
            }
            finally
            {
                cm.ReleaseConnection(cd);
            }
            return message;
        }

        public async Task<string> PeekMessageAsync(string messageId)
        {
            string ret = "";
            Task t = Task.Run(() =>
            {
                ret = PeekMessage(messageId);
            });
            await t;
            return ret;
        }
        public string PeekMessage(string messageId)
        {
            string message = "";
            using (IConnection connection = _factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);

                // Start the connection so that messages will be processed.
                connection.Start();

                IQueueBrowser queueBrowser = messageId.Equals(string.Empty) ? session.CreateBrowser((IQueue)destination) : session.CreateBrowser((IQueue)destination, "JMSCorrelationID = '" + messageId + "'");
                IEnumerator messages = queueBrowser.GetEnumerator();
                if (messages.MoveNext())
                {
                    ITextMessage m = messages.Current as ITextMessage;
                    message = m.Text;
                }
                else                
                {
                    message = "No messages found.";
                }

                connection.Close();
                
            }
            return message;
        }

        public List<Tuple<string, string>> ListQueue()
        {
            List<Tuple<string, string>> messages = new List<Tuple<string, string>>();

            using (IConnection connection = _factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);

                // Start the connection so that messages will be processed.
                connection.Start();

                IQueueBrowser queueBrowser = session.CreateBrowser((IQueue)destination);
                IEnumerator msgs = queueBrowser.GetEnumerator();
                while (msgs.MoveNext())
                {
                    IMessage imessage = (IMessage)msgs.Current;
                    ITextMessage m = imessage as ITextMessage;
                    Tuple<string, string> tm = Tuple.Create(m.NMSCorrelationID, new TimeSpan(DateTime.Now.Ticks).ToString());
                    messages.Add(tm);
                }

                connection.Close();
            }
            return messages;
        }

        public async Task<List<Tuple<string, string>>> ListQueueAsync()
        {
            List<Tuple<string, string>> messages = new List<Tuple<string, string>>();

            using (IConnection connection = _factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);

                // Start the connection so that messages will be processed.
                connection.Start();

                IQueueBrowser queueBrowser = session.CreateBrowser((IQueue)destination);
                IEnumerator msgs = queueBrowser.GetEnumerator();
                List<Task> tList = new List<Task>();
                while (msgs.MoveNext())
                {
                    IMessage message = (IMessage)msgs.Current;
                    tList.Add(Task.Run(() =>
                    {
                        ITextMessage m = message as ITextMessage;
                        Tuple<string, string> tm = Tuple.Create(m.NMSCorrelationID, new TimeSpan(DateTime.Now.Ticks).ToString());
                        messages.Add(tm);
                    }));
                }

                await Task.WhenAll(tList.ToArray());
                connection.Close();
                
            }
            return messages;
        }

        public async Task<List<Tuple<string, string>>> ReadQueueAsync()
        {
            List<Tuple<string, string>> messages = new List<Tuple<string, string>>();

            using (IConnection connection = _factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);

                using (IMessageConsumer consumer = session.CreateConsumer(destination))
                {
                    // Start the connection so that messages will be processed.
                    connection.Start();


                    IQueueBrowser queueBrowser = session.CreateBrowser((IQueue)destination);
                    IEnumerator msgs = queueBrowser.GetEnumerator();
                    List<Task> tList = new List<Task>();
                    while (msgs.MoveNext())
                    {
                        IMessage message = (IMessage)msgs.Current;
                        tList.Add(Task.Run(() =>
                        {
                            ITextMessage m = consumer.Receive<ITextMessage>(new TimeSpan(0, 0, 2));
                            Tuple<string, string> tm = Tuple.Create(m.NMSCorrelationID, new TimeSpan(DateTime.Now.Ticks).ToString());
                            messages.Add(tm);
                        }));
                    }

                    await Task.WhenAll(tList.ToArray());
                    connection.Close();
                }
            }

            return messages;
        }

        public List<Tuple<string, string>> ReadQueue()
        {
            List<Tuple<string, string>> messages = new List<Tuple<string, string>>();

            using (IConnection connection = _factory.CreateConnection())
            using (ISession session = connection.CreateSession())
            {
                IDestination destination = SessionUtil.GetDestination(session, "queue://" + _queueName);

                using (IMessageConsumer consumer = session.CreateConsumer(destination))
                {
                    // Start the connection so that messages will be processed.
                    connection.Start();

                    IMessage message;
                    while ((message = consumer.Receive(new TimeSpan(0, 0, 0, 2)) as ITextMessage) != null)
                    {
                        Tuple<string, string> tm = Tuple.Create(message.NMSCorrelationID, new TimeSpan(DateTime.Now.Ticks).ToString());
                        messages.Add(tm);
                    }
                    connection.Close();
                }
            }
            return messages;
        }


    }
}
