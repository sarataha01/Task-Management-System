using linq_ef_finalproject.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms.VisualStyles;
using TaskStatus = linq_ef_finalproject.Models.TaskStatus;

namespace linq_ef_finalproject
{
    public partial class Form1 : Form
    {
        TaskManagementContext context = new TaskManagementContext();
        private int selectedTaskId = -1;
        private int currentPage = 1;
        private const int pageSize = 5;
        private int _userId;
        private System.Windows.Forms.Timer overdueTimer;
        private NotifyIcon notifyIcon;
        private HashSet<int> alertedTaskIds = new HashSet<int>();

        public Form1(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void ResetTasks()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

        private void comboBoxFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedStatus = comboBox4.SelectedItem?.ToString();
            LoadTasks(selectedStatus);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedStatus = comboBox4.SelectedItem?.ToString();
            var selectedSort = comboBox5.SelectedItem?.ToString();

            LoadTasks(selectedStatus, selectedSort);
        }


        private void LoadTasks(string? statusFilter = null, string? sortOrder = null, string? searchTerm = null)
        {
            var query = context.Tasks.Include(t => t.Category).Where(t => t.UserId == _userId).AsQueryable();

            // status
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                if (Enum.TryParse<TaskStatus>(statusFilter, out var parsedStatus))
                {
                    query = query.Where(t => t.Status == parsedStatus);
                }
            }

            // title or text searxh
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(t =>
                    t.Title.Contains(searchTerm) ||
                    t.Description.Contains(searchTerm));
            }

            // date
            if (sortOrder == "Ascending")
            {
                query = query.OrderBy(t => t.DueDate);
            }
            else if (sortOrder == "Descending")
            {
                query = query.OrderByDescending(t => t.DueDate);
            }
            else
            {
                // Default = Descending
                query = query.OrderByDescending(t => t.DueDate);
            }

            //pagination
            int totalTasks = query.Count();
            int maxPage = (int)Math.Ceiling((double)totalTasks / pageSize);
            if (currentPage > maxPage && maxPage > 0)
            {
                currentPage = maxPage;
            }

            var tasks = query.Select(t => new
            {
                t.Id,
                t.Title,
                t.Description,
                t.DueDate,
                t.Priority,
                t.Status,
                Category = t.Category.Name,
            }).Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //tasks.Count();

            dataGridView1.DataSource = tasks;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Refresh();
            dataGridView1.Columns["Id"].Visible = false;

