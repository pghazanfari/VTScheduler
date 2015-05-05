using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using VTSchedulerEngine;

namespace VTScheduler
{
    public partial class MainForm : Form
    {
        private Form parent;

        private Preferences preferences;

        private String[] subjects;
        private String[] detailedSubjects;

        private String[] currentClasses;
        private String[] currentClassesInformation;

        private List<String> addedClasses;
        private List<String> addedClassesInformation;

        public TimetableRequest.SemesterType Semester { get; private set; }
        
        public int Year { get; private set; }

        public MainForm(Form parentForm, TimetableRequest.SemesterType semester, int year)
        {
            parent = parentForm;
            Semester = semester;
            Year = year;

            addedClasses = new List<string>();
            addedClassesInformation = new List<string>();
            preferences = new Preferences();

            InitializeComponent();
        }

        private static String[] loadFile(string file)
        {
            StreamReader reader = new StreamReader(file);
            String line;
            List<String> lines = new List<string>();
            while ((line = reader.ReadLine()) != null)
                lines.Add(line);
            return lines.ToArray();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            subjects = loadFile("subjects.txt");
            detailedSubjects = loadFile("detailed_subjects.txt");

            subjectSelector.Items.AddRange(detailedSubjects);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Close();
        }

        private void loadClassesButton_Click(object sender, EventArgs e)
        {
            TimetableRequest request = new TimetableRequest();
            request.Campus = TimetableRequest.CampusType.Blacksburg;
            request.Semester = Semester;
            request.Year = Year;
            request.Subject = subjects[subjectSelector.SelectedIndex];

            List<Class> classes = request.Post();
            HashSet<String> uniqueClasses = new HashSet<string>();
            List<String> classDescriptions = new List<string>();
            List<String> classInformation = new List<string>();
            foreach (Class c in classes)
            {
                if (!uniqueClasses.Contains(c.Title))
                {
                    uniqueClasses.Add(c.Title);
                    classDescriptions.Add(c.Course + " - " + c.Title);
                    classInformation.Add(subjects[subjectSelector.SelectedIndex] + " " + c.CourseNumber);
                }
            }
            currentClasses = classDescriptions.ToArray();
            currentClassesInformation = classInformation.ToArray();
            classesList.Items.Clear();
            classesList.Items.AddRange(currentClasses);
            
        }

        private void subjectSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadClassesButton.Enabled = true;
        }

        private void classesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addClassButton.Enabled = true;
        }

        private void addedClassesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeClassButton.Enabled = true;
        }

        private void addClassButton_Click(object sender, EventArgs e)
        {
            string selectedClass = currentClasses[classesList.SelectedIndex];
            string selectedClassInformation = currentClassesInformation[classesList.SelectedIndex];

            if (!addedClassesInformation.Contains(selectedClassInformation))
            {
                addedClasses.Add(selectedClass);
                addedClassesInformation.Add(selectedClassInformation);
                addedClassesList.Items.Add(selectedClass);
            }
        }

        private void removeClassButton_Click(object sender, EventArgs e)
        {
            addedClasses.RemoveAt(addedClassesList.SelectedIndex);
            addedClassesInformation.RemoveAt(addedClassesList.SelectedIndex);
            addedClassesList.Items.RemoveAt(addedClassesList.SelectedIndex);
        }

        private void findScheduleButton_Click(object sender, EventArgs e)
        {
            preferences.DislikeMorning = preferencesList.CheckedIndices.Contains(0);
            preferences.DislikeEvening = preferencesList.CheckedIndices.Contains(1);
            preferences.DislikeFriday = preferencesList.CheckedIndices.Contains(2);
            preferences.AvoidGaps = preferencesList.CheckedIndices.Contains(3);

            List<ClassSchedule> list = ClassSchedule.GetPossibleSchedules(
                TimetableRequest.CampusType.Blacksburg, Year, Semester, 
                TimetableRequest.Section.All, addedClassesInformation.ToArray());

            List<KeyValuePair<int, ClassSchedule>> scores = new List<KeyValuePair<int, ClassSchedule>>();
            foreach (ClassSchedule sched in list)
                scores.Add(new KeyValuePair<int, ClassSchedule>(preferences.Score(sched), sched));
            scores.Sort(delegate(KeyValuePair<int, ClassSchedule> a, KeyValuePair<int, ClassSchedule> b)
            {
                return b.Key.CompareTo(a.Key); //Sort in descending order
            });

            ResultsForm form = new ResultsForm(scores);
            form.Show();
        }
    }
}
