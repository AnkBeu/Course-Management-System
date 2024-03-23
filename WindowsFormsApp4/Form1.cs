using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        private Course course = new Course();
        private double totalPoints;

        public Form1()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form1_Load);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListBox(); // Call the method to update ListBox on form load
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            {
                // Get the trimmed text content of the 'txtStudentName' TextBox and store it in the 'name' variable.
                string name = txtStudentName.Text.Trim();
                string email = txtStudentEmail.Text.Trim();
                string surname = txtSurname.Text.Trim();
                DateTime dateOfBirth = dateTimePicker1.Value;
                bool isValidMidtermGrade = double.TryParse(textBox4.Text.Trim(), out double midtermGrade);
                bool isValidFinalGrade = double.TryParse(textBox5.Text.Trim(), out double finalGrade);



                // Checking if name, surname, and email are not empty
                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(surname) && !string.IsNullOrWhiteSpace(email))
                {
                    // Checking if grades are valid and within the expected range
                    if (isValidMidtermGrade && isValidFinalGrade
                        && (midtermGrade >= 0 && midtermGrade <= 30) && (finalGrade >= 0 && finalGrade <= 70))
                    {
                        try
                        {
                            // Creating a new Student object
                            Student newStudent = new Student(name, surname, email, dateOfBirth, midtermGrade, finalGrade);
                            course.AddStudent(newStudent);
                            UpdateListBox();

                            // Clear input fields after adding a student
                            txtStudentName.Clear();
                            txtSurname.Clear();
                            txtStudentEmail.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            dateTimePicker1.Value = DateTime.Now; // Reset DateTimePicker
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid grades).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter  valid information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            // Get the index of the selected item in the list box.
            int selectedIndex = lstStudents.SelectedIndex;

            // Check if a student is selected (index is not -1)
            if (selectedIndex >= 0)
            {
                // Remove the selected student from the 'course' object.
                course.RemoveStudent(selectedIndex);
                UpdateListBox();
                // Clear the text boxes related to student information.
                txtStudentName.Clear();
                txtSurname.Clear();
                txtStudentEmail.Clear();
                dateTimePicker1.Value = DateTime.Now;
                textBox4.Clear();
                textBox5.Clear();

            }
            else
            {
                MessageBox.Show("Please select a student to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstStudents.SelectedIndex;

            if (selectedIndex >= 0)
            {
               // Get  the selected student from the 'course' object based on the index.
                Student selectedStudent = course.GetStudents()[selectedIndex];

                // Update the details of the selected student with the values from the text boxes.
                selectedStudent.Name = txtStudentName.Text.Trim();
                selectedStudent.Surname = txtSurname.Text.Trim();
                selectedStudent.Email = txtStudentEmail.Text.Trim();
                selectedStudent.DateOfBirth = dateTimePicker1.Value;
                selectedStudent.MidtermGrade = double.Parse(textBox4.Text);
                selectedStudent.FinalGrade = double.Parse(textBox5.Text);

                // Refresh the ListBox with updated student information
                UpdateListBox();
                txtStudentName.Clear();
                txtSurname.Clear();
                txtStudentEmail.Clear();
                dateTimePicker1.Value = DateTime.Now;
                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                MessageBox.Show("Please select a student to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (course.GetStudents().Count > 0)
            {
                double average = course.CalculateAverage();


                double totalPoints = course.CalculateTotalPoints();

                // Calculate letter grade for the total points
                string letterGrade = CalculateLetterGrade(totalPoints);

                MessageBox.Show($"Average: {average:F2}\nLetter Grade for Total Points: {letterGrade}",
                    "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There are no students in the course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string CalculateLetterGrade(double totalPoints)
        {
            if (totalPoints >= 90)
            {
                return "A";
            }
            else if (totalPoints >= 80)
            {
                return "B";
            }
            else if (totalPoints >= 70)
            {
                return "C";
            }
            else if (totalPoints >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }







        private void UpdateListBox()
        {
            // Clear all existing items in the lstStudents ListBox.
            lstStudents.Items.Clear();

            // Get the list of students from the 'course' object.
            List<Student> students = course.GetStudents();

            // Iterate through each student in the list.
            foreach (Student student in students)
            {
                // Add the updated student information to the lstStudents ListBox.
                lstStudents.Items.Add(student.GetStudentInfo());
            }
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Checking if an item is selected in the list
            if (lstStudents.SelectedIndex >= 0)
            {
                // Take the selected student from the list using the index
                Student selectedStudent = course.GetStudents()[lstStudents.SelectedIndex];

                // Display the student's information in the input fields for editing
                txtStudentName.Text = selectedStudent.Name;
                txtSurname.Text = selectedStudent.Surname;
                txtStudentEmail.Text = selectedStudent.Email;
                dateTimePicker1.Value = selectedStudent.DateOfBirth;
                textBox4.Text = selectedStudent.MidtermGrade.ToString();
                textBox5.Text = selectedStudent.FinalGrade.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // Calling the SearchStudentByName method to find a student by name
            Student foundStudent = course.SearchStudentByName(searchTerm);

            if (foundStudent != null)
            {
                MessageBox.Show($"Student found!\nName: {foundStudent.Name}\nSurname: {foundStudent.Surname}\nEmail: {foundStudent.Email}");
            }
            else
            {
                MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
    
    




