
using AutoMapper;
using Business.Abstract;
using Castle.Core.Resource;
using Core.Entities.Concrete.DBEntities;

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
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;

        }


        [HttpPost("Add")]

        public IActionResult Add(StudentDto studentDto)
        {
            var map = _mapper.Map<Student>(studentDto);
            var result = _studentService.Add(map);
            if (result.Success)
            {
                return Ok(result);






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
