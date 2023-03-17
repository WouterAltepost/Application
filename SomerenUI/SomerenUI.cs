using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.VisualBasic.Logging;
using System.Diagnostics;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        public async Task<dynamic> ProcessList(Func<dynamic> targetFunction)
        {
            PanelTitle.Text = "Loading...";
            return await Task.Factory.StartNew(() =>
            {
                return targetFunction();
            });
        }

        private void ShowDashboardPanel()
        {
            // Reset the main panel and hide it
            ResetPanel();
            PanelMain.Visible = false;

            // show dashboard
            pnlDashboard.Visible = true;
        }

        private async void ShowLecturersPanel()
        {
            try
            {
                ResetPanel();
                List<Human> teachers = await ProcessList(GetTeachers);
                ResetPanel(title: "Lecturers");

                DisplayTeachers(teachers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
            }

        }

        private void ResetPanel(string title = "") {
            PanelMain.Visible = true;
            PanelTitle.Text = title;
            ListViewMain.Clear();
        }

        private async void ShowStudentsPanel()
        {

            /*
            List<Room> rooms = GetRooms();

            foreach (Room room in rooms)
            {
                MessageBox.Show(room.ToString());
            }
             */

            try
            {
                ResetPanel();
                List<Human> students = await ProcessList(GetStudents);
                ResetPanel(title: "Students");

                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private List<Room> GetRooms()
        {
            RoomService roomService = new RoomService();
            List<Room> rooms = roomService.GetRooms();
            return rooms;
        }

        private List<Human> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();
            return students.Cast<Human>().ToList();
        }

        private List<Human> GetTeachers()
        {
            TeacherService teacherService = new TeacherService();
            List<Teacher> teachers = teacherService.GetTeacher();
            return teachers.Cast<Human>().ToList();
        }

        private void DisplayStudents(List<Human> students)
        {
            // clear the listview before filling it
            ListViewMain.Clear();

            foreach (Student student in students)
            {
                ListViewItem li = new ListViewItem(student.Name);
                li.Tag = student;   // link student object to listview item
                ListViewMain.Items.Add(li);
            }
        }

        private void DisplayTeachers(List<Human> teachers)
        {
            // clear the listview before filling it
            ListViewMain.Clear();

            foreach (Teacher teacher in teachers)
            {
                ListViewItem li = new ListViewItem(teacher.Name);
                li.Tag = teacher;   // link student object to listview item
                ListViewMain.Items.Add(li);
            }
        }

        private void dashboardToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }
        
        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLecturersPanel();
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}