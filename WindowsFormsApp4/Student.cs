using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double MidtermGrade { get; set; }
        public double FinalGrade { get; set; }
        public Student(string name,string surname, string email, DateTime dateOfBirth, double midtermGrade, double finalGrade)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            MidtermGrade = midtermGrade;
            FinalGrade = finalGrade;
        }

        // Method to get updated information about the student.
        public string GetStudentInfo()
        {
            return $"Name: {Name}, Surname: {Surname}, Email: {Email}, Date of Birth: {DateOfBirth.ToShortDateString()}, Midterm Grade: {MidtermGrade}, Final Grade: {FinalGrade}";
        }
    }
}



