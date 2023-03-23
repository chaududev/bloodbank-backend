using Application.IService;
using Domain.Model.BloodRegister;
using Domain.Model.Posts;
using Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Service
{
    public class BlogService : IBlogService
    {
        readonly IBaseRepository<Blog> repository;

        public BlogService(IBaseRepository<Blog> repository)
        {
            this.repository = repository;
        }

        public void Add(string title, string description, string content, int imageId)
        {
            Blog entity = new Blog(title, description, content, imageId);
            repository.Add(entity);
        }

        public void Delete(int id)
        {
            Blog entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            repository.Delete(entity);
        }

        public Blog GetById(int id)
        {
            Expression<Func<Blog, object>>[] includeProperties = {p => p.Image};
            return repository.GetById(id, includeProperties);
        }

        public (IEnumerable<Blog> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Blog, bool>> filter = null;
            if (key != null)
                filter = e => e.Title.ToUpper().Contains(key.ToUpper());
            Expression<Func<Blog, object>>[] includeProperties = { p => p.Image };
            Expression<Func<Blog, object>> sort = null;
            return repository.Get(includeProperties, filter, sort, pageSize ?? int.MaxValue, page ?? 1);
        }

        public void Update(int id, string title, string description, string content, int imageId)
        {
            Blog entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            entity.Update(title, description, content, imageId);
            repository.Update(entity);
        }
    }
}
