using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KKU_Internet_Autologin
{
    public partial class Form1 : Form
    {
        login l = new login();
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            MessageBox.Show("กำลังเข้าสู่ระบบ");
            string u = user.Text;
            string pass = password.Text;
            Thread myNewThread = new Thread(() => l.login_cli(u, pass));
            myNewThread.IsBackground = true;
            myNewThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
