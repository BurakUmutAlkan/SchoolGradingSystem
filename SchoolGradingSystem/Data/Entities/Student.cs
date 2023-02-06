using SchoolGradingSystem.Data.Abstract_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGradingSystem.Data.Entities
{
    public class Student : BaseUser
    {
        public int? ClassId { get; set; }
        public string StudentNumber { get; set; }
        public float? AttendancePercentage { get; set; }
        public float Average { get; set; } = 0f;
        public ICollection<Class> Classes { get; set; } = null;
    }
}
