using System.ComponentModel;

namespace Education.Core.Models
{
    /// <summary>
    /// Verilerin durumunu tutar
    /// </summary>
    public enum Status
    {
        [Description("Aktif")]
        Active = 0,
        [Description("Pasif")]
        InActive = 1,
        [Description("Silimiş")]
        Removed = 2
    }
    /// <summary>
    /// Eğitim içerik tipi
    /// </summary>
    public enum ContentType
    {
        [Description("Video")]
        Video = 0,
        [Description("Pdf")]
        Pdf = 1
    }
    /// <summary>
    /// Sınav tipi
    /// </summary>
    public enum ExamType
    {
        [Description("Ön Sınav")]
        Prelim = 0,
        [Description("Ara Sınav")]
        MidTerm = 1,
        [Description("Son Sınav")]
        LastExam = 2,
    }
    /// <summary>
    /// Cevap tipi
    /// </summary>
    public enum AnswerType
    {
        [Description("Şıklı")]
        ClosedEnded = 0,
        [Description("Çoktan Seçmeli")]
        MultipleChoice = 1
    }
    /// <summary>
    /// Kullanıcıya atanan eğitimin durumunu tutar
    /// </summary>
    public enum UserEducationStatus
    {
        [Description("Atandı")]
        Assigned = 0,
        [Description("Devam ediyor")]
        Resuming = 1,
        [Description("Tamamladı")]
        Complated = 2,
    }
    /// <summary>
    /// Kullanıcının eğitim içeriği üzerindeki hareketlerini tutar
    /// </summary>
    public enum EducationContentActionType
    {
        [Description("Başladı")]
        Start = 0,
        [Description("Duraklatıldı")]
        Stop = 1,
        [Description("Bitirdi")]
        End = 2,
    }
    /// <summary>
    /// Filtreleme istek modelinde kullanılır
    /// </summary>
    public enum OrderByType
    {
        [Description("Oluşturulma Tarihi")]
        CreatedDate = 0,
        [Description("Alfabetik")]
        Alphabetical = 0
    }
    /// <summary>
    /// Eğitim tipi
    /// </summary>
    public enum EducationType
    {
        [Description("İsteğe Bağlı")]
        Optional = 0,
        [Description("Zorunlu")]
        Compulsory = 1,
        [Description("Sabit")]
        Constant = 2,
    }
}
