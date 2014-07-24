using ActiveMQHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ActiveMQConsumerWebAPI.Classes
{
    public static class StaticQueueListener
    {
        static ActiveMQListener _activeMQListener;
        static object _mutex = new object();
        static bool _isListening;
        static int _msgCount;


        static StaticQueueListener()
        {
            lock (_mutex)
            {
                _msgCount = 0;
                _isListening = false;
            }
        }

        public static void StartListen()
        {
            if (!_isListening)
            {
                lock (_mutex)
                {
                    if (!_isListening)
                    {
                        _isListening = true;
                        _activeMQListener = new ActiveMQListener(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"],100);
                        _activeMQListener.OnMessageArrived += OnMessageArrived;
                        _activeMQListener.StartListen("");
                    }
                }
            }
        }

        public static void StopListen()
        {
            if (_isListening)
            {
                lock (_mutex)
                {
                    if (_isListening)
                    {
                        _msgCount = 0;
                        _isListening = false;
                        _activeMQListener.Close();
                        _activeMQListener.OnMessageArrived -= OnMessageArrived;
                        _activeMQListener = null;
                    }
                }
            }
        }

        private static void OnMessageArrived(Tuple<string, string, TimeSpan> tMessage)
        {
            Interlocked.Increment(ref _msgCount);

            int m = _msgCount;
            Task.Run(()=>
                {
                    Thread.Sleep(int.Parse(System.Configuration.ConfigurationManager.AppSettings["SleepTime"]));

                    Debug.Print(tMessage.Item1 + " at " + tMessage.Item3.ToString("hhmmssfff") + ". Total of " + m + " messages read.");
                });
        }
    }
}