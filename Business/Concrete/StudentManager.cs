﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System.Collections.Generic;

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
        public IDataResult<StudentDetailsDto> GetDetailsById(string id)
        {
            return new SuccessDataResult<StudentDetailsDto>(_studentDal.GetStudentById(id), Messages.Successful);
        }
        public IDataResult<StudentEvolved> GetById(string id)
        {
            return new SuccessDataResult<StudentEvolved>(_studentDal.GetWithClaims(id), Messages.Successful);
        }

        public IDataResult<Student> GetByMail(string email)
        {
            return new SuccessDataResult<Student>(_studentDal.GetByMail(email));
        }
        public IResult Delete(string id)
        {
            var data = GetById(id).Data;
            var result = _studentDal.Delete(data.Id);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheDeleteProcess);

        }
        public IResult Update(Student updatedStudent)
        {
            _studentDal.Update(updatedStudent);
            return new SuccessResult(Messages.StudentUpdated);
        }
        private IResult StudentExists(string id)
        {
            var result = _studentDal.GetUserById(id);
            if (result != null)
            {
                return new ErrorResult(Messages.StudentAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }
    }
}
