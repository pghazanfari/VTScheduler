using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSchedulerEngine
{
    public class ClassSchedule
    {
        public ReadOnlyCollection<Class> Classes { get; private set; }

        private ClassSchedule(params Class[] classes)
        {
            Classes = new ReadOnlyCollection<Class>(classes);
        }

        private static bool checkForClassIntersections(List<Class> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i != j)
                    {
                        if (list[i].Intersects(list[j]))
                            return true;
                    }
                }
            }
            return false;
        }

        public static List<ClassSchedule> GetPossibleSchedules(
            TimetableRequest.CampusType campus, 
            int year, 
            TimetableRequest.SemesterType semester, 
            TimetableRequest.Section section,
            params string[] classes)
        {
            List<ClassSchedule> schedules = new List<ClassSchedule>();

            List<List<Class>> list = new List<List<Class>>(classes.Length);
            for (int i = 0; i < classes.Length; i++)
            {
                string[] info = classes[i].Split(' ');
                TimetableRequest req = new TimetableRequest();
                req.Campus = campus;
                req.Year = year;
                req.Semester = semester;
                req.SectionType = section;
                req.Subject = info[0];
                req.CourseNumber = Convert.ToInt32(info[1]);
                List<Class> results = req.Post();
                list.Add(results);
                //list.Add(req.Post());
            }
            int[] indices = new int[list.Count];
            int mindex = list.Count - 1;
            while (indices[0] < list[0].Count)
            {
                List<Class> sched = new List<Class>(list.Count);
                for (int j = 0; j < list.Count; j++)
                {
                    sched.Add(list[j][indices[j]]);
                }

                if (!checkForClassIntersections(sched))
                    schedules.Add(new ClassSchedule(sched.ToArray()));

                indices[indices.Length - 1]++;
                int i = indices.Length - 1;
                while (i >= 1 && indices[i] >= list[i].Count)
                {
                    indices[i - 1]++;
                    indices[i] = 0;
                    i--;
                }
            }

            return schedules;
        }

        public override string ToString()
        {
            string sum = "";
            foreach (Class c in Classes)
            {
                sum += c.ToString() + "\n";
            }
            return sum;
        }
    }
}
