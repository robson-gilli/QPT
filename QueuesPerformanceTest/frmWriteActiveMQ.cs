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
    public partial class frmWriteActiveMQ : Form
    {
        public frmWriteActiveMQ()
        {
            InitializeComponent();
        }

        private async void btnWriteSync_Click(object sender, EventArgs e)
        {
            if (!double.IsNaN(double.Parse(txtNrThreads.Text.Trim())))
            {
                int total = Int32.Parse(txtNrThreads.Text.Trim());

                lblProcessing.Text = "Processing...";
                string message = GetMessage();

                List<Tuple<string, string>> messageList = new List<Tuple<string, string>>();
                for (int i = 0; i < total; i++)
                {
                    Tuple<string, string> tm = Tuple.Create("message_" + i.ToString(), message);
                    messageList.Add(tm);
                }
                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);

                ActiveMQWriter w = new ActiveMQWriter(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);
                w.WriteMessageListToQueue(messageList, chkPersist.Checked); ;

                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);

                txtResult.Text += "==== Async Output ==== Message size: " + cmbMessageSize.Text + " ==== # Threads: " + txtNrThreads.Text + "  \r\n";
                txtResult.Text += "Inicio: " + inicio.ToString() + "\r\n";
                txtResult.Text += "Fim: " + fim.ToString() + "\r\n";
                txtResult.Text += "Total: " + (fim - inicio).ToString() + "\r\n";

                lblProcessing.Text = "Completed.";
            }
        }

        private async void btnWriteTask_Click(object sender, EventArgs e)
        {
            if (!double.IsNaN(double.Parse(txtNrThreads.Text.Trim())))
            {
                int total = Int32.Parse(txtNrThreads.Text.Trim());

                lblProcessing.Text = "Processing...";
                string message = GetMessage();

                List<Tuple<string, string>> messageList = new List<Tuple<string, string>>();
                for (int i = 0; i < total; i++)
                {
                    Tuple<string, string> tm = Tuple.Create("message_" + i.ToString(), message);
                    messageList.Add(tm);
                }
                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);

                ActiveMQWriter w = new ActiveMQWriter(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);
                await w.WriteMessageListToQueueAsync(messageList, chkPersist.Checked); ;
                
                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);

                txtResult.Text += "==== Async Output ==== Message size: " + cmbMessageSize.Text + " ==== # Threads: " + txtNrThreads.Text + "  \r\n";
                txtResult.Text += "Inicio: " + inicio.ToString() + "\r\n";
                txtResult.Text += "Fim: " + fim.ToString() + "\r\n";
                txtResult.Text += "Total: " + (fim - inicio).ToString() + "\r\n";

                lblProcessing.Text = "Completed.";
            }

        }



        private string GetMessage()
        {
            switch (cmbMessageSize.SelectedIndex)
            {
                case 0://5KB
                    return MessageSample.Message5KB;
                    break;
                case 1://50KB
                    return MessageSample.Message50KB;
                    break;
                case 2://100KB
                    return MessageSample.Message100KB;
                    break;
                case 3://500KB
                    return MessageSample.Message500KB;
                    break;
                case 4://1000KB
                    return MessageSample.Message500KB + MessageSample.Message500KB;
                    break;
                default:
                    return "";
                    break;
            }
        }

        private void frmWriteActiveMQ_Load(object sender, EventArgs e)
        {
            cmbMessageSize.SelectedIndex = 0;
        }

        private async void btnPurge_Click(object sender, EventArgs e)
        {
            lblProcessing.Text = "Processing...";

            ActiveMQManager m = new ActiveMQManager(System.Configuration.ConfigurationManager.AppSettings["ActiveMQURL"], System.Configuration.ConfigurationManager.AppSettings["ActiveMQName"]);

            Task t1 = m.DeleteQueueAsync();
            Task t2 = m.CreateQueueAsync();
            await Task.WhenAll(t1, t2);

            txtResult.Clear();
            lblProcessing.Text = "Completed.";
        }

    }
}
