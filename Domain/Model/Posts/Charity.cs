using Domain.Model.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Posts
{
    public class Charity : BaseModel
    {
        public Charity()
        {
        }

        [MaxLength(50)]
        public string Name { get; private set; }
        [MaxLength(100)]

        public string Situation { get; private set; }
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string Content { get; private set; }
        public int Money { get; private set; }

        [ForeignKey("Image")]
        public int ImageId { get; private set; }
        public virtual Image? Image { get; private set; }

        public Charity(string name, string situation, string content, int money, int imageId)
        {
            Add();
            Update(name, situation, content, money, imageId);
        }

        public void Update(string name, string situation, string content, int money, int imageId)
        {
            Update();
            Name = name.Trim();
            Situation = situation.Trim();
            Content = content.Trim();
            Money = money;
            ImageId = imageId;
        }
    }
}
