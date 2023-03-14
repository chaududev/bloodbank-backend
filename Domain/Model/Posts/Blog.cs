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
    public class Blog : BaseModel
    {

        [MaxLength(50)]
        public string Title { get; private set; }
        [MaxLength(100)]

        public string Description { get; private set; }
        public string Content { get; private set; }
        [ForeignKey("Image")]
        public Guid ImageId { get; set; }
        public virtual Image Image { get; set; }
        public Blog(string title, string description, string content, Guid imageId)
        {
            Add(Id);
            Update(title, description, content, imageId);
        }
        public void Update(string title, string description, string content, Guid imageId)
        {
            Update();
            Title = title.Trim();
            Description = description.Trim();
            Content = content.Trim();
            ImageId = imageId;
        }
    }
}
