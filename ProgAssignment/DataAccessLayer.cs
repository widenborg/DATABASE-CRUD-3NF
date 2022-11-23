using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAssignment
{
    public class DataAccessLayer
    { 
        private string connectionString = "Server=tcp:hackoverflow.database.windows.net,1433;Initial Catalog=ProgAssignment1;Persist Security Info=False;User ID=hackoverflowadmin;Password=hackoverflowuser123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
     
        //lägg adapter här, entity framework, repository pattern(bra om vi sätter oss in i det (DAL 2.0) - daniel 2022
        //Student-
        //methods

        public void CreateStudent(string studentID, string studentName) //Create student
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateStudentAdapter(connection))
                {
                    DataSet dataSetStudents = new DataSet();
                    adapter.Fill(dataSetStudents);

                    DataTable dataTableStudent = dataSetStudents.Tables["Table"];

                    DataRow newStudentRow = dataTableStudent.NewRow();

                    newStudentRow["studentID"] = studentID;
                    newStudentRow["studentname"] = studentName;

                    dataTableStudent.Rows.Add(newStudentRow);
                    
                    adapter.Update(dataTableStudent);

                }
            }
        }


        public DataSet GetStudents() //Read student
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateStudentAdapter(connection))
                {

                    DataSet dataSetStudents = new DataSet();

                    adapter.Fill(dataSetStudents);

                    return dataSetStudents;

                }
            }
        }


        public void UpdateStudent(string studentID, string studentName) //Uppdate student
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateStudentAdapter(connection))
                {
                
                    adapter.UpdateCommand.Parameters[0].Value = studentID; ;
                    adapter.UpdateCommand.Parameters[1].Value = studentName; ;


                    connection.Open();
                    adapter.UpdateCommand.ExecuteNonQuery();

                }
            }
        }

        public void DeleteStudent(string studentID) //Delete student
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateStudentAdapter(connection))
                {
                    adapter.DeleteCommand.Parameters[0].Value = studentID; ;
                    
                    connection.Open ();
                    adapter.DeleteCommand.ExecuteNonQuery(); ;
                }
            }
        }

        //Course-
        //methods
        public void AddCourse(string courseID, string courseName, int credits) //Add course
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateCourseAdapter(connection))
                {
                    DataSet dataSetCourse = new DataSet();
                    adapter.Fill(dataSetCourse);

                    DataTable dataTableCourse = dataSetCourse.Tables[0];

                    DataRow newCourseRow = dataTableCourse.NewRow();
                    newCourseRow["courseID"] = courseID;
                    newCourseRow["courseName"] = courseName;
                    newCourseRow["credits"] = credits;
                    //Convert.ToInt32(newCourseRow[credits]);

                    dataTableCourse.Rows.Add(newCourseRow);

                    adapter.Update(dataTableCourse);

                    connection.Open();
                }


            }
        }


        public DataSet GetCourse() //Read course
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateCourseAdapter(connection))
                {

                    DataSet dataSetCourses = new DataSet();

                    adapter.Fill(dataSetCourses);

                    return dataSetCourses;

                }
            }
        }
        public void UpdateCourse(string courseID, string courseName, int credits) //Update course
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateCourseAdapter(connection))
                {
                    adapter.UpdateCommand.Parameters[0].Value = courseID;
                    adapter.UpdateCommand.Parameters[1].Value = courseName;
                    adapter.UpdateCommand.Parameters[2].Value = credits;

                    connection.Open();
                    adapter.UpdateCommand.ExecuteNonQuery();
                        
                }
            }
                

        }
        //public void DeleteStudent(string studentID) //Delete student
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlDataAdapter adapter = AdapterManager.CreateStudentAdapter(connection))
        //        {
        //            adapter.DeleteCommand.Parameters[0].Value = studentID; ;

        //            connection.Open();
        //            adapter.DeleteCommand.ExecuteNonQuery(); ;
        //        }
        //    }
        //}
        public void DeleteCourse(string courseID) //Delete course
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateCourseAdapter(connection))
                {
                    adapter.DeleteCommand.Parameters[0].Value = courseID;

                    connection.Open();
                    adapter.DeleteCommand.ExecuteNonQuery();
                }
            }
        }

        //Teacher-
        //methods

        public void AddTeacher(string empID, string empName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateTeacherAdapter(connection))
                {
                    DataSet dataSetTeachers = new DataSet();
                    adapter.Fill(dataSetTeachers);

                    DataTable dataTableTeacher = dataSetTeachers.Tables["Table"];

                    DataRow newTeacherRow = dataTableTeacher.NewRow();

                    newTeacherRow["empID"] = empID;
                    newTeacherRow["empName"] = empName;

                    dataTableTeacher.Rows.Add(newTeacherRow);

                    adapter.Update(dataSetTeachers);
                }
            }

        }

        public DataSet GetTeacher()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateTeacherAdapter(connection))
                {

                    DataSet dataSetTeachers = new DataSet();

                    adapter.Fill(dataSetTeachers);

                    return dataSetTeachers;

                }
            }
        }

        public void UpdateTeacher(string empID, string empName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateTeacherAdapter(connection))
                {

                    adapter.UpdateCommand.Parameters[0].Value = empID;
                    adapter.UpdateCommand.Parameters[1].Value = empName;


                    connection.Open();
                    adapter.UpdateCommand.ExecuteNonQuery();

                }
            }
        }

        public void DeleteTeacher(string empID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateTeacherAdapter(connection))
                {
                    adapter.DeleteCommand.Parameters[0].Value = empID;
                    

                    connection.Open();
                    adapter.DeleteCommand.ExecuteNonQuery(); ;
                }
            }

        }

        //WorksOn-methods
        public DataSet GetWorksOn()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateWorksOnAdapter(connection))
                {
                    DataSet dataSetWorksOn = new DataSet();

                    adapter.Fill(dataSetWorksOn);

                    return dataSetWorksOn;
                }
            }
        }


        //Exam-
        //methods
        public void CreateExam(string examId, int points, string courseID, string studentID) 
        {
         using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                using (SqlDataAdapter adapter = AdapterManager.CreateExamAdapter(connection))
                {
                    DataSet dataSetExams = new DataSet();
                    adapter.Fill(dataSetExams);

                    DataTable dataTableExam = dataSetExams.Tables["Table"];

                    DataRow newExamRow = dataTableExam.NewRow();

                    newExamRow["examID"] = examId;
                    newExamRow["points"] = points;
                    newExamRow["courseID"] = courseID;
                    newExamRow["studentID"] = studentID;

                    dataTableExam.Rows.Add(newExamRow);
                    adapter.Update(dataTableExam);

                }
            }
        }

        public DataSet GetExams()
        { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                using (SqlDataAdapter adapter = AdapterManager.CreateExamAdapter(connection))
                {
                    DataSet dataSetExams = new DataSet();
                    adapter.Fill(dataSetExams);

                    return dataSetExams;
                }
            }
        }

        public void UpdateExam(string examID, int points,string courseID, string studentID)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            { 
                using (SqlDataAdapter adapter = AdapterManager.CreateExamAdapter(connection))
                {
                    adapter.UpdateCommand.Parameters[0].Value = examID;
                    adapter.UpdateCommand.Parameters[1].Value = points;
                    adapter.UpdateCommand.Parameters[2].Value = courseID;
                    adapter.UpdateCommand.Parameters[3].Value = studentID;

                    connection.Open();
                    adapter.UpdateCommand.ExecuteNonQuery();
                }
            }
        }

        public void DeleteExam(string examID)
        { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                using (SqlDataAdapter adapter = AdapterManager.CreateExamAdapter(connection))
                {
                    adapter.DeleteCommand.Parameters[0].Value = examID;

                    connection.Open();
                    adapter.DeleteCommand.BeginExecuteNonQuery();
                }
            }
        }


        //StudentLoan-
        //methods

        //Fill dataGridView/get students
        public DataSet GetStudentLoan()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateLoanAdapter(connection))
                {
                    DataSet dataSetStudentLoans = new DataSet();
                    adapter.Fill(dataSetStudentLoans);

                    return dataSetStudentLoans;

                }
            }
        }
        public void AddStudentOnCourse( string studentID, string courseID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = AdapterManager.CreateStudiesAdapter(connection))
                {
                    DataSet dataSetStudies = new DataSet();
                    adapter.Fill(dataSetStudies);

                    DataTable dataTableStudies = dataSetStudies.Tables["Table"];

                    DataRow newStudiesRow = dataTableStudies.NewRow();

                    newStudiesRow["studentID"] = studentID;
                    newStudiesRow["courseID"] = courseID;

                    dataTableStudies.Rows.Add(newStudiesRow);

                    adapter.Update(dataSetStudies);
                }
            }
        }

        public void AddStudentLoan()
        {

        }

        public void UpdateStudentLoan()
        {

        }

        public void DeleteStudentLoan()
        {

        }

    }
  }

