using Domain.Enum;
using Domain.Model.Posts;

namespace Application.IService
{
    public interface IEventService
    {
        (IEnumerable<Event> data, int total) GetList(string? key, int? pageSize, int? page);
        Event GetById(int id);
        void Add(string eventName, string description, string content, DateTime startTime, DateTime endTime, EventStatus status, int imageId);
        void Update(int id, string eventName, string description, string content, DateTime startTime, DateTime endTime, EventStatus status, int imageId);

        void Delete(int id);
    }
}
