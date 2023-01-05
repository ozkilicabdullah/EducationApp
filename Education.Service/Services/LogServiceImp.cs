using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class LogServiceImp : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogRepository _logRepository;

        public LogServiceImp(ILogRepository logRepository, IUnitOfWork unitOfWork)
        {
            _logRepository = logRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddLog(Log log)
        {
            _logRepository.AddLog(log);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
