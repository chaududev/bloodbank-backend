﻿using Application.IService;
using Domain.Enum;
using Domain.Model.BloodRegister;
using Infrastructure.IRepository;
using System.Linq.Expressions;

namespace Application.Service
{
    public class RegisterService : IRegisterService
    {
        readonly IBaseRepository<Register> repository;

        public RegisterService(IBaseRepository<Register> repository)
        {
            this.repository = repository;
        }

        public void Add(string note, Status status, int bloodId, string userId, DateTime timeSign, int qR, int hospitalId, int ml)
        {
            Register entity = new Register(note, status, bloodId, userId, timeSign, qR, hospitalId,ml);
            repository.Add(entity);
        }

        public void Delete(int id)
        {
            Register entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            repository.Delete(entity);
        }


        public Register GetById(int id)
        {
            Expression<Func<Register, object>>[] includeProperties =
                {
                    p => p.BloodGroup,
                    p => p.Image,
                    p => p.User,
                    p => p.Hospital
                };
            return repository.GetById(id,includeProperties);
        }

        public (IEnumerable<Register> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Register, bool>> filter = null;
            if (key != null)
                filter = e => e.Note.ToUpper().Contains(key.ToUpper());
            Expression<Func<Register, object>>[] includeProperties =
                {
                    p => p.BloodGroup,
                    p => p.Image,
                    p => p.User,
                    p => p.Hospital
                };
            return repository.Get(includeProperties, filter, null, pageSize, page);
        }

        public (IEnumerable<Register> data, int total) GetListByUser(string username, int? pageSize, int? page)
        {
            Expression<Func<Register, bool>> filter = e => e.User.UserName.ToUpper().Contains(username.ToUpper());
            Expression<Func<Register, object>>[] includeProperties =
                {
                    p => p.BloodGroup,
                    p => p.Image,
                    p => p.User,
                    p => p.Hospital
                };
            return repository.Get(includeProperties, filter, e => e.User.UserName, pageSize , page);
        }

        public void Update(int id, string note, Status status, int bloodId, DateTime timeSign, int hospitalId, int ml)
        {
            Register entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            entity.Update(note, status, bloodId, timeSign, hospitalId, ml);
            repository.Update(entity);
        }
    }
}
