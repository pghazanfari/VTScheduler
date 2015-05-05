using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VTSchedulerEngine;

namespace VTScheduler
{
    public partial class chooseSemesterForm : Form
    {
        public chooseSemesterForm()
        {
            InitializeComponent();
        }

        private void confirmSemesterButton_Click(object sender, EventArgs e)
        {
            int index = semesterSelector.SelectedIndex;
            TimetableRequest.SemesterType semester = TimetableRequest.SemesterType.Fall;
            switch (index)
            {
                case 0:
                {
                    semester = TimetableRequest.SemesterType.Fall;
                    break;
                }
                case 1:
                {
                    semester = TimetableRequest.SemesterType.Spring;
                    break;
                }
                case 2:
                {
                    semester = TimetableRequest.SemesterType.Winter;
                    break;
                }
                case 3:
                {
                    semester = TimetableRequest.SemesterType.Summer1;
                    break;
                }
                case 4:
                {
                    semester = TimetableRequest.SemesterType.Summer2;
                    break;
                }
            }
            

            int year = int.Parse(yearSelector.SelectedItem.ToString());

            MainForm form = new MainForm(this, semester, year);
            form.Show();


            this.Hide();
        }

        private void chooseSemesterForm_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            yearSelector.Items.Add(today.Year);
            yearSelector.Items.Add(today.Year + 1);
        }

        private void semesterSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            confirmSemesterButton.Enabled = true;
        }

        private void yearSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            confirmSemesterButton.Enabled = true;
        }
    }
}
