using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp4
{

    internal class Course
    {
        //store a list of students in the course
        private List<Student> students;

        // Constructor to initialize the Course object with an empty list of students
        public Course()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(int index)

        // Check if the index is within the valid range
        {
            if (index >= 0 && index < students.Count)
            {
                students.RemoveAt(index);
            }

        }
        // Method to remove the grade of a student by index and reset it to 0
        public void RemoveGrade(int index)
        {
            if (index >= 0 && index < students.Count)
            {
                students[index].FinalGrade = 0;   // Resetting the final grade of the student at the specified index to 0
            }
        }

        // Method to get the list of students in the course
        public List<Student> GetStudents()
        {
            return students;
        }

        public double CalculateAverage()

        {
            // Check if there are students in the course
            if (students.Count == 0)
            {
                return 0;
            }

            double sum = 0;
            // Iterate through each student and calculate the average of midterm and final grades
            foreach (var student in students)
            {
                sum += (student.MidtermGrade + student.FinalGrade) / 2;
            }
            return sum / students.Count;
        }


        public double CalculateTotalPoints()
        {
            double totalPoints = 0;

            foreach (Student student in students)
            {
                totalPoints += student.MidtermGrade + student.FinalGrade;
            }

            return totalPoints;
        }
        public Student SearchStudentByName(string name)
        {
            // Iterate through each student and check if the name matches 
            foreach (Student student in students)
            {
                if (student.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return student;// Return the student if a match is found
                }
            }
            return null;
        }
    }
    }























