using Microsoft.EntityFrameworkCore;

namespace HelloUnitOfWork
{
    public class CourseBO
    {
        public void PerformProcessing()
        {
            using (var unitOfWork = new CourseUOW(new IMSDBContext(new DbContextOptions<IMSDBContext>())))
            {
                // example of calling the generic base class repo queries
                var course = unitOfWork.Courses.Get(2);
                var allCourses = unitOfWork.Courses.GetAll();

                // derived repo created for more complex queries per entity type
                var coursesWithAuthors = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);
                var author = unitOfWork.Authors.GetAuthorWithCourses(1);

                // transaction begin
                unitOfWork.Courses.RemoveRange(author.Courses); // remove courses from author
                // uncomment the following to mimmick a failed transaction
                //throw new Exception();
                unitOfWork.Authors.Remove(author); // remove the author
                unitOfWork.Complete();
                // transaction end
            }
        }
    }
}
