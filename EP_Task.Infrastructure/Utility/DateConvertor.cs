using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EP_Task.Infrastructure.Utility
{
    public class DateConvertor
    {
        public static DateTime ShamsiToMiladi(string date)
        {
            string[] strs = date.Split('/');
            int year, month, day = 0;
            year = int.Parse(translateToEng(strs[0]));
            month = int.Parse(translateToEng(strs[1]));
            day = int.Parse(translateToEng(strs[2]));
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(year, month, day, pc);
            return dt;
        }

        public static DateTime ShamsiToMiladiByTime(string date)
        {
            int year, month, day, hour = 0, minute = 0, second = 0;
            string[] dates = date.Split('/');
            string[] dayofdate = dates[2].Split(' ');
            year = int.Parse(translateToEng(dates[0]));
            month = int.Parse(translateToEng(dates[1]));
            day = int.Parse(translateToEng(dayofdate[0]));
            if (dayofdate.Count() > 1)
            {
                string[] time = dayofdate[1].Split(':');
                hour = int.Parse(translateToEng(time[0]));
                minute = int.Parse(translateToEng(time[1]));

                second = int.Parse(translateToEng(time[2]));
            }

            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(year, month, day, hour, minute, second, pc);
            return dt;
        }

        public static int MiladitoshamsiYear(DateTime? DateTime)
        {
            if (DateTime != null)
            {
                string miladiToShamsi = MiladiToShamsi(DateTime);
                string[] Sepreted = new string[2];
                Sepreted = miladiToShamsi.Split('_');
                string[] yearcheck = Sepreted[0].Split("/");
                int year = int.Parse(yearcheck[0]);

                return year;
            }
            return 0;
        }

        public static string MiladiToShamsi(DateTime? DateTime)
        {
            if (DateTime != null)
            {
                string DateString = DateTime.Value.ToString("dd-MMM-yyyy HH:mm");
                //برای تبدیل فرمت 12ساعت پیشفرض به 24 ساعته
                DateTime Hour24Format = Convert.ToDateTime(DateString);
                PersianCalendar PersianCalendar = new PersianCalendar();
                return string.Format(@"{0}/{1:D2}/{2:D2}_{3}:{4}",
                             PersianCalendar.GetYear(Hour24Format),
                             PersianCalendar.GetMonth(Hour24Format),
                             PersianCalendar.GetDayOfMonth(Hour24Format),
                             PersianCalendar.GetHour(Hour24Format),
                             PersianCalendar.GetMinute(Hour24Format)

                             );
            }
            return null;
        }

        public static DateTime SpecialShamsiToMilad(string date)
        {
            string[] strs = new string[3];
            strs[0]= date.Substring(0,4);
            strs[1]=date.Substring(4,2);
            strs[2]= date.Substring(6, 2);
            int year, month, day = 0;
            year = int.Parse(translateToEng(strs[0]));
            month = int.Parse(translateToEng(strs[1]));
            day = int.Parse(translateToEng(strs[2]));
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(year, month, day, pc);
            return dt;

        }

        //تاریخ و زمان را جدا برمی گیرداند مناسب برای وب سرویس
        public static string[] MiladiToShamsiSeprate(DateTime? DateTime)
        {
            if (DateTime != null)
            {
                string miladiToShamsi = MiladiToShamsi(DateTime);
                string[] Sepreted = new string[2];
                Sepreted = miladiToShamsi.Split('_');
                return Sepreted;
            }
            return null;
        }

        public static string ShamsiDayMonthName(DateTime? DateTime)
        {
            if (DateTime != null)
            {

                PersianCalendar PersianCalendar = new PersianCalendar();
                List<String> MonthNames = new List<string> { "", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };

                Dictionary<string, string[]> DayOfWeeks = new Dictionary<string, string[]>();
                DayOfWeeks.Add("en", new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
                DayOfWeeks.Add("fa", new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" });
                var DayNumeral = PersianCalendar.GetDayOfMonth(DateTime.Value);
                var DayName = DayOfWeeks["fa"][(int)PersianCalendar.GetDayOfWeek(DateTime.Value)];
                var MonthName = PersianCalendar.GetMonth(DateTime.Value);
                var YearNumeral = PersianCalendar.GetYear(DateTime.Value);
                string Date = "<span>" + DayName + " - " + DayNumeral + "</span><span>" + MonthNames[MonthName] + " " + YearNumeral + "</span>";
                return Date;
            }
            return null;
        }

        public static string translateToEng(string persianStr)
        {
            Regex regex = new Regex("[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");

            if (regex.IsMatch(persianStr))
            {


                Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
                {
                    ['۰'] = '0',
                    ['۱'] = '1',
                    ['۲'] = '2',
                    ['۳'] = '3',
                    ['۴'] = '4',
                    ['۵'] = '5',
                    ['۶'] = '6',
                    ['۷'] = '7',
                    ['۸'] = '8',
                    ['۹'] = '9'
                };

                foreach (var item in persianStr)
                {
                    persianStr = persianStr.Replace(item, LettersDictionary[item]);
                }
            }

            return persianStr;

        }
    }
}
