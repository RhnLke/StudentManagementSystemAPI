using Application.UseCases.Student.Commands;
using Application.UseCases.Student.Queries;
using Domain.Commons;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/EnrollStudent")]
        public async Task<IActionResult> EnrollStudent([FromBody] StudentCommon model)
        {
            try
            {
                var result = await mediator.Send(new Enroll.Command(model));
                return Ok(result);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("/GetStudentById/{Id}")]
        public async Task<IActionResult> GetStudentById (int Id)
        {
            try
            {
                var result = await mediator.Send(new GetStudentById.Query(Id));
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var result = await mediator.Send(new GetStudents.Query());
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
