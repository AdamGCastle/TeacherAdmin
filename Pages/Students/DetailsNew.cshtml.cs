using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherAdmin.Models;

namespace TeacherAdmin.Pages.Students
{
    public class DetailsNewModel : PageModel
    {
        private readonly TeacherAdmin.Data.ItalkiDatabaseContext _context;

        public DetailsNewModel(TeacherAdmin.Data.ItalkiDatabaseContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }
        public string ImgSource { get; set; }
        public List<LessonBlog> Reports { get; set; }

        public LessonBlog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student = await _context.Students
                          .Include(s => s.Lessons)
                          .AsNoTracking()
                          .FirstOrDefaultAsync(s => s.ID == id);

            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            Reports = Student.Lessons.ToList();
            IEnumerable<LessonBlog> sortedEnum = Reports.OrderByDescending(f => f.TimeAndDate);
            Reports = sortedEnum.ToList();
            ImgSource = "http://127.0.0.1:8887/" + Student.StudentName.ToLower() + ".png";

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }

}

