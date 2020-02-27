using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HelloUnitOfWork
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly IMSDBContext _context;

        public AuthorRepository(IMSDBContext context) : base(context)
        {
            _context = context;
        }

        public Author GetAuthorWithCourses(int id)
        {
            return _context.Authors.Include(a => a.Courses).SingleOrDefault(a => a.AuthorId == id);
        }
    }
}