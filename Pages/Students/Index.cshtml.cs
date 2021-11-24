using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherAdmin.Data;
using TeacherAdmin.Models;

namespace TeacherAdmin.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly TeacherAdmin.Data.ItalkiDatabaseContext _context;

        public IndexModel(TeacherAdmin.Data.ItalkiDatabaseContext context)
        {
            _context = context;
        }

        public IList<Student> CurrentStudents { get; set; }
        public IList<Student> OldStudents { get; set; }

        public async Task OnGetAsync()
        {
            var currentStudents = from s in _context.Students
                                  where s.IsCurrent
                                  select s;

            var oldStudents = from s in _context.Students
                              where s.IsCurrent == false
                              select s;

            currentStudents = currentStudents.OrderBy(s => s.StudentName);

            CurrentStudents = await currentStudents.ToListAsync();

            OldStudents = await oldStudents.ToListAsync();

            foreach (Student item in CurrentStudents)
            {
                item.PicSource = "http://127.0.0.1:8887/" + item.StudentName + ".png";
            }

        }
    }
}
