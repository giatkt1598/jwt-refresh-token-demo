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
    public partial interface IUserRepository : IBaseRepository<User>
    {
    }
    public partial class UserRepository : BaseRepository<User>, IUserRepository
    {
         public UserRepository(BaseDbContext dbContext) : base(dbContext)
         {
         }
    }
}

