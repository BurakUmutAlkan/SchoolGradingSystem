using SchoolGradingSystem.Data.Abstract_Classes;
using SchoolGradingSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGradingSystem.Data.Entities
{
    public class Teacher : BaseUser
    {
        public int? ClassId { get; set; }
        public string Email { get; set; }
        public Major Major { get; set; }
        public ICollection<Class> Classes { get; set; } = null;
    }
}
