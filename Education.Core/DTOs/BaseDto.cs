using Education.Core.Models;
using System.Text.Json.Serialization;

namespace Education.Core.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public DateTime? ModifiedOn { get; set; }
        [JsonIgnore]
        public int? CreatedBy { get; set; }
        [JsonIgnore]
        public int? ModifiedBy { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
    }
}
