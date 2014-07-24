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
    public partial class frmReadFile : Form
    {
        public frmReadFile()
        {
            InitializeComponent();
        }

        private async void btnListQueue_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Text = "";
            FileHandler.FileHandler fh = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);
            StringBuilder s = new StringBuilder();

            TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
            List<Tuple<string, string>> files = await fh.ListFileAsync();
            if (files.Count() > 0)
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
                s.Append("Total Msg: " + files.Count() + "\r\n");
                s.Append("=================================\r\n");

                foreach (Tuple<string, string> t in files)
                {
                    s.Append(t.Item1 + " - at " + t.Item2 + "\r\n");
                }
                txtResult.Text = s.ToString();
            }
            label1.Text = "Completed...";
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            StringBuilder s = new StringBuilder();
            FileHandler.FileHandler f = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);
            TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
            await f.DeleteAllAsync();
            TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
            s.Append("=================================\r\n");
            s.Append("ALL DELETED...\r\n");
            s.Append("=================================\r\n");
            s.Append("Inicio: " + inicio.ToString() + "\r\n");
            s.Append("=================================\r\n");
            s.Append("Fim: " + fim.ToString() + "\r\n");
            s.Append("=================================\r\n");
            s.Append("Tempo Total: " + (fim - inicio).ToString() + "\r\n");
            s.Append("=================================\r\n");
            txtResult.Text = s.ToString();


            label1.Text = "Completed...";
        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";
            txtResult.Clear();
            if (txtId.Text.Trim() != String.Empty)
            {
                StringBuilder s = new StringBuilder();
                FileHandler.FileHandler f = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);
                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                string fileContent = await f.OpenFileAsync(txtId.Text.Trim());
                if (fileContent != String.Empty)
                {

                    TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
                    s.Append("=================================\r\n");
                    s.Append("FILE OPENED...\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Inicio: " + inicio.ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Fim: " + fim.ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append("Tempo Total: " + (fim - inicio).ToString() + "\r\n");
                    s.Append("=================================\r\n");
                    s.Append(fileContent);
                    txtResult.Text = s.ToString();
                }
            }

            label1.Text = "Completed...";
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing...";

            txtResult.Clear();
            if (txtId.Text.Trim() != String.Empty)
            {
                StringBuilder s = new StringBuilder();
                FileHandler.FileHandler f = new FileHandler.FileHandler(System.Configuration.ConfigurationManager.AppSettings["FilesDir"]);
                TimeSpan inicio = new TimeSpan(DateTime.Now.Ticks);
                await f.DeleteFileAsync(txtId.Text.Trim());

                TimeSpan fim = new TimeSpan(DateTime.Now.Ticks);
                s.Append("=================================\r\n");
                s.Append("FILE OPENED...\r\n");
                s.Append("=================================\r\n");
                s.Append("Inicio: " + inicio.ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Fim: " + fim.ToString() + "\r\n");
                s.Append("=================================\r\n");
                s.Append("Tempo Total: " + (fim - inicio).ToString() + "\r\n");
                s.Append("=================================\r\n");

                txtResult.Text = s.ToString();
            }

            label1.Text = "Completed...";
        }
    }
}
