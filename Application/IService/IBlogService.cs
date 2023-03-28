using Domain.Model.Posts;

namespace Application.IService
{
    public interface IBlogService
    {
        (IEnumerable<Blog> data, int total) GetList(string? key, int? pageSize, int? page);
        Blog GetById(int id);
        void Add(string title, string description, string content, int imageId);
        void Update(int id, string title, string description, string content, int imageId);
        void Delete(int id);
    }
}
