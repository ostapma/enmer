using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnmerCore;

namespace EnmerCore.DAL
{
    public class DataRepository<TEntity>: IDisposable where TEntity : class
    {
        protected EnmerDbContext Context;

        public DataRepository()
        {
            Context = new EnmerDbContext();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
