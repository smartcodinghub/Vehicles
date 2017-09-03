using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Vehicles.Persistence
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        protected IDbConnection connection;
        protected IDbTransaction transaction;
        protected bool disposed;

        public UnitOfWorkBase(IDbConnection connection)
        {
            this.connection = connection;
            this.connection.Open();

            this.transaction = this.connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
                transaction = connection.BeginTransaction();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }

                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }

                disposed = true;
            }
        }
    }
}
