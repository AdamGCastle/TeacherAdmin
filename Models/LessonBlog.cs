using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherAdmin.Models
{
    public class LessonBlog
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        [Display(Name = "Slides")]
        public string SlidesUsed { get; set; }
        public string Grammar { get; set; }
        public string Vocab { get; set; }
        [Display(Name = "Next Lesson Ideas")]
        public string NextLessonIdeas { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:ddd d/MM HH:mm}")]
        public DateTime TimeAndDate { get; set; } = DateTime.Now;
        public Student Student { get; set; }
    }
}
