using ActiveMQHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Threading;

namespace QueuesPerformanceTest
{
    public partial class frmListenActiveMQ : Form
    {
        System.Timers.Timer timer;
        ActiveMQListener _activeMQListener;

        public frmListenActiveMQ()
        {
            InitializeComponent();
        }

        private async void btnListen_Click(object sender, EventArgs e)
        {
            _activeMQListener = new ActiveMQListener(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);

            _activeMQListener.OnMessageArrived += OnMessageArrived;
            _activeMQListener.StartListen("", 10);

            //timer = new System.Timers.Timer(1000);
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            //timer.Enabled = true;
        }

        private void OnMessageArrived(Tuple<string, string, TimeSpan> tMessage)
        {

            FileHandler.FileHandler f = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);
            f.WriteTask(tMessage.Item2, tMessage.Item1 + "_" + DateTime.Now.Ticks.ToString());

            //Tuple<string, string> tMessage = ActiveMQReader.ReadMessage(message.Item1, _activeMQListener.Consumer);
            //Tuple<string, string> tMessage = r.ReadMessage(messageID.Item1);

        }

        void OnTimedEvent(object source, ElapsedEventArgs e)
        {



        //    StringBuilder s = new StringBuilder();
        //    ActiveMQReader r = new ActiveMQReader(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);
        //    List<Tuple<string, string>> messages = r.ListQueue();
        //    if (messages.Count() > 0)
        //    {
        //        TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
        //        s.Append("=================================\r\n");
        //        s.Append("LISTENING...\r\n");
        //        s.Append("=================================\r\n");

        //        foreach (Tuple<string, string> t in messages)
        //        {
        //            s.Append(t.Item1 + " - at " + t.Item2 + "\r\n");
        //        }

        //        this.Invoke((MethodInvoker)delegate()
        //        {
        //            txtResult.Text = s.ToString();
        //        });
        //    }
        //    else
        //    {
        //        this.Invoke((MethodInvoker)delegate()
        //        {
        //            txtResult.Text = "";
        //        });
        //    }
        }



    }
}
