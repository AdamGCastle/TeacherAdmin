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
    public class EditModel : PageModel
    {
        private readonly TeacherAdmin.Data.ItalkiDatabaseContext _context;

        public EditModel(TeacherAdmin.Data.ItalkiDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LessonBlog LessonBlog { get; set; }
        public SelectList Students { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Students = new SelectList(_context.Students, nameof(Student.ID), nameof(Student.StudentName));

            LessonBlog = await _context.LessonBlogs.FirstOrDefaultAsync(m => m.ID == id);

            if (LessonBlog == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LessonBlog.Student = _context.Students.FirstOrDefault(s => s.ID == LessonBlog.StudentID);

            _context.Attach(LessonBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonBlogExists(LessonBlog.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LessonBlogExists(int id)
        {
            return _context.LessonBlogs.Any(e => e.ID == id);
        }
    }
}
