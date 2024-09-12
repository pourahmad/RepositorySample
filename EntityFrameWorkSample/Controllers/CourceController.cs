using EntityFrameWorkSample.DTOs;
using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Services.CoursesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkSample.Controllers;

[Route("[controller]")]
[ApiController]
public class CourceController(ICourseRepository courseRepository) : ControllerBase
{
    private readonly ICourseRepository _courseRepository = courseRepository;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _courseRepository.GetByIdAsync(id);

        var result = new CourseDto { 
            Id = response.Id, 
            Title = response.Title , 
            Enrollments  = response.enrollments
            .Select( s => new EnrollmentsDto
            {
                Id = s.Id,
                EnrollmentDate = s.EnrollmentDate,
            }).ToList()
        };
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 10)
    {
        var response = await _courseRepository.GetAllAsync(pageNumber, pageSize);

        var result = response
            .Select(s => new CoursesDto
            {
                Id = s.Id,
                Title = s.Title,
            }).ToList();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CourseCreateDto courseCreateDto)
    {
        Course course = new()
        {
            Title = courseCreateDto.Title,
        };

        await _courseRepository.AddAsync(course);
        return Created("", course.Id);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] CourseUpdateDto courseUpdateDto)
    {
        Course course = new()
        {
            Id = courseUpdateDto.Id,
            Title = courseUpdateDto.Title,
        };

        await _courseRepository.UpdateAsync(course);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Course course = new()
        {
            Id = id
        };

        await _courseRepository.DeleteAsync(course);
        return Ok();
    }
}
