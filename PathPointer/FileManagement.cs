﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathPointer
{
    public class FileManagement : Management
    {

        public static void CheckAllFiles() {
            CheckForDirectory();
            CheckForCommon();
            CheckForEfficiency();
            CheckForCodes();
            CheckForBusiness();
            CheckForFun();
            CheckForGoals();
            CheckForRest();
        }

        private static void CheckForDirectory() {
            SetPath();
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            if (!Directory.Exists(FilePath + "\\Employments"))
            {
                Directory.CreateDirectory(FilePath + "\\Employments");
            }

        }

        private static void CheckForCommon(){
            if (!CheckFileExistance("Common")) {
                string[] fileArray = new string[1];
                var cal = new GregorianCalendar();
                int currentWeekNumber = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                fileArray[0] = $"Week Number!{currentWeekNumber}";
                File.WriteAllLines(FilePath, fileArray);
            }
        }

        private static void CheckForEfficiency() {
            if (!CheckFileExistance("Efficiency"))
            {
                string[] fileArray = new string[48];
                for (int j = 0; j < 2; j++)
                for (int i = 0; i<24; i++) {
                    fileArray[i + (j * 24)] = $"{i}:00;";
                }
                File.WriteAllLines(FilePath, fileArray);
            }

        }

        private static void CheckForCodes() {
            if (!CheckFileExistance("Employments\\Codes"))
            {
                string[] fileArray = new string[4];
                fileArray[0] = "Business!0";
                fileArray[1] = "Goals!0";
                fileArray[2] = "Rest!0";
                fileArray[3] = "Fun!0";
                File.WriteAllLines(FilePath, fileArray);
            }
        }

        private static void CheckForBusiness() {
            if (!CheckFileExistance("Employments\\Business"))
            {
                using (File.Create(FilePath)) { }
            }
        }

        private static void CheckForGoals()
        {
            if (!CheckFileExistance("Employments\\Goals"))
            {
                using (File.Create(FilePath)) { }
                DataManagement.WriteEmpFiles($"Установка PathPointer!{DataManagement.Code}!1!{DateTime.Today.ToShortDateString()}", "Employments\\Goals");
                MainMenu.ShowQuest();
            }
        }

        private static void CheckForRest() {
            if (!CheckFileExistance("Employments\\Rest"))
            {
                using (File.Create(FilePath)) { }
            }
        }

        private static void CheckForFun()
        {
            if (!CheckFileExistance("Employments\\Fun"))
            {
                using (File.Create(FilePath)) { }
            }
        }

        private static bool CheckFileExistance(string fileStr) {
            SetPath(fileStr);
            if (File.Exists(FilePath)) return true;
            else return false;
        }


    }
}
