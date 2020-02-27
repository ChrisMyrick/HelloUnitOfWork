using System;

namespace HelloUnitOfWork
{
    public interface ICourseUOW : IUnitOfWork
    {
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
    }
}