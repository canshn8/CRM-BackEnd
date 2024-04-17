using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
        public class MongoDB_StudentContactDal : MongoDB_RepositoryBase<StudentContact, MongoDB_Context<StudentContact, MongoDB_StudentContactCollection>>, IStudentContactDal
        { 

        private readonly IMapper _mapper;

        public MongoDB_StudentContactDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<StudentContactDto> GetAllStudentContact()
        {
            throw new NotImplementedException();
        }

        public List<StudentContactDto> GetAllStudentStarting()
        {
            List<StudentContact> students = new List<StudentContact>();
            using (var studentContext = new MongoDB_Context<StudentContact, MongoDB_StudentContactCollection>())
            {
                studentContext.GetMongoDBCollection();
                students = studentContext.collection.Find<StudentContact>(document => true).ToList();
                var studentDtos = new List<StudentContactDto>();
                foreach (var student in students)
                {
                    if (student.Id != null)
                    {
                        studentDtos.Add(new StudentContactDto
                        {
                            Id = student.Id,
                            No = student.No,
                            Name = student.Name,
                            InterestedEducation = student.InterestedEducation,
                            DataSource = student.DataSource,
                            Staff = student.Staff,
                            CareerCounselor = student.CareerCounselor,
                            Comment = student.Comment,
                            Status = student.Status,
                        });
                    }
                }
                return studentDtos;
            }
        }


        public List<StudentContactEvolved> GetAllWithClaimsContact()
        {
            List<StudentContactEvolved> _studentContactEvolveds = new List<StudentContactEvolved>();
            List<StudentContact> _students = new List<StudentContact>();
            using (var students = new MongoDB_Context<StudentContact, MongoDB_StudentContactCollection>())
            {
                students.GetMongoDBCollection();
                _students = students.collection.Find<StudentContact>(document => true).ToList();
            }

            foreach (var studentCt in _students)
            {

                StudentContactEvolved studentContactEvolved = new StudentContactEvolved
                {
                    Id = studentCt.Id,
                    Name = studentCt.Name,
                    DataSource = studentCt.DataSource,
                    No = studentCt.No,
                    Staff = studentCt.Staff,
                    Comment = studentCt.Comment,
                    Status = studentCt.Status,
                    InterestedEducation = studentCt.InterestedEducation,
                    CareerCounselor = studentCt.CareerCounselor,
                    OperationClaims = GetClaimsContact(studentCt),

                };
                _studentContactEvolveds.Add(studentContactEvolved);

            }

            return _studentContactEvolveds;

        }


        public List<OperationClaim> GetClaimsContact(StudentContact studentContact)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<StudentOperationClaim> _studentOperationClaim = new List<StudentOperationClaim>();
            List<OperationClaim> _currentStudentOperationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();

                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();

            }

            using (var operationClaims = new MongoDB_Context<StudentOperationClaim, MongoDB_StudentOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _studentOperationClaim = operationClaims.collection.Find<StudentOperationClaim>(document => true).ToList();

            }


            var studentOperationClaims = _studentOperationClaim.Where(u => u.StudentId == studentContact.Id).ToList();
            foreach (var studentOperationClaim in studentOperationClaims)
            {
                _currentStudentOperationClaims.Add(_operationClaims.Where(oc => oc.Id == studentOperationClaim.OperationClaimId).FirstOrDefault());
            }

            return _currentStudentOperationClaims;
        }


        public StudentContactDto GetUserByIdContact(string id)
        {
            using (var studentContext = new MongoDB_Context<StudentContact, MongoDB_StudentContactCollection>())
            {
                studentContext.GetMongoDBCollection();
                var students = studentContext.collection.Find<StudentContact>(document => true).ToList();
                var tempt = students.Find(u => u.Id == id);
                var real = _mapper.Map<StudentContactDto>(tempt);
                return real;
            }
        }

    }
}
