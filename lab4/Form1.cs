using lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CuniversityEFContext context = new CuniversityEFContext();

            //eager loading
            var eager = context.Students.Include(s => s.Department).ThenInclude(d => d.Head).ToList(); //.First();
            //lazy loading
            var lazy = context.Students.ToList();
            //explicitt loading
            var explicitt = context.Students.First();
            context.Entry(explicitt).Reference(s => s.Department).Load();
            context.Entry(explicitt.Department).Reference(d => d.Head).Load();
        }
    }
}
