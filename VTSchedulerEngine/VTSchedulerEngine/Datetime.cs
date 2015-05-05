using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSchedulerEngine
{
    public class Datetime : IComparable<Datetime>
    {
        public enum Weekday { MONDAY = 0, TUESDAY = 1, WEDNESDAY = 2, THURSDAY = 3, FRIDAY = 4, SATURDAY = 5, SUNDAY = 6 };

        public static Weekday WeekdayFromString(string s)
        {
            s = s.ToLower();
            if (s.Equals("m")) return Weekday.MONDAY;
            if (s.Equals("t")) return Weekday.TUESDAY;
            if (s.Equals("w")) return Weekday.WEDNESDAY;
            if (s.Equals("r")) return Weekday.THURSDAY;
            if (s.Equals("f")) return Weekday.FRIDAY;

            return Weekday.MONDAY;
        }

        public static string Abbreviate(Weekday weekday)
        {
            switch (weekday)
            {
                case Weekday.MONDAY:
                {
                    return "M";
                }

                case Weekday.TUESDAY:
                {
                    return "T";
                }
                case Weekday.WEDNESDAY:
                {
                    return "R";
                }
                case Weekday.THURSDAY:
                {
                    return "M";
                }
                case Weekday.FRIDAY:
                {
                    return "F";
                }
                case Weekday.SATURDAY:
                {
                    return "Sat";
                }
                case Weekday.SUNDAY:
                {
                    return "Sun";
                }
            }
            return "";
        }

        public int WeekdayIndex { get; private set; }
        public Weekday Day
        {
            get { return (Weekday)WeekdayIndex; }
        }
        public int Hour { get; private set; }
        public int Minute { get; private set; }

        public Datetime(int weekday, int hour, int minute)
        {
            WeekdayIndex = weekday;
            Hour = hour;
            Minute = minute;
        }

        public Datetime(Weekday day, int hour, int minute)
            : this((int)day, hour, minute)
        { }

        public Datetime(string day, int hour, int minute) 
            : this(WeekdayFromString(day), hour, minute) 
        { }

        public int CompareTo(Datetime wdt)
        {
            if (wdt.WeekdayIndex != WeekdayIndex) return WeekdayIndex.CompareTo(wdt.WeekdayIndex);
            if (wdt.Hour != Hour) return Hour.CompareTo(wdt.Hour);
            return Minute.CompareTo(wdt.Minute);
        }

        public string toTimeString()
        {
            string suffix = Hour >= 12 ? "PM" : "AM";
            int h = Hour > 12 ? Hour - 12 : Hour;
            string hour = h < 10 ? "0" + h : "" + h;
            string min = Minute < 10 ? "0" + Minute : "" + Minute;
            return hour + ":" + min + " " + suffix;
        }

        public override string ToString()
        {
            string suffix = Hour >= 12 ? "PM" : "AM";
            int h = Hour > 12 ? Hour - 12 : Hour;
            string hour = h < 10 ? "0" + h : "" + h;
            string min = Minute < 10 ? "0" + Minute : "" + Minute;
            return Day.ToString() + " " + hour + ":" + min + suffix;
        }
    }

    public class DatetimeEvent : IComparable<DatetimeEvent>
    {
        public Datetime Start { get; private set; }
        public Datetime End { get; private set; }
        public int Duration { get; private set; }

        public DatetimeEvent(Datetime start, int duration)
        {
            Start = start;
            int endhour = start.Hour + (duration + start.Minute > 59 ? 1 : 0);
            int endminute = (start.Minute + duration) % 60;
            End = new Datetime(start.WeekdayIndex, endhour, endminute);
            Duration = duration;
        }

        public bool Intersects(DatetimeEvent ev)
        {
            if (Start.WeekdayIndex == ev.Start.WeekdayIndex)
            {
                int start1 = Start.Hour * 60 + Start.Minute;
                int end1 = start1 + Duration;

                int start2 = ev.Start.Hour * 60 + ev.Start.Minute;
                int end2 = start2 + ev.Duration;

                return start2 >= start1 && start2 <= end1;
            }
            return false;
        }

        public int CompareTo(DatetimeEvent wdt)
        {
            return Start.CompareTo(wdt.Start);
        }

        public string toTimeString() 
        {
            return Start.toTimeString() + "-" + End.toTimeString();
        }

        public override string ToString()
        {
            string suffix = End.Hour >= 12 ? "PM" : "AM";
            int h = End.Hour > 12 ? End.Hour - 12 : End.Hour;
            string hour = h < 10 ? "0" + h : "" + h;
            string min = End.Minute < 10 ? "0" + End.Minute : "" + End.Minute;

            return Start.ToString() + " - " + hour + ":" + min + suffix;
        }
    }
}
