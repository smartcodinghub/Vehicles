using System;

namespace Vehicles.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
