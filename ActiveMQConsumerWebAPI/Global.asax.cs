using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ActiveMQHandler;

namespace ActiveMQConsumerWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //ActiveMQListener _activeMQListener;
        //Classes.MessageListener _messageListener;
        //private bool disposed = false;
        //private bool isFirst = true;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //_messageListener = new Classes.MessageListener();

            //if (disposed || isFirst)
            //{
            //    isFirst = false;
            //    _activeMQListener = new ActiveMQListener(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);
            //}
            //_activeMQListener.OnMessageArrived += _messageListener.Listen;
            //_activeMQListener.StartListen("");
        }

        //public override void Dispose()
        //{
        //    disposed = true;
        //    if (_activeMQListener != null)
        //        _activeMQListener.Close();
        //    base.Dispose();
        //}

        protected void Application_End()
        {

            Classes.StaticQueueListener.StopListen();
        }
    }
}
