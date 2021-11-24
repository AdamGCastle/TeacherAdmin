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
    public class IndexNewModel : PageModel
    {
        private readonly TeacherAdmin.Data.ItalkiDatabaseContext _context;
        public IndexNewModel(TeacherAdmin.Data.ItalkiDatabaseContext context)
        {
            _context = context;
        }
        public IList<Student> Students { get; set; }
        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
            foreach (Student item in Students)
            {
                item.PicSource = "http://127.0.0.1:8887/" + item.StudentName.ToLower() + ".png";
            }
        }
    }
}
