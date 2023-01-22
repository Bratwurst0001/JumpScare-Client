using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace JumpScare
{
    public partial class JumpscareScreen : Form
    {

        [DllImport("Winmm.dll", SetLastError = true)]
        static extern int mciSendString(string lpszCommand, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszReturnString, int cchReturn, IntPtr hwndCallback);

          public static String MainPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public JumpscareScreen()
        {
            InitializeComponent();
        }

        private void JumpscareScreen_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string sFileName = MainPath + "\\hi.wav";
            string sAliasName = "MP3";
            int nRet = mciSendString("open \"" + sFileName + "\" alias " + sAliasName, sb, 0, IntPtr.Zero);

            nRet = mciSendString("play " + sAliasName, sb, 0, IntPtr.Zero);
        }
    }
}
