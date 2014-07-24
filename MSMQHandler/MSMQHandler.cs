using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQHandler
{
    public class MSMQHandler
    {
        private string _qPath;
        

        public MSMQHandler(string queuePath)
        {
            _qPath = queuePath;
        }

        private MessageQueue GetQueue(string path)
        {
            if (!MessageQueue.Exists(_qPath))
                MessageQueue.Create(_qPath);

            return  new MessageQueue(path);
        }

        public void WriteToQueue(string content, string label, int index)
        {
            MessageQueue q = GetQueue(_qPath);
            try
            {
                Message m = new Message();
                m.Label = label;
                m.Body = content;
                m.AppSpecific = index;

                q.Send(m);
            }
            finally
            {
                q.Close();
            }
        }

        public async Task WriteToQueueAsync(string content, string label, int index)
        {
            MessageQueue q = GetQueue(_qPath);
            try
            {
                await Task.Run(() =>
                {
                    Message m = new Message();
                    m.Label = label;
                    m.Body = content;
                    m.AppSpecific = index;

                    q.Send(m);
                });
            }
            finally
            {
                q.Close();
            }
        }

        public async Task PurgeAsync()
        {
            await Task.Run(() =>
            {
                MessageQueue q = GetQueue(_qPath);
                q.Purge();
            });
        }

        public async Task<List<Tuple<string, string>>> ReadQueueAsync()
        {
            List<Tuple<string, string>> messages= new List<Tuple<string, string>> ();
            MessageQueue q = GetQueue(_qPath);

            try
            {
                await Task.Run(() =>
                {
                    MessageEnumerator en = q.GetMessageEnumerator2();
                    while (en.MoveNext())
                    {
                        Message msg = q.ReceiveById(en.Current.Id);
                        Tuple<string, string> tm = Tuple.Create(msg.Id, new TimeSpan(DateTime.Now.Ticks).ToString());
                        messages.Add(tm);
                    }
                });
            }
            catch (Exception e) 
            {
                throw e;
            }
            finally
            {
                q.Close();
            }
            return messages;
        }

        public async Task<List<Tuple<string, string>>> ListQueueAsync()
        {
            List<Tuple<string, string>> messages = new List<Tuple<string, string>>();

            MessageQueue q = GetQueue(_qPath);
            try
            {
                MessageEnumerator en = q.GetMessageEnumerator2();

                await Task.Run(() =>
                {
                    Message[] msgs = q.GetAllMessages();
                    foreach (Message m in msgs)
                    {
                        Tuple<string, string> tm = Tuple.Create(m.Id, new TimeSpan(DateTime.Now.Ticks).ToString());
                        messages.Add(tm);
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                q.Close();
            }
            return messages;
        }

        public async Task<string> PeekMessage(string messageId)
        {
            string message = "";
            MessageQueue q = GetQueue(_qPath);
            try
            {
                await Task.Run(() =>
                {
                    //Open an existing queue
                    MessageEnumerator en = q.GetMessageEnumerator2();
                    Message msg = q.PeekById(messageId);

                    message = GetMessageBody(msg);
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                q.Close();
            }

            return message;
        }

        public async Task<string> ReadMessage(string messageId)
        {
            string message = "";
            MessageQueue q = GetQueue(_qPath);
            try
            {
                await Task.Run(() =>
                {
                    //Open an existing queue
                    MessageEnumerator en = q.GetMessageEnumerator2();
                    Message msg = q.ReceiveById(messageId);

                    message = GetMessageBody(msg);
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                q.Close();
            }

            return message;
        }

        private string GetMessageBody(Message msg)
        {
            StreamReader sr = new StreamReader(msg.BodyStream);
            string ms = "";
            while (sr.Peek() >= 0)
            {
                ms += sr.ReadLine();
            }

            return ms;
        }

    }
}
