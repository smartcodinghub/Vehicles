using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Vehicles.Persistence
{
    public abstract class RepositoryBase
    {
        protected IDbConnection Connection { get; set; }

        public RepositoryBase(IDbConnection connection)
        {
            this.Connection = connection;
        }
    }
}
