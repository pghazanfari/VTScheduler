using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

using System.IO;
using System.Net;

namespace VTSchedulerEngine
{
    public class TimetableRequest
    {
        private const string Base = "https://banweb.banner.vt.edu/ssb/prod/HZSKVTSC.P_ProcRequest?";

        public enum CampusType { Blacksburg = 0, Virtual = 10, Western = 2, Valley = 3, NationalCapitalRegion = 4, Central = 6, HamptonRoadsCenter = 7, Capital = 8, Other = 9 };
        public enum SemesterType {Fall = 9, Winter = 12, Spring = 1, Summer1 = 6, Summer2 = 7};
        public enum Section { All, IndependentStudy, Lab, Lecture, Recitation, Research };


        public CampusType Campus { get; set; }
        public int Year { get; set; }
        public SemesterType Semester { get; set; }
        private string CoreCode = "AR%25";
        public string Subject { get; set; }
        public Section SectionType { get; set; }
        public int CourseNumber { get; set; }
        public int CRN { get; set; }
        public bool OpenOnly { get; set; }

        public TimetableRequest()
        {
            Campus = CampusType.Blacksburg;
            Year = DateTime.Now.Year;
            SectionType = Section.All;
            OpenOnly = false;
        }

        private string getSectionString(Section s)
        {
            switch (s)
            {
                case Section.IndependentStudy:
                    return "%I%";
                case Section.Lab:
                    return "%B%";
                case Section.Lecture:
                    return "%L%";
                case Section.Recitation:
                    return "%C%";
                case Section.Research:
                    return "%R%";
            }
            return "%25";
        }

        public List<Class> Post()
        {
            string campus = "" + ((int)Campus);
            //if (campus.Length == 1) campus = "0" + campus;

            string semester = "" + ((int)Semester);
            if (semester.Length == 1) semester = "0" + semester;

            string s = Base + "CAMPUS="  + campus + 
                "&TERMYEAR=" + Year + semester + 
                "&CORE_CODE=" + CoreCode +
                "&subj_code=" + Subject + 
                "&SCHDTYPE=" + getSectionString(SectionType) + 
                "&CRSE_NUMBER=" + (CourseNumber < 1000 ? "" : "" + CourseNumber) + 
                "&crn=" + (CRN == 0 ? "" : "" + CRN) + 
                "&open_only=" + (OpenOnly ? "on" : "") + 
                "&BTN_PRESSED=FIND+class+section&inst_name=";


            string http = null;
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(s);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                http = reader.ReadToEnd();
                stream.Close();
                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            if (http == null)
                return null;

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(http);

            List<Class> classes = new List<Class>();

            List<List<string>> grid = new List<List<string>>();

            HtmlNode table = doc.DocumentNode.SelectSingleNode("//table[@class='dataentrytable']");
            HtmlNode[] arr = table.Descendants("tr").ToArray();
            int index = 0;
            foreach (HtmlNode row in arr)
            {
                List<HtmlNode> cols = row.Elements("td").ToList();//row.ChildNodes.ToList();

                if (index++ == 0 || cols[0].Element("a") == null)
                    continue;
                int r = grid.Count - 1;
                //grid.Add(new List<string>());

                int crn;
                string course;
                string title;
                string type;
                int creditHours;
                int capacity;
                string instructor;
                //ReadOnlyCollection<DatetimeEvent> Schedule { get; private set; }
                string location;

                string[] days;
                string[] begin;
                string[] end;


                try
                {
                    //Add CRN
                    crn = Convert.ToInt32(cols[0].Element("a").Element("b").InnerText.Trim());
                }
                catch (Exception e)
                {
                    crn = 0;
                }
                //Add Course
                course = cols[1].InnerText.Trim();
                //Add Title
                title = cols[2].InnerText.Trim();
                //Add Type
                type = cols[3].InnerText.Trim();
                //Add Credit Hours
                try
                {
                    creditHours = Convert.ToInt32(cols[4].InnerText.Trim());
                }
                catch (Exception e)
                {
                    creditHours = 0;
                }

                try
                {
                    //Add Capacity
                    capacity = Convert.ToInt32(cols[5].InnerText.Trim());
                }
                catch (Exception e)
                {
                    capacity = 0;
                }

                //Add Instructor
                instructor = cols[6].InnerText.Trim();

                List<DatetimeEvent> dt = new List<DatetimeEvent>();
                try
                {
                    //Add Days
                    days = cols[7].InnerText.Trim().Split(' ');

                    //Add Begin
                    string _begin = cols[8].InnerText.Trim();
                    string beginAmPm = _begin.Substring(_begin.Length - 2);
                    begin = _begin.Substring(0, _begin.Length - 2).Split(':');

                    //Add End
                    string _end = cols[9].InnerText.Trim();
                    string endAmPm = _end.Substring(_end.Length - 2);
                    end = _end.Substring(0, _end.Length - 2).Split(':');

                    
                    for (int i = 0; i < days.Length; i++)
                    {
                        int sHour = Convert.ToInt32(begin[0]) + (beginAmPm.ToLower().Equals("am") ? 0 : 12);
                        int sMinute = Convert.ToInt32(begin[1]);

                        int eHour = Convert.ToInt32(end[0]) + (endAmPm.ToLower().Equals("am") ? 0 : 12);
                        int eMinute = Convert.ToInt32(end[1]);

                        Datetime start = new Datetime(days[i], sHour, sMinute);
                        int duration = (eHour - sHour) * 60 + eMinute - sMinute;
                        DatetimeEvent ev = new DatetimeEvent(start, duration);
                        dt.Add(ev);
                    }
                }
                catch (Exception e) { }

                //Add Location
                location = cols[10].InnerText.Trim();

                Class cl = new Class(crn, course, title, type, creditHours, capacity, instructor, location, dt.ToArray());
                classes.Add(cl);
            }

            return classes;
        }
    }
}
