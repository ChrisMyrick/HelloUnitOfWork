using System.Collections.Generic;

namespace HelloUnitOfWork
{
    public class Tag
    {
        public Tag()
        {
            //Courses = new HashSet<Course>();
        }

        public int TagId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course_Tag> Course_Tags { get; set; }
    }
}
