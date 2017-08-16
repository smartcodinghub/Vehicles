using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Vehicles.Persistence
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private IDbConnection connection;
        private IDbTransaction transaction;
        private bool disposed;

        public UnitOfWork(IDbConnection connection)
        {
            this.connection = connection;
            this.connection.Open();

            this.transaction = this.connection.BeginTransaction();
        }

        partial void ResetRepositories();

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
                ResetRepositories();
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
