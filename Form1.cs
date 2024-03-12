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



    public partial class Form1 : Form
    {
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
                    try
                    {
                        // Potentially time-consuming operation, so await it
                        await Task.Run(() => ds.ReadXml(openFileDialog.FileName));
                        MessageBox.Show("XML Data Imported");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}