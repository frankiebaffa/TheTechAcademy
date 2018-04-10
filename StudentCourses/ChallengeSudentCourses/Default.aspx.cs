using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */

            List<Course> courses = new List<Course>()
            {
                new Course() { CourseId=001, Name="Calculus I", Students = new List<Student>()
                {
                    new Student() { StudentId = 001, Name = "Frankie Baffa"},
                    new Student() { StudentId = 002, Name = "Jane Doe"},
                } },
                new Course() { CourseId=002, Name="Software Development", Students = new List<Student>()
                {
                    new Student() { StudentId = 003, Name = "John Smith"},
                    new Student() { StudentId = 004, Name = "Barack Obama"}
                } },
                new Course() { CourseId=003, Name="General Chemistry", Students = new List<Student>()
                {
                    new Student() { StudentId = 005, Name = "Donald Trump"},
                    new Student() { StudentId = 006, Name = "Bernie Sanders" }
                } }
            };


            foreach (var course in courses)
            {
                resultLabel.Text += String.Format("<br/>Course: {0} - {1}", course.CourseId, course.Name);
                foreach (var student in course.Students)
                {
                    resultLabel.Text += String.Format("<br/>&nbsp;&nbsp;Student: {0} - {1}", student.StudentId, student.Name);
                }
            }

        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */

            Course course1 = new Course() { CourseId = 1, Name = "Calculus I" };
            Course course2 = new Course() { CourseId = 2, Name = "Software Development" };
            Course course3 = new Course() { CourseId = 3, Name = "General Chemistry" };

            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { 001, new Student{ StudentId = 001, Name = "Frankie Baffa", Courses = new List<Course>(){ course1, course2} } },
                { 002, new Student{ StudentId = 002, Name = "Jane Doe", Courses = new List<Course>(){ course2, course3} } },
                { 003, new Student{ StudentId = 003, Name = "John Smith", Courses = new List<Course>(){ course3, course1} } }
            };

            foreach (var student in students)
            {
                resultLabel.Text += String.Format("<br/>Student: {0} - {1}", student.Value.StudentId, student.Value.Name);
                foreach (var course in student.Value.Courses)
                {
                    resultLabel.Text += String.Format("<br/>&nbsp;&nbsp;Course: {0} - {1}", course.CourseId, course.Name);
                }
            }

        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */
            Student student1 = new Student() { StudentId = 1, Name = "Frankie Baffa" };
            student1.Enrollments = new List<Enrollment>()
            {
                new Enrollment { Grade = 90, Course = new Course { CourseId = 1, Name = "Calculus I"} },
                new Enrollment { Grade = 84, Course = new Course { CourseId = 2, Name = "Software Development"} },
            };
            Student student2 = new Student() { StudentId = 2, Name = "Jane Doe" };
            student2.Enrollments = new List<Enrollment>()
            {
                new Enrollment { Grade = 95, Course = new Course { CourseId = 3, Name = "Differential Equations"} },
                new Enrollment { Grade = 89, Course = new Course { CourseId = 4, Name = "Project Management"} },
            };

            List<Student> students = new List<Student>
            {
                student1, student2
            };

            foreach (var student in students)
            {
                resultLabel.Text += String.Format("<br/>Student: {0} - {1}", student.StudentId, student.Name);
                foreach (var enrollment in student.Enrollments)
                {
                    resultLabel.Text += String.Format("<br/>&nbsp;&nbsp;Grades: {0}% - {1}", enrollment.Grade, enrollment.Course.Name);
                }
            }
        }
    }
}