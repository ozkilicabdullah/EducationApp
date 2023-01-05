using Microsoft.Extensions.Logging;

namespace Education.Core.Models
{
    public class Log : DbBaseEntity
    {
        public string Message { get; set; }
        public LogLevel LogLevel { get; set; }
        public int? UserId { get; set; }
    }
}
