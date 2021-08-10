/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
namespace DataService.Services
{
    using Microsoft.Extensions.Configuration;
    using DataService.BaseConnect;
    using DataService.Models.Entities;
    using DataService.Repositories;
    public partial interface ISoundService : IBaseService<Sound>
    {
    }
    public partial class SoundService : BaseService<Sound>, ISoundService
    {
        private readonly string ConnectionString;

        public SoundService(IUnitOfWork unitOfWork, ISoundRepository repository, 
            IConfiguration configuration) : base(unitOfWork, repository) {
            ConnectionString = configuration.GetConnectionString("Default");
        }
    }
}
