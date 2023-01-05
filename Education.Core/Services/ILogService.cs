using Education.Core.Models;
using System.Runtime.CompilerServices;

namespace Education.Core.Services
{
    public interface ILogService
    {
        Task<bool> AddLog(Log log);
    }
}
