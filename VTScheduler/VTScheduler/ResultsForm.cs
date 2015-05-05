using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

using VTSchedulerEngine;

namespace VTScheduler
{
    public partial class ResultsForm : Form
    {
        private List<KeyValuePair<int, ClassSchedule>> schedules;
        private int index = 0;

        public ResultsForm(List<KeyValuePair<int, ClassSchedule>> schedules)
        {
            this.schedules = schedules;
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            populate(schedules[0].Value);
            if (schedules.Count > 1)
                nextButton.Enabled = true;
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            index = Math.Max(index - 1, 0);
            populate(schedules[index].Value);
            if (index == 0)
                previousButton.Enabled = false;
            nextButton.Enabled = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            index = Math.Min(index + 1, schedules.Count - 1);
            populate(schedules[index].Value);
            if (index == schedules.Count - 1)
                nextButton.Enabled = false;
            previousButton.Enabled = true;
        }

        private void populate(ClassSchedule schedule)
        {
            resultsGrid.Rows.Clear();

            List<String> row = new List<string>();
            foreach (Class c in schedule.Classes) {
                row.Clear();
                row.Add(c.CRN + "");
                row.Add(c.CourseNumber + "");
                row.Add(c.Title);
                row.Add(format(c.Schedule));
                row.Add(c.Location);
                row.Add(c.Instructor);
                resultsGrid.Rows.Add(row.ToArray());
            }
        }

        private string format(ReadOnlyCollection<DatetimeEvent> events)
        {
            Dictionary<string, List<String>> dictionary = new Dictionary<string, List<String>>();
            foreach (DatetimeEvent ev in events)
            {
                string time = ev.toTimeString();
                if (!dictionary.ContainsKey(time))
                    dictionary.Add(time, new List<String>());
                dictionary[time].Add(Datetime.Abbreviate(ev.Start.Day));
            }
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, List<string>> pair in dictionary)
            {
                pair.Value.Sort();
                foreach (string s in pair.Value)
                { builder.Append(s).Append(' '); }
                builder.Append(pair.Key);
            }
            return builder.ToString();
        }
    }
}
