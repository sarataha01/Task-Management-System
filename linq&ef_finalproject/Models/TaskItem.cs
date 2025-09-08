using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_ef_finalproject.Models
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    internal class TaskItem // many tasks have 1 category && many tasks belong to single user
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public TaskStatus Status { get; set; } // Pending, In Progress, Completed

        // 1 user has many tasks
        public int UserId { get; set; }
        public User User { get; set; }

        // 1 category has many tasks
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime? CompletedDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
