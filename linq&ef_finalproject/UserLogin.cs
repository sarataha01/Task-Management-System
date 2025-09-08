using linq_ef_finalproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace linq_ef_finalproject
{
    public partial class UserLogin : Form
    {
        private TaskManagementContext context = new TaskManagementContext();

        public UserLogin()
        {
            InitializeComponent();
        }

        //log in
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your information.");
                return;
            }

            var user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                OpenMainForm(user.Id);
            }
            else
            {
                MessageBox.Show("User not found. Please register first.");
            }
        }

        //signup
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string email = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter all information.");
                return;
            }

            var existingUser = context.Users.FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                MessageBox.Show("This email is already registered. Please log in.");
                return;
            }

            var newUser = new User
            {
                Name = name,
                Email = email
            };

            context.Users.Add(newUser);
            context.SaveChanges();
            OpenMainForm(newUser.Id);
            MessageBox.Show("Registration successful!");

            textBox1.Clear();
            textBox2.Clear();
        }

        private void OpenMainForm(int userId)
        {
            Form1 mainForm = new Form1(userId);
            mainForm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick(); 
            }
        }
    }
}

