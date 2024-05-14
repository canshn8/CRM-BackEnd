using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_StudentStartingDal : MongoDB_RepositoryBase<StudentStarting, MongoDB_Context<StudentStarting, MongoDB_StudentStartingCollection>>, IStudentStartingDal
    {
        private readonly IMapper _mapper;

        public MongoDB_StudentStartingDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<StudentStartingDto> GetAllStudentStarting()
        {
            List<StudentStarting> students = new List<StudentStarting>();
            using (var studentContext = new MongoDB_Context<StudentStarting, MongoDB_StudentStartingCollection>())
            {
                studentContext.GetMongoDBCollection();
                students = studentContext.collection.Find<StudentStarting>(document => true).ToList();
                var studentDtos = new List<StudentStartingDto>();
                foreach (var student in students)
                {
                    if (student.Id != null)
                    {
                        studentDtos.Add(new StudentStartingDto
                        {
                            Name = student.Name,
                            DataSource = student.DataSource,
                            No = student.No,
                            Tc = student.Tc,
                            Staff = student.Staff,
                            NumberBills = student.NumberBills,
                            AdvancePay = student.AdvancePay,
                            CareerCounselor = student.CareerCounselor,
                            CollectionAmount = student.CollectionAmount,
                            EducationHistory = student.EducationHistory,
                            InterestedEducation = student.InterestedEducation,
                            RegHistory = student.RegHistory,
                            Email = student.Email,
                            Location = student.Location,
                            Status = student.Status,
                        });
                    }
                }
                return studentDtos;
            }
        }


        public List<StudentStartingEvolved> GetAllWithClaimsStarting()
        {
            List<StudentStartingEvolved> _studentStartingEvolveds = new List<StudentStartingEvolved>();
            List<StudentStarting> _students = new List<StudentStarting>();
            using (var students = new MongoDB_Context<StudentStarting, MongoDB_StudentStartingCollection>())
            {
                students.GetMongoDBCollection();
                _students = students.collection.Find<StudentStarting>(document => true).ToList();
            }

            foreach (var student in _students)
            {

                StudentStartingEvolved studentStartingEvolved = new StudentStartingEvolved
                {
                    Name = student.Name,
                    DataSource = student.DataSource,
                    No = student.No,
                    Tc = student.Tc,
                    Staff = student.Staff,
                    NumberBills = student.NumberBills,
                    AdvancePay = student.AdvancePay,
                    CareerCounselor = student.CareerCounselor,
                    CollectionAmount = student.CollectionAmount,
                    EducationHistory = student.EducationHistory,
                    InterestedEducation = student.InterestedEducation,
                    RegHistory = student.RegHistory,
                    Email = student.Email,
                    Location = student.Location,
                    OperationClaims = GetClaimsStarting(student),

                };
                _studentStartingEvolveds.Add(studentStartingEvolved);

            }

            return _studentStartingEvolveds;

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

        public StudentClaimStartingDto GetClaimAndStudentStartingDetails(string Email)
        {
            StudentClaimStartingDto myList = new StudentClaimStartingDto();

            List<StudentStarting> _students = new List<StudentStarting>();
            using (var students = new MongoDB_Context<StudentStarting, MongoDB_StudentStartingCollection>())
            {
                students.GetMongoDBCollection();
                _students = students.collection.Find<StudentStarting>(document => true).ToList();
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
                        myList.OperationClaims = GetClaimsStarting(student);
                        myList.Status = student.Status;
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



        public List<OperationClaim> GetClaimsStarting(StudentStarting studentStarting)
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


            var studentOperationClaims = _studentOperationClaim.Where(u => u.StudentId == studentStarting.Id).ToList();
            foreach (var studentOperationClaim in studentOperationClaims)
            {
                _currentStudentOperationClaims.Add(_operationClaims.Where(oc => oc.Id == studentOperationClaim.OperationClaimId).FirstOrDefault());
            }

            return _currentStudentOperationClaims;
        }


        public StudentStartingDto GetUserByIdStarting(string id)
        {
            using (var studentContext = new MongoDB_Context<StudentStarting, MongoDB_StudentStartingCollection>())
            {
                studentContext.GetMongoDBCollection();
                var students = studentContext.collection.Find<StudentStarting>(document => true).ToList();
                var tempt = students.Find(u => u.Id == id);
                var real = _mapper.Map<StudentStartingDto>(tempt);
                return real;
            }
        }

        public StudentStartingEvolved GetWithClaims(string studentId)
        {
            StudentStarting student = new StudentStarting();
            using (var students = new MongoDB_Context<StudentStarting, MongoDB_StudentStartingCollection>())
            {
                students.GetMongoDBCollection();
                student = students.collection.Find<StudentStarting>(document => document.Id == studentId).FirstOrDefault();
            }

            StudentStartingEvolved studentEvolved = new StudentStartingEvolved
            {
                Id = student.Id,
                Name = student.Name,
                DataSource = student.DataSource,
                No = student.No,
                Staff = student.Staff,
                NumberBills = student.NumberBills,
                AdvancePay = student.AdvancePay,
                CareerCounselor = student.CareerCounselor,
                CollectionAmount = student.CollectionAmount,
                EducationHistory = student.EducationHistory,
                InterestedEducation = student.InterestedEducation,
                RegHistory = student.RegHistory,
                Email = student.Email,
                Location = student.Location,
                OperationClaims = GetClaimsStarting(student),

            };
            return studentEvolved;
        }


    }
}
