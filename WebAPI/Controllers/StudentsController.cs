
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


        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _studentService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Update")]
        public IActionResult Update(Student student)
        {
            var result = _studentService.Update(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Add")]
        public IActionResult Add(StudentDto studentDto)
        {
            var map = _mapper.Map<Student>(studentDto);
            var result = _studentService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("AddContact")]
        public IActionResult StudentContact(StudentContactDto studentContactDto)
        {
            var map = _mapper.Map<StudentContact>(studentContactDto);
            var result = _studentService.AddContact(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("StudentStarting")]
        public IActionResult AddStarting(StudentStartingDto studentStartingDto)
        {
            var map = _mapper.Map<StudentStarting>(studentStartingDto);
            var result = _studentService.AddStarting(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


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


        [HttpGet("GetAllContact")]
        public IActionResult GetAllContact()
        {
            var result = _studentService.GetAllContact();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAllStarting")]
        public IActionResult GetAllStarting()
        {
            var result = _studentService.GetAllStarting();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetByMail")]
        public IActionResult GetByMail(string email)
        {
            var result = _studentService.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
