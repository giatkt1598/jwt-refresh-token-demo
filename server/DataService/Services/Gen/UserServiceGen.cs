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
    public partial interface IUserService : IBaseService<User>
    {
    }
    public partial class UserService : BaseService<User>, IUserService
    {
        private readonly string ConnectionString;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository, 
            IConfiguration configuration) : base(unitOfWork, repository) {
            ConnectionString = configuration.GetConnectionString("Default");
        }
    }
}
