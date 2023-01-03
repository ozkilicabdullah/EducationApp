using System.ComponentModel;

namespace Education.Core.Models
{
    public enum Status
    {
        [Description("Aktif")]
        Active = 0,
        [Description("Pasif")]
        InActive = 1,
        [Description("Silimiş")]
        Removed = 2
    }

    public enum ContentType
    {
        [Description("Video")]
        Video = 0,
        [Description("Pdf")]
        Pdf = 1
    }

    public enum ExamType
    {
        [Description("Ön Sınav")]
        Prelim = 0,
        [Description("Ara Sınav")]
        MidTerm = 1,
        [Description("Son Sınav")]
        LastExam = 2,
    }
    public enum AnswerType
    {
        [Description("Şıklı")]
        ClosedEnded = 0,
        [Description("Çoktan Seçmeli")]
        MultipleChoice = 1
    }
    public enum EducationContentActionType
    {
        [Description("Başladı")]
        Start = 0,
        [Description("Bitirdi")]
        End = 1
    }
}
