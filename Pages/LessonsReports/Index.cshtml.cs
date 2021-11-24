using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherAdmin.Data;
using TeacherAdmin.Models;

namespace TeacherAdmin.Pages.LessonsReports
{
    public class IndexModel : PageModel
    {
        private readonly TeacherAdmin.Data.ItalkiDatabaseContext _context;

        public IndexModel(TeacherAdmin.Data.ItalkiDatabaseContext context)
        {
            _context = context;
        }

        public IList<LessonBlog> UpcomingLessons { get; set; }
        public IList<LessonBlog> CompletedLessons { get; set; }
        public bool ReportIncomplete => CompletedLessons.Any(r => r.SlidesUsed == null && r.Vocab == null && r.NextLessonIdeas == null && r.TimeAndDate.Date == DateTime.Now.Date);
        public async Task OnGetAsync()
        {
            var lessons = from l in _context.LessonBlogs
                          .AsNoTracking()
                          .Include(l => l.Student)
                          select l;

            var upcoming = lessons.Where(l => l.TimeAndDate >= DateTime.Now);
            var completed = lessons.Where(l => l.TimeAndDate < DateTime.Now);

            UpcomingLessons = await upcoming.ToListAsync();
            CompletedLessons = await completed.ToListAsync();

            IEnumerable<LessonBlog> orderedUpcoming = UpcomingLessons.OrderBy(f => f.TimeAndDate);
            IEnumerable<LessonBlog> orderedCompleted = CompletedLessons.OrderByDescending(f => f.TimeAndDate);

            UpcomingLessons = orderedUpcoming.ToList();
            CompletedLessons = orderedCompleted.ToList();

            //ReportIncomplete = CompletedLessons.Any(r => r.SlidesUsed == null && r.Vocab == null && r.NextLessonIdeas == null);

        }
    }
}
