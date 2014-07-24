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
    public abstract class ActiveMQClient
    {
        protected Uri _connecturi;
        protected IConnectionFactory _factory ;
        protected string _queueName;
        protected string _queueUrl;

        public ActiveMQClient(string queueUrl, string queueName)
        {
            _queueUrl = queueUrl;
            _queueName = queueName;
            _connecturi = new Uri("activemq:tcp://" + queueUrl + "?keepAlive=true&randomize=false&wireFormat.maxInactivityDuration=0&nms.prefetchPolicy.all=1000");
            _factory = new NMSConnectionFactory(_connecturi);
        }
    }
}
