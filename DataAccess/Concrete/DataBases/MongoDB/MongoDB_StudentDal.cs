﻿using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.DTOs;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_StudentDal : MongoDB_RepositoryBase<Student, MongoDB_Context<Student, MongoDB_StudentCollection>>, IStudentDal
    {

        private readonly IMapper _mapper;

        public MongoDB_StudentDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void DeleteClaims(Student student)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<StudentOperationClaim, MongoDB_StudentOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                operationClaims.collection.DeleteMany(c => c.StudentId == student.Id);
            }
        }

        public List<StudentDetailsDto> GetAllStudent()
        {
            List<Student> students = new List<Student>();
            using (var studentContext = new MongoDB_Context<Student, MongoDB_StudentCollection>())
            {
                studentContext.GetMongoDBCollection();
                students = studentContext.collection.Find<Student>(document => true).ToList();
                var studentDtos = new List<StudentDetailsDto>();
                foreach (var student in students)
                {
                    if (student.Id != null)
                    {
                        studentDtos.Add(new StudentDetailsDto
                        {
                            Id = student.Id,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Email = student.Email,
                            Report = student.Report,
                            No = student.No,
                            InterestedEducation = student.InterestedEducation,
                            DataSource = student.DataSource,
                            IsReg = student.IsReg,
                            PaymentHistory = student.PaymentHistory,
                            PaymentMethod = student.PaymentMethod,
                            Collection = student.Collection,
                            Status = student.Status,
                        });
                    }
                }
                return studentDtos;
            }
        }



        public List<StudentEvolved> GetAllWithClaims()
        {
            List<StudentEvolved> _studentEvolveds = new List<StudentEvolved>();
            List<Student> _students = new List<Student>();
            using (var students = new MongoDB_Context<Student, MongoDB_StudentCollection>())
            {
                students.GetMongoDBCollection();
                _students = students.collection.Find<Student>(document => true).ToList();
            }

            foreach (var student in _students)
            {

                StudentEvolved studentEvolved = new StudentEvolved
                {
                    Id = student.Id,
                    PaymentMethod = student.PaymentMethod,
                    PaymentHistory = student.PaymentHistory,
                    Collection = student.Collection,
                    No = student.No,
                    InterestedEducation = student.InterestedEducation,
                    DataSource = student.DataSource,
                    IsReg = student.IsReg,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    OperationClaims = GetClaims(student),
                    Status = student.Status

                };
                _studentEvolveds.Add(studentEvolved);

            }

            return _studentEvolveds;

        }


        public Student GetByMail(string email)
        {
            using (var studentContext = new MongoDB_Context<Student, MongoDB_StudentCollection>())
            {
                studentContext.GetMongoDBCollection();

                var students = studentContext.collection.Find<Student>(document => document.Email == email).ToList();

                if (students.Count == 0)
                {
                    return null;
                }

                var real = _mapper.Map<Student>(students[0]);
                return real;
            }
        }

        public StudentClaimDto GetClaimAndStudentDetails(string Email)
        {
            StudentClaimDto myList = new StudentClaimDto();

            List<Student> _students = new List<Student>();
            using (var students = new MongoDB_Context<Student, MongoDB_StudentCollection>())
            {
                students.GetMongoDBCollection();
                _students = students.collection.Find<Student>(document => true).ToList();
            }

            List<StudentOperationClaim> _studentOperationClaims = new List<StudentOperationClaim>();
            using (var studentOperationClaims = new MongoDB_Context<StudentOperationClaim, MongoDB_StudentOperationClaimCollection>())
            {
                studentOperationClaims.GetMongoDBCollection();
                _studentOperationClaims = studentOperationClaims.collection.Find<StudentOperationClaim>(document => true).ToList();
            }
            foreach (var item in _studentOperationClaims)
            {
                var student = _students.Find(x => x.Email == Email);
                if (student != null)
                {
                    if (item.StudentId == student.Id)
                    {
                        myList.OperationClaims = GetClaims(student);
                        myList.Status = student.Status;
                        myList.StudentId = student.Id;
                        myList.FirstName = student.FirstName;
                        myList.LastName = student.LastName;
                    }
                }

            }
            return myList;
        }

        public List<OperationClaim> GetClaims(Student student)
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


            var studentOperationClaims = _studentOperationClaim.Where(u => u.StudentId == student.Id).ToList();
            foreach (var studentOperationClaim in studentOperationClaims)
            {
                _currentStudentOperationClaims.Add(_operationClaims.Where(oc => oc.Id == studentOperationClaim.OperationClaimId).FirstOrDefault());
            }

            return _currentStudentOperationClaims;
        }

        public StudentDetailsDto GetStudentById(string id)
        {
            using (var studentContext = new MongoDB_Context<Student, MongoDB_StudentCollection>())
            {

                var student = studentContext.collection.Find(r => r.Id == id).FirstOrDefault();
                if (student == null)
                    return null;

                return new StudentDetailsDto
                {
                    Id = student.Id,
                    Email = student.Email,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Collection = student.Collection,
                    DataSource = student.DataSource,
                    Status = student.Status,
                    Report = student.Report,
                    IsReg = student.IsReg,
                    No = student.No,
                    InterestedEducation = student.InterestedEducation,
                    PaymentHistory = student.PaymentHistory,
                    PaymentMethod = student.PaymentMethod,
                };
            }
        }

        public StudentDto GetUserById(string id)
        {
            using (var studentContext = new MongoDB_Context<Student, MongoDB_StudentCollection>())
            {
                studentContext.GetMongoDBCollection();
                var students = studentContext.collection.Find<Student>(document => true).ToList();
                var tempt = students.Find(u => u.Id == id);
                var real = _mapper.Map<StudentDto>(tempt);
                return real;
            }
        }



            public StudentEvolved GetWithClaims(string studentId)
        {
            Student student = new Student();
            using (var students = new MongoDB_Context<Student, MongoDB_StudentCollection>())
            {
                students.GetMongoDBCollection();
                student = students.collection.Find<Student>(document => document.Id == studentId).FirstOrDefault();
            }

            StudentEvolved studentEvolved = new StudentEvolved
            {
                Id = student.Id,
                Email = student.Email,
                PaymentHistory = student.PaymentHistory,
                PaymentMethod = student.PaymentMethod,
                FirstName = student.FirstName,
                InterestedEducation = student.InterestedEducation,
                No = student.No,
                DataSource = student.DataSource,
                IsReg = student.IsReg,
                LastName = student.LastName,
                Collection = student.Collection,
                Report = student.Report,
                OperationClaims = GetClaims(student),
                Status = student.Status

            };
            return studentEvolved;
        }

        public StudentDto UpdateUser(string email)
        {
            using (var studentContext = new MongoDB_Context<Student, MongoDB_StudentCollection>())
            {
                studentContext.GetMongoDBCollection();
                var student = studentContext.collection.Find<Student>(document => document.Email == email).FirstOrDefault();

                if (student != null)
                {
                    return new StudentDto
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.Email,
                        Report = student.Report,
                        PaymentHistory = student.PaymentHistory,
                        PaymentMethod = student.PaymentMethod,
                        Collection = student.Collection,
                        Status = student.Status,
                        InterestedEducation = student.InterestedEducation,
                        No = student.No,
                        DataSource = student.DataSource,
                        IsReg = student.IsReg,
                    };
                }

                return null;
            }
        }


    }
}
