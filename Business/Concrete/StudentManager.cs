using Business.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Entities.Concrete.DBEntities;
using Business.Constants;
using Core.Utilities.Business;
using Entities.DTOs;
using Entities.Concrete.Simples;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
           _studentDal = studentDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(Student student)
        {
            return new SuccessDataResult<List<OperationClaim>>(_studentDal.GetClaims(student), Messages.Successful);
        }


        public IResult Add(Student student)
        {
            IResult result = BusinessRules.Run(StudentExists(student.Id));
            if (result != null)
            {
                return result;
            }
            _studentDal.Add(student);
            return new SuccessResult(Messages.Successful);
        }
        public IDataResult<List<StudentDetailsDto>> GetAll()
        {
            return new SuccessDataResult<List<StudentDetailsDto>>(_studentDal.GetAllStudent(), Messages.Successful);

        }

        public IDataResult<StudentEvolved> GetById(string id)
        {
            return new SuccessDataResult<StudentEvolved>(_studentDal.GetWithClaims(id), Messages.Successful);
        }

        public IDataResult<Student> GetByMail(string email)
        {
            return new SuccessDataResult<Student>(_studentDal.Get(u => u.Email == email));
        }


        public IResult Delete(string id)
        {
            var data = GetById(id).Data;
            var result = _studentDal.Delete(data.Id);
            if(result.DeletedCount>0)
            {
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);

        }

        //public IDataResult<StudentDto> Update(StudentDto student)
        //{
        //    Console.WriteLine(student);
        //    var selectedUser = GetByMail(student.Email);
        //    selectedUser.Data.FirstName = student.FirstName;
        //    selectedUser.Data.LastName = student.LastName;
        //    selectedUser.Data.Email = student.Email;
        //    selectedUser.Data.Report = student.Report;
        //    selectedUser.Data.Collection = student.Collection;
        //    selectedUser.Data.PaymentHistory = student.PaymentHistory;
        //    selectedUser.Data.PaymentMethod = student.PaymentMethod;
        //    selectedUser.Data.Status = student.Status;

        //    var result = _studentDal.Update(selectedUser.Data);
        //    if (result.MatchedCount > 0)
        //    {
        //        return new SuccessDataResult<StudentDto>(student, Messages.StudentUpdated);
        //    }
        //    throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);

        //}
        public IDataResult<StudentDto> Update(StudentDto student)
        {
            Console.WriteLine(student);
            var selectedUser = GetByMail(student.Email);

            if (selectedUser != null && selectedUser.Success)
            {
                selectedUser.Data.FirstName = student.FirstName;
                selectedUser.Data.LastName = student.LastName;
                selectedUser.Data.Email = student.Email;
                selectedUser.Data.Report = student.Report;
                selectedUser.Data.Collection = student.Collection;
                selectedUser.Data.PaymentHistory = student.PaymentHistory;
                selectedUser.Data.PaymentMethod = student.PaymentMethod;
                selectedUser.Data.Status = student.Status;

                var result = _studentDal.Update(selectedUser.Data);
                if (result.MatchedCount > 0)
                {
                    return new SuccessDataResult<StudentDto>(student, Messages.StudentUpdated);
                }
                throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
            }
            else
            {
                throw new ArgumentNullException("selectedUser", "Selected user is null or operation failed.");
            }
        }


        private IResult StudentExists(string email)
        {
            var result = GetByMail(email);
            if (result.Data != null)
            {
                return new ErrorResult(Messages.StudentAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }

      
    }
}
