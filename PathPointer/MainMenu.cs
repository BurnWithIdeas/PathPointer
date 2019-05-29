﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace PathPointer
{
    public partial class MainMenu : Form
    {
        const int interval60Min = 60 * 60 * 1000;

        public MainMenu()
        {
            InitializeComponent();
        }

        private static void ShowQuest(){
            Console.WriteLine("It works");
            TimeSpent form = new TimeSpent();
            form.Show();

        }

        private void EmployButton_Click(object sender, EventArgs e)
        {
            Employments employments = new Employments();
            employments.Show();
            this.Hide();
        }


        private void pathPointerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrayIcon_MouseDoubleClick(null,null);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            DateTime dateTime1 = new DateTime();   //вызов фрпмы в ближайшие "00" минут
            dateTime1 = DateTime.Now;
            dateTime1 = dateTime1.AddHours(1).AddMinutes(-dateTime1.Minute);
            TimerHour.Interval = dateTime1.Subtract(DateTime.Now).Minutes * 1000;
            TimerHour.Enabled = true;
        }

        private void TimerHour_Tick(object sender, EventArgs e)
        {
            TimerHour.Interval = interval60Min;
            ShowQuest();
        }
    }
}