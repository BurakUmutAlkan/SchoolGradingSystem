using SchoolGradingSystem.Data.Abstract_Classes;
using SchoolGradingSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGradingSystem.Data.Entities
{
    public class Class : BaseEntity
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; } = 20;
        public float MinimumAttendancePercentageRequired { get; set; } = 70f;
        public float MinimumAverageRequired { get; set; } = 45f;
        public Major Major { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
