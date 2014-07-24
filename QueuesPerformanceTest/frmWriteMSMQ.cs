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
    public partial class frmWriteMSMQ : Form
    {
        public frmWriteMSMQ()
        {
            InitializeComponent();
        }

        private void frmWriteMSMQ_Load(object sender, EventArgs e)
        {
            cmbMessageSize.SelectedIndex = 0;
        }

        private async void btnWriteTask_Click(object sender, EventArgs e)
        {
            if (!double.IsNaN(double.Parse(txtNrThreads.Text.Trim())))
            {
                int total = Int32.Parse(txtNrThreads.Text.Trim());

                lblProcessing.Text = "Processing...";

                MSMQHandler.MSMQHandler mh = new MSMQHandler.MSMQHandler(System.Configuration.ConfigurationManager.AppSettings["MSMQPath"]);
                string message = GetMessage();

                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                txtResult.Text += "==== Async Output ==== Message size: " + cmbMessageSize.Text + " ==== # Threads: " + txtNrThreads.Text + "  \r\n";
                txtResult.Text += "Inicio: " + inicio.ToString() + "\r\n";

                //Task[] taskList = new Task[total];
                //for (int i = 0; i < total; i++)
                //{
                //    taskList[i] = mh.WriteToQueueAsync(message, "test_" + i.ToString(), i);
                //}
                //await Task.WhenAll(taskList);

                Task[] tasklist = new Task[total];
                for (int i = 0; i < total; i++)
                {
                    int idx = i;
                    tasklist[idx] = Task.Run(() =>
                    {
                        mh.WriteToQueue(message, "test_" + idx.ToString(), idx);
                    });
                }
                await Task.WhenAll(tasklist);


                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);

                txtResult.Text += "Fim: " + fim.ToString() + "\r\n";
                txtResult.Text += "Total: " + (fim - inicio).ToString() + "\r\n"; 

                lblProcessing.Text = "Completed.";
            }
        }

        private async void btnWriteSync_Click(object sender, EventArgs e)
        {
            if (!double.IsNaN(double.Parse(txtNrThreads.Text.Trim())))
            {
                int total = Int32.Parse(txtNrThreads.Text.Trim());

                lblProcessing.Text = "Processing...";

                MSMQHandler.MSMQHandler mh = new MSMQHandler.MSMQHandler(System.Configuration.ConfigurationManager.AppSettings["MSMQPath"]);

                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                txtResult.Text += "==== Sync Output ==== Message size: " + cmbMessageSize.Text + " ==== # Threads: " + txtNrThreads.Text + "  \r\n";
                txtResult.Text += "Inicio: " + inicio.ToString() + "\r\n";
                string message = GetMessage();

                for (int i = 0; i < total; i++)
                {
                    mh.WriteToQueue(message, "test_" + i.ToString(), i);
                }

                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);

                txtResult.Text += "Fim: " + fim.ToString() + "\r\n";
                txtResult.Text += "Total: " + (fim - inicio).ToString() + "\r\n";

                lblProcessing.Text = "Completed.";
            }
        }

        private async void btnPurge_Click(object sender, EventArgs e)
        {
            lblProcessing.Text = "Processing...";

            MSMQHandler.MSMQHandler mh = new MSMQHandler.MSMQHandler(@".\private$\QueueTest");
            await mh.PurgeAsync();
            txtResult.Clear();
            lblProcessing.Text = "Completed.";
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
    }
}
