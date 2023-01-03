using Education.Core.Models;

namespace Education.Core.DTOs
{
    /// <summary>
    /// Kullanıcının içerik üzerindeki haraketlerini tutar (Başla-Bitir)
    /// </summary>
    public class EducationContentHistoryActionDto
    {
        public DateTime CreatedOn { get; set; }
        public EducationContentActionType ActionType { get; set; }
    }
}
