﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAssignment
{
    internal class AdapterManager
    {
        public static SqlDataAdapter CreateStudentAdapter(SqlConnection connection)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command;

            //Select command
            command = new SqlCommand("SELECT * FROM Student");

            command.Connection = connection;
            adapter.SelectCommand = command;

            //insert command
            command = new SqlCommand(
                "INSERT INTO Student(studentID, studentName)" +
                "VALUES(@studentID, @studentName)", connection);
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
            command.Parameters.Add("studentName", SqlDbType.VarChar, 50, "studentName");

            command.Connection = connection;

            adapter.InsertCommand = command;

            //Update command

            command = new SqlCommand(
                "UPDATE Student " +
                "SET studentName = @studentName " +
                "WHERE studentID = @studentID");
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
            command.Parameters.Add("studentName", SqlDbType.VarChar, 50, "studentName");

            command.Connection = connection;

            adapter.UpdateCommand = command;

            //Delete command

            command = new SqlCommand(
                "DELETE Student " +
                "WHERE studentID = @studentID");
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");

            command.Connection = connection;

            adapter.DeleteCommand = command;

            return adapter;

        }


        public static SqlDataAdapter CreateCourseAdapter(SqlConnection connection)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command;

            //Select command
            command = new SqlCommand("SELECT * FROM Course");

            command.Connection = connection;
            adapter.SelectCommand = command;

            //insert command
            command = new SqlCommand(
                "INSERT INTO Course(courseID, courseName, credits)" +

                "VALUES(@courseID, @courseName, @credits)", connection);

            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
            command.Parameters.Add("courseName", SqlDbType.VarChar, 50, "courseName");
            command.Parameters.Add("credits", SqlDbType.Int, 20, "credits");

            command.Connection = connection;

            adapter.InsertCommand = command;

            //Update command

            command = new SqlCommand(
                "UPDATE Course " +
                "SET courseName = @courseName, credits = @credits " +
                "WHERE courseID = @courseID");
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
            command.Parameters.Add("courseName", SqlDbType.VarChar, 50, "courseName");
            command.Parameters.Add("credits", SqlDbType.Int, 15, "credits");

            command.Connection = connection;

            adapter.UpdateCommand = command;

            //Update credits command
            //command = new SqlCommand(
            //    "UPDATE Course" +
            //    "SET credits = @credits" +
            //    "WHERE courseID = @courseID");
            //command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
            //command.Parameters.Add("courseName", SqlDbType.VarChar, 50, "courseName");
            //command.Parameters.Add("credits", SqlDbType.Int, 15, "credits");

            //Delete command

            command = new SqlCommand(
                "DELETE Course " +
                "WHERE courseID = @courseID");
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");

            command.Connection = connection;

            adapter.DeleteCommand = command;

            return adapter;

        }


        public static SqlDataAdapter CreateTeacherAdapter(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command;

            //select command
            command = new SqlCommand("SELECT * FROM Teacher");

            command.Connection = connection;
            adapter.SelectCommand = command;

            //insert command
            command = new SqlCommand(
                "INSERT INTO Teacher(empID, empName)" +
                "VALUES (@empID, @empName)", connection);

            command.Parameters.Add("empID", SqlDbType.VarChar, 5, "empID");
            command.Parameters.Add("empName", SqlDbType.VarChar, 50, "empName");

            command.Connection = connection;

            adapter.InsertCommand = command;


            //Update name command

            command = new SqlCommand(
                "UPDATE Teacher " +
                "SET empName = @empName " +
                "WHERE empID = @empID");
            command.Parameters.Add("empID", SqlDbType.VarChar, 5, "empID");
            command.Parameters.Add("empName", SqlDbType.VarChar, 50, "empName");

            command.Connection = connection;

            adapter.UpdateCommand = command;


            //Delete command

            command = new SqlCommand(
                "DELETE Teacher " +
                "WHERE empID = @empID");
            command.Parameters.Add("empID", SqlDbType.VarChar, 5, "empID");
            //command.Parameters.Add("empName", SqlDbType.VarChar, 50, "empName");

            command.Connection = connection;

            adapter.DeleteCommand = command;

            return adapter;
        }

<<<<<<< HEAD

=======
>>>>>>> parent of e5056f6 (removed exam)
        public static SqlDataAdapter CreateExamAdapter(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command;

            //Select command 
            command = new SqlCommand("SELECT * FROM Exam");

            command.Connection = connection;
            adapter.SelectCommand = command;

            //Insert command  
            //TODO, Check how to handle Foreign Keys for Exam
            command = new SqlCommand(
<<<<<<< HEAD
                "INSERT INTO Exam(examID, points, courseID, studentID)" + "VALUES (@examID, @points, @courseID, @studentID)", connection);

            command.Parameters.Add("examID", SqlDbType.VarChar, 5, "examID");
            command.Parameters.Add("points", SqlDbType.Int, 100, "points");
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
=======
                "INSERT INTO Exam(examID, points, studentID, courseID)" + "VALUES (@examID, @points, @studentID, @courseID)", connection);

            command.Parameters.Add("examID", SqlDbType.VarChar, 5, "examID");
            command.Parameters.Add("points", SqlDbType.Int, 100, "points");
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
>>>>>>> parent of e5056f6 (removed exam)

            command.Connection = connection;

            adapter.InsertCommand = command;

            //Update points command 
            command = new SqlCommand("UPDATE EXAM " +
                "SET points = @points" +
                "WHERE points = @points");
            command.Parameters.Add("examID", SqlDbType.VarChar, 5, "examID");
            command.Parameters.Add("points", SqlDbType.Int, 100, "points");
