using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.BaseConnect
{
    public class UnitOfWork : IUnitOfWork
    {
        public BaseDbContext DbContext { get; private set; }
        public UnitOfWork(BaseDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public int Commit()
        {
            return this.DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return this.DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.DbContext != null)
            {
                this.DbContext.Dispose();
                this.DbContext = null;
            }
        }
    }
}
