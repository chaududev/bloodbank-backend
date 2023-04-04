using Application.IService;
using Domain.Enum;
using Domain.Model.Posts;
using Infrastructure.IRepository;
using System.Linq.Expressions;

namespace Application.Service
{
    public class EventService : IEventService
    {
        readonly IBaseRepository<Event> repository;

        public EventService(IBaseRepository<Event> repository)
        {
            this.repository = repository;
        }
        public void Add(string eventName, string description, string content, DateTime startTime, DateTime endTime, EventStatus status, int imageId)
        {
            Event Entity = new Event(eventName, description, content, startTime, endTime, status, imageId);
            repository.Add(Entity);
        }

        public void Delete(int id)
        {
            Event entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            repository.Delete(entity);
        }

        public Event GetById(int id)
        {
            return repository.GetById(id, new Expression<Func<Event, object>>[] { p => p.Image });
        }

        public (IEnumerable<Event> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Event, bool>> filter = null;
            if (key != null)
                filter = e => e.EventName.ToUpper().Contains(key.ToUpper());
            return repository.Get(new Expression<Func<Event, object>>[] { p => p.Image }, filter, null, pageSize, page);
        }
        public void Update(int id, string eventName, string description, string content, DateTime startTime, DateTime endTime, EventStatus status, int imageId)
        {
            Event entity = this.GetById(id);
            if (entity == null)
            {
                throw new Exception($"The entity with ID {id} was not found.");
            }
            entity.Update(eventName, description, content, startTime, endTime, status, imageId);
            repository.Update(entity);
        }
    }
}
