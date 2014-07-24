using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ActiveMQConsumerWCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ActiveMQConsumerService : IActiveMQConsumerService, IDisposable
    {
        private int _i;
        private Classes.QueueListener _ql;
        public ActiveMQConsumerService()
        {
            _i = 0;
        }

        public string StartListen(string maxConcurrency)
        {
            int mc;

            if (int.TryParse(maxConcurrency, out mc))
            {
                if (_ql == null)
                    _ql = new Classes.QueueListener();

                _ql.StartListen(mc);

                return "OK";
            }
            else
            {
                throw new ArgumentException("'maxConcurrency' needs to be a valid integer.");
            }
        }

        public bool StopListen()
        {
            if (_ql != null)
            {
                _ql.StopListen();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int TestSingleton()
        {
            return _i++;
        }

        public void Dispose()
        {
            if (_ql != null)
            {
                _ql.StopListen();
                _ql = null;
            }
        }
        ~ActiveMQConsumerService()
        {
            if (_ql != null)
            {
                _ql.StopListen();
                _ql = null;
            }
        }
    }
}
