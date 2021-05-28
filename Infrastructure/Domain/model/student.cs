using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jhoncedricromano.window.Infrastructure.Domain.model
{
    public class Student
    {
        public Guid? StudentID { get; set; }
        public string studentname { get; set; }
        public string studentage { get; set; }
        public string studentcourse { get; set; }

    }
}
