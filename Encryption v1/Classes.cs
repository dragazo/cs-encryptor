using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace Encryption_v1
{
    public static class Encryptor
    {
        #region Constants
        private const int BufferSize = 1048576;

        private readonly static int[] F =
        {
            1,
            2,
            6,
            24,
            120,
            720,
            5040
        };

        private readonly static byte[] P =
        {
            1,
            2,
            4,
            8,
            16,
            32,
            64,
            128
        };
        #endregion

        public static byte[] GetMasks(int key)
        {
            List<byte> pos = new List<byte>() { 1, 2, 4, 8, 16, 32, 64, 128 };
            byte[] r = new byte[8];
            key %= 40320;

            for (int i = 7; i > 0; i--)
            {
                int res = key / F[i - 1];
                r[i] = pos[res];
                pos.RemoveAt(res);
                key -= res * F[i - 1];
            }
            r[0] = pos[0];

            return r;
        }

        public static byte[][] GetMasks(string keys)
        {
            byte[][] k = new byte[keys.Length][];
            for (int i = 0; i < keys.Length; i++) k[i] = GetMasks(keys[i]);

            return k;
        }

        //Encryption -----------------------------

        public static void Encrypt(byte[] data, byte[][] masks, int offset, int length, int maskOffset = 0)
        {
            int n = masks.Length;
            for (int i = 0; i < length; i++)
            {
                byte res = 0;
                byte[] set = masks[(i + maskOffset) % n];
                for (int m = 0; m < 8; m++)
                    if ((set[m] & data[i + offset]) == set[m]) res += P[7 - m];

                data[i + offset] = res;
            }
        }

        public static BackgroundWorker Encrypt(string inputPath, string outputPath, string keys)
        {
            FileStream input = null, output = null;
            long length;
            
            try
            {
                input = File.Open(inputPath, FileMode.Open);
                output = File.Open(outputPath, FileMode.Create);
                
                length = input.Length;
                output.SetLength(length);

                input.Lock(0, length);
                output.Lock(0, length);

                byte[][] masks = GetMasks(keys);
                byte[] raw = new byte[BufferSize];

                BackgroundWorker w = new BackgroundWorker();
                w.WorkerReportsProgress = true;
                w.WorkerSupportsCancellation = true;

                w.DoWork += (o, e) =>
                {
                    long t = 0;
                    int prevProg = 0;
                    w.ReportProgress(0);

                    for (int offset = 0; ; offset = (offset + BufferSize) % keys.Length)
                    {
                        int len = input.Read(raw, 0, BufferSize);
                        Encrypt(raw, masks, 0, len, offset);
                        output.Write(raw, 0, len);

                        t += len;
                        int nowProg = (int)(100d * t / length);
                        if (nowProg != prevProg)
                        {
                            w.ReportProgress(nowProg);
                            prevProg = nowProg;
                        }

                        if (w.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        if (len != BufferSize) break;
                    }
                };

                w.RunWorkerCompleted += (o, e) =>
                {
                    input.Close();
                    output.Close();

                    if (e.Cancelled || e.Error != null) File.Delete(outputPath);
                };

                return w;
            }
            catch (Exception ex)
            {
                input.Close();
                output.Close();
            }

            return null;
        }

        //Decryption -----------------------------

        public static void Decrypt(byte[] data, byte[][] masks, int offset, int length, int maskOffset = 0)
        {
            int n = masks.Length;
            for (int i = 0; i < length; i++)
            {
                byte res = 0;
                byte[] set = masks[(i + maskOffset) % n];
                for (int m = 0; m < 8; m++)
                    if ((P[7 - m] & data[i + offset]) == P[7 - m]) res += set[m];

                data[i + offset] = res;
            }
        }

        public static BackgroundWorker Decrypt(string inputPath, string outputPath, string keys)
        {
            FileStream input = null, output = null;

            try
            {
                input = File.Open(inputPath, FileMode.Open);
                output = File.Open(outputPath, FileMode.Create);

                long length = input.Length;
                output.SetLength(length);

                input.Lock(0, length);
                output.Lock(0, length);

                byte[][] masks = GetMasks(keys);
                byte[] raw = new byte[BufferSize];

                BackgroundWorker w = new BackgroundWorker();
                w.WorkerReportsProgress = true;
                w.WorkerSupportsCancellation = true;
                
                w.DoWork += (o, e) =>
                {
                    long t = 0;
                    int prevProg = 0;
                    w.ReportProgress(0);

                    for (int offset = 0; ; offset = (offset + BufferSize) % keys.Length)
                    {
                        int len = input.Read(raw, 0, BufferSize);
                        Decrypt(raw, masks, 0, len, offset);
                        output.Write(raw, 0, len);

                        t += len;
                        int nowProg = (int)Math.Floor(100d * t / length);
                        if (nowProg != prevProg)
                        {
                            w.ReportProgress(nowProg);
                            prevProg = nowProg;
                        }

                        if (w.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        if (len != raw.Length) break;
                    }
                };

                w.RunWorkerCompleted += (o, e) =>
                {
                    input.Close();
                    output.Close();

                    if (e.Cancelled || e.Error != null) File.Delete(outputPath);
                };

                return w;
            }
            catch(Exception ex)
            {
                input.Close();
                output.Close();
            }

            return null;
        }
    }
}
