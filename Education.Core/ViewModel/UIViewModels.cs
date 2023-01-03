using Education.Core.DTOs;
using System.Diagnostics.Contracts;

namespace Education.Core.ViewModel;

/// <summary>
///  Arayüzdeki statemanegement model yapısına uygun olması için dönüş modelleri güncellenedi
/// </summary>
/// xx

#region  Answer
public class AnswerDtoViewModel
{
    public AnswerDto answer { get; set; }
}
public class AnswerCreatePayloadDto
{
    public AnswerCreateDto payload { get; set; }
}
public class AnswerUpdatePayloadDto
{
    public AnswerUpdateDto payload { get; set; }
}
#endregion

#region  Department
public class DepartmentDtoViewModel
{
    public DepartmentDto department { get; set; }
}
public class DepartmentCreatePayloadDto
{
    public DepartmentCreateDto payload { get; set; }
}
public class DepartmentUpdatePayloadDto
{
    public DepartmentUpdateDto payload { get; set; }
}
#endregion

#region Department Unit
public class DepartmentUnitDtoViewModel
{
    public DepartmentUnitDto departmentUnit { get; set; }
}
public class DepartmentUnitCreatePayloadDto
{
    public DepartmentUnitCreateDto payload { get; set; }
}
public class DepartmentUnitUpdatePayloadDto
{
    public DepartmentUnitUpdateDto payload { get; set; }
}
#endregion

#region EducationCategory
public class EducationCategoryDtoViewModel
{
    public EducationCategoryDto educationCategory { get; set; }
}
public class EducationCategoryCreatePayloadDto
{
    public EducationCategoryCreateDto payload { get; set; }
}
public class EducationCategoryUpdatePayloadDto
{
    public EducationCategoryUpdateDto payload { get; set; }
}
#endregion

#region EducationContent
public class EducationContentDtoViewModel
{
    public EducationContentDto educationContent { get; set; }
}
public class EducationContentListDtoViewModel
{
    public List<EducationContentDto> educationContents { get; set; }
}
public class EducationContenCreatePayloadDto
{
    public EducationContentCreateDto payload { get; set; }

}
public class EducationContenUpdatePayloadDto
{
    public EducationContentUpdateDto payload { get; set; }
}
#endregion

#region EducationContentQuestion
public class EducationContentQuestionCreatePayloadDto
{
    public EducationContentQuestionBulkCreateDto payload { get; set; }
}
public class EducationContentQuestionBulkCreateDto
{
    public int EducationContentId { get; set; }
    public List<EducationContentQuestionCreateQuestionListDto> Questions { get; set; }
}
public class EducationContentQuestionCreateQuestionListDto
{
    public int QuestionId { get; set; }
    public int? ShowMinute { get; set; }
}
#endregion

#region ExamQuestion
public class ExamQuestionCreatePayloadDto
{
    public ExamQuestionBulkCreateDto payload { get; set; }
}
public class ExamQuestionBulkCreateDto
{
    public int ExamId { get; set; }
    public List<int> QuestionIds { get; set; }
}
#endregion

#region Education
public class EducationDtoViewModel
{
    public EducationDto education { get; set; }
}
public class EducationCreatePayloadDto
{
    public EducationCreateDto payload { get; set; }
}
public class EducationUpdatePayloadDto
{
    public EducationUpdateDto payload { get; set; }
}
#endregion

#region EducationSubject
public class EducationSubjectDtoViewModel
{
    public EducationSubjectDto educationSubject { get; set; }
}
public class EducationSubjectCreatePayloadDto
{
    public EducationSubjectCreateDto payload { get; set; }
}
public class EducationSubjectUpdatePayloadDto
{
    public EducationSubjectUpdateDto payload { get; set; }
}
#endregion

#region ExamCategory
public class ExamCategoryDtoViewModel
{
    public ExamCategoryDto examCategory { get; set; }
}
public class ExamCategoryCreatePayloadDto
{
    public ExamCategoryCreateDto payload { get; set; }
}
public class ExamCategoryUpdatePayloadDto
{
    public ExamCategoryUpdateDto payload { get; set; }
}
#endregion

#region Exam
public class ExamDtoViewModel
{
    public ExamDto exam { get; set; }
}
public class ExamCreatePayloadDto
{
    public ExamCreateDto payload { get; set; }
}
public class ExamUpdatePayloadDto
{
    public ExamUpdateDto payload { get; set; }
}
#endregion

#region QuestionCategory
public class QuestionCategoryDtoViewModel
{
    public QuestionCategoryDto questionCategory { get; set; }
}
public class QuestionCategoryCreatePayloadDto
{
    public QuestionCategoryCreateDto payload { get; set; }
}
public class QuestionCategoryUpdatePayloadDto
{
    public QuestionCategoryUpdateDto payload { get; set; }
}
#endregion

#region Question
public class QuestionDtoViewModel
{
    public QuestionDto question { get; set; }
}
public class QuestionCreatePayloadDto
{
    public QuestionCreateDto payload { get; set; }
}
public class QuestionUpdatePayloadDto
{
    public QuestionUpdateDto payload { get; set; }
}
#endregion
