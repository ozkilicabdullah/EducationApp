using Education.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.DTOs
{
    public class ExamDto : BaseDto
    {
        public int ExcamCategoryId { get; set; }
        public ExamType ExamType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Defination { get; set; }
        public string Description { get; set; }
        public bool IsQuestionsSortRandom { get; set; }
        public bool IsAnswersSortRandom { get; set; }
    }

    public class ExamCreateDto
    {
        public int ExcamCategoryId { get; set; }
        public ExamType ExamType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Defination { get; set; }
        public string Description { get; set; }
        public bool IsQuestionsSortRandom { get; set; }
        public bool IsAnswersSortRandom { get; set; }
    }
    public class ExamUpdateDto
    {
        public int Id { get; set; }
        public int ExcamCategoryId { get; set; }
        public ExamType ExamType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Defination { get; set; }
        public string Description { get; set; }
        public bool IsQuestionsSortRandom { get; set; }
        public bool IsAnswersSortRandom { get; set; }
    }
}
