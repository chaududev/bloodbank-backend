using Application.IService;
using Domain.Model.BloodRegister;
using Infrastructure.IRepository;
using System.Linq.Expressions;

namespace Application.Service
{
    public class BloodGroupService : IBloodGroupService
    {
        readonly IBaseRepository<BloodGroup> repository;

        public BloodGroupService(IBaseRepository<BloodGroup> repository)
        {
            this.repository = repository;
        }

        public void Add(string name, string description)
        {
            BloodGroup entity = new BloodGroup(name, description);
            repository.Add(entity);
        }

        public void Delete(int id)
        {
            BloodGroup entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            repository.Delete(entity);
        }

        public BloodGroup GetById(int id)
        {
            return repository.GetById(id, null);
        }

        public (IEnumerable<BloodGroup> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<BloodGroup, bool>> filter = null;
            if (key != null)
                filter = e => e.Name.ToUpper().Contains(key.ToUpper());
            return repository.Get(null, filter,null, pageSize ?? int.MaxValue, page ?? 1);
        }

        public void Update(int id, string name, string description)
        {
            BloodGroup entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            entity.Update(name, description);
            repository.Update(entity);
        }
    }
}
