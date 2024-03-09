using Business.Abstract;
using Castle.Core.Resource;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        //[HttpPost("Add")]
        //public IActionResult Add(StudentDto customerDto)
        //{
            //var student = _mapper.Map<Student>(customerDto);
            //var result = _studentService.Add(student);
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);
        //}




        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            var result = _studentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
