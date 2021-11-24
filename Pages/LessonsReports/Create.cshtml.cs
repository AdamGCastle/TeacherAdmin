using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherAdmin.Data;
using TeacherAdmin.Models;

namespace TeacherAdmin.Pages.LessonsReports
{
    public class CreateModel : PageModel
    {
        private readonly TeacherAdmin.Data.ItalkiDatabaseContext _context;

        public CreateModel(TeacherAdmin.Data.ItalkiDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var currentStudents = from s in _context.Students
                                  where s.IsCurrent
                                  select s;

            IEnumerable<Student> list = await currentStudents.ToListAsync();
            list = list.OrderBy(s => s.StudentName);

            Students = new SelectList(list, nameof(Student.ID), nameof(Student.StudentName));


            if (id != null)
            {
                LessonBlog.StudentID = (int)id;
            }
            return Page();
        }

        public SelectList Students { get; set; }       

        [BindProperty]
        public LessonBlog LessonBlog { get; set; } = new LessonBlog();
        public int StudentID { get; set; }



        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            LessonBlog.Student = _context.Students.FirstOrDefault(a => a.ID == LessonBlog.StudentID);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.LessonBlogs.Add(LessonBlog);
            LessonBlog.Student.Lessons.Add(LessonBlog);
            LessonBlog.Student.LessonsTaught++;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