<<<<<<< HEAD
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
=======
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
>>>>>>> parent of e5056f6 (removed exam)

            command.Connection = connection;

            adapter.UpdateCommand = command;

            //Delete command 
            command = new SqlCommand(
                "DELETE Exam " +
                "WHERE examID = @examID");
            command.Parameters.Add("examID", SqlDbType.VarChar, 5, "examID");
            command.Parameters.Add("points", SqlDbType.Int, 100, "points");
<<<<<<< HEAD
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
=======
            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
>>>>>>> parent of e5056f6 (removed exam)

            command.Connection = connection;

            adapter.DeleteCommand = command;

            return adapter;
        }
        public static SqlDataAdapter CreateLoanAdapter(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command;

            //Select command 
            command = new SqlCommand("SELECT * FROM StudentLoan");

            command.Connection = connection;
            adapter.SelectCommand = command;

            //Insert command  
            //Check how to handle Foreign Keys for StudentLoan

            command = new SqlCommand(
                "INSERT INTO StudentLoan(loanID, amount) " + "VALUES (@loanID, @amount)", connection);

            command.Parameters.Add("loanID", SqlDbType.VarChar, 5, "loanID");
            command.Parameters.Add("amount", SqlDbType.Int, 1000000, "amount");

            command.Connection = connection;
            adapter.InsertCommand = command;

            //Update amount command 
            command = new SqlCommand(
                "UPDATE StudentLoan" + "SET amount = @amount " +
                "WHERE amount = @amount");
            command.Parameters.Add("loanID", SqlDbType.VarChar, 5, "loanID");
            command.Parameters.Add("amount", SqlDbType.Int, 1000000, "amount");

            command.Connection = connection;
            adapter.UpdateCommand = command;

            //Delete command 
            command = new SqlCommand(
                "DELETE StudentLoan " +
                "WHERE loanID = @loanID");
            command.Parameters.Add("loanID", SqlDbType.VarChar, 5, "loanID");
            command.Parameters.Add("amount", SqlDbType.Int, 1000000, "amount");

            command.Connection = connection;
            adapter.DeleteCommand = command;

            return adapter;
        }

        public static SqlDataAdapter CreateWorksOnAdapter(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command;

            //Select command
            command = new SqlCommand("SELECT * FROM EXAM");
			
        public static SqlDataAdapter CreateStudentStudiesAdapter(SqlConnection connection)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command;

            //Select command
            command = new SqlCommand("SELECT courseID, studentID FROM Studies WHERE courseID = @courseID");
<<<<<<< HEAD

=======
>>>>>>> parent of e5056f6 (removed exam)

            command.Connection = connection;
            adapter.SelectCommand = command;

            //Insert Command
            command = new SqlCommand(
                "INSERT INTO worksOn(empID, courseID) " + "VALUES (@empID, @courseID)", connection);

            command.Parameters.Add("empID", SqlDbType.VarChar, 5, "empID");
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");

            command.Connection = connection;
            adapter.InsertCommand = command;
                       
            return adapter;
        }
    }
    
            //Insert command
            command = new SqlCommand("INSERT INTO Studies(studentID, studentName, courseID) " + "VALUES(@studentID, @studentName, @courseID", connection);

            command.Parameters.Add("studentID", SqlDbType.VarChar, 5, "studentID");
            command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");

            command.Connection = connection;
            adapter.InsertCommand = command;

            ////Update command
            //command = new SqlCommand(
            //    "UPDATE Studies " +
            //    "SET studentName = @studentName, credits = @credits " +
            //    "WHERE courseID = @courseID");
            //command.Parameters.Add("courseID", SqlDbType.VarChar, 5, "courseID");
            //command.Parameters.Add("courseName", SqlDbType.VarChar, 50, "courseName");
            //command.Parameters.Add("credits", SqlDbType.Int, 15, "credits");

            //command.Connection = connection;
<<<<<<< HEAD
=======

            //adapter.UpdateCommand = command;
>>>>>>> parent of e5056f6 (removed exam)

            //adapter.UpdateCommand = command;

<<<<<<< HEAD
            //Delete command
            command = new SqlCommand("DELETE FROM Studies WHERE courseID = @courseID AND studentID = @studentID")


=======
            return adapter;
>>>>>>> parent of e5056f6 (removed exam)
        }
    }

