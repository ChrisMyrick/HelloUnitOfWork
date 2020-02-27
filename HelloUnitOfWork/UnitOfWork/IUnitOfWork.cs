using System;

namespace HelloUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    { 
        int Complete();
    }
}