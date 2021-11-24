using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherAdmin.Models;

namespace TeacherAdmin.Data
{
    public class ItalkiDatabaseContext : DbContext
    {
        public ItalkiDatabaseContext(DbContextOptions<ItalkiDatabaseContext> options)
                   : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<LessonBlog> LessonBlogs { get; set; }
    }
}
