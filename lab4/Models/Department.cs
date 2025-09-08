using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        [ForeignKey("Head")]
        public int? HeadId { get; set; } //FK
        public virtual Head Head { get; set; }
    }
}
