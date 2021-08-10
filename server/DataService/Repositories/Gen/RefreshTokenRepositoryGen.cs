
/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
using DataService.BaseConnect;
using DataService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataService.Repositories
{
    public partial interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
    {
    }
    public partial class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
         public RefreshTokenRepository(BaseDbContext dbContext) : base(dbContext)
         {
         }
    }
}

