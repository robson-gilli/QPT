using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;
using System.Collections;
using System.Threading;

namespace ActiveMQHandler
{
    public class ActiveMQListener: ActiveMQClient, IDisposable
    {
        private bool isDisposed = false;
        private int _maximumConcurrency;
        private int _currentConcurrency;
        private AutoResetEvent _concurrencyEvent;
        private bool isListening;

        protected IConnection _connection;
        protected ISession _session;
        protected IDestination _destination;
        protected IMessageConsumer _consumer;

        public IMessageConsumer Consumer
        {
            get { return _consumer; }
        }
        public delegate void MessageArrived(Tuple<string, string, TimeSpan> tuple);
        public event MessageArrived OnMessageArrived;


        public ActiveMQListener(string queueUrl, string queueName)
            : base(queueUrl, queueName) 
        {
            
            isListening = false;
        }

        public void StartListen(string selector, int maximumConcurrency)
        {
            if (!isListening)
            {
                _maximumConcurrency = maximumConcurrency;
                _concurrencyEvent = new AutoResetEvent(false);

                _connection = _factory.CreateConnection();
                _session = _connection.CreateSession();
                _destination = SessionUtil.GetDestination(_session, "queue://" + _queueName);
                _consumer = selector.Equals(string.Empty) ? _session.CreateConsumer(_destination) : _session.CreateConsumer(_destination, selector, false);

                _connection.Start();
                _consumer.Listener += new MessageListener(OnMessage);
                isListening = true;
            }
        }

        /// <summary>
        /// Cópia praticamente exata do método ITravel.Framework.ServiceBus.DispatchMessage(Message message) (solution  ITravel.Framework)
        /// </summary>
        /// <param name="tMessage"></param>
        private void OnMessage(IMessage receivedMsg)
        {
            if (this.OnMessageArrived != null)
            {
                if (_maximumConcurrency == 1)
                {
                    FireMessageArrivedEvent(receivedMsg);
                    System.Diagnostics.Debug.WriteLine("_maximumConcurrency==1 at " + DateTime.Now.ToString("hhmmssfff"));
                }
                else
                {
                    if (Interlocked.Increment(ref _currentConcurrency) > _maximumConcurrency)
                    {
                        _concurrencyEvent.WaitOne();
                        System.Diagnostics.Debug.WriteLine("Interlocked.Increment, _concurrencyEvent.WaitOne(); _current=" + _currentConcurrency + " at " + DateTime.Now.ToString("hhmmssfff"));
                    }

                    Task.Run(delegate 
                        {
                            try
                            {
                                FireMessageArrivedEvent(receivedMsg);
                                System.Diagnostics.Debug.WriteLine("ThreadPool.QueueUserWorkItem.FireMessageArrivedEvent, _current=" + _currentConcurrency + " at " + DateTime.Now.ToString("hhmmssfff"));
                            }
                            finally
                            {
                                if (Interlocked.Decrement(ref _currentConcurrency) >= _maximumConcurrency)
                                {
                                    _concurrencyEvent.Set();
                                    System.Diagnostics.Debug.WriteLine("ThreadPool.QueueUserWorkItem._concurrencyEvent.Set(), _current=" + _currentConcurrency + " at " + DateTime.Now.ToString("hhmmssfff"));

                                }
                            }
                        });
                    //ThreadPool.QueueUserWorkItem((m) =>
                    //{

                    //    try
                    //    {
                    //        FireMessageArrivedEvent((IMessage)m);
                    //        System.Diagnostics.Debug.WriteLine("ThreadPool.QueueUserWorkItem.FireMessageArrivedEvent, _current=" + _currentConcurrency + " at " + DateTime.Now.ToString("hhmmssfff"));
                    //    }
                    //    finally
                    //    {
                    //        if (Interlocked.Decrement(ref _currentConcurrency) >= _maximumConcurrency)
                    //        {
                    //            _concurrencyEvent.Set();
                    //            System.Diagnostics.Debug.WriteLine("ThreadPool.QueueUserWorkItem._concurrencyEvent.Set(), _current=" + _currentConcurrency + " at " + DateTime.Now.ToString("hhmmssfff"));

                    //        }
                    //    }

                    //}, receivedMsg);
                }
            }
        }

        private void FireMessageArrivedEvent(IMessage receivedMsg)
        {
            if (OnMessageArrived != null)
            {
                ITextMessage msg = receivedMsg as ITextMessage;
                Tuple<string, string, TimeSpan> m = Tuple.Create(receivedMsg.NMSCorrelationID, msg.Text, new TimeSpan(DateTime.Now.Ticks));
                OnMessageArrived(m);
            }
        }

        public void Close()
        {
            Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _connection.Close();
                    _connection.Dispose();

                    _session.Close();
                    _session.Dispose();

                    _consumer.Close();
                    _consumer.Listener -= new MessageListener(OnMessage);
                    _consumer.Dispose();

                    _maximumConcurrency = 0;
                    _currentConcurrency = 0;
                    _concurrencyEvent = null;

                    isDisposed = true;
                    isListening = false;
                }
            }
            
        }
    }
}
