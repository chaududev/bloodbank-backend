using Domain.Model.BloodRegister;
using Domain.Model.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model.Base
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string FileName { get; private set; }
        [MaxLength(50)]
        public string ContentType { get; private set; }
        public string Url { get; private set; }
        [JsonIgnore]
        public virtual Event Event { get; private set; }
        [JsonIgnore]
        public virtual Blog Blog { get; private set; }
        [JsonIgnore]
        public virtual Charity Charity { get; private set; }
        [JsonIgnore]
        public virtual Register Register { get; private set; }
        public Image()
        {
        }

        public Image(string fileName, string contentType, string url)
        {
            FileName = fileName.Trim();
            ContentType = contentType.Trim();
            Url=url.Trim();
        }
    }
}
