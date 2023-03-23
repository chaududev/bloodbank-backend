using Application.IService;
using Domain.Model.Base;
using Domain.Model.BloodRegister;
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
            Expression<Func<Event, object>>[] includeProperties = { p => p.Image };
            return repository.GetById(id, includeProperties);
        }

        public (IEnumerable<Event> data, int total) GetList(string? key, int? pageSize, int? page)
        {
            Expression<Func<Event, bool>> filter = null;
            if (key != null)
                filter = e => e.EventName.ToUpper().Contains(key.ToUpper());
            Expression<Func<Event, object>>[] includeProperties = { p => p.Image };
            Expression<Func<Event, object>> sort = null;
            return repository.Get(includeProperties, filter, sort, pageSize ?? int.MaxValue, page ?? 1);
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
