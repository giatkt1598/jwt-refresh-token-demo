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
    public partial interface ISoundRepository : IBaseRepository<Sound>
    {
    }
    public partial class SoundRepository : BaseRepository<Sound>, ISoundRepository
    {
         public SoundRepository(BaseDbContext dbContext) : base(dbContext)
         {
         }
    }
}

