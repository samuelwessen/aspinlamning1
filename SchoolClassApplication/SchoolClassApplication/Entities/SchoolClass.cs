using SchoolClassApplication.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolClassApplication.Entities
{
    public partial class SchoolClass
    {
        public SchoolClass()
        {
            SchoolClassCourses = new HashSet<SchoolClassCourse>();
            SchoolClassStudents = new HashSet<SchoolClassStudent>();
        }

        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public string TeacherId { get; set; }
        public DateTime Created { get; set; }


        //la till detta efter db skapades
        public virtual ApplicationUser Teacher { get; set; }

        public virtual ICollection<SchoolClassCourse> SchoolClassCourses { get; set; }
        public virtual ICollection<SchoolClassStudent> SchoolClassStudents { get; set; }
    }
}
