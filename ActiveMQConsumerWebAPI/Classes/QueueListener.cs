using ActiveMQHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace ActiveMQConsumerWebAPI.Classes
{
    public class QueueListener
    {
        ActiveMQListener _activeMQListener;

        public QueueListener()
        {
            _activeMQListener = new ActiveMQListener(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"],100);
        }

        public void StartListen()
        {
            _activeMQListener.OnMessageArrived += OnMessageArrived;
            _activeMQListener.StartListen("");
        }

        public void StopListen()
        {
            _activeMQListener.OnMessageArrived -= OnMessageArrived;
            _activeMQListener.Close();
        }

        private void OnMessageArrived(Tuple<string, string, TimeSpan> tMessage)
        {
            Thread.Sleep(int.Parse(System.Configuration.ConfigurationManager.AppSettings["SleepTime"]));

            Debug.Print(tMessage.Item1 + "at " + tMessage.Item3.ToString("hhmmssfff"));

            //System.Diagnostics.Debug.WriteLine(tMessage.Item1 + "at " + tMessage.Item3.ToString("hhmmssfff"));

            //FileHandler.FileHandler f = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);
            //f.WriteTask(tMessage.Item2, tMessage.Item1 + "_" + tMessage.Item3.ToString("hhmmssfff") + ".txt");
        }

    }
}