namespace Education.Core.Models
{
    public class EducationContent : DbBaseEntity
    {
        public int EducationId { get; set; }
        public Education Education { get; set; }
        public string Name { get; set; }
        public string Descriptiron { get; set; }
        public ContentType ContentType { get; set; }
        public string Url { get; set; }
        //public ICollection<EducationContentQuestion> EducationContentQuestions { get; set; }
    }
}
