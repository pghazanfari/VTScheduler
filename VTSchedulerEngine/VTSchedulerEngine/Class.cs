using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace VTSchedulerEngine
{
    public class Class
    {
        public int CRN { get; private set; }
        public string Course { get; private set; }
        public string Title { get; private set; }
        public string Type { get; private set; }
        public int CreditHours { get; private set; }
        public int Capacity { get; private set; }
        public string Instructor { get; private set; }
        public ReadOnlyCollection<DatetimeEvent> Schedule { get; private set; }
        public string Location { get; private set; }

        public Class(int crn, string course, string title, string type, int crhrs, int capacity, string instructor, string location, params DatetimeEvent[] schedule)
        {
            Schedule = new ReadOnlyCollection<DatetimeEvent>(schedule);
            CRN = crn;
            Course = course;
            Title = title;
            Type = type;
            CreditHours = crhrs;
            Capacity = capacity;
            Instructor = instructor;
            Location = location;
        }
        
        public bool Intersects(Class c)
        {
            foreach (DatetimeEvent e1 in Schedule)
                foreach (DatetimeEvent e2 in c.Schedule)
                    if (e1.Intersects(e2)) return true;

            return false;
        }

        public override string ToString()
        {
            string sum = CRN + " " + Course + ": " + Title + "\n";
            foreach (DatetimeEvent ev in Schedule)
                sum += ev.ToString() + "\n";

            return sum;
        }
    }
}
