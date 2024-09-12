using EntityFrameWorkSample.Data;
using EntityFrameWorkSample.Services.CoursesServices;
using EntityFrameWorkSample.Services.EnrollmentServices;
using EntityFrameWorkSample.Services.Repository;
using EntityFrameWorkSample.Services.StudentService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppSampleDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("AppSampleConnectionString"));
});

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRapository<>));
builder.Services.AddScoped<IStudentsRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
