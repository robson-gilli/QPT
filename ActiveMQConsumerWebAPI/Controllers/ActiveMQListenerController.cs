using ActiveMQHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActiveMQConsumerWebAPI.Controllers
{
    public class ActiveMQListenerController : ApiController
    {
        //private static Classes.MessageListener _l;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Route("api/startlisten")]
        [HttpGet]
        public void StartListen()
        {
            //_l = new Classes.MessageListener();
            //_l.StartListen();
            Classes.StaticQueueListener.StartListen();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Route("api/stoplisten")]
        [HttpGet]
        public void StopListen()
        {
            //_l.StopListen();
            Classes.StaticQueueListener.StopListen();
        }

    }
}
