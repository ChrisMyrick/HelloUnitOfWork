using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HelloUnitOfWork
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly IMSDBContext _context;

        public CourseRepository(IMSDBContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return _context.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return _context.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}