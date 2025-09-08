using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class StudentCourse //many to many
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        //composite key
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student {  get; set; }
        public virtual Course Course {  get; set; }

    }
}
