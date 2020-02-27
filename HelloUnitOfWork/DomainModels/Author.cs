using System.Collections.Generic;

namespace HelloUnitOfWork
{
    public class Author
    {
        public Author()
        {
            Courses = new HashSet<Course>();
        }

        public int AuthorId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
