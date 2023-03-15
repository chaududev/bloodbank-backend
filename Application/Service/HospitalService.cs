using Application.IService;
using Domain.Model.BloodRegister;
using Domain.Model.Posts;
using Domain.Model.Users;
using Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class HospitalService : IHospitalService
    {
        readonly IBaseRepository<Hospital> repository;

        public HospitalService(IBaseRepository<Hospital> repository)
        {
            this.repository = repository;
        }

        public void Add(string name, string address)
        {
            Hospital entity = new Hospital(name, address);
            repository.Add(entity);
        }

        public void Delete(int id)
        {
            Hospital entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            repository.Delete(entity);
        }

        public Hospital GetById(int id)
        {
            Expression<Func<Hospital, object>>[] includeProperties = { p => p.Users };
            return repository.GetById(includeProperties, id);
        }

        public (IEnumerable<Hospital> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Hospital, bool>> filter = null;
            Expression<Func<Hospital, object>>[] includeProperties = { p => p.Users };
            if (key != null)
                filter = e => e.Name.ToUpper().Contains(key.ToUpper());
            return repository.Get(includeProperties, filter, null, pageSize ?? int.MaxValue, page ?? 1);
        }

        public void Update(int id, string name, string address)
        {
            Hospital entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            entity.Update(name, address);
            repository.Update(entity);
        }
    }
}
