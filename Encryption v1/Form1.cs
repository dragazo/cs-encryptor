using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text;

namespace Encryption_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            KeyBox.UseSystemPasswordChar = true;
        }

        private string[] GetPaths()
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Title = "Select File to Process";
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "Select Output Location";

            if (od.ShowDialog() == DialogResult.OK && sd.ShowDialog() == DialogResult.OK)
            {
                od.Dispose();
                sd.Dispose();
                return new string[] { od.FileName, sd.FileName };
            }

            od.Dispose();
            sd.Dispose();
            return null;
        }

        private void ShowPassCheck_CheckedChanged(object sender, EventArgs e)
        {
            KeyBox.UseSystemPasswordChar = !ShowPassCheck.Checked;
        }

        private void Display(BackgroundWorker w, string title)
        {
            ProgressForm f = new ProgressForm(w);
            f.Text = title;

            w.RunWorkerAsync();
            f.ShowDialog();
            f.Dispose();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (KeyBox.Text == string.Empty) { MessageBox.Show("Password Blank"); return; }

            string[] paths = GetPaths();
            if (paths == null) return;

            Display(Encryptor.Encrypt(paths[0], paths[1], KeyBox.Text),
                string.Format("Encrypting {0}", paths[0]));
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (KeyBox.Text == string.Empty) { MessageBox.Show("Password Blank"); return; }

            string[] paths = GetPaths();
            if (paths == null) return;

            Display(Encryptor.Decrypt(paths[0], paths[1], KeyBox.Text),
                string.Format("Decrypting {0}", paths[0]));
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            Stopwatch s = Stopwatch.StartNew();
            int c = 50;
            for (int i = 0; i < c; i++)
            {
                Display(Encryptor.Encrypt("input.jpg", string.Format("output{0}.jpg", i), "password"), "Encrypting");
            }

            s.Stop();
            MessageBox.Show((s.Elapsed.TotalMilliseconds / c).ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int times = 1000000;

            int c = 30;

            byte ab = 5;
            byte bb = 20;

            int ai = 5;
            int bi = 20;

            double avg = 0d;
            StringBuilder b = new StringBuilder();
            for (int _ = 0; _ < c; _++)
            {
                Stopwatch bytes = Stopwatch.StartNew();
                for (int i = 0; i < times; i++)
                {
                    byte r = (byte)(ab & bb);
                }
                bytes.Stop();

                Stopwatch ints = Stopwatch.StartNew();
                for (int i = 0; i < times; i++)
                {
                    int r = ai & bi;
                }
                ints.Stop();

                double d = ints.Elapsed.TotalMilliseconds / bytes.Elapsed.TotalMilliseconds;
                avg += d;
                b.AppendFormat("{0}\n", d);
            }
            avg /= c;
            b.AppendFormat("\navg: {0}", avg);


            MessageBox.Show(b.ToString());
        }
    }
}
