using lab3.Models;

namespace lab3
{
    public partial class Form1 : Form
    {
        ItiContext context = new ItiContext();
        private int selectedStudentId;
        public Form1()
        {
            InitializeComponent();
        }

        private List<object> StudentsList()
        {
            var students = context.Students.Select(s => new
            {
                Id = s.StId,
                Name = s.StFname + " " + s.StLname,
                Age = s.StAge,
                Address = s.StAddress,
                Department = s.Dept.DeptName
            }).ToList<object>();

            return students;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = StudentsList();

            comboBox1.DataSource = context.Departments.ToList();
            comboBox1.DisplayMember = "DeptName";
            comboBox1.ValueMember = "DeptId";
        }

        //search
        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text.ToLower();
            var FilteredStudents = context.Students.Where(s => (s.StFname + " " + s.StLname).ToLower().StartsWith(text)).ToList();
            dataGridView1.DataSource = FilteredStudents;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.DataSource = StudentsList();
        }

        //save
        private void button3_Click(object sender, EventArgs e)
        {
            var sName = textBox2.Text.Trim();
            var sAge = int.Parse(textBox3.Text);
            var sAddress = textBox4.Text;
            var sDeptId = (int)comboBox1.SelectedValue;

            string sFname = "";
            string sLname = "";

            if (!string.IsNullOrEmpty(sName))
            {
                var parts = sName.Split(' ', 2);
                sFname = parts[0];
                if (parts.Length > 1)
                    sLname = parts[1];
            }

            Student s = new Student()
            {
                StFname = sFname,
                StLname = sLname,
                StAge = sAge,
                StAddress = sAddress,
                DeptId = sDeptId
            };

            context.Students.Add(s);
            context.SaveChanges();

            MessageBox.Show("Student added successfully!");
            dataGridView1.DataSource = StudentsList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                selectedStudentId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                var studentToEdit = context.Students.FirstOrDefault(s => s.StId == selectedStudentId);

                if (studentToEdit != null)
                {
                    textBox2.Text = $"{studentToEdit.StFname} {studentToEdit.StLname}";
                    textBox3.Text = studentToEdit.StAge.ToString();
                    textBox4.Text = studentToEdit.StAddress;

                    comboBox1.SelectedValue = studentToEdit.DeptId;
                }
            }
        }

        //update
        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedStudentId > 0)
            {
                try
                {
                    var studentToUpdate = context.Students.Find(selectedStudentId);

                    if (studentToUpdate != null)
                    {
                        var sName = textBox2.Text.Trim();
                        var sAge = int.Parse(textBox3.Text);
                        var sAddress = textBox4.Text;
                        var sDeptId = (int)comboBox1.SelectedValue;

                        string sFname = "";
                        string sLname = "";

                        if (!string.IsNullOrEmpty(sName))
                        {
                            var parts = sName.Split(' ', 2);
                            sFname = parts[0];
                            if (parts.Length > 1)
                                sLname = parts[1];
                        }

                        studentToUpdate.StFname = sFname;
                        studentToUpdate.StLname = sLname;
                        studentToUpdate.StAge = sAge;
                        studentToUpdate.StAddress = sAddress;
                        studentToUpdate.DeptId = sDeptId;

                        context.SaveChanges();

                        MessageBox.Show("Student updated successfully!");
                        dataGridView1.DataSource = StudentsList();
                        ResetFormFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a student to update by double-clicking on the grid.");
            }
        }

        private void ResetFormFields()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            selectedStudentId = 0;
        }

        //delete
        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedStudentId > 0)
            {
                var studentToDelete = context.Students.Find(selectedStudentId);

                if (studentToDelete != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete {studentToDelete.StFname} {studentToDelete.StLname}?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            context.Students.Remove(studentToDelete);

                            context.SaveChanges();

                            MessageBox.Show("Student deleted successfully!");

                            dataGridView1.DataSource = StudentsList();

                            ResetFormFields();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete by double-clicking on the grid.");
            }
        }
    }
}
