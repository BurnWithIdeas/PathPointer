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
    public class StatsManagement : Management
    {
        public static string[] StatsFileArr { get; set; }
        public string Business { get; set; }        //элемент DataSource


        public static void FillGrid(ref DataGridView dataGridView, int dayOfWeek)      //вывод в DataGridView данных из документа с названием empType  
        {
            
            SetPath("Efficiency");

            int currentDayOfWeekCode = CurrentDateInfo.DayOfWeek;
            dayOfWeek = dayOfWeek == 0 ? 7 : dayOfWeek;     //американская неделя начинается с воскресенья, исправление
            bool pickedCurrentDay = currentDayOfWeekCode == dayOfWeek ? true : false;

            dataGridView.ColumnCount = 24;
            dataGridView.RowCount = 1;

            if (dayOfWeek > currentDayOfWeekCode) StatsFileArr = FillStatsArray(2, pickedCurrentDay);     //заполнить массив данными предыдущей недели
            else StatsFileArr = FillStatsArray(1, pickedCurrentDay);                                      //заполнить массив данными текущей недели
                
            for (int i = 0; i < 24; i++) {
                for (int symbCount = 0; symbCount < dayOfWeek; symbCount++)                               //получение расписания для текущего дня недели 
                    StatsFileArr[i] = StatsFileArr[i].Substring(StatsFileArr[i].IndexOf(";") + 1);
                             
                if (StatsFileArr[i].Contains(";")) StatsFileArr[i] = StatsFileArr[i].Substring(0, (StatsFileArr[i].IndexOf(";")));
                GetCellColor(StatsFileArr[i], i, dataGridView);
            }

        }

        private static string[] FillStatsArray(int index, bool pickedCurrentDay) { //вывод массива данных об определенной недели
            string[] statsArray = new string[24];
            string readLine;
            int arrayIndex = 0;
            int currentHour = DateTime.Now.Hour;

            using (StreamReader reader = new StreamReader(FilePath))
            {
                for (int i = 0; (readLine = reader.ReadLine()) != null; i++) {
                    if (24 * (index - 1) <= i) {
                        statsArray[arrayIndex] = readLine;

                        if (pickedCurrentDay == true) {
                            if (arrayIndex == currentHour) statsArray[arrayIndex] = "T";
                            else if (arrayIndex > currentHour) statsArray[arrayIndex] = "F";
                        }

                        arrayIndex++;
                        if (arrayIndex == 24) break;
                    }
                }
            }
            return statsArray;
        }

        private static void GetCellColor(string cellValue, int cellIndex, DataGridView dataGridView) {

            switch (GetValueByIndex(StatsFileArr[cellIndex]))
            {
                case "Business":
                    dataGridView.Rows[0].Cells[cellIndex].Style.BackColor = System.Drawing.Color.Blue;
                    break;
                case "Goals":
                    dataGridView.Rows[0].Cells[cellIndex].Style.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case "Rest":
                    dataGridView.Rows[0].Cells[cellIndex].Style.BackColor = System.Drawing.Color.DarkOrange;
                    break;
                case "Fun":
                    dataGridView.Rows[0].Cells[cellIndex].Style.BackColor = System.Drawing.Color.Red;
                    break;
                case "T":
                    dataGridView.Rows[0].Cells[cellIndex].Style.BackColor = System.Drawing.Color.LightBlue;
                    break;
                case "F":
                    dataGridView.Rows[0].Cells[cellIndex].Style.BackColor = System.Drawing.Color.Black;
                    break;
                default:
                    dataGridView.Rows[0].Cells[cellIndex].Style.BackColor = System.Drawing.Color.Gray;
                    break;

            }
        }

        public static void DisplayMainStats(ref Label lblName, ref Label lblType, ref Label lblDoneHours, ref Label lblMustSpend, int currentEmployment) {
            string employment = "";
            string employmentName = "";
            string employmentType  = GetValueByIndex(StatsFileArr[currentEmployment]);
            string employmentHours = "";
            string employmentsMustSpend = "";
            DateTime dateGoal = new DateTime();
            int hoursGoal;
            int doneHours;
            int needDays;


            if (employmentType == "" || employmentType == " ")
            {
                employmentName = "ПРОПУСК";
                employmentType = "Похоже, что в это время вы занимались чем-то ДЕЙСТВИТЕЛЬНО полезным" +
                                "\nВам должно быть стыдно";
                employmentHours = "Ноль часов из нуля - стопроцентная продуктивность для ленивых";
            }
            else if (employmentType == "T")
            {
                employmentName = "СЕЙЧАС";
                employmentType = "Ваша судьба в ваших руках" +
                                "\nПочему бы не заняться чем-нибудь полезным прямо сейчас?";
                employmentHours = "Самое время изменить вашу жизнь к лучшему!";
            }
            else if (employmentType == "F")
            {

                employmentName = "БУДУЩЕЕ";
                employmentType = "Этот отрезок времени покрыт великой тайной..." +
                                "\nНикто не знает, будете ли вы через пару часов смотреть телевизор или встанете на путь к своей цели" +
                                "\nРазработчик этой программы верит в вас (Пожалуйста, встаньте на на путь к своей цели, не расстраивайте программиста)";
                employmentHours = "Ваш успех зависит от ваших действий";
            }
            else {
                try
                {
                    SetPath($"Employments\\{employmentType}");    //ищем в документе с указанным видом деятельности информацию о занятии
                    using (StreamReader sr = new StreamReader(FilePath))
                    {
                        employmentType = "";
                        while ((employment = sr.ReadLine()) != null)
                        {
                            if (GetValueByIndex(employment, 1) == GetValueByIndex(StatsFileArr[currentEmployment], 1)) //проверка сходства кода из расписания и кода из списка деятельности
                            {
                                employmentName = GetValueByIndex(employment);
                                employmentType = GetValueByIndex(StatsFileArr[currentEmployment]);
                                employmentHours = GetValueByIndex(employment, 2);
                                break;
                            }
                        }
                    }
                }
                catch { }
                finally
                {
                    switch (employmentType)
                    {
                        case "":
                            employmentName = "УПС, КАЖЕТСЯ, МЫ ПОТЕРЯЛИ ВАШИ ДАННЫЕ"; 
                            employmentType = "Обратитесь к вашему системному администратору" +
                                            "\nНе факт, что он найдет, но разработчик этой программы очень любит людей";
                            employmentHours = "Ваша продуктивность появится сразу, как только найдутся ваши данные";
                            break;
                        case "Business":
                            employmentType = "Похоже, в это время вы гуляли с собакой и вам было очень холодно" +
                                            "\nЗнайте, что разработчику этой программы очень вас жалко :)";
                            employmentHours = employmentHours == "N" ? "Для этого дела нет расписания" : $"Расписание для этого дела: {FormatTime(GetValueByIndex(employment, CurrentDateInfo.DayOfWeek))}";
                            break;
                        case "Goals":
                            dateGoal = Convert.ToDateTime(GetValueByIndex(employment,3));
                            needDays = (int)(dateGoal - DateTime.Now).TotalDays;
                            employmentType = "Ого, вы на верном пути к вашей цели!" +
                                            "\nВы ведь не потратили это время на чепуху, в роде, \"Смотреть весь день телевизор\", верно?";
                            hoursGoal = Convert.ToInt32(employmentHours);
                            doneHours = CountReadyHours(StatsFileArr[currentEmployment], hoursGoal);
                            
                            employmentHours = hoursGoal == doneHours ? $"Цель выполнена, на ее выполнение вы потратили {doneHours} часов! Но не спешите расслабляться, у вас еще много дел впереди!" : $"Выполнено {doneHours} из {hoursGoal} часов";
                            if (hoursGoal != doneHours)
                            {
                                if (needDays < 0) employmentsMustSpend = "Увы, время вышло, старайтесь лучше в следующий раз";
                                else if (needDays == 0 && 24 - DateTime.Now.Hour >= hoursGoal - doneHours) employmentsMustSpend = "Цель должна быть выполнена уже сегодня! Спешите!";
                                else if ((needDays == 0 && 24 - DateTime.Now.Hour < hoursGoal - doneHours) || (needDays * 24 - (hoursGoal - doneHours) < 0)) employmentsMustSpend = "Увы, но даже если вы возьметесь за дело прямо сейчас, уже не успеете :(";
                                else employmentsMustSpend = $"В среднем, чтобы достичь этой цели, вы должны тратить по {(hoursGoal - doneHours) / needDays} часов в сутки";
                            }
                            else employmentsMustSpend = $"Цель должна была быть выполнена {dateGoal.ToLongDateString()}";
                            break;
                        case "Rest":
                            employmentType = "Надеюсь, вы хорошо отдохнули!" +
                                            "\nНо помните, что если вы провели 4 часа за компьютером, \"Посидеть в вашем модном телефончике\" - не будет для вас отдыхом" +
                                            "\nОтдых - это смена деятельности, лучше сходите на прогулку или поиграйте с кошкой";
                            hoursGoal = Convert.ToInt32(employmentHours) * 7;
                            doneHours = CountReadyHours(StatsFileArr[currentEmployment], hoursGoal, true);
                            
                            employmentHours = hoursGoal == 0 ? $"Потрачено на этой неделе: {doneHours} часов" : $"Потрачено {doneHours} из доступных {hoursGoal} часов";

                            break;
                        case "Fun":
                            employmentType = "Развлечения могут повысить продуктивность, но чрезмерное злоупотребление ими, может вас погубить" +
                                            "\nБудьте осторожны";
                            hoursGoal = Convert.ToInt32(employmentHours) * 7;
                            doneHours = CountReadyHours(StatsFileArr[currentEmployment], hoursGoal, true);

                            employmentHours = hoursGoal == 0 ? $"Потрачено на этой неделе: {doneHours} часов" : $"Потрачено {doneHours} из доступных {hoursGoal} часов";
                            employmentsMustSpend = $"Каждый пол года вы тратите на это {hoursGoal * 27} часов, это {(hoursGoal * 27) / 24} полных суток";
                            break;
                    }
                }
            }



            lblName.Text = employmentName;
            lblType.Text = employmentType;
            lblDoneHours.Text = employmentHours;
            lblMustSpend.Text = employmentsMustSpend;
        }

        private static string FormatTime(string time) {
            string beginTime = time.Remove(time.IndexOf(" "));
            string endTime = time.Substring(time.IndexOf(" ") + 1);

            beginTime = beginTime.Length == 2 ? $"{beginTime}:00" : $"0{beginTime}:00";
            endTime = endTime.Length == 2 ? $"{endTime}:00" : $"0{endTime}:00";

            time = $"{beginTime} - {endTime}";
            return time;
        }

        public static void WriteStats(string name, int range = 1)
        {
            SetPath("Efficiency");

            int hour = DateTime.Now.Hour - range;
            int dayOfWeek = CurrentDateInfo.DayOfWeek;

            if (hour < 0 && dayOfWeek == 1)
            {
                hour = 47;
                dayOfWeek = 7;
            }
            else if (hour < 0) {
                dayOfWeek--;
                hour = 23;
            }


            string[] efficiency = File.ReadAllLines(FilePath);

            for (int i = 1; i < 7; i++) {      //заполнение дней недели пропусками, если пользователь в это время был неактивен
                if (dayOfWeek > i) efficiency[hour] += " ;";
                else break;
            }
            efficiency[hour] += $"{name};";

            File.WriteAllLines(FilePath, efficiency);

        }

        public static int FindCode(string name, string empType)
        {
            SetPath($"Employments\\{empType}");
            int code = 0;
            string[] empTypeFileArr = File.ReadAllLines(FilePath);

            for (int i = 0; i < empTypeFileArr.Length; i++) {
                if (GetValueByIndex(empTypeFileArr[i]) == name)
                {
                    code = Convert.ToInt32(GetValueByIndex(empTypeFileArr[i], 1));
                    break;
                }
            }

            return code;
        }

        public static void CheckWeekRelevance() {
            SetPath("Common");



            int fileWeekNumber;
            const int hoursADay = 24;
            string fileContainer = "";
            string[] commonFileArr = File.ReadAllLines(FilePath);

            for (int i = 0; i< commonFileArr.Length; i++) {
                if (GetValueByIndex(commonFileArr[i], 0) == "Week Number")
                {
                    fileWeekNumber = Convert.ToInt32(GetValueByIndex(commonFileArr[i], 1));
                    if (fileWeekNumber != CurrentDateInfo.WeekNumber)
                    {
                        commonFileArr[i] = $"Week Number!{CurrentDateInfo.WeekNumber}";

                        File.WriteAllLines(FilePath, commonFileArr);

                        SetPath("Efficiency");
                        fileContainer = File.ReadAllText(FilePath);
                        File.Delete(FilePath);

                        using (StreamWriter wr = new StreamWriter(FilePath))
                        {
                            for (int j = 0; j < hoursADay; j++)
                            {
                                wr.WriteLine($"{j}:00;");
                            }
                            wr.Write(fileContainer);
                        }
                        break;
                    }
                }
            }
            /*
            using (StreamReader sr = new StreamReader(FilePath))    //если последняя запись в файл производилась не на этой неделе
            {
                while ((readLine = sr.ReadLine()) != null)
                {
                    if (GetValueByIndex(readLine, 0) == "Week Number")
                    {
                        fileWeekNumber = Convert.ToInt32(GetValueByIndex(readLine, 1));
                        if (fileWeekNumber != currentWeekNumber) {
                            weekIsNowRelevant = true;
                            fileContainer = File.ReadAllText(FilePath);
                        }
                        break;
                    }
                }
            }

            if (weekIsNowRelevant == true) {
                using (StreamWriter wr = new StreamWriter(FilePath))
                {
                    fileContainer = fileContainer.Replace(readLine, $"Week Number!{currentWeekNumber}");
                    wr.Write(fileContainer);
                }

                SetPath("Efficiency");

                using (StreamReader sr = new StreamReader(FilePath)) fileContainer = sr.ReadToEnd();
                File.Delete(FilePath);

                using (StreamWriter wr = new StreamWriter(FilePath))
                {
                    for (int i = 0; i < hoursADay; i++) {
                        wr.WriteLine($"{i}:00;");
                    }
                    wr.Write(fileContainer);
                }
            }            */
        }


        public static bool CheckSchedule() {        //указан ли текущий час в расписании
            SetPath("Employments\\Business");
            string[] scheduleFileArray = File.ReadAllLines(FilePath);
            string choosedHourEmployment;
            bool hourInSchedule = false;
            int checkingDayOfWeek = CurrentDateInfo.DayOfWeek;
            int checkingHour = DateTime.Now.Hour - 1;
            int beginHour;
            int endHour;

            if (checkingHour == -1 && checkingDayOfWeek == 1)
            {
                checkingHour = 47;
                checkingDayOfWeek = 7;
            }
            else if (checkingHour == -1) checkingHour = 47;

            for (int i = 0; i < scheduleFileArray.Length; i++) {
                if (GetValueByIndex(scheduleFileArray[i], 2) == "N") continue;
                else
                {
                    scheduleFileArray[i] = GetValueByIndex(scheduleFileArray[i], checkingDayOfWeek + 1);

                    if (scheduleFileArray[i] == "H") continue;
                    beginHour = Convert.ToInt32(scheduleFileArray[i].Remove(scheduleFileArray[i].IndexOf(" ")));
                    endHour = Convert.ToInt32(scheduleFileArray[i].Substring(scheduleFileArray[i].IndexOf(" ") + 1));

                    if (beginHour <= checkingHour && checkingHour - 1 < endHour) {
                        hourInSchedule = true;
                        break;
                    }
                }
            }

            if (hourInSchedule == false) {
                SetPath("Efficiency");
                scheduleFileArray = File.ReadAllLines(FilePath);

                


                choosedHourEmployment = GetValueByIndex(scheduleFileArray[checkingHour], checkingDayOfWeek, ";");

                if (!(choosedHourEmployment == " " || choosedHourEmployment == "")) {  //если в этот час опрос уже был показан
                    hourInSchedule = true;
                }
            }

            return hourInSchedule;
        }




        public static int CountReadyHours(string desiredEmployment, int hoursGoal, bool restCheck = false)
        {
            SetPath("Efficiency");
            int hoursDone = 0;
            
            string readLine;

            using (StreamReader reader = new StreamReader(FilePath))
            {
                for (int j = 0; (readLine = reader.ReadLine()) != null; j++)
                {
                    for (int i = 1; i <= 7; i++) {
                        if (GetValueByIndex(readLine, i, ";") == "") break;
                        else if (desiredEmployment == GetValueByIndex(readLine, i, ";")) hoursDone++;  
                    }

                    if (hoursDone >= hoursGoal && restCheck == false) break;
                    else if (restCheck == true && j == 23) break;
                }
            }


            return hoursDone;
        }






    }
}