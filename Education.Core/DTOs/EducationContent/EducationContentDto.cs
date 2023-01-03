using Education.Core.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Education.Core.DTOs
{
    public class EducationContentDto : BaseDto
    {
        public string Name { get; set; }
        public string Descriptiron { get; set; }
        public ContentType ContentType { get; set; }
        public string Url { get; set; }
        public int EducationId { get; set; }
    }
    public class EducationContentCreateDto
    {
        public string Name { get; set; }
        public string Descriptiron { get; set; }
        public ContentType ContentType { get; set; }
        [JsonIgnore]
        public string? Url { get; set; }
        public int EducationId { get; set; }
        public IFormFile file { get; set; }

    }
    public class EducationContentUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptiron { get; set; }
        public ContentType ContentType { get; set; }
        public string Url { get; set; }
        public int EducationId { get; set; }

    }
    public class CreateEducationContentSelectItemDto
    {
        public List<SelectItemDto> VideoContents { get; set; }
        public List<SelectItemDto> PdfContents { get; set; }

    }

}
