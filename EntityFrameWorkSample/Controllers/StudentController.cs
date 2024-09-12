using EntityFrameWorkSample.DTOs;
using EntityFrameWorkSample.Entities;
using EntityFrameWorkSample.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkSample.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController(IStudentsRepository studentsRepository) : ControllerBase
{
    private readonly IStudentsRepository _studentsRepository = studentsRepository;


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _studentsRepository.GetByIdAsync(id);

        var result = new StudentDto
        {
            Id = response.Id,
            Name = response.Name,
            Enrollments = response.enrollments
             .Select(s => new EnrollmentsDto { 
                 Id = s.Id, 
                 EnrollmentDate = s.EnrollmentDate 
             })
             .ToList()
        };
            
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 10)
    {
        var response = await _studentsRepository.GetAllAsync(pageNumber, pageSize);

        var result = response.Select(s => new StudentsDto
        {
            Id = s.Id,
            Name = s.Name
        }).ToList();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentCreateDto studentCreateDto)
    {
        Student student = new()
        {
            Name = studentCreateDto.Name,
        };
        await _studentsRepository.AddAsync(student);

        return Created("", student.Id);
    }


    [HttpPut]
    public async Task<IActionResult> Put([FromBody] StudentUpdateDto studentUpdateDto)
    {
        Student student = new()
        {
            Id = studentUpdateDto.Id,
            Name = studentUpdateDto.Name,
        };
        await _studentsRepository.UpdateAsync(student);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Student student = new()
        {
            Id = id
        };

        await _studentsRepository.DeleteAsync(student);
        return Ok();
    }
}
