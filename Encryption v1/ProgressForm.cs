using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Encryption_v1
{
    public partial class ProgressForm : Form
    {
        private BackgroundWorker W;
        private DateTime Start = DateTime.Now;

        public ProgressForm(BackgroundWorker w)
        {
            InitializeComponent();
            W = w;

            W.ProgressChanged += Updated;
            W.RunWorkerCompleted += Completed;

            FormClosing += (o, e) =>
            {
                if (W.IsBusy) W.CancelAsync();
            };
        }

        private void Updated(object Sender, ProgressChangedEventArgs e)
        {
            Progress.Value = e.ProgressPercentage;
            double elapsed = (DateTime.Now - Start).TotalSeconds;
            double rem = e.ProgressPercentage == 0 ? 0d :
                100d * elapsed / e.ProgressPercentage - elapsed;

            Display.Text = string.Format("{0}% Complete {1}s Elapsed {2}s Remaining", e.ProgressPercentage, (int)elapsed, (int)rem);
        }

        private void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}
