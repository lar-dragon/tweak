using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Tweak
{
    public partial class ProgressForm : Form
    {
        private Config _config;

        public ProgressForm() : this(new Config())
        {}
        
        public ProgressForm(Config config)
        {
            _config = config;
            InitializeComponent();
        }

        private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker.ReportProgress(0, "Оценка...");

            var tasks = new Tasks(_config);
            ulong progress = 0;

            foreach (var task in tasks)
            {
                BackgroundWorker.ReportProgress((int) (progress / tasks.Total * 100), task.ToString());
                task.Apply();
                progress = task.Weight;
            }
            
            BackgroundWorker.ReportProgress(100, "Готово!");
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Style = e.ProgressPercentage == 0 ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
            ProgressBar.Value = e.ProgressPercentage;
            Label.Text = (string) e.UserState;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            BackgroundWorker.RunWorkerAsync();
        }
    }
}