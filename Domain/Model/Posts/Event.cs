using Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Posts
{
    public enum Status
    {
        None,
        Upcoming,
        Ongoing,
        Finished,
        Canceled
    }
    public class Event : BaseModel
    {
        [MaxLength(50)]
        public string EventName { get; private set; }
        [MaxLength(100)]
        public string Description { get; private set; }
        public string Content { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public Status Status { get; private set; }
        [ForeignKey("Image")]
        public Guid ImageId { get; private set; }
        public virtual Image Image { get; private set; }
        public Event(string eventName, string description, string content, DateTime startTime, DateTime endTime, Status status, Guid imageId)
        {
            Add(Id);
            Update(eventName,description,content,startTime,endTime,status,imageId);
        }
        public void Update(string eventName, string description, string content, DateTime startTime, DateTime endTime, Status status, Guid imageId)
        {
            Update();
            EventName = eventName.Trim();
            Description = description.Trim();
            Content = content.Trim();
            StartTime = startTime;
            EndTime = endTime;
            Status = status;
            ImageId = imageId;
        }
    }
}
