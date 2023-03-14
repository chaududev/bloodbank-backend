using Domain.Model.BloodRegister;
using Domain.Model.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Base
{
    public class Image
    {
        public Guid Id { get; private set; }
        [MaxLength(50)]
        public string FileName { get; private set; }
        [MaxLength(50)]
        public string ContentType { get; private set; }
        public byte[] Data { get; private set; }
        public virtual Event Event { get; private set; }
        public virtual Blog Blog { get; private set; }
        public virtual Register Register { get; private set; }
        public Image()
        {
            Id = Guid.NewGuid();
        }
    }
}
