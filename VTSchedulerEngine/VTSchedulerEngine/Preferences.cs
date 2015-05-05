using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSchedulerEngine
{
    public class Preferences
    {
        public bool DislikeMorning { get; set; }
        public bool DislikeEvening { get; set; }
        public bool DislikeFriday { get; set; }
        public bool AvoidGaps { get; set; }

        public Preferences() { }

        public int Score(ClassSchedule schedule)
        {
            Dictionary<Datetime.Weekday, List<DatetimeEvent>> dictionary = new Dictionary<Datetime.Weekday, List<DatetimeEvent>>();
            foreach (Class c in schedule.Classes)
            {
                foreach (DatetimeEvent ev in c.Schedule)
                {
                    if (!dictionary.ContainsKey(ev.Start.Day))
                        dictionary[ev.Start.Day] = new List<DatetimeEvent>();

                    dictionary[ev.Start.Day].Add(ev);
                }
            }

            foreach (KeyValuePair<Datetime.Weekday, List<DatetimeEvent>> pair in dictionary)
                pair.Value.Sort();

            int sum = 0;
            if (DislikeMorning)
                sum += scoreDislikeMorning(dictionary);
            if (DislikeEvening)
                sum += scoreDislikeEvening(dictionary);
            if (DislikeFriday)
                sum += scoreDislikeFriday(dictionary);
            if (AvoidGaps)
                sum += scoreAvoidGaps(dictionary);

            return sum;

        }

        private int scoreAvoidGaps(Dictionary<Datetime.Weekday, List<DatetimeEvent>> schedule)
        {
            int sum = 0;
            foreach (KeyValuePair<Datetime.Weekday, List<DatetimeEvent>> pair in schedule)
            {
                for (int i = 0; i < pair.Value.Count - 1; i++)
                {
                    int minBetween = (pair.Value[i + 1].Start.Hour - pair.Value[i].Start.Hour) * 60 + pair.Value[i + 1].Start.Minute - pair.Value[i].Start.Minute;
                    if (minBetween > 15)
                    {
                        float score = (float)Math.Pow(Math.E, 6 - minBetween / 20.0);
                        sum += Math.Min((int)score, 100);
                    }
                }
            }
            return -sum;
        }

        private int scoreDislikeMorning(Dictionary<Datetime.Weekday, List<DatetimeEvent>> schedule)
        {
            int sum = 0;
            foreach (KeyValuePair<Datetime.Weekday, List<DatetimeEvent>> pair in schedule)
            {
                foreach (DatetimeEvent ev in pair.Value)
                {
                    if (ev.Start.Hour < 12)
                        sum += (12 - ev.Start.Hour - 1) * 60 + 60 - ev.Start.Minute;
                }
            }
            return -sum;
        }

        private int scoreDislikeEvening(Dictionary<Datetime.Weekday, List<DatetimeEvent>> schedule)
        {
            int sum = 0;
            foreach (KeyValuePair<Datetime.Weekday, List<DatetimeEvent>> pair in schedule)
            {
                foreach (DatetimeEvent ev in pair.Value)
                {
                    if (ev.Start.Hour >= 5)
                        sum += (ev.Start.Hour - 5) * 60 + ev.Start.Minute;
                }
            }
            return -sum;
        }

        private int scoreDislikeFriday(Dictionary<Datetime.Weekday, List<DatetimeEvent>> schedule)
        {
            if (schedule.ContainsKey(Datetime.Weekday.FRIDAY))
                return schedule[Datetime.Weekday.FRIDAY].Count * -120;
            else
                return 0;
        }
    }
}
