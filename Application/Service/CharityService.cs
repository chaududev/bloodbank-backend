using Application.IService;
using Domain.Model.Posts;
using Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
            Expression<Func<Charity, object>>[] includeProperties = { p => p.Image };
            return repository.GetById(id, includeProperties);
        }

        public (IEnumerable<Charity> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Charity, bool>> filter = null;
            if (key != null)
                filter = e => e.Name.ToUpper().Contains(key.ToUpper());
            Expression<Func<Charity, object>>[] includeProperties = { p => p.Image };
            Expression<Func<Charity, object>> sort = null;
            return repository.Get(includeProperties, filter, sort, pageSize ?? int.MaxValue, page ?? 1);
        }

        public (IEnumerable<Charity> data, int total) GetListHaveMoney(int? pageSize, int? page)
        {
            Expression<Func<Charity, bool>> filter = e => e.Money>0;
            Expression<Func<Charity, object>>[] includeProperties = { p => p.Image };
            Expression<Func<Charity, object>> sort = null;
            return repository.Get(includeProperties, filter, sort, pageSize ?? int.MaxValue, page ?? 1);
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
