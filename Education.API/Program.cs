using Education.API.Filters;
using Education.API.Middlewares;
using Education.Core.Configuration;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Education.Repository;
using Education.Repository.Repositories;
using Education.Repository.UnitOfWork;
using Education.Service.Mapping;
using Education.Service.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation();
//Kendi oluþturduðumuz filtrenin fluentvalidations filtresini ezmesi için kullanýlýr
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI    

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IFirebaseStorageService, FirebaseStorageServiceImp>();

builder.Services.AddScoped<IAssignedEducationRepository, AssignedEducationRepositoryImp>();
builder.Services.AddScoped<IAssignedEducationService, AssignedEducationServiceImp>();

builder.Services.AddScoped<IAnswerService, AnswerServiceImp>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepositoryImp>();

builder.Services.AddScoped<IDepartmentService, DepartmentServiceImp>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepositoryImp>();

builder.Services.AddScoped<IDepartmentUnitService, DepartmentUnitServiceImp>();
builder.Services.AddScoped<IDepartmentUnitRepository, DepartmentUnitRepositoryImp>();

builder.Services.AddScoped<IEducationCategoryService, EducationCategoryServiceImp>();
builder.Services.AddScoped<IEducationCategoryRepository, EducationCategoryRepositoryImp>();

builder.Services.AddScoped<IEducationContentService, EducationContentServiceImp>();
builder.Services.AddScoped<IEducationContentRepository, EducationContentRepositoryImp>();

builder.Services.AddScoped<IEducationContentQuestionsService, EducationContentQuestionServiceImp>();
builder.Services.AddScoped<IEducationContentQuestionsRepository, EducationContentQuestionRepositoryImp>();

builder.Services.AddScoped<IEducationService, EducationServiceImp>();
builder.Services.AddScoped<IEducationRepository, EducationRepositoryImp>();

builder.Services.AddScoped<IEducationSubjectService, EducationSubjectServiceImp>();
builder.Services.AddScoped<IEducationSubjectRepository, EducationSubjectRepositoryImp>();

builder.Services.AddScoped<IExamCategoryService, ExamCategoryServiceImp>();
builder.Services.AddScoped<IExamCategoryRepository, ExamCategoryRepositoryImp>();

builder.Services.AddScoped<IExamService, ExamServiceImp>();
builder.Services.AddScoped<IExamRepository, ExamRepositoryImp>();

builder.Services.AddScoped<IExamQuestionsService, ExamQuestionServiceImp>();
builder.Services.AddScoped<IExamQuestionsRepository, ExamQuestionRespositoryImp>();

builder.Services.AddScoped<IQuestionCategoryService, QuestionCategoryServiceImp>();
builder.Services.AddScoped<IQuestionCategoryRepository, QuestionCategoryRepositoryImp>();

builder.Services.AddScoped<IQuestionService, QuestionServiceImp>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepositoryImp>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IUserService, UserServiceImp>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImp>();

builder.Services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
builder.Services.AddScoped<IUserRefreshTokenService, UserRefreshTokenServiceImp>();

builder.Services.AddScoped<IUserEducationContentHistoryRepository, UserEducationContentHistoryRepositoryImp>();
builder.Services.AddScoped<IUserEducationContentHistoryService, UserEducationContentHistoryServiceImp>();
#endregion

builder.Services.AddDbContext<EducationDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(EducationDbContext)).GetName().Name);
    });
});

//builder.Services.AddIdentity<User, IdentityRole>(opt =>
//{
//    opt.User.RequireUniqueEmail = true;
//    opt.Password.RequireNonAlphanumeric = false;
//});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience[0],
        IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = false,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");
app.UseAuthentication();
app.UseCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();
