using Domain.Model.BloodRegister;
using Domain.Model.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
