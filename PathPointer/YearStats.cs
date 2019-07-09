﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathPointer
{
    abstract class YearStats
    {
        StatsManagement stats = new StatsManagement();
        public abstract string EmpType { get; }
        public string MainEmployment { get; set; }
        public int MainEmploymentHrs { get; set; }
        public int[,] yearEmpNum = new int[7, 52];


        public YearStats()  //поиск статистики за целый год
        {
            int getWeek = 0;

            DayEfficiency[] dayEfficiency;

            for (int yw = 51; yw >= 0; yw--)
            {
                getWeek++;
                for (int dow = 0; dow < 7; dow++)
                {
                    dayEfficiency = stats.FillStatsArray(yw, dow);              
                    if (dayEfficiency != null)
                    {
                        for (int hr = 0; hr < 24; hr++)
                        {
                            if (dayEfficiency[hr].EmpType == EmpType)
                            {
                                CountHours(dayEfficiency[hr].EmpType);
                                yearEmpNum[dow, yw]++;
                            }
                        }
                    }
                    else
                    {
                        yw = 0;
                        break;
                    }
                }
            }
        }

        public abstract Color GetCellColor(int colorCode);

        protected abstract void CountHours(string currentEmp);

    }
}
