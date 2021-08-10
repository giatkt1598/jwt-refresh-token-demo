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
    public partial interface IRefreshTokenService : IBaseService<RefreshToken>
    {
    }
    public partial class RefreshTokenService : BaseService<RefreshToken>, IRefreshTokenService
    {
        private readonly string ConnectionString;

        public RefreshTokenService(IUnitOfWork unitOfWork, IRefreshTokenRepository repository, 
            IConfiguration configuration) : base(unitOfWork, repository) {
            ConnectionString = configuration.GetConnectionString("Default");
        }
    }
}