            UpdatePaginationLabel(totalTasks);
        }

        private void UpdatePaginationLabel(int totalTasks)
        {
            int maxPage = (int)Math.Ceiling((double)totalTasks / pageSize);
            label10.Text = $"Page {currentPage} of {maxPage}";
        }


        private void LoadCategories()
        {
            comboBox3.DataSource = context.Categories.ToList();
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == _userId);
            if (user != null)
            {
                label12.Text = $"Hello, {user.Name} 👋";
            }

            dateTimePicker1.MinDate = DateTime.Today;

            LoadTasks();
            LoadCategories();

            comboBox1.Items.AddRange(new[] { "Low", "Medium", "High" });
            comboBox2.DataSource = Enum.GetValues(typeof(TaskStatus));

            comboBox4.Items.Add("All");
            comboBox4.Items.AddRange(Enum.GetNames(typeof(TaskStatus)));
            comboBox4.SelectedIndex = 0;

            comboBox4.SelectedIndexChanged += comboBoxFilterStatus_SelectedIndexChanged;

            comboBox5.Items.AddRange(new[] { "Descending", "Ascending" });
            comboBox5.SelectedIndex = 0;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;

            checkBox1.Checked = false;

            notifyIcon = new NotifyIcon
            {
                Visible = true,
                Icon = SystemIcons.Warning,
                Text = "Task Manager Alerts"
            };

            overdueTimer = new System.Windows.Forms.Timer();
            overdueTimer.Tick += (s, ev) => CheckOverdueAndNotify();
            overdueTimer.Start();

            CheckOverdueAndNotify();

        }

        private void CheckOverdueAndNotify()
        {
            var now = DateTime.Now;
            var overdue = context.Tasks
                .Where(t => t.UserId == _userId
                            && t.Status != TaskStatus.Completed
                            && t.DueDate < now)
                .Select(t => new { t.Id, t.Title, t.DueDate })
                .ToList();

            foreach (var t in overdue)
            {
                if (alertedTaskIds.Contains(t.Id)) continue; // already alerted

                string title = "Overdue task";
                string message = $"{t.Title} (due {t.DueDate:g})";

                // show a balloon tip 
                notifyIcon.BalloonTipTitle = title;
                notifyIcon.BalloonTipText = message;
                notifyIcon.ShowBalloonTip(5000);

                alertedTaskIds.Add(t.Id);
            }
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            var task = new TaskItem
            {
                Title = textBox1.Text,
                Description = textBox2.Text,
                DueDate = dateTimePicker1.Value,
                Priority = comboBox1.SelectedItem?.ToString(),
                Status = (TaskStatus)comboBox2.SelectedItem,
                CategoryId = (int)comboBox3.SelectedValue,
                UserId = _userId,
                CreatedDate = DateTime.Now,
                CompletedDate = (TaskStatus)comboBox2.SelectedItem == TaskStatus.Completed
                        ? DateTime.Now
                        : null
            };

            context.Tasks.Add(task);
            context.SaveChanges();
            alertedTaskIds.Remove(selectedTaskId);
            CheckOverdueAndNotify();

            int totalTasks = context.Tasks.Count(t => t.UserId == _userId);
            currentPage = (int)Math.Ceiling((double)totalTasks / pageSize);

            //ReloadWithCurrentFilters();
            LoadTasks();
            ResetTasks();
        }

        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedTaskId == -1)
            {
                MessageBox.Show("Please double-click a task to select it first.");
                return;
            }

            var taskToDelete = context.Tasks.FirstOrDefault(t => t.Id == selectedTaskId);

            if (taskToDelete != null)
            {
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this task?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    context.Tasks.Remove(taskToDelete);
                    context.SaveChanges();
                    alertedTaskIds.Remove(selectedTaskId);
                    CheckOverdueAndNotify();
                    LoadTasks();

                    MessageBox.Show("Task deleted successfully!");
                    selectedTaskId = -1;
                    ResetTasks();
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                selectedTaskId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                var taskToEdit = context.Tasks
                    .FirstOrDefault(t => t.Id == selectedTaskId);

                if (taskToEdit != null)
                {
                    textBox1.Text = taskToEdit.Title;
                    textBox2.Text = taskToEdit.Description;
                    dateTimePicker1.Value = taskToEdit.DueDate;
                    comboBox1.SelectedItem = taskToEdit.Priority;
                    comboBox2.SelectedItem = taskToEdit.Status;
                    comboBox3.SelectedValue = taskToEdit.CategoryId;
                }
            }
        }

        //update
        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedTaskId == -1)
            {
                MessageBox.Show("Please double-click a task to edit first.");
                return;
            }

            var taskToUpdate = context.Tasks.FirstOrDefault(t => t.Id == selectedTaskId);

            if (taskToUpdate != null)
            {
                taskToUpdate.Title = textBox1.Text;
                taskToUpdate.Description = textBox2.Text;
                taskToUpdate.DueDate = dateTimePicker1.Value;
                taskToUpdate.Priority = comboBox1.SelectedItem?.ToString();
                taskToUpdate.Status = (TaskStatus)comboBox2.SelectedItem;
                taskToUpdate.CategoryId = (int)comboBox3.SelectedValue;

                if (taskToUpdate.Status == TaskStatus.Completed && taskToUpdate.CompletedDate == null)
                {
                    taskToUpdate.CompletedDate = DateTime.Now;
                }
                else if (taskToUpdate.Status != TaskStatus.Completed)
                {
                    taskToUpdate.CompletedDate = null;
                }

                context.SaveChanges();
                alertedTaskIds.Remove(selectedTaskId);
                CheckOverdueAndNotify();

                ReloadWithCurrentFilters();
                LoadTasks();

                MessageBox.Show("Task updated successfully!");
                ResetTasks();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var selectedStatus = comboBox4.SelectedItem?.ToString();
            var selectedSort = comboBox5.SelectedItem?.ToString();
            var searchTerm = textBox3.Text;

            LoadTasks(selectedStatus, selectedSort, searchTerm);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                LoadTasksGroupedByPriority();
            }
            else
            {
                LoadTasks();
            }
        }

        private void LoadTasksGroupedByPriority()
        {
            var priorityOrder = new Dictionary<string, int>
            {
                { "High", 1 },
                { "Medium", 2 },
                { "Low", 3 }
            };

            var groupedTasks = context.Tasks
                .Include(t => t.Category)
                .Where(t => t.UserId == _userId)
                .AsEnumerable()
                .OrderBy(t => priorityOrder.ContainsKey(t.Priority ?? "") ? priorityOrder[t.Priority] : 99)
                .GroupBy(t => t.Priority)
                .SelectMany(g => g.Select(t => new
                {
                    t.Title,
                    t.Description,
                    t.DueDate,
                    PriorityGroup = g.Key,
                    t.Status,
                    Category = t.Category.Name
                }))
                .ToList();

            dataGridView1.DataSource = groupedTasks;
        }


        //previous
        private void button4_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ReloadWithCurrentFilters();
            }
        }

        //next
        private void button5_Click(object sender, EventArgs e)
        {
            int totalTasks = context.Tasks.Count();
            int maxPage = (int)Math.Ceiling((double)totalTasks / pageSize);

            if (currentPage < maxPage)
            {
                currentPage++;
                ReloadWithCurrentFilters();
            }
        }

        private void ReloadWithCurrentFilters()
        {
            var selectedStatus = comboBox4.SelectedItem?.ToString();
            var selectedSort = comboBox5.SelectedItem?.ToString();
            var searchTerm = textBox3.Text;

            if (checkBox1.Checked)
            {
                LoadTasksGroupedByPriority();
            }
            else
            {
                LoadTasks(selectedStatus, selectedSort, searchTerm);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is null) return;

            var row = dataGridView1.Rows[e.RowIndex];

            var dueDate = (DateTime)row.Cells["DueDate"].Value;
            var status = (TaskStatus)row.Cells["Status"].Value;

            bool isOverdue = status != TaskStatus.Completed && dueDate < DateTime.Now;
            bool isNearDue = status != TaskStatus.Completed && dueDate >= DateTime.Now && dueDate <= DateTime.Now.AddDays(3);

            if (isOverdue)
            {
                // Overdue: red
                row.DefaultCellStyle.BackColor = Color.MistyRose;
                row.DefaultCellStyle.ForeColor = Color.Maroon;
                row.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (isNearDue)
            {
                // Near: yellow
                row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                row.DefaultCellStyle.SelectionBackColor = Color.Gold;
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else
            {
                row.DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
                row.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.SelectionBackColor;
                row.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.SelectionForeColor;
            }
        }

        private void GenerateTaskReport()
        {
            var report = context.Tasks
                .Where(t => t.UserId == _userId)
                .GroupBy(t => t.Status)
                .Select(g => new
                {
                    Status = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToList();

            string reportText = "📊 Task Report:\n\n";
            foreach (var item in report)
            {
                reportText += $"{item.Status}: {item.Count}\n";
            }

            MessageBox.Show(reportText, "Task Report");
        }

        private void CalculateAverageCompletionTime()
        {
            var completedTasks = context.Tasks
                .Where(t => t.UserId == _userId &&
                            t.Status == TaskStatus.Completed &&
                            t.CompletedDate != null &&
                            t.CompletedDate != DateTime.MinValue)
                .Select(t => new
                {
                    Duration = EF.Functions.DateDiffDay(t.CreatedDate, t.CompletedDate.Value)
                })
                    .ToList();

            if (!completedTasks.Any())
            {
                MessageBox.Show("No completed tasks found.");
                return;
            }

            double avgDays = completedTasks.Average(t => t.Duration);

            MessageBox.Show($"📊 Average task completion time: {avgDays:F2} days", "Report");
        }


        private void button6_Click(object sender, EventArgs e)
        {
            GenerateTaskReport();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CalculateAverageCompletionTime();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
