using System.Windows.Forms;

namespace _391project1_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            yearBox = new ComboBox();
            semesterBox = new ComboBox();
            majorBox = new ComboBox();
            genderBox = new ComboBox();
            facultyBox = new ComboBox();
            universityBox = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            applyButton = new Button();
            clearButton = new Button();
            label9 = new Label();
            courseRadio = new RadioButton();
            studentRadio = new RadioButton();
            InstructorRadio = new RadioButton();
            departmentLabel = new Label();
            departmentBox = new ComboBox();
            importBtn = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(344, 24);
            listBox1.Margin = new Padding(2, 1, 2, 1);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(156, 259);
            listBox1.TabIndex = 0;
            // 
            // yearBox
            // 
            yearBox.FormattingEnabled = true;
            yearBox.Location = new Point(7, 156);
            yearBox.Margin = new Padding(2, 1, 2, 1);
            yearBox.Name = "yearBox";
            yearBox.Size = new Size(132, 23);
            yearBox.TabIndex = 2;
            // 
            // semesterBox
            // 
            semesterBox.FormattingEnabled = true;
            semesterBox.Location = new Point(7, 26);
            semesterBox.Margin = new Padding(2, 1, 2, 1);
            semesterBox.Name = "semesterBox";
            semesterBox.Size = new Size(132, 23);
            semesterBox.TabIndex = 3;
            // 
            // majorBox
            // 
            majorBox.FormattingEnabled = true;
            majorBox.Location = new Point(162, 90);
            majorBox.Margin = new Padding(2, 1, 2, 1);
            majorBox.Name = "majorBox";
            majorBox.Size = new Size(132, 23);
            majorBox.TabIndex = 4;
            // 
            // genderBox
            // 
            genderBox.FormattingEnabled = true;
            genderBox.Location = new Point(162, 156);
            genderBox.Margin = new Padding(2, 1, 2, 1);
            genderBox.Name = "genderBox";
            genderBox.Size = new Size(132, 23);
            genderBox.TabIndex = 9;
            // 
            // facultyBox
            // 
            facultyBox.FormattingEnabled = true;
            facultyBox.Location = new Point(162, 25);
            facultyBox.Margin = new Padding(2, 1, 2, 1);
            facultyBox.Name = "facultyBox";
            facultyBox.Size = new Size(132, 23);
            facultyBox.TabIndex = 8;
            // 
            // universityBox
            // 
            universityBox.FormattingEnabled = true;
            universityBox.Location = new Point(7, 90);
            universityBox.Margin = new Padding(2, 1, 2, 1);
            universityBox.Name = "universityBox";
            universityBox.Size = new Size(132, 23);
            universityBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 140);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 11;
            label2.Text = "Year";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 10);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 12;
            label3.Text = "Semester";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(162, 74);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 13;
            label4.Text = "Major";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 74);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 14;
            label5.Text = "University";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(162, 9);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 16;
            label7.Text = "Faculty";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(162, 140);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 17;
            label8.Text = "Gender";
            // 
            // applyButton
            // 
            applyButton.Location = new Point(344, 287);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(75, 39);
            applyButton.TabIndex = 18;
            applyButton.Text = "Apply Filters";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(425, 287);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 39);
            clearButton.TabIndex = 19;
            clearButton.Text = "Clear Filters";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(38, 287);
            label9.Name = "label9";
            label9.Size = new Size(71, 15);
            label9.TabIndex = 22;
            label9.Text = "Count Total:";
            // 
            // courseRadio
            // 
            courseRadio.AutoSize = true;
            courseRadio.Location = new Point(38, 305);
            courseRadio.Name = "courseRadio";
            courseRadio.Size = new Size(67, 19);
            courseRadio.TabIndex = 23;
            courseRadio.TabStop = true;
            courseRadio.Text = "Courses";
            courseRadio.UseVisualStyleBackColor = true;
            courseRadio.CheckedChanged += courseRadio_CheckedChanged;
            // 
            // studentRadio
            // 
            studentRadio.AutoSize = true;
            studentRadio.Location = new Point(111, 305);
            studentRadio.Name = "studentRadio";
            studentRadio.Size = new Size(71, 19);
            studentRadio.TabIndex = 24;
            studentRadio.TabStop = true;
            studentRadio.Text = "Students";
            studentRadio.UseVisualStyleBackColor = true;
            studentRadio.CheckedChanged += studentRadio_CheckedChanged;
            // 
            // InstructorRadio
            // 
            InstructorRadio.AutoSize = true;
            InstructorRadio.Location = new Point(188, 305);
            InstructorRadio.Name = "InstructorRadio";
            InstructorRadio.Size = new Size(81, 19);
            InstructorRadio.TabIndex = 25;
            InstructorRadio.TabStop = true;
            InstructorRadio.Text = "Instructors";
            InstructorRadio.UseVisualStyleBackColor = true;
            InstructorRadio.CheckedChanged += InstructorRadio_CheckedChanged;
            // 
            // departmentLabel
            // 
            departmentLabel.AutoSize = true;
            departmentLabel.Location = new Point(7, 207);
            departmentLabel.Name = "departmentLabel";
            departmentLabel.Size = new Size(70, 15);
            departmentLabel.TabIndex = 27;
            departmentLabel.Text = "Department";
            // 
            // departmentBox
            // 
            departmentBox.FormattingEnabled = true;
            departmentBox.Location = new Point(7, 223);
            departmentBox.Margin = new Padding(2, 1, 2, 1);
            departmentBox.Name = "departmentBox";
            departmentBox.Size = new Size(132, 23);
            departmentBox.TabIndex = 26;
            // 
            // importBtn
            // 
            importBtn.Location = new Point(194, 214);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(75, 39);
            importBtn.TabIndex = 28;
            importBtn.Text = "Import Data";
            importBtn.UseVisualStyleBackColor = true;
            importBtn.Click += importBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 349);
            Controls.Add(importBtn);
            Controls.Add(departmentLabel);
            Controls.Add(departmentBox);
            Controls.Add(InstructorRadio);
            Controls.Add(studentRadio);
            Controls.Add(courseRadio);
            Controls.Add(label9);
            Controls.Add(clearButton);
            Controls.Add(applyButton);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(genderBox);
            Controls.Add(facultyBox);
            Controls.Add(universityBox);
            Controls.Add(majorBox);
            Controls.Add(semesterBox);
            Controls.Add(yearBox);
            Controls.Add(listBox1);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private ComboBox yearBox;
        private ComboBox semesterBox;
        private ComboBox majorBox;
        private ComboBox genderBox;
        private ComboBox facultyBox;
        private ComboBox universityBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Button applyButton;
        private Button clearButton;
        private Label label9;
        private RadioButton courseRadio;
        private RadioButton studentRadio;
        private RadioButton InstructorRadio;
        private Label departmentLabel;
        private ComboBox departmentBox;
        private Button importBtn;
    }
}