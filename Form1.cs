using System.Xml;

namespace _391project1_3
{
    using Microsoft.VisualBasic;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using static System.Net.Mime.MediaTypeNames;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using System.Xml.Serialization;
    using System.IO;
    using static _391project1_3.Form1;


    public partial class Form1 : Form
    {

        [XmlRoot("InstructorsRoot")]
        public class InstructorsRoot
        {
            [XmlArray("File")]
            [XmlArrayItem("Item", typeof(Instructor))]
            public Instructor[] Instructors { get; set; }
        }

        [XmlRoot("StudentsRoot")]
        public class StudentsRoot
        {
            [XmlArray("File")]
            [XmlArrayItem("Item", typeof(Student))]
            public Student[] Students { get; set; }
        }

        [XmlRoot("CoursesRoot")]
        public class CoursesRoot
        {
            [XmlArray("File")]
            [XmlArrayItem("Item", typeof(Course))]
            public Course[] Courses { get; set; }
        }

        [XmlRoot("TakesRoot")]
        public class TakesRoot
        {
            [XmlArray("File")]
            [XmlArrayItem("Item", typeof(Takes))]
            public Takes[] Takes { get; set; }
        }

        public class Instructor
        {
            [XmlAttribute("instructor")]
            public int InstructorNumber { get; set; }
            public string instructorID { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string rank { get; set; }
            public int age { get; set; }
            public string university { get; set; }
            public string faculty { get; set; }
            public string gender { get; set; }
        }

        public class Student
        {
            [XmlAttribute("student")]
            public int StudentNumber { get; set; }
            public string studentID { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string major { get; set; }
            public int age { get; set; }
            public string gender { get; set; }
            public string university { get; set; }
        }

        public class Course
        {
            [XmlAttribute("course")]
            public int CourseNumber { get; set; }
            public string courseID { get; set; }
            public string department { get; set; }
            public string faculty { get; set; }
            public string university { get; set; }
        }

        public class Takes
        {
            [XmlAttribute("takes")]
            public int TakesNumber { get; set; }
            public string instructorID { get; set; }
            public string courseID { get; set; }
            public string studentID { get; set; }
            public string dateID { get; set; }
        }


        private readonly string connectionString = "Data Source = 206.75.31.209,11433; " +
                    "Initial Catalog = 391project1P2; " +
                    "User ID = mckenzy; " +
                    "Password = 123456; " +
                    "MultipleActiveResultSets = true;";


        public Form1()
        {
            InitializeComponent();
            fillSemesterBox();
            fillDepartmentBox();
            fillFacultyBox();
            fillYearBox();
            fillMajorBox();
            fillGenderBox();
            fillUniversityBox();


        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            string query0 = "";
            string query1 = "";
            string query2 = "";
            string query3 = "";
            string query = "";

            if (courseRadio.Checked)
            {

                query1 = "SELECT COUNT(*) AS total ";
                query2 = "FROM takes t, course c ";
                query3 = "WHERE t.courseID = c.courseID "; // A dummy WHERE clause to simplify appending additional conditions
            }
            else if (studentRadio.Checked)
            {
                query1 = "SELECT COUNT (*) AS total ";
                query2 = "FROM takes t, student s ";
                query3 = "WHERE t.studentID = s.studentID ";
            }
            else if (InstructorRadio.Checked)
            {
                query1 = "SELECT COUNT (*) AS total ";
                query2 = "FROM takes t, student s ";
                query3 = "WHERE t.studentID = s.studentID ";
            }


            if (semesterBox.SelectedItem != null)
            {
                query0 += $"DECLARE @semester NVARCHAR(10) = '{semesterBox.SelectedItem.ToString()}' ";
                query2 += $", date d ";
                query3 += $" AND t.dateID = d.dateID and d.semester = @semester ";
            }
            if (facultyBox.SelectedItem != null)
            {
                query0 += $"DECLARE @faculty NVARCHAR(40) = '{facultyBox.SelectedItem.ToString()}' ";
                query2 += $", course c1 ";
                query3 += $" AND t.courseID = c1.courseID and c1.faculty = @faculty ";
            }
            if (universityBox.SelectedItem != null)
            {
                query0 += $"DECLARE @university NVARCHAR(60) = '{universityBox.SelectedItem.ToString()}' ";
                query2 += $", course c2 ";
                query3 += $" AND t.courseID = c2.courseID and c2.university = @university ";
            }
            if (majorBox.SelectedItem != null)
            {
                query0 += $"DECLARE @major NVARCHAR(40) = '{majorBox.SelectedItem.ToString()}' ";

                query3 += $" AND major = @major ";
            }
            if (yearBox.SelectedItem != null)
            {
                query0 += $"DECLARE @year NCHAR(10) = {yearBox.SelectedItem.ToString()} ";
                query2 += $", date d1 ";
                query3 += $" AND t.dateID = d1.dateID and d1.year = @year ";
            }
            if (genderBox.SelectedItem != null)
            {
                query0 += $"DECLARE @gender NVARCHAR(10) = '{genderBox.SelectedItem.ToString()}' ";

                query3 += $" AND gender = @gender ";
            }
            if (departmentBox.SelectedItem != null)
            {
                query0 += $"DECLARE @department VARCHAR(100) = '{departmentBox.SelectedItem.ToString()}' ";
                query2 += $", course c3 ";
                query3 += $" AND t.courseID = c3.courseID and c3.department = @department ";
            }
            if (query0 != "")
            {
                query = query0 + query1 + query2 + query3;
                Debug.WriteLine(query);
            }
            else
            {
                query = query1 + query2 + query3;
                Debug.WriteLine(query);
            }

            DatabaseAccess dbAccess = new DatabaseAccess();
            string total = dbAccess.ExecuteQuery(query);
            listBox1.Items.Clear();
            listBox1.Items.Add($"Total: {total}");
            Debug.WriteLine(total);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            semesterBox.SelectedIndex = -1;
            facultyBox.SelectedIndex = -1;
            universityBox.SelectedIndex = -1;
            majorBox.SelectedIndex = -1;
            yearBox.SelectedIndex = -1;
            genderBox.SelectedIndex = -1;
            departmentBox.SelectedIndex = -1;
        }


