﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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


        public static BindingList<MainStatistic> statCells;


        public MainMenu()
        {
            InitializeComponent();

        }


        private void MainMenu_Load(object sender, EventArgs e)
        {
            const int miliseconds = 1000;
            const int minutes = 60;
            MenuManagement.AreAllFormsClosed = false;

            DateTime dateTime1 = new DateTime();   //"будильник" на вызов фрпмы в ближайшие "00" минут
            dateTime1 = DateTime.Now;
            dateTime1 = dateTime1.AddHours(1).AddMinutes(-dateTime1.Minute);
            TimerHour.Interval = dateTime1.Subtract(DateTime.Now).Minutes * miliseconds * minutes;
            TimerHour.Enabled = true;
            MenuManagement.questCheck = false;

            MainStatistic.CheckWeekRelevance();
            FillDaysOfWeek();


            DataGridDayOfWeek_CellClick(null, null);


            DataGridBusiness.CurrentCell = DataGridBusiness[23, 0];
            DataGridBusiness_CellClick(null, null);
        }





        private void EmployButton_Click(object sender, EventArgs e)
        {
            Employments employments = new Employments();
            MenuManagement.AreAllFormsClosed = false;
            employments.Show();

            this.Hide();
        }


        private void BtnMoreStats_Click(object sender, EventArgs e)
        {

        }

        private void pathPointerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrayIcon_MouseDoubleClick(null,null);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MenuManagement.TrayShow(this);
        }



        private void TimerHour_Tick(object sender, EventArgs e)
        {
            const int interval60Mins = 60 * 60 * 1000;
            TimerHour.Interval = interval60Mins;
            ShowQuest();
        }

        private static void ShowQuest()
        {
            TimeSpent form = TimeSpent.CreateInstance();
            form.Show();

        }

        private void FillDaysOfWeek() {     //заполнение таблицы дней недели с учетом сдвига
            DataGridDayOfWeek.RowCount = 1;
            DataGridDayOfWeek.ColumnCount = 7;
            int dayOfWeek = 7;

            for (int i = 0; i < 7; i++)
            {
                dayOfWeek--;
                DataGridDayOfWeek.Rows[0].Cells[i].Value = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.AddDays(-dayOfWeek).DayOfWeek);
            }
            DataGridDayOfWeek.CurrentCell = DataGridDayOfWeek[6,0];


        }

        public void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            MenuManagement.AreAllFormsClosed = true;
        }

        private void DataGridDayOfWeek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MainStatistic.FillGrid(ref DataGridBusiness, Convert.ToInt32(DateTime.Now.AddDays(-(6 - DataGridDayOfWeek.CurrentCell.ColumnIndex)).DayOfWeek));  //вывод деятельности за 24 часа выбранного дня недели
        }

        private void DataGridBusiness_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MainStatistic.DisplayMainStats(ref lblEmployName,ref lblEmployType, DataGridBusiness.CurrentCell.ColumnIndex);
        }



    }
}
