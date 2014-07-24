using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActiveMQHandler;
namespace QueuesPerformanceTest
{
    public partial class frmReadActiveMQ : Form
    {
        public frmReadActiveMQ()
        {
            InitializeComponent();
        }

        private async void btnListQueue_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Text = "";
            ActiveMQReader r = new ActiveMQReader(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);
            StringBuilder s = new StringBuilder();

            TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
            List<Tuple<string, string>> messages = r.ListQueue();
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
            ActiveMQReader r = new ActiveMQReader(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);
            StringBuilder s = new StringBuilder();

            TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
            List<Tuple<string, string>> messages = r.ReadQueue();
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

        private void btnPeek_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Text = "";
            if (txtId.Text.Trim() != String.Empty)
            {
                ActiveMQReader r = new ActiveMQReader(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);
                StringBuilder s = new StringBuilder();

                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                string message = r.PeekMessage(txtId.Text.Trim());
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

        private void btnRead_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Text = "";
            ActiveMQReader r = new ActiveMQReader(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);
            StringBuilder s = new StringBuilder();

            TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
            Tuple<string, string> message = r.ReadMessage(txtId.Text.Trim());
            if (message.Item1 != null)
            {
                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
                s.Append("=================================\r\n");
                s.Append("READING MESSAGE: " + message.Item1 + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Inicio: " + inicio.ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Fim: " + fim.ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Tempo Total: " + (fim - inicio).ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append(message.Item2);
                txtResult.Text = s.ToString();
            }

            label1.Text = "Completed";

        }
    }
}
