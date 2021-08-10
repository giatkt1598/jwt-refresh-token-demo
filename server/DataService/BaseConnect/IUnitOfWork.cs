using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.BaseConnect
{
    public interface IUnitOfWork : IDisposable
    {
        BaseDbContext DbContext { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
