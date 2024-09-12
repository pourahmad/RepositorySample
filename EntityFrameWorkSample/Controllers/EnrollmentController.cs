using EntityFrameWorkSample.DTOs;
using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Models;
using EntityFrameWorkSample.Services.EnrollmentServices;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkSample.Controllers;

[Route("[controller]")]
[ApiController]
public class EnrollmentController(IEnrollmentRepository enrollmentRepository) : ControllerBase
{
    private readonly IEnrollmentRepository _enrollmentRepository = enrollmentRepository;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _enrollmentRepository.GetByIdAsync(id);

        var result = new EnrollmentDto
        {
            Id = response.Id,
            EnrollmentDate = response.EnrollmentDate,
            Course = new CoursesDto { Id = response.Course.Id, Title = response.Course.Title },
            Student = new StudentsDto { Id = response.Student.Id, Name = response.Student.Name }
        };
        return Ok(result);
    }


    [HttpGet]
    public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _enrollmentRepository
            .GetAllAsync(pageNumber, pageSize);

        IList<EnrollmentVM> enrollments = result
            .Select(s => new EnrollmentVM
            {
                Id = s.Id,
                CourseId = s.CourseId,
                StudentId = s.StudentId,
                EnrollmentDate = s.EnrollmentDate,
                Course = new CourseVM { Id = s.Course.Id, Title = s.Course.Title },
                Student = new StudentVM { Id = s.Student.Id, Name = s.Student.Name}
            }).ToList();

        return Ok(enrollments);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EnrollmentCreateDto enrollmentCreateDto)
    {
        Enrollment enrollment = new()
        {
            CourseId = enrollmentCreateDto.CourseId,
            StudentId = enrollmentCreateDto.StudentId,
            EnrollmentDate = enrollmentCreateDto.EnrollmentDate,
        };
        await _enrollmentRepository.AddAsync(enrollment);

        return Created("", enrollment.Id);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] EnrollmentUpdeatDto enrollmentUpdeatDto)
    {
        Enrollment enrollment = new()
        {
            Id = enrollmentUpdeatDto.Id,
            CourseId = enrollmentUpdeatDto.CourseId,
            StudentId = enrollmentUpdeatDto.StudentId,
            EnrollmentDate = enrollmentUpdeatDto.EnrollmentDate,

        };
        await _enrollmentRepository.UpdateAsync(enrollment);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Enrollment enrollment = new()
        {
            Id = id
        };
        await _enrollmentRepository.DeleteAsync(enrollment);

        return Ok();
    }
}
