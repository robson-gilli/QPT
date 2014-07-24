using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuesPerformanceTest
{
    public partial class frmWriteFile : Form
    {
        public frmWriteFile()
        {
            InitializeComponent();
        }

        private async void btnWriteTask_Click(object sender, EventArgs e)
        {
            if (!double.IsNaN(double.Parse(txtNrThreads.Text.Trim())))
            {
                int total = Int32.Parse(txtNrThreads.Text.Trim());

                lblProcessing.Text = "Processing...";


                string message = GetMessage();
                Task[] taskList = new Task[total];

                List<Tuple<string, string>> messageList = new List<Tuple<string, string>>();
                for (int i = 0; i < total; i++)
                {
                    Tuple<string, string> tm = Tuple.Create("Arquivo_" + i.ToString(), message);
                    messageList.Add(tm);
                }
                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                FileHandler.FileHandler f = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);
                await f.WriteListAsync(messageList);
                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);


                txtResult.Text += "==== Async Output ==== Message size: " + cmbMessageSize.Text + " ==== # Threads: " + txtNrThreads.Text + "  \r\n";
                txtResult.Text += "Inicio: " + inicio.ToString() + "\r\n";

                //for (int i = 0; i < total; i++)
                //{
                //    taskList[i] = f.WriteAsync(message, "Arquivo_" + i.ToString());
                //}
                //await Task.WhenAll(taskList);
                //TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);

                txtResult.Text += "Fim: " + fim.ToString() + "\r\n";
                txtResult.Text += "Total: " + (fim - inicio).ToString() + "\r\n";

                lblProcessing.Text = "Completed.";
            }


        }

        private void btnWriteSync_Click(object sender, EventArgs e)
        {
           if (!double.IsNaN(double.Parse(txtNrThreads.Text.Trim())))
            {
                int total = Int32.Parse(txtNrThreads.Text.Trim());

                lblProcessing.Text = "Processing...";

                FileHandler.FileHandler f = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);

                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                txtResult.Text += "==== Sync Output ==== Message size: " + cmbMessageSize.Text + " ==== # Threads: " + txtNrThreads.Text + "  \r\n";
                txtResult.Text += "Inicio: " + inicio.ToString() + "\r\n";


                string message = GetMessage();
                for (int i = 0; i < total; i++)
                {
                    f.Write(message, "Arquivo_" + i.ToString());
                }


                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FileHandler.FileHandler f = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);
            f.DeleteAllAsync();


            txtResult.Clear();
        }

        private void frmWriteFile_Load(object sender, EventArgs e)
        {
            cmbMessageSize.SelectedIndex = 0;
        }

    }
}
