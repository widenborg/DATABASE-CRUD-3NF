﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgAssignment
{
    public partial class Form : System.Windows.Forms.Form
    {
        DataAccessLayer DAL = new DataAccessLayer();

        public Form()
        {
            InitializeComponent();
            PopulateDataGridViewWithStudents();
            PopulateDataGridViewWithCourses();
            PopulateDataGridViewWithTeachers();
            PopulateDataGridViewWithTeachersOnCourses();
            //PopulateDataGridViewWithExams();
            //PopulateDataGridViewWithStudentLoans();
            //PopulateExamDataGridViewWithCourses();
            //PopulateExamDataGridViewWithStudents();
        }


        //Student
        public void PopulateDataGridViewWithStudents()
        {
            try
            {
                dataGridViewStudent.DataSource = DAL.GetStudents().Tables[0];
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {

                }
            }

        }

        //Add student
        private void studentAddButton_Click(object sender, EventArgs e)
        {
            string newStudentID = studentIDTxtField.Text;
            string newStudentName = studentNameTxtField.Text;

            if (String.IsNullOrEmpty(newStudentID) && String.IsNullOrEmpty(newStudentName))
            {
                studentResponsTxtField.Text = "Please fill in both ID and name to add a student";
            }
            else if (String.IsNullOrEmpty(newStudentID))
            {
                studentResponsTxtField.Text = "Student must have an ID";
            }
            else if (String.IsNullOrEmpty(newStudentName))
            {
                studentResponsTxtField.Text = "Student must have a name";
            }
            else
            {
                try
                {
                    DAL.CreateStudent(newStudentID, newStudentName);
                    PopulateDataGridViewWithStudents();
                    studentResponsTxtField.Text = "Student was successfully added!";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        studentResponsTxtField.Text = "Student ID already excists, please choose another";
                    }
                }
            }
        }

        //Update student
        private void studentUpdateButton_Click(object sender, EventArgs e)
        {
            string newStudentID = studentIDTxtField.Text;
            string newStudentName = studentNameTxtField.Text;

            if (string.IsNullOrEmpty(newStudentID) && string.IsNullOrEmpty(newStudentName))
            {
                studentResponsTxtField.Text = "Please fill in Student ID and the new name";
            }
            else if (string.IsNullOrEmpty(newStudentID))
            {
                studentResponsTxtField.Text = "Please fill in the ID on the student you want to update";
            }
            else if (string.IsNullOrEmpty(newStudentName))
            {
                studentResponsTxtField.Text = "Please fill in the new name of the student";
            }
            else
            {
                try
                {
                    DAL.UpdateStudent(newStudentID, newStudentName);

                    PopulateDataGridViewWithStudents();
                    studentResponsTxtField.Text = "Student was successfully updated!";
                }
                catch (SqlException ex)
                {
                   
                }

            }
        }

        //Delete student
        private void studentDeleteButton_Click(object sender, EventArgs e)
        {
            string newStudentID = studentIDTxtField.Text;
            if (string.IsNullOrEmpty(newStudentID))
            {
                studentResponsTxtField.Text = "Please fill in the ID on the student you want to delete";
            }
            else if (newStudentID == null)
            {
                studentResponsTxtField.Text = "Student ID does not exist";
            }
            else
            {
                try
                {
                    DAL.DeleteStudent(newStudentID);

                    PopulateDataGridViewWithStudents();
                    studentResponsTxtField.Text = "Student was successfully deleted!";
                }
                catch(SqlException ex)
                {

                }
            }
        }


        //Course

        public void PopulateDataGridViewWithCourses()
        {
            try
            {
                dataGridViewCourses.DataSource = DAL.GetCourse().Tables[0];
            }
            catch (SqlException ex)
            {

            }
        }

        //Add course
        private void courseAddButton_Click(object sender, EventArgs e)
        {
            string newCourseID = courseIDTxtField.Text;
            string newCourseName = courseNameTxtField.Text;

            if (string.IsNullOrEmpty(newCourseID) && string.IsNullOrEmpty(newCourseName) && string.IsNullOrEmpty(courseCreditsTxtField.Text))
            {                 
                courseResponseTxtField.Text = "Fill in all required field";
            }
            else if (string.IsNullOrEmpty(newCourseID))
            {
                courseResponseTxtField.Text = "The course must have an ID, fill that in";
            }
            else if (string.IsNullOrEmpty(newCourseName))
            {
                courseResponseTxtField.Text = "Fill in the Name of the course you want to add";
            }
            else if (string.IsNullOrEmpty(courseCreditsTxtField.Text))
            {
                courseResponseTxtField.Text = "Fill in the amount of credits this course is worth";
            }
            else
            {
                try
                {
                    int newCredits = int.Parse(courseCreditsTxtField.Text);
                    DAL.AddCourse(newCourseID, newCourseName, newCredits);
                    PopulateDataGridViewWithCourses();
                    courseResponseTxtField.Text = "A course was successfully added!";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        courseResponseTxtField.Text = "That courseID is taken, choose another";
                    }
                }
            }
        }

        //Update course
        private void courseUpdateButton_Click(object sender, EventArgs e)
        {
            string newCourseID = courseIDTxtField.Text;
            string newCourseName = courseNameTxtField.Text;
            
            if (string.IsNullOrEmpty(newCourseID) && string.IsNullOrEmpty(newCourseName) && string.IsNullOrEmpty(courseCreditsTxtField.Text))
            {
                courseResponseTxtField.Text = "Fill in all required fields";
            }
            else if(string.IsNullOrEmpty(newCourseID))
            {
                courseResponseTxtField.Text = "Fill in the courseID";
            }
            else if (string.IsNullOrEmpty(newCourseName))
            {
                courseResponseTxtField.Text = "Fill in the course Name";
            }
            else if (string.IsNullOrEmpty(courseCreditsTxtField.Text))
            {
                courseResponseTxtField.Text = "Please fill in the credits";
            }

            try
            {
                int newCredits = int.Parse(courseCreditsTxtField.Text);
                DAL.UpdateCourse(newCourseID, newCourseName, newCredits);

                PopulateDataGridViewWithCourses();
                courseResponseTxtField.Text = "The course was successfully updated!";
            }
            catch (FormatException)//Blir fel atm
            {
                courseResponseTxtField.Text = "The credits must be a number";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)//ej användbart
                {

                }
                
             
            }
        }





        //Delete course
        private void courseDeleteButton_Click(object sender, EventArgs e)
        {
            string newCourseID = courseIDTxtField.Text;

            if (string.IsNullOrEmpty(newCourseID))
            {
                courseResponseTxtField.Text = "Please fill in the course ID of the course you want to delete";
            }
            else
            {
                try {
                    DAL.DeleteCourse(newCourseID);
                    PopulateDataGridViewWithCourses();
                    courseResponseTxtField.Text = "The course was successfully deleted!";
                }
                catch (SqlException ex)
                {
                                        
                }
            }
        }

        //Teacher
        public void PopulateDataGridViewWithTeachers()
        {
            try
            {
                dataGridViewTeachers.DataSource = DAL.GetTeacher().Tables[0];
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {

                }
            }
        }

        //Add teacher
        public void teacherAddButton_Click(object sender, EventArgs e)
        {
            string newEmpID = teacherIDTxtField.Text;
            string newEmpName = teacherNameTxtField.Text;

            if (string.IsNullOrEmpty(newEmpID) && string.IsNullOrEmpty(newEmpName))
            {
                teacherResponseTxtField.Text = "Please fill in both required fields";
            }
            else if (string.IsNullOrEmpty(newEmpID))
            {
                teacherResponseTxtField.Text = "Please fill in the TeacherID";
            }
            else if (string.IsNullOrEmpty(newEmpName))
            {
                teacherResponseTxtField.Text = "Please fill in the name of the teacher";
            }
            else
            {
                try
                {
                    DAL.AddTeacher(newEmpID, newEmpName);
                    PopulateDataGridViewWithTeachers();
                    teacherResponseTxtField.Text = "Teacher was successfully added";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        teacherResponseTxtField.Text = "That ID is already in use, please take another";
                    }
                }
            }
        }
        public void teacherUpdateButton_Click(object sender, EventArgs e)
        {
            string newEmpID = teacherIDTxtField.Text;
            string newEmpName = teacherNameTxtField.Text;

            if (string.IsNullOrEmpty(newEmpID) && string.IsNullOrEmpty(newEmpName))
            {
                teacherResponseTxtField.Text = "Please fill in the required fields";
            }
            else if (string.IsNullOrEmpty(newEmpID))
            {
                teacherResponseTxtField.Text = "Please fill in the teacher ID to update a teacher";
            }
            else if (string.IsNullOrEmpty(newEmpName))
            {
                teacherResponseTxtField.Text = "Please fill in the new name";
            }
            else
            {

                try
                {
                    DAL.UpdateTeacher(newEmpID, newEmpName);
                    PopulateDataGridViewWithTeachers();
                    teacherResponseTxtField.Text = "Teacher was successfully updated";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {

                    }
                }
            }
        }

        public void teacherDeleteButton_Click(object sender, EventArgs e)
        {
            string newEmpID = teacherIDTxtField.Text;

            if (string.IsNullOrEmpty(newEmpID))
            {
                teacherResponseTxtField.Text = "Please fill in the ID of the teacher you want to delete";
            }
            else
            {
                try
                {
                    DAL.DeleteTeacher(newEmpID);
                    PopulateDataGridViewWithTeachers();
                    teacherResponseTxtField.Text = "Teacher was successfully deleted!";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {

                    }
                }
            }
        }

        //WorksON
        public void PopulateDataGridViewWithTeachersOnCourses()
        {
            try
            {
                dataGridViewWorksOn.DataSource = DAL.GetWorksOn().Tables[0];
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {

                }
            }
        }

        public void PopulateDataGridViewWithStudentLoans()
        {
            try
            {
                dataGridViewStudentLoan.DataSource = DAL.GetStudentLoan().Tables[0];
            }
            catch (SqlException e)
            {

            }
        }
        //Studies
        public void PopulateDataGridViewWithStudies()
        {
            try
            {
                dataGridViewTeachers.DataSource = DAL.GetTeacher().Tables[0];
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {

                }
            }
        }
    }
}


