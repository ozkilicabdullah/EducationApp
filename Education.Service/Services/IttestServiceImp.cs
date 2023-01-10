using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class IttestServiceImp : Service<ITTest>,IITtestService
    {
        public IttestServiceImp(IGenericRepository<ITTest> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
