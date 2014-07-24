using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuesPerformanceTest
{
    public partial class frmReadMSMQ : Form
    {
        public frmReadMSMQ()
        {
            InitializeComponent();
        }

        private async void btnListQueue_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Text = "";
            MSMQHandler.MSMQHandler mh = new MSMQHandler.MSMQHandler(System.Configuration.ConfigurationManager.AppSettings["MSMQPath"]);
            StringBuilder s = new StringBuilder();

            TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
            List<Tuple<string, string>> messages = await mh.ListQueueAsync();
            if (messages.Count() > 0)
            {
                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
                s.Append("=================================\r\n");
                s.Append("LISTING...\r\n");
                s.Append("=================================\r\n");
                s.Append("Inicio: " + inicio.ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Fim: " + fim.ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Tempo Total: " + (fim - inicio).ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Total Msg: " + messages.Count() + "\r\n");
                s.Append("=================================\r\n");

                foreach (Tuple<string, string> t in messages)
                {
                    s.Append(t.Item1 + " - at " + t.Item2 + "\r\n");
                }
                txtResult.Text = s.ToString();
            }
            label1.Text = "Completed";
        }

        private async void btnReadAll_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Text = "";
            MSMQHandler.MSMQHandler mh = new MSMQHandler.MSMQHandler(System.Configuration.ConfigurationManager.AppSettings["MSMQPath"]);
            StringBuilder s = new StringBuilder();

            TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
            List<Tuple<string, string>> messages = await mh.ReadQueueAsync();
            if (messages.Count() > 0)
            {
                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
                s.Append("=================================\r\n");
                s.Append("READING...\r\n");
                s.Append("=================================\r\n");
                s.Append("Inicio: " + inicio.ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Fim: " + fim.ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Tempo Total: " + (fim - inicio).ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Total Msg: " + messages.Count() + "\r\n");
                s.Append("=================================\r\n");

                foreach (Tuple<string, string> t in messages)
                {
                    s.Append(t.Item1 + " - at " + t.Item2 + "\r\n");
                }
                txtResult.Text = s.ToString();
            }
            label1.Text = "Completed";
        }

        private async void btnPeek_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Text = "";
            if (txtId.Text.Trim() != String.Empty)
            {
                MSMQHandler.MSMQHandler mh = new MSMQHandler.MSMQHandler(System.Configuration.ConfigurationManager.AppSettings["MSMQPath"]);
                StringBuilder s = new StringBuilder();

                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                string message = await mh.PeekMessage(txtId.Text.Trim());
                if (message != String.Empty)
                {
                    TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
                    s.Append("=================================\r\n");
                    s.Append("PEEKING MESSAGE: " + txtId.Text.Trim() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Inicio: " + inicio.ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Fim: " + fim.ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Tempo Total: " + (fim - inicio).ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append(message);
                    txtResult.Text = s.ToString();
                }
            }
            label1.Text = "Completed";
        }

        private async void btnRead_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Text = "";
            if (txtId.Text.Trim() != String.Empty)
            {
                MSMQHandler.MSMQHandler mh = new MSMQHandler.MSMQHandler(System.Configuration.ConfigurationManager.AppSettings["MSMQPath"]);
                StringBuilder s = new StringBuilder();

                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                string message = await mh.ReadMessage(txtId.Text.Trim());
                if (message != String.Empty)
                {
                    TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
                    s.Append("=================================\r\n");
                    s.Append("READING MESSAGE: " + txtId.Text.Trim() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Inicio: " + inicio.ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Fim: " + fim.ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Tempo Total: " + (fim - inicio).ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append(message);
                    txtResult.Text = s.ToString();
                }
            }
            label1.Text = "Completed";
        }
    }
}
