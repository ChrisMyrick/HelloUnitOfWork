using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HelloUnitOfWork
{
    class Program
    {
        static void Main()
        {
            CourseBO bizObject = new CourseBO();

            bizObject.PerformProcessing();
        }

    }
}