        private void studentRadio_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void courseRadio_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void InstructorRadio_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Connects to the SSMS server
        public class DatabaseAccess
        {
            private string connectionString =
                "Data Source = 206.75.31.209,11433; " +
                "Initial Catalog = 391project1P2; " +
                "User ID = mckenzy; " +
                "Password = 123456; " +
                "MultipleActiveResultSets = true;";

            // Sends a query to the database and returns the result
            public string ExecuteQuery(string query)
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    try
                    {
                        con.Open();
                        object result = command.ExecuteScalar();
                        return result?.ToString() ?? "0";
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL ERROR: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error: {ex.Message}");
                    }
                    return "0";
                }
            }
        }
        private void fillSemesterBox()
        {
            // Construct the connection string
            SqlConnection con = new SqlConnection(connectionString);
            {
                try
                {
                    // Open the connection

                    Debug.WriteLine("Connection successful!");


                    SqlCommand command = new SqlCommand("select distinct semester from date", con);
                    SqlDataReader myreader;
                    Debug.WriteLine("Executed succesfully");
                    con.Open();
                    myreader = command.ExecuteReader();
                    List<String> semester = new List<String>();
                    while (myreader.Read())
                    {
                        semester.Add(myreader[0].ToString());

                    }
                    for (int i = 0; i < semester.Count; i++)
                    {
                        semesterBox.Items.Add(semester[i]);
                    }

                    // Close the connection
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"SQL ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
        /*private void fillCityBox()
        {
            // Construct the connection string
            SqlConnection con = new SqlConnection(connectionString);
            {
                try
                {
                    // Open the connection

                    Debug.WriteLine("Connection successful!");


                    SqlCommand command = new SqlCommand("select distinct city from student", con);
                    SqlDataReader myreader;
                    Debug.WriteLine("Executed succesfully");
                    con.Open();
                    myreader = command.ExecuteReader();
                    List<String> semester = new List<String>();
                    while (myreader.Read())
                    {
                        semester.Add(myreader[0].ToString());

                    }
                    for (int i = 0; i < semester.Count; i++)
                    {
                        cityBox.Items.Add(semester[i]);
                    }

                    // Close the connection
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"SQL ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }*/
        private void fillYearBox()
        {
            // Construct the connection string
            SqlConnection con = new SqlConnection(connectionString);
            {
                try
                {
                    // Open the connection

                    Debug.WriteLine("Connection successful!");


                    SqlCommand command = new SqlCommand("select distinct year from date", con);
                    SqlDataReader myreader;
                    Debug.WriteLine("Executed succesfully");
                    con.Open();
                    myreader = command.ExecuteReader();
                    List<String> year = new List<String>();
                    while (myreader.Read())
                    {
                        year.Add(myreader[0].ToString());

                    }
                    for (int i = 0; i < year.Count; i++)
                    {
                        yearBox.Items.Add(year[i]);
                    }

                    // Close the connection
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"SQL ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
        private void fillMajorBox()
        {
            // Construct the connection string
            SqlConnection con = new SqlConnection(connectionString);
            {
                try
                {
                    // Open the connection

                    Debug.WriteLine("Connection successful!");


                    SqlCommand command = new SqlCommand("select distinct major from student", con);
                    SqlDataReader myreader;
                    Debug.WriteLine("Executed succesfully");
                    con.Open();
                    myreader = command.ExecuteReader();
                    List<String> major = new List<String>();
                    while (myreader.Read())
                    {
                        major.Add(myreader[0].ToString());

                    }
                    for (int i = 0; i < major.Count; i++)
                    {
                        majorBox.Items.Add(major[i]);
                    }

                    // Close the connection
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"SQL ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
        private void fillUniversityBox()
        {
            // Construct the connection string
            SqlConnection con = new SqlConnection(connectionString);
            {
                try
                {
                    // Open the connection

                    Debug.WriteLine("Connection successful!");


                    SqlCommand command = new SqlCommand("select distinct university from course", con);
                    SqlDataReader myreader;
                    Debug.WriteLine("Executed succesfully");
                    con.Open();
                    myreader = command.ExecuteReader();
                    List<String> uni = new List<String>();
                    while (myreader.Read())
                    {
                        uni.Add(myreader[0].ToString());

                    }
                    for (int i = 0; i < uni.Count; i++)
                    {
                        universityBox.Items.Add(uni[i]);
                    }

                    // Close the connection
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"SQL ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
        private void fillDepartmentBox()
        {
            // Construct the connection string
            SqlConnection con = new SqlConnection(connectionString);
            {
                try
                {
                    // Open the connection

                    Debug.WriteLine("Connection successful!");


                    SqlCommand command = new SqlCommand("select distinct department from course", con);
                    SqlDataReader myreader;
                    Debug.WriteLine("Executed succesfully");
                    con.Open();
                    myreader = command.ExecuteReader();
                    List<String> studentOrInstructor = new List<String>();
                    while (myreader.Read())
                    {
                        studentOrInstructor.Add(myreader[0].ToString());

                    }
                    for (int i = 0; i < studentOrInstructor.Count; i++)
                    {
                        departmentBox.Items.Add(studentOrInstructor[i]);
                    }

                    // Close the connection
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"SQL ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
        private void fillFacultyBox()
        {
            // Construct the connection string
            SqlConnection con = new SqlConnection(connectionString);
            {
                try
                {
                    // Open the connection

                    Debug.WriteLine("Connection successful!");


                    SqlCommand command = new SqlCommand("select distinct faculty from course", con);
                    SqlDataReader myreader;
                    Debug.WriteLine("Executed succesfully");
                    con.Open();
                    myreader = command.ExecuteReader();
                    List<String> faculty = new List<String>();
                    while (myreader.Read())
                    {
                        faculty.Add(myreader[0].ToString());

                    }
                    for (int i = 0; i < faculty.Count; i++)
                    {
                        facultyBox.Items.Add(faculty[i]);
                    }

                    // Close the connection
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"SQL ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
        private void fillGenderBox()
        {
            // Construct the connection string
            SqlConnection con = new SqlConnection(connectionString);
            {
                try
                {
                    // Open the connection

                    Debug.WriteLine("Connection successful!");


                    SqlCommand command = new SqlCommand("select distinct gender from student", con);
                    SqlDataReader myreader;
                    Debug.WriteLine("Executed succesfully");
                    con.Open();
                    myreader = command.ExecuteReader();
                    List<String> gender = new List<String>();
                    while (myreader.Read())
                    {
                        gender.Add(myreader[0].ToString());

                    }
                    for (int i = 0; i < gender.Count; i++)
                    {
                        genderBox.Items.Add(gender[i]);
                    }

                    // Close the connection
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine($"SQL ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }

        private async void importBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select File";
                openFileDialog.Filter = "All files (*.*)|*.*|XML File (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = openFileDialog.FileName;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlFilePath);
                    XmlElement root = doc.DocumentElement;

                    try
                    {
                        if (root.Name == "InstructorsRoot")
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(InstructorsRoot));
                            using (FileStream stream = new FileStream(xmlFilePath, FileMode.Open))
                            {
                                InstructorsRoot instructorsRoot = (InstructorsRoot)serializer.Deserialize(stream);
                                ImportInstructors(instructorsRoot);
                                Debug.WriteLine("Instructor data imported successfully.");
                            }
                        }
                        else if (root.Name == "StudentsRoot")
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(StudentsRoot));
                            using (FileStream stream = new FileStream(xmlFilePath, FileMode.Open))
                            {
                                StudentsRoot studentsRoot = (StudentsRoot)serializer.Deserialize(stream);
                                ImportStudents(studentsRoot);
                                Debug.WriteLine("Student data imported successfully.");
                            }
                        }
                        else if (root.Name == "CoursesRoot")
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(CoursesRoot));
                            using (FileStream stream = new FileStream(xmlFilePath, FileMode.Open))
                            {
                                CoursesRoot coursesRoot = (CoursesRoot)serializer.Deserialize(stream);
                                ImportCourses(coursesRoot);
                                Debug.WriteLine("Course data imported successfully.");
                            }
                        }
                        else if (root.Name == "TakesRoot")
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(TakesRoot));
                            using (FileStream stream = new FileStream(xmlFilePath, FileMode.Open))
                            {
                                TakesRoot takesRoot = (TakesRoot)serializer.Deserialize(stream);
                                ImportTakes(takesRoot);
                                Debug.WriteLine("Takes data imported successfully.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unrecognized XML structure.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Debug.WriteLine($"An error occurred during XML import: {ex.Message}");
                    }
                }
            }
        }

        /*
         * INSERTION
         */

        // Instructors

        private void ImportInstructors(InstructorsRoot instructorsRoot)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var instructor in instructorsRoot.Instructors)
                {
                    string query = @"INSERT INTO [dbo].[instructor] 
                            ([instructorID], [firstName], [lastName], [rank], [age], [university], [faculty], [gender]) 
                            VALUES 
                            (@InstructorID, @FirstName, @LastName, @Rank, @Age, @University, @Faculty, @Gender)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InstructorID", instructor.instructorID);
                        cmd.Parameters.AddWithValue("@FirstName", instructor.firstName);
                        cmd.Parameters.AddWithValue("@LastName", instructor.lastName);
                        cmd.Parameters.AddWithValue("@Rank", instructor.rank);
                        cmd.Parameters.AddWithValue("@Age", instructor.age);
                        cmd.Parameters.AddWithValue("@University", instructor.university);
                        cmd.Parameters.AddWithValue("@Faculty", instructor.faculty);
                        cmd.Parameters.AddWithValue("@Gender", instructor.gender);

                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }
        }

        // STUDENTS
        private void ImportStudents(StudentsRoot studentsRoot)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var student in studentsRoot.Students)
                {
                    string query = @"INSERT INTO [dbo].[student] 
                            ([studentID], [firstName], [lastName], [major], [age], [gender], [university]) 
                            VALUES 
                            (@StudentID, @FirstName, @LastName, @Major, @Age, @Gender, @University)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", student.studentID);
                        cmd.Parameters.AddWithValue("@FirstName", student.firstName);
                        cmd.Parameters.AddWithValue("@LastName", student.lastName);
                        cmd.Parameters.AddWithValue("@Major", student.major);
                        cmd.Parameters.AddWithValue("@Age", student.age);
                        cmd.Parameters.AddWithValue("@Gender", student.gender);
                        cmd.Parameters.AddWithValue("@University", student.university);

                        cmd.ExecuteNonQuery();
                        Debug.WriteLine($"Inserted student: {student.firstName} {student.lastName}");
                    }
                }

                conn.Close();
            }
        }


        // COURSES
        private void ImportCourses(CoursesRoot coursesRoot)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var course in coursesRoot.Courses)
                {
                    string query = @"INSERT INTO [dbo].[course] 
                            ([courseID], [department], [faculty], [university]) 
                            VALUES 
                            (@CourseID, @Department, @Faculty, @University)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CourseID", course.courseID);
                        cmd.Parameters.AddWithValue("@Department", course.department);
                        cmd.Parameters.AddWithValue("@Faculty", course.faculty);
                        cmd.Parameters.AddWithValue("@University", course.university);

                        cmd.ExecuteNonQuery();
                        Debug.WriteLine($"Inserted course: {course.courseID}");
                    }
                }

                conn.Close();
            }
        }

        private void ImportTakes(TakesRoot takesRoot)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var takes in takesRoot.Takes)
                {
                    string query = @"INSERT INTO [dbo].[takes] 
                            ([instructorID], [courseID], [studentID], [dateID]) 
                            VALUES 
                            (@InstructorID, @CourseID, @StudentID, @DateID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InstructorID", takes.instructorID);
                        cmd.Parameters.AddWithValue("@CourseID", takes.courseID);
                        cmd.Parameters.AddWithValue("@StudentID", takes.studentID);
                        cmd.Parameters.AddWithValue("@DateID", takes.dateID);

                        cmd.ExecuteNonQuery();
                        Debug.WriteLine($"Inserted takes: {takes}");
                    }
                }

                conn.Close();
            }
        }
    }
}