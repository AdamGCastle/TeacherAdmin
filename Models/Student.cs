using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherAdmin.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string StudentName { get; set; }

        public string Age { get; set; }

        [Display(Name = "Background")]
        public string Info { get; set; }

        [Display(Name = "Likes and Dislkies")]
        public string Likes { get; set; }

        public string Course { get; set; }

        [Display(Name = "Lessons Completed")]
        public int LessonsTaught { get; set; } = 0;

        [Display(Name = "Italki UserName")]
        public string ItalkiName { get; set; }

        [Display(Name = "Picture Source")]
        public string PicSource { get; set; }

        [Display(Name = "Preferred Platform")]
        public string Platform { get; set; } = "italki";

        [Display(Name = "Discount")]
        public bool HasDiscount { get; set; } = false;

        [Display(Name = "Current")]
        public bool IsCurrent { get; set; } = true;

        public ICollection<LessonBlog> Lessons { get; set; }
    }
}
