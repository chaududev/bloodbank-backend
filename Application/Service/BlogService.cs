using Application.IService;
using Domain.Model.Posts;
using Infrastructure.IRepository;
using System.Linq.Expressions;
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
            return repository.GetById(id, new Expression<Func<Blog, object>>[] { p => p.Image });
        }

        public (IEnumerable<Blog> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Blog, bool>> filter = null;
            if (key != null)
                filter = e => e.Title.ToUpper().Contains(key.ToUpper());
            return repository.Get(new Expression<Func<Blog, object>>[] { p => p.Image }, filter, null, pageSize, page);
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
