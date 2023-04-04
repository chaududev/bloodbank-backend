using Application.IService;
using Domain.Model.Posts;
using Infrastructure.IRepository;
using System.Linq.Expressions;

namespace Application.Service
{
    public class CharityService : ICharityService
    {
        readonly IBaseRepository<Charity> repository;

        public CharityService(IBaseRepository<Charity> repository)
        {
            this.repository = repository;
        }

        public void Add(string name, string situation, string content, int money, int imageId)
        {
            Charity entity = new Charity(name, situation, content, money, imageId);
            repository.Add(entity);
        }

        public void Delete(int id)
        {
            Charity entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            repository.Delete(entity);
        }

        public Charity GetById(int id)
        {
            return repository.GetById(id, new Expression<Func<Charity, object>>[] { p => p.Image });
        }

        public (IEnumerable<Charity> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Charity, bool>> filter = null;
            if (key != null)
                filter = e => e.Name.ToUpper().Contains(key.ToUpper());
            return repository.Get(new Expression<Func<Charity, object>>[] { p => p.Image }, filter, null, pageSize, page);
        }

        public void Update(int id, string name, string situation, string content, int money, int imageId)
        {
            Charity entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            entity.Update(name, situation, content, money, imageId);
            repository.Update(entity);
        }
    }
}
