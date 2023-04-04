using Application.IService;
using Domain.Model.Users;
using Infrastructure.IRepository;
using System.Linq.Expressions;

namespace Application.Service
{
    public class HospitalService : IHospitalService
    {
        readonly IBaseRepository<Hospital> repository;

        public HospitalService(IBaseRepository<Hospital> repository)
        {
            this.repository = repository;
        }

        public void Add(string name, string address, string lat, string longdata)
        {
            Hospital entity = new Hospital(name, address,lat,longdata);
            repository.Add(entity);
        }

        public void Delete(int id)
        {
            Hospital entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            if (id == 1)
            {
                throw new Exception($"This value must not be deleted!");
            }
            repository.Delete(entity);
        }

        public Hospital GetById(int id)
        {
            return repository.GetById(id, null);
        }

        public (IEnumerable<Hospital> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Hospital, bool>> filter = null;
            if (key != null)
                filter = e => e.Name.ToUpper().Contains(key.ToUpper());
            return repository.Get(null, filter, null, pageSize, page);
        }

        public void Update(int id, string name, string address, string lat, string longdata)
        {
            Hospital entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            entity.Update(name, address,lat,longdata);
            repository.Update(entity);
        }
    }
}
