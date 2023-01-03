
namespace Education.Core.DTOs
{
    public class CheckRulesDto
    {
        public bool isSuccess { get; set; }
        public List<string> Errors { get; set; }

        public static CheckRulesDto Success()
        {
            return new CheckRulesDto { isSuccess = true };
        }
        public static CheckRulesDto Fail(string error)
        {
            return new CheckRulesDto { isSuccess = false, Errors = new List<string> { error } };
        }
        public static CheckRulesDto Fail(List<string> errors)
        {
            return new CheckRulesDto { isSuccess = false, Errors = errors };
        }
    }
}